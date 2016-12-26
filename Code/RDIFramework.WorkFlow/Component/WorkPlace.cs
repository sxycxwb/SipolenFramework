using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// WorkPlace 的摘要说明。
    /// </summary>
    public class WorkPlace : UserControl
    {
        #region 私有变量定义区别
        private int _stId; //启动节点计数
        private int _endtId; //终止节点计数
        private int _altId; //交互节点计数
        private int _jtId; //判断节点计数
        private int _etId; //查看节点计数
        private int _autoId; //自动节点计数
        private int _conId; //控制节点计数
        private int _subId; //子流程节点计数
        private Rubberband _rubberband = null; //橡皮圈									
        private Dragger _dragger = null; //拖拽处理
        private bool _isZhexian; //选中的连线的选中折点的索引
        private int _breakIndex;
        private bool _isInAnchor;
        private bool _isDrawingLine;
        private Link _link; //画折线时选中的直线.因为移动鼠标拖动时不需要画原来的直线
        private Point _startPoint, _endPoint, _breakPoint;
        private Bounds _myBounds;
        private BaseComponent _startTask, _endTask;
        #endregion

        /// <summary>
        /// 流程模板所有节点列表
        /// </summary>
        public ArrayList TaskItems = new ArrayList();

        /// <summary>
        /// 流程模板所有连线列表
        /// </summary>
        public ArrayList LineItems = new ArrayList();

        /// <summary>
        /// 选中的节点列表
        /// </summary>
        public SelectedItems SelectedItems = new SelectedItems();

        /// <summary>
        /// 选中的连线列表
        /// </summary>
        public SelectedLine SelectedLine = new SelectedLine();

        public ToolStripButton NowButton;

        /// <summary>
        /// 进入流程图设计模式，只有在设计模式才能画任务节点或线
        /// </summary>
        public bool ToolModel;

        /// <summary>
        /// 节点模式，画线模式：1--启动节点；2-终止节点;3-交互节点;4-判断节点;5-查看节点;6-自动节点;7-控制节点;
        /// 8-子流程节点；0－连线,-1-自连线;
        /// </summary>
        public int Module;

        /// <summary>
        /// 画图锁定，同时画多个任务节点时LockModel=true
        /// </summary>
        public bool LockModel;

        /// <summary>
        /// 流程模板名称
        /// </summary>
        public string WorkFlowCaption = "";

        /// <summary>
        /// 流程模板Id
        /// </summary>
        public string WorkFlowId = "";

        /// <summary>
        /// 修改、新建、查看三种状态
        /// </summary>
        public string State;

        /// <summary>
        /// 是否允许编辑
        /// </summary>
        public bool CanEdit;

        /// <summary>
        /// 是否修改
        /// </summary>
        public bool IsModify = false;

        /// <summary>
        /// 操作人账号，用作权限判断。
        /// </summary>
        public string UserId = "";

        /// <summary>
        /// 操作人姓名，用作显示。
        /// </summary>
        public string UserName = "";

        public WorkPlace(string workFlowId, string userId, string userName)
        {
            InitializeComponent();
            UserId = userId;
            UserName = userName;
            _stId = 0;
            _endtId = 0;
            _altId = 0;
            _jtId = 0;
            _etId = 0;
            _autoId = 0;
            _conId = 0;
            _subId = 0;
            ToolModel = false;
            _isDrawingLine = false;
            _isZhexian = false;
            IsModify = false;
            _breakIndex = -1;
            WorkFlowId = workFlowId;
            if (WorkFlowId != null && WorkFlowId.Trim().Length > 0)
            {
                var tmpWorkflow = new WorkFlowData {WorkFlowId = WorkFlowId};
                tmpWorkflow.ReadWorkFlow();
                TaskItems = tmpWorkflow.TaskItems;
                LineItems = tmpWorkflow.LineItems;
            }
        }

        #region 画图处理
        /// <summary>
        /// 判断点p是否在直线的某个锚点,同时作一些准备工作
        /// </summary>
        /// <param name="p"></param>
        /// <returns>p是直线的某个锚点,返回true,否则false </returns>
        protected bool IsInAnchor(Point p)
        {
            bool result = false;
            for (int i = 1; i < _link.breakPointX.Count - 1; i++)
            {
                Region region =
                    new Region(new Rectangle(Convert.ToInt16(_link.breakPointX[i]) - 3,
                        Convert.ToInt16(_link.breakPointY[i]) - 3, 6, 6));
                if (region.IsVisible(p))
                {
                    this._breakIndex = i;
                    _startPoint.X = Convert.ToInt16(_link.breakPointX[i - 1]);
                    _startPoint.Y = Convert.ToInt16(_link.breakPointY[i - 1]);
                    _endPoint.X = Convert.ToInt16(_link.breakPointX[i + 1]);
                    _endPoint.Y = Convert.ToInt16(_link.breakPointY[i + 1]);
                    result = true;
                    _link.selectedAnchor = i;
                    break;
                }
            }
            if (result == false)
            {
                this._breakIndex = -1;
                _link.selectedAnchor = -1;
            }
            return result;
        }

        /// <summary>
        /// 给定点是否在选定的直线上
        /// </summary>
        /// <param name="thePoint">给定点</param>
        /// <returns>thePoint在选定的某一直线上返回该直线,否则返回null</returns>
        protected Link IsInALine(Point thePoint)
        {
            int i;
            for (i = LineItems.Count - 1; i >= 0; i--)
            {
                Link linkLine = LineItems[i] as Link;
                if (linkLine.Contains(thePoint))
                    return linkLine;
            }
            return null;
        }

        /// <summary>
        /// 给定点是否在选中的任务节点上
        /// </summary>
        /// <param name="thePoint">给定点</param>
        /// <returns>如果给定点thePoint在某一选中的任务节点上返回该任务节点,否则的返回null</returns>
        protected BaseComponent SelectedComponentContaining(Point thePoint)
        {
            // iterate backwards over the TaskItems collection
            // if a selected item is found, return it
            for (int i = TaskItems.Count - 1; i >= 0; i--)
            {
                BaseComponent c = TaskItems[i] as BaseComponent;
                if (SelectedItems.Contains(c))
                    if (c.Contains(thePoint))
                        return c;
            }
            return null;
        }

        protected void AddItem(BaseComponent theItem, int taskType)
        {
            theItem.WorkFlowId = this.WorkFlowId;
            theItem.TaskType = taskType;
            TaskItems.Add(theItem);
            IsModify = true;
            this.Invalidate();
        }

        protected bool IsInASelectedItem(Point thePoint)
        {
            return SelectedComponentContaining(thePoint) != null ? true : false;
        }

        /// <summary>
        /// 给定点是否在任务节点上
        /// </summary>
        /// <param name="thePoint">给定点</param>
        /// <returns>给定点在任务节点上,返回该任务节点,否则返回null</returns>		
        protected BaseComponent IsInAItem(Point thePoint)
        {
            int i;
            for (i = TaskItems.Count - 1; i >= 0; i--)
            {
                BaseComponent baseComponent = TaskItems[i] as BaseComponent;
                if (baseComponent.Contains(thePoint))
                    return baseComponent;
            }
            return null;
        }

        protected void MouseDownInAComponent(Point thePoint)
        {
            SelectedLine.Clear();
            BaseComponent c = SelectedComponentContaining(thePoint);
            if (c == null)
                return;
            _myBounds = new Bounds();
            _myBounds.AddList(SelectedItems);
            _dragger = new Dragger(this, SelectedItems, thePoint, _myBounds);
        }

        #endregion

        #region Windows 窗体设计器生成的代码

        private System.ComponentModel.IContainer components;
        private ContextMenu cmPanel;
        private MenuItem WorkPlaceCloseFlow;
        private MenuItem menuProperty;
        private System.Drawing.Printing.PrintDocument printDoc;
        private MenuItem menuDelete;
        private MenuItem menuSave;
        private MenuItem menuPrint;
        private MenuItem menuPrintView;
        private PrintPreviewDialog view;
        private MenuItem menuItem1;
        private ContextMenu contextMenu;
        private MenuItem menuTaskLine;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof (WorkPlace));
            this.cmPanel = new ContextMenu();
            this.menuSave = new MenuItem();
            this.menuPrint = new MenuItem();
            this.menuPrintView = new MenuItem();
            this.WorkPlaceCloseFlow = new MenuItem();
            this.menuDelete = new MenuItem();
            this.menuProperty = new MenuItem();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.view = new PrintPreviewDialog();
            this.contextMenu = new ContextMenu();
            this.menuItem1 = new MenuItem();
            this.menuTaskLine = new MenuItem();
            this.SuspendLayout();
            // 
            // cmPanel
            // 
            this.cmPanel.MenuItems.AddRange(new MenuItem[]
            {
                this.menuSave,
                this.menuPrint,
                this.menuPrintView,
                this.WorkPlaceCloseFlow
            });
            // 
            // menuSave
            // 
            this.menuSave.Index = 0;
            this.menuSave.Text = "保存";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuPrint
            // 
            this.menuPrint.Index = 1;
            this.menuPrint.Text = "打印";
            this.menuPrint.Click += new System.EventHandler(this.menuPrint_Click);
            // 
            // menuPrintView
            // 
            this.menuPrintView.Index = 2;
            this.menuPrintView.Text = "打印预览";
            this.menuPrintView.Click += new System.EventHandler(this.menuPrintView_Click);
            // 
            // WorkPlaceCloseFlow
            // 
            this.WorkPlaceCloseFlow.Index = 3;
            this.WorkPlaceCloseFlow.Text = "关闭";
            this.WorkPlaceCloseFlow.Click += new System.EventHandler(this.WorkPlaceCloseFlow_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Index = -1;
            this.menuDelete.Text = "删除";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuProperty
            // 
            this.menuProperty.Index = -1;
            this.menuProperty.Text = "属性";
            this.menuProperty.Click += new System.EventHandler(this.menuProperty_Click);
            // 
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // view
            // 
            this.view.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.view.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.view.ClientSize = new System.Drawing.Size(400, 300);
            this.view.Enabled = true;
            this.view.Icon = ((System.Drawing.Icon) (resources.GetObject("view.Icon")));
            this.view.Name = "view";
            this.view.Visible = false;
            // 
            // contextMenu
            // 
            this.contextMenu.MenuItems.AddRange(new MenuItem[]
            {
                this.menuItem1,
                this.menuTaskLine
            });
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "删除";
            this.menuItem1.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuTaskLine
            // 
            this.menuTaskLine.Index = 1;
            this.menuTaskLine.Text = "属性";
            this.menuTaskLine.Click += new System.EventHandler(this.WorkPlace_DoubleClick);
            // 
            // WorkPlace
            // 
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(1000, 1000);
            this.AutoScrollMinSize = new System.Drawing.Size(15, 15);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Name = "WorkPlace";
            this.Padding = new Padding(10);
            this.Size = new System.Drawing.Size(5600, 5080);
            this.DoubleClick += new System.EventHandler(this.WorkPlace_DoubleClick);
            this.Paint += new PaintEventHandler(this.WorkPlace_Paint);
            this.Click += new System.EventHandler(this.menuTaskLine_Click);
            this.MouseMove += new MouseEventHandler(this.WorkPlace_MouseMove);
            this.KeyUp += new KeyEventHandler(this.WorkPlace_KeyUp);
            this.MouseDown += new MouseEventHandler(this.WorkPlace_MouseDown);
            this.MouseUp += new MouseEventHandler(this.WorkPlace_MouseUp);
            this.ResumeLayout(false);
        }

        #endregion

        private bool IsReadOnly()
        {
            if (!this.CanEdit)
            {
                MessageBoxHelper.ShowInformationMsg("只读状态不允许修改!");
                this._dragger = null;
            }
            return CanEdit;
        }

        #region OnPaint 重画事件

        /// <summary>
        /// 重绘的区域
        /// </summary>
        /// <param name="start">重绘区域的起始点</param>
        /// <param name="end">重绘区域的终止点</param>
        /// <returns></returns>
        private Region reDrawRegion(Point start, Point end)
        {
            int dx;
            int dy;
            Point[] point = new Point[] {start, start, end, end, start};
            int width = 3;
            if (end.Y == start.Y)
            {
                dx = 0;
                dy = width;
            }
            else
            {
                dx = width;
                float k = (start.X - end.X)/(end.Y - start.Y);
                dy = (int) (dx*k);
            }

            point[0].Offset(-dx, -dy);
            point[1].Offset(dx, dy);
            point[2].Offset(dx, dy);
            point[3].Offset(-dx, -dy);
            point[4] = point[0];
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLines(point);
            Region region = new Region(graphicsPath);
            return region;
        }

        private void WorkPlace_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("楷体_GB2312", 14, FontStyle.Regular);
            string displayName = WorkFlowCaption;
            StringFormat alignVertically = new StringFormat();
            SizeF sizeF = e.Graphics.MeasureString(displayName, font);
            //int Stringx = 400;
            int Stringx = 500;
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            //e.Graphics.DrawString(displayName, font, Brushes.Black, Stringx, 60, alignVertically);
            e.Graphics.DrawString(displayName, font, Brushes.Black, Stringx, 30, alignVertically);

            if (Module == 0 && _isDrawingLine == true)
            {
                Pen pen = new Pen(Color.Green, 1);
                AdjustableArrowCap Arrow = new AdjustableArrowCap(3, 3);
                pen.CustomEndCap = Arrow;
                e.Graphics.DrawLine(pen, _startPoint, _endPoint);
            }

            //折线的画图在l中已经画了.不需要再加.因为直线已经生成了.不同于画直线的是:画直线是在鼠标释放时才生成的直线对象/					
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            foreach (BaseComponent c in TaskItems)
                c.OnPaint(e);
            foreach (Link l in LineItems)
            {
                l.OnPaint(e);
            }
            if (_dragger != null)
                _myBounds.OnPaint(e);
        }

        #endregion

        #region MouseDown 鼠标按下事件

        private void WorkPlace_MouseDown(object sender, MouseEventArgs e)
        {
            //点击的是右键
            if (MouseButtons == MouseButtons.Right)
            {
                if (SelectedLine.Count != 0 && SelectedItems.Count == 0) //选中直线，没有选中任务节点
                {
                    this.ContextMenu = this.contextMenu;
                }
                else if (SelectedItems.Count > 0) //选中任务节点
                {
                    this.ContextMenu = this.contextMenu;
                }
                else //直线和任务节点都没有选中
                    this.ContextMenu = this.cmPanel;
                return;
            }
            //点击的是左键
            if (ToolModel == true) //工具模式下
            {
                Point p = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);

                //操作节点
                switch (this.Module)
                {
                    case 1:
                        this._stId++;
                        StartTask st = new StartTask(p, _stId);
                        AddItem(st, 1);
                        break;
                    case 2:
                        this._endtId++;
                        EndTask endt = new EndTask(p, _endtId);
                        AddItem(endt, 2);
                        break;
                    case 3:
                        this._altId++;
                        AlternateTask at = new AlternateTask(p, _altId);
                        AddItem(at, 3);
                        break;
                    case 4:
                        this._jtId++;
                        JudgeTask jt = new JudgeTask(p, _jtId);
                        AddItem(jt, 4);
                        break;
                    case 5:
                        this._etId++;
                        ViewTask et = new ViewTask(p, _etId);
                        AddItem(et, 5);
                        break;
                    case 6:
                        this._subId++;
                        SubFlowTask sft = new SubFlowTask(p, _subId);
                        AddItem(sft, 6);
                        break;
                    case 0: //连线				
                        Point point = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                        foreach (BaseComponent c in TaskItems)
                        {
                            if (c.Contains(point))
                            {
                                _startTask = c;
                                this._isDrawingLine = true;
                                _startPoint.X = e.X;
                                _startPoint.Y = e.Y;
                                break;
                            }
                            else
                            {
                                _startTask = null;
                                this._isDrawingLine = false;
                            }
                        }
                        break;
                    case -1: //自连线
                        point = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                        foreach (BaseComponent c in TaskItems)
                        {
                            if (c.Contains(point))
                            {
                                _startTask = c;
                                _endTask = c;
                                Link lnk = new Link(_startTask, _endTask);
                                lnk.flowGuid = this.WorkFlowId;
                                this.LineItems.Add(lnk);
                                IsModify = true;
                                this.Invalidate();
                                break;
                            }
                        }
                        break;
                }
                if (NowButton != null && LockModel == false) NowButton.Checked = false; //添加完后修改toolbar按钮为非选中状态
            }
            else //非工具模式下
            {
                Point p = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                BaseComponent baseComponent = IsInAItem(p);
                _link = IsInALine(p);
                if (baseComponent != null) //鼠标点击了某一个任务节点
                {
                    if (IsInASelectedItem(p))
                    {
                        MouseDownInAComponent(p);
                    }
                    else
                    {
                        SelectedItems.Clear();
                        SelectedItems.Add(baseComponent);
                        SelectedLine.Clear();
                        MouseDownInAComponent(p);
                        this.Invalidate();
                    }
                }
                else
                {
                    if (_link != null) //点击了某条连线
                    {
                        SelectedLine.Clear();
                        SelectedLine.Add(_link);
                        SelectedItems.Clear();
                        //点中的是锚点话,拖动锚点或者删除,在这里认为是拖动.利用函数来找出startPoint,endPoint和breakIndex等
                        _isInAnchor = IsInAnchor(p);
                        _breakPoint = p;
                        this.Invalidate();
                    }
                    else
                    {
                        SelectedItems.Clear();
                        SelectedLine.Clear();
                        if (e.Button == MouseButtons.Right)
                            return;
                        else
                            _rubberband = new Rubberband(this, p);
                    }
                }
                //this.label1.Text=SelectedLine.Count.ToString();
            }
        }

        #endregion

        #region MouseMove 鼠标移动事件

        /// <summary>
        /// 鼠标键移动时执行该函数，首先判断是否是在画线,如果是就进行画线处理;
        /// 然后判断是否在进行节点的拖拽操作，
        /// 如果是，就调用dragger的MoveT函数处理；否则，就判断是否在绘制橡皮圈，如果是，就调用rubberband的ResizeTo函数调整橡皮圈的大小。
        /// 同时，函数还调用了BaseComponent类的方法Contains判断当前点是否在某个任务节点的边框内。
        /// </summary>
        /// <param name="e"></param>
        private void WorkPlace_MouseMove(object sender, MouseEventArgs e)
        {

            if (this.Module == 0 && _isDrawingLine == true) //判断是否画线
            {
                Region region = reDrawRegion(_startPoint, _endPoint);
                this.Invalidate(region);
                _endPoint.X = e.X;
                _endPoint.Y = e.Y;

            }

            if (this.SelectedLine.Count > 0 && e.Button == MouseButtons.Left) //拖拽连线，画锚点。
            {
                if (!IsReadOnly()) return; //判断是否只读状态
                Link line = (Link) SelectedLine[0];
                if (line.startTask != line.endTask)
                {
                    //删除锚点时,breakIndex已经不等于-1.
                    //只有拖动时才知道是添加锚点所以在这里求出breakIndex.
                    if (this._breakIndex == -1) //新锚点
                    {
                        if (_link.breakPointX != null && _link.breakPointX.Count <= 3) //最多只让画三个锚点 2014.06.27修改
                        {
                            this._breakIndex = _link.BreakIndex(_breakPoint);
                            _startPoint.X = Convert.ToInt16(_link.breakPointX[_breakIndex - 1]);
                            _startPoint.Y = Convert.ToInt16(_link.breakPointY[_breakIndex - 1]);

                            _endPoint.X = Convert.ToInt16(_link.breakPointX[_breakIndex]);
                            _endPoint.Y = Convert.ToInt16(_link.breakPointY[_breakIndex]);

                            _link.breakPointX.Insert(_breakIndex, _breakPoint.X);
                            _link.breakPointY.Insert(_breakIndex, _breakPoint.Y);
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (_breakIndex >= 0 && _breakIndex < _link.breakPointX.Count) //已存在锚点
                    {
                        Region region = reDrawRegion(_startPoint, _breakPoint);
                        this.Invalidate(region);
                        region = reDrawRegion(_breakPoint, _endPoint);
                        this.Invalidate(region);
                        _link.breakPointX[_breakIndex] = _breakPoint.X; //为了画折线时拖动不需要画原来的	
                        _link.breakPointY[_breakIndex] = _breakPoint.Y;
                        _breakPoint.X = e.X;
                        _breakPoint.Y = e.Y;
                        _isZhexian = true;
                    }
                    IsModify = true;
                }

            }

            Point p = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
            if (_dragger != null)
            {
                if (!IsReadOnly()) return; //判断是否只读状态
                this.Cursor = Cursors.Hand;
                _dragger.DragT(p);
                IsModify = true;
            }
            else
                this.Cursor = Cursors.Default;
            if (_rubberband != null) //重定位橡皮圈的位置
                _rubberband.ResizeTo(p);
            // set the cursor if the mouse is over a selected item
            foreach (BaseComponent c in SelectedItems)
            {
                if (c.Contains(p))
                {
                    this.Cursor = c.GetCursor(p);
                    return;
                }
            }
        }

        #endregion

        #region MouseUp鼠标抬起事件

        /// <summary>
        /// 鼠标键抬起时执行该函数.
        /// 由于连线可以拖动来画,所以鼠标抬起时表示可以画一条连线.
        /// 由于连线的折点可以改变位置，所以鼠标抬起时也可能是折点位置修改好了。
        /// 切换工具的工作模式， 然后判断橡皮圈是否圈选了某些节点，如果是，就把它们添加到SelectedItems中。
        /// </summary>
        /// <param name="e"></param>
        private void WorkPlace_MouseUp(object sender, MouseEventArgs e)
        {
            if (ToolModel == true) //工具模式下
            {
                if (this.Module == 0 && _isDrawingLine == true) //画线,终止点
                {
                    Point point = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                    foreach (BaseComponent c in TaskItems)
                    {
                        if (c.Contains(point))
                        {
                            _endTask = c;
                            if (_endTask != _startTask)
                            {
                                var l = new Link(_startTask, _endTask) {flowGuid = this.WorkFlowId};
                                LineItems.Add(l);
                                IsModify = true;
                                //添加Undo操作用的

                                //	his.OperationLineItem.Add(l);
                            }
                            this._isDrawingLine = false;
                            break;
                        }
                        else
                        {
                            _endTask = null;
                            this._isDrawingLine = false;
                        }
                    }
                    this.Invalidate();
                }
                ToolModel = LockModel; //是否锁定，画多个任务节点

            }
            Point p = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
            //折线						
            if (this.SelectedLine.Count > 0 && this.CanEdit)
            {
                if (this.SelectedLine.Count > 0)
                {
                    //oldBreakPoint.Add(link.breakPoint);	
                    if (this._isZhexian)
                    {
                        _link.breakPointX[_breakIndex] = p.X;
                        _link.breakPointY[_breakIndex] = p.Y;
                        this._breakIndex = -1;
                        this._isZhexian = false;
                        IsModify = true;
                    }
                    //this.OperationLineItem.Add(link);
                    //this.OperationType.Add(UndoType.Zhexian);
                    this.Invalidate();

                }
            }
            //拖拽
            if (_dragger != null)
            {
                if (this.CanEdit && !_dragger.location.Equals(p))
                {
                    _dragger.DragTo(p);
                    _dragger.End();
                    IsModify = true;
                }
                _dragger = null;
                return;
            }
            //橡皮圈选择区域时的鼠标释放
            if (_rubberband != null)
            {
                Rectangle rect = _rubberband.Bounds();
                _rubberband.End();
                _rubberband = null;
                foreach (BaseComponent c in TaskItems)
                {
                    if (rect.Contains(c.bounds))
                        SelectedItems.Add(c);
                }
                this.Invalidate();
            }
        }

        #endregion

        private void menuDelete_Click(object sender, System.EventArgs e)
        {
            DeleteSelect();
        }

        private void menuSave_Click(object sender, System.EventArgs e)
        {
            SaveWorkFlow();
        }

        private void menuPrint_Click(object sender, System.EventArgs e)
        {
            var print = new PrintDialog {Document = this.printDoc};
            if (print.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.printDoc.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void menuPrintView_Click(object sender, System.EventArgs e)
        {
            try
            {
                view.Document = this.printDoc;
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowErrorMsg("打印出错,错误代码:" + ex.Message);
            }
        }

        #region 打印

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            for (int i = 0; i < this.TaskItems.Count; i++)
            {
                var bc = (BaseComponent) TaskItems[i];
                Bitmap bitmap = null;
                switch (bc.TaskType)
                {
                    case 1:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\启动节点.ico");
                        break;
                    case 2:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\终止节点.ico");
                        break;
                    case 3:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\交互节点.ico");
                        break;
                    case 4:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\判断节点.ico");
                        break;
                    case 5:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\查看节点.ico");
                        break;
                    case 6:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\自动节点.ico");
                        break;
                    case 7:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\控制节点.ico");
                        break;
                    case 8:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\子流程节点.ico");
                        break;
                }
                Point point = new Point(bc.X, bc.Y);
                e.Graphics.DrawImage(bitmap, point.X, point.Y, 32, 32);
                //流程名称	
                Font f = new Font("宋体", 18, FontStyle.Bold);
                string displayName = WorkFlowCaption;
                StringFormat alignVertically = new StringFormat();
                SizeF sizef = e.Graphics.MeasureString(displayName, f);
                int Stringx = (this.Width - ((int) sizef.Width))/2;
                e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                e.Graphics.DrawString(displayName, f, Brushes.Black, Stringx, 25, alignVertically);
                //写出图片的名字
                Font font = new Font("Arial", 8);
                Rectangle bounds = bc.bounds;
                SizeF sizeF = e.Graphics.MeasureString(bc.TaskName, font);
                int Namex = bounds.Left - ((int) sizeF.Width)/2 + bounds.Width/2;
                e.Graphics.DrawString(bc.TaskName, font, Brushes.Black, Namex, bounds.Top + 40, alignVertically);
            }

            //画线
            for (int i = 0; i < LineItems.Count; i++)
            {
                Link line = (Link) LineItems[i];
                Pen pen = new Pen(Color.Green, 1);

                for (int m = 0; m < line.breakPointX.Count - 2; m++)
                {
                    Point bp = new Point(Convert.ToInt16(line.breakPointX[m]), Convert.ToInt16(line.breakPointY[m]));
                    Point bp2 = new Point(Convert.ToInt16(line.breakPointX[m + 1]),
                        Convert.ToInt16(line.breakPointY[m + 1]));
                    e.Graphics.DrawLine(pen, bp, bp2);
                }
                //画最后一条带箭头的
                Point tt = new Point(Convert.ToInt16(line.breakPointX[line.breakPointX.Count - 2]),
                    Convert.ToInt16(line.breakPointY[line.breakPointX.Count - 2]));
                Point tt2 = new Point(Convert.ToInt16(line.breakPointX[line.breakPointX.Count - 1]),
                    Convert.ToInt16(line.breakPointY[line.breakPointX.Count - 1]));
                AdjustableArrowCap Arrow = new AdjustableArrowCap(3, 3);
                pen.CustomEndCap = Arrow;
                e.Graphics.DrawLine(pen, tt, tt2);
                //画注释	
                if (line.Des == "")
                    continue;
                Font font = new Font("Arial", 8);
                StringFormat alignVertically = new StringFormat();
                alignVertically.LineAlignment = StringAlignment.Center; //指定文本在布局矩形中居中对齐
                SizeF sizeF = e.Graphics.MeasureString(line.Des, font);
                int x = ((int) line.breakPointX[0] + (int) line.breakPointX[1] - (int) sizeF.Width)/2;
                int y = ((int) line.breakPointY[0] + (int) line.breakPointY[1])/2;
                e.Graphics.DrawString(line.Des, font, Brushes.Blue, x, y, alignVertically);
            }
        }

        #endregion

        /// <summary>
        /// 删除选中的节点或者连线
        /// </summary>
        private void DeleteSelect()
        {
            //
            //TODO:这儿应该判断下是否有删除节点或连线的权限。
            //

            if (SelectedItems.Count > 0)
            {
                this.FuncDeleteTask();
            }

            if (SelectedLine.Count > 0)
            {
                if (_link.selectedAnchor >= 0 && _link.selectedAnchor < _link.breakPointX.Count)
                {
                    _link.breakPointX.RemoveAt(_link.selectedAnchor);
                    _link.breakPointY.RemoveAt(_link.selectedAnchor);
                    _link.selectedAnchor = -1;
                    this.Invalidate();
                }
                else
                    this.FuncDeleteLine();
            }
        }

        private void FuncDeleteTask()
        {
            if (!IsReadOnly()) return; //判断是否只读状态
            DialogResult result = MessageBox.Show("确定要删除所选的任务节点吗?", "提示!", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK)
                return;
            int lineNum = 0, taskNodeNum = 0;

            foreach (BaseComponent c in SelectedItems)
            {
                for (int i = LineItems.Count - 1; i >= 0; i--)
                {
                    if (((Link) LineItems[i]).startTask == c || ((Link) LineItems[i]).endTask == c)
                    {
                        Link l = (Link) LineItems[i];
                        LineItems.Remove(l);
                        RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkLine(SystemInfo.UserInfo,WorkFlowId, l.linkGuid);
                        lineNum++;
                    }
                }

                TaskItems.Remove(c);
                RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkTask(SystemInfo.UserInfo, WorkFlowId,c.TaskId);
                taskNodeNum++;
                IsModify = true;
            }

            SelectedItems.Clear();
            SelectedLine.Clear();
            this.Invalidate();
        }

        private void FuncDeleteLine()
        {
            if (!IsReadOnly()) return; //判断是否只读状态
            Link l = (Link) SelectedLine[0];
            LineItems.Remove(l);
            RDIFrameworkService.Instance.WorkFlowTemplateService.DeleteWorkLine(SystemInfo.UserInfo, WorkFlowId,l.linkGuid);
            SelectedLine.Clear();
            IsModify = true;
            this.Invalidate();
        }

        private void WorkPlace_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelect();
            }
        }

        /// <summary>
        /// 清除资源
        /// </summary>
        private void ClearAndMenu()
        {
            SelectedItems.Clear();
            SelectedLine.Clear();
            TaskItems.Clear();
            LineItems.Clear();
            this.IsModify = false;
        }

        private void WorkPlaceCloseFlow_Click(object sender, System.EventArgs e)
        {
            this.closeFlow();
        }

        /// <summary>
        /// 点击关闭流程模版
        /// </summary>	
        public void closeFlow()
        {
            if (!this.IsModify) //流程没有改变,不用保存直接关闭流程
            {
                this.ClearAndMenu();
            }
            else
            {
                DialogResult result =MessageBoxHelper.Show("是否保存对[" + WorkFlowCaption + "]的修改?");
                switch (result)
                {
                    case DialogResult.Yes:
                        SaveWorkFlow();
                        this.ClearAndMenu();
                        break;
                    case DialogResult.No:
                        this.ClearAndMenu();
                        break;
                }
            }
        }

        private void menuProperty_Click(object sender, System.EventArgs e)
        {

        }

        public void PanelPass(ToolBar toolBar, ToolBarButton btnLock1)
        {
            //this.toolBar = toolBar;
            //this.btnLock = btnLock1;
        }

        private void menuTaskLine_Click(object sender, System.EventArgs e)
        {

        }

        private void WorkPlace_DoubleClick(object sender, System.EventArgs e)
        {
            //节点属性
            if (SelectedItems.Count == 1)
            {
                BaseComponent tmpBaseComponent = (BaseComponent) SelectedItems[0];
                if (tmpBaseComponent.TaskType == 2) //结束节点
                    return;
                Object[] objArray = new object[3];
                objArray[0] = tmpBaseComponent;
                objArray[1] = this.UserId;
                objArray[2] = this.UserName;
                DynamicLibrary myDll = new DynamicLibrary
                {
                    DllFileName = tmpBaseComponent.DllFileName,
                    DllClassName = tmpBaseComponent.DllClassName,
                    ObjArray = objArray
                };
                myDll.CallSDIWindows();
            }
            else //连线属性
            {
                if (SelectedLine.Count == 1)
                {
                    Link tmpLink = (Link) SelectedLine[0];
                    Object[] objArray = new object[3];
                    objArray[0] = tmpLink;
                    objArray[1] = this.UserId;
                    objArray[2] = this.UserName;
                    DynamicLibrary myDll = new DynamicLibrary
                    {
                        DllFileName = tmpLink.DllFileName,
                        DllClassName = tmpLink.DllClassName,
                        ObjArray = objArray
                    };
                    myDll.CallSDIWindows();
                }
            }
        }

        public void SaveWorkFlow()
        {
            try
            {
                WorkFlowData tmpWorkflow = new WorkFlowData();
                tmpWorkflow.SaveWorkFlow(WorkFlowId, TaskItems, LineItems, State);
                IsModify = false;
                MessageBoxHelper.ShowInformationMsg("保存成功!");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowErrorMsg("保存失败，错误代码:" + ex.Message.ToString());
            }
        }
    }
}
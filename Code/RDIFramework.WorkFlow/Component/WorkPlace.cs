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
    /// WorkPlace ��ժҪ˵����
    /// </summary>
    public class WorkPlace : UserControl
    {
        #region ˽�б�����������
        private int _stId; //�����ڵ����
        private int _endtId; //��ֹ�ڵ����
        private int _altId; //�����ڵ����
        private int _jtId; //�жϽڵ����
        private int _etId; //�鿴�ڵ����
        private int _autoId; //�Զ��ڵ����
        private int _conId; //���ƽڵ����
        private int _subId; //�����̽ڵ����
        private Rubberband _rubberband = null; //��ƤȦ									
        private Dragger _dragger = null; //��ק����
        private bool _isZhexian; //ѡ�е����ߵ�ѡ���۵������
        private int _breakIndex;
        private bool _isInAnchor;
        private bool _isDrawingLine;
        private Link _link; //������ʱѡ�е�ֱ��.��Ϊ�ƶ�����϶�ʱ����Ҫ��ԭ����ֱ��
        private Point _startPoint, _endPoint, _breakPoint;
        private Bounds _myBounds;
        private BaseComponent _startTask, _endTask;
        #endregion

        /// <summary>
        /// ����ģ�����нڵ��б�
        /// </summary>
        public ArrayList TaskItems = new ArrayList();

        /// <summary>
        /// ����ģ�����������б�
        /// </summary>
        public ArrayList LineItems = new ArrayList();

        /// <summary>
        /// ѡ�еĽڵ��б�
        /// </summary>
        public SelectedItems SelectedItems = new SelectedItems();

        /// <summary>
        /// ѡ�е������б�
        /// </summary>
        public SelectedLine SelectedLine = new SelectedLine();

        public ToolStripButton NowButton;

        /// <summary>
        /// ��������ͼ���ģʽ��ֻ�������ģʽ���ܻ�����ڵ����
        /// </summary>
        public bool ToolModel;

        /// <summary>
        /// �ڵ�ģʽ������ģʽ��1--�����ڵ㣻2-��ֹ�ڵ�;3-�����ڵ�;4-�жϽڵ�;5-�鿴�ڵ�;6-�Զ��ڵ�;7-���ƽڵ�;
        /// 8-�����̽ڵ㣻0������,-1-������;
        /// </summary>
        public int Module;

        /// <summary>
        /// ��ͼ������ͬʱ���������ڵ�ʱLockModel=true
        /// </summary>
        public bool LockModel;

        /// <summary>
        /// ����ģ������
        /// </summary>
        public string WorkFlowCaption = "";

        /// <summary>
        /// ����ģ��Id
        /// </summary>
        public string WorkFlowId = "";

        /// <summary>
        /// �޸ġ��½����鿴����״̬
        /// </summary>
        public string State;

        /// <summary>
        /// �Ƿ�����༭
        /// </summary>
        public bool CanEdit;

        /// <summary>
        /// �Ƿ��޸�
        /// </summary>
        public bool IsModify = false;

        /// <summary>
        /// �������˺ţ�����Ȩ���жϡ�
        /// </summary>
        public string UserId = "";

        /// <summary>
        /// ������������������ʾ��
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

        #region ��ͼ����
        /// <summary>
        /// �жϵ�p�Ƿ���ֱ�ߵ�ĳ��ê��,ͬʱ��һЩ׼������
        /// </summary>
        /// <param name="p"></param>
        /// <returns>p��ֱ�ߵ�ĳ��ê��,����true,����false </returns>
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
        /// �������Ƿ���ѡ����ֱ����
        /// </summary>
        /// <param name="thePoint">������</param>
        /// <returns>thePoint��ѡ����ĳһֱ���Ϸ��ظ�ֱ��,���򷵻�null</returns>
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
        /// �������Ƿ���ѡ�е�����ڵ���
        /// </summary>
        /// <param name="thePoint">������</param>
        /// <returns>���������thePoint��ĳһѡ�е�����ڵ��Ϸ��ظ�����ڵ�,����ķ���null</returns>
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
        /// �������Ƿ�������ڵ���
        /// </summary>
        /// <param name="thePoint">������</param>
        /// <returns>������������ڵ���,���ظ�����ڵ�,���򷵻�null</returns>		
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

        #region Windows ������������ɵĴ���

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
        /// ������������ʹ�õ���Դ��
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
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
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
            this.menuSave.Text = "����";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuPrint
            // 
            this.menuPrint.Index = 1;
            this.menuPrint.Text = "��ӡ";
            this.menuPrint.Click += new System.EventHandler(this.menuPrint_Click);
            // 
            // menuPrintView
            // 
            this.menuPrintView.Index = 2;
            this.menuPrintView.Text = "��ӡԤ��";
            this.menuPrintView.Click += new System.EventHandler(this.menuPrintView_Click);
            // 
            // WorkPlaceCloseFlow
            // 
            this.WorkPlaceCloseFlow.Index = 3;
            this.WorkPlaceCloseFlow.Text = "�ر�";
            this.WorkPlaceCloseFlow.Click += new System.EventHandler(this.WorkPlaceCloseFlow_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Index = -1;
            this.menuDelete.Text = "ɾ��";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuProperty
            // 
            this.menuProperty.Index = -1;
            this.menuProperty.Text = "����";
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
            this.menuItem1.Text = "ɾ��";
            this.menuItem1.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuTaskLine
            // 
            this.menuTaskLine.Index = 1;
            this.menuTaskLine.Text = "����";
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
                MessageBoxHelper.ShowInformationMsg("ֻ��״̬�������޸�!");
                this._dragger = null;
            }
            return CanEdit;
        }

        #region OnPaint �ػ��¼�

        /// <summary>
        /// �ػ������
        /// </summary>
        /// <param name="start">�ػ��������ʼ��</param>
        /// <param name="end">�ػ��������ֹ��</param>
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
            Font font = new Font("����_GB2312", 14, FontStyle.Regular);
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

            //���ߵĻ�ͼ��l���Ѿ�����.����Ҫ�ټ�.��Ϊֱ���Ѿ�������.��ͬ�ڻ�ֱ�ߵ���:��ֱ����������ͷ�ʱ�����ɵ�ֱ�߶���/					
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

        #region MouseDown ��갴���¼�

        private void WorkPlace_MouseDown(object sender, MouseEventArgs e)
        {
            //��������Ҽ�
            if (MouseButtons == MouseButtons.Right)
            {
                if (SelectedLine.Count != 0 && SelectedItems.Count == 0) //ѡ��ֱ�ߣ�û��ѡ������ڵ�
                {
                    this.ContextMenu = this.contextMenu;
                }
                else if (SelectedItems.Count > 0) //ѡ������ڵ�
                {
                    this.ContextMenu = this.contextMenu;
                }
                else //ֱ�ߺ�����ڵ㶼û��ѡ��
                    this.ContextMenu = this.cmPanel;
                return;
            }
            //����������
            if (ToolModel == true) //����ģʽ��
            {
                Point p = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);

                //�����ڵ�
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
                    case 0: //����				
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
                    case -1: //������
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
                if (NowButton != null && LockModel == false) NowButton.Checked = false; //�������޸�toolbar��ťΪ��ѡ��״̬
            }
            else //�ǹ���ģʽ��
            {
                Point p = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                BaseComponent baseComponent = IsInAItem(p);
                _link = IsInALine(p);
                if (baseComponent != null) //�������ĳһ������ڵ�
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
                    if (_link != null) //�����ĳ������
                    {
                        SelectedLine.Clear();
                        SelectedLine.Add(_link);
                        SelectedItems.Clear();
                        //���е���ê�㻰,�϶�ê�����ɾ��,��������Ϊ���϶�.���ú������ҳ�startPoint,endPoint��breakIndex��
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

        #region MouseMove ����ƶ��¼�

        /// <summary>
        /// �����ƶ�ʱִ�иú����������ж��Ƿ����ڻ���,����Ǿͽ��л��ߴ���;
        /// Ȼ���ж��Ƿ��ڽ��нڵ����ק������
        /// ����ǣ��͵���dragger��MoveT�����������򣬾��ж��Ƿ��ڻ�����ƤȦ������ǣ��͵���rubberband��ResizeTo����������ƤȦ�Ĵ�С��
        /// ͬʱ��������������BaseComponent��ķ���Contains�жϵ�ǰ���Ƿ���ĳ������ڵ�ı߿��ڡ�
        /// </summary>
        /// <param name="e"></param>
        private void WorkPlace_MouseMove(object sender, MouseEventArgs e)
        {

            if (this.Module == 0 && _isDrawingLine == true) //�ж��Ƿ���
            {
                Region region = reDrawRegion(_startPoint, _endPoint);
                this.Invalidate(region);
                _endPoint.X = e.X;
                _endPoint.Y = e.Y;

            }

            if (this.SelectedLine.Count > 0 && e.Button == MouseButtons.Left) //��ק���ߣ���ê�㡣
            {
                if (!IsReadOnly()) return; //�ж��Ƿ�ֻ��״̬
                Link line = (Link) SelectedLine[0];
                if (line.startTask != line.endTask)
                {
                    //ɾ��ê��ʱ,breakIndex�Ѿ�������-1.
                    //ֻ���϶�ʱ��֪�������ê���������������breakIndex.
                    if (this._breakIndex == -1) //��ê��
                    {
                        if (_link.breakPointX != null && _link.breakPointX.Count <= 3) //���ֻ�û�����ê�� 2014.06.27�޸�
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

                    if (_breakIndex >= 0 && _breakIndex < _link.breakPointX.Count) //�Ѵ���ê��
                    {
                        Region region = reDrawRegion(_startPoint, _breakPoint);
                        this.Invalidate(region);
                        region = reDrawRegion(_breakPoint, _endPoint);
                        this.Invalidate(region);
                        _link.breakPointX[_breakIndex] = _breakPoint.X; //Ϊ�˻�����ʱ�϶�����Ҫ��ԭ����	
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
                if (!IsReadOnly()) return; //�ж��Ƿ�ֻ��״̬
                this.Cursor = Cursors.Hand;
                _dragger.DragT(p);
                IsModify = true;
            }
            else
                this.Cursor = Cursors.Default;
            if (_rubberband != null) //�ض�λ��ƤȦ��λ��
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

        #region MouseUp���̧���¼�

        /// <summary>
        /// ����̧��ʱִ�иú���.
        /// �������߿����϶�����,�������̧��ʱ��ʾ���Ի�һ������.
        /// �������ߵ��۵���Ըı�λ�ã��������̧��ʱҲ�������۵�λ���޸ĺ��ˡ�
        /// �л����ߵĹ���ģʽ�� Ȼ���ж���ƤȦ�Ƿ�Ȧѡ��ĳЩ�ڵ㣬����ǣ��Ͱ�������ӵ�SelectedItems�С�
        /// </summary>
        /// <param name="e"></param>
        private void WorkPlace_MouseUp(object sender, MouseEventArgs e)
        {
            if (ToolModel == true) //����ģʽ��
            {
                if (this.Module == 0 && _isDrawingLine == true) //����,��ֹ��
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
                                //���Undo�����õ�

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
                ToolModel = LockModel; //�Ƿ����������������ڵ�

            }
            Point p = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
            //����						
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
            //��ק
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
            //��ƤȦѡ������ʱ������ͷ�
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
                MessageBoxHelper.ShowErrorMsg("��ӡ����,�������:" + ex.Message);
            }
        }

        #region ��ӡ

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            for (int i = 0; i < this.TaskItems.Count; i++)
            {
                var bc = (BaseComponent) TaskItems[i];
                Bitmap bitmap = null;
                switch (bc.TaskType)
                {
                    case 1:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\�����ڵ�.ico");
                        break;
                    case 2:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\��ֹ�ڵ�.ico");
                        break;
                    case 3:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\�����ڵ�.ico");
                        break;
                    case 4:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\�жϽڵ�.ico");
                        break;
                    case 5:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\�鿴�ڵ�.ico");
                        break;
                    case 6:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\�Զ��ڵ�.ico");
                        break;
                    case 7:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\���ƽڵ�.ico");
                        break;
                    case 8:
                        bitmap = new Bitmap(Application.StartupPath + @"\Resource\WFImage\�����̽ڵ�.ico");
                        break;
                }
                Point point = new Point(bc.X, bc.Y);
                e.Graphics.DrawImage(bitmap, point.X, point.Y, 32, 32);
                //��������	
                Font f = new Font("����", 18, FontStyle.Bold);
                string displayName = WorkFlowCaption;
                StringFormat alignVertically = new StringFormat();
                SizeF sizef = e.Graphics.MeasureString(displayName, f);
                int Stringx = (this.Width - ((int) sizef.Width))/2;
                e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                e.Graphics.DrawString(displayName, f, Brushes.Black, Stringx, 25, alignVertically);
                //д��ͼƬ������
                Font font = new Font("Arial", 8);
                Rectangle bounds = bc.bounds;
                SizeF sizeF = e.Graphics.MeasureString(bc.TaskName, font);
                int Namex = bounds.Left - ((int) sizeF.Width)/2 + bounds.Width/2;
                e.Graphics.DrawString(bc.TaskName, font, Brushes.Black, Namex, bounds.Top + 40, alignVertically);
            }

            //����
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
                //�����һ������ͷ��
                Point tt = new Point(Convert.ToInt16(line.breakPointX[line.breakPointX.Count - 2]),
                    Convert.ToInt16(line.breakPointY[line.breakPointX.Count - 2]));
                Point tt2 = new Point(Convert.ToInt16(line.breakPointX[line.breakPointX.Count - 1]),
                    Convert.ToInt16(line.breakPointY[line.breakPointX.Count - 1]));
                AdjustableArrowCap Arrow = new AdjustableArrowCap(3, 3);
                pen.CustomEndCap = Arrow;
                e.Graphics.DrawLine(pen, tt, tt2);
                //��ע��	
                if (line.Des == "")
                    continue;
                Font font = new Font("Arial", 8);
                StringFormat alignVertically = new StringFormat();
                alignVertically.LineAlignment = StringAlignment.Center; //ָ���ı��ڲ��־����о��ж���
                SizeF sizeF = e.Graphics.MeasureString(line.Des, font);
                int x = ((int) line.breakPointX[0] + (int) line.breakPointX[1] - (int) sizeF.Width)/2;
                int y = ((int) line.breakPointY[0] + (int) line.breakPointY[1])/2;
                e.Graphics.DrawString(line.Des, font, Brushes.Blue, x, y, alignVertically);
            }
        }

        #endregion

        /// <summary>
        /// ɾ��ѡ�еĽڵ��������
        /// </summary>
        private void DeleteSelect()
        {
            //
            //TODO:���Ӧ���ж����Ƿ���ɾ���ڵ�����ߵ�Ȩ�ޡ�
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
            if (!IsReadOnly()) return; //�ж��Ƿ�ֻ��״̬
            DialogResult result = MessageBox.Show("ȷ��Ҫɾ����ѡ������ڵ���?", "��ʾ!", MessageBoxButtons.OKCancel);
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
            if (!IsReadOnly()) return; //�ж��Ƿ�ֻ��״̬
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
        /// �����Դ
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
        /// ����ر�����ģ��
        /// </summary>	
        public void closeFlow()
        {
            if (!this.IsModify) //����û�иı�,���ñ���ֱ�ӹر�����
            {
                this.ClearAndMenu();
            }
            else
            {
                DialogResult result =MessageBoxHelper.Show("�Ƿ񱣴��[" + WorkFlowCaption + "]���޸�?");
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
            //�ڵ�����
            if (SelectedItems.Count == 1)
            {
                BaseComponent tmpBaseComponent = (BaseComponent) SelectedItems[0];
                if (tmpBaseComponent.TaskType == 2) //�����ڵ�
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
            else //��������
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
                MessageBoxHelper.ShowInformationMsg("����ɹ�!");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowErrorMsg("����ʧ�ܣ��������:" + ex.Message.ToString());
            }
        }
    }
}
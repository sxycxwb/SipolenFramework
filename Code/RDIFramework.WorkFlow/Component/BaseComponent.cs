using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// 工作流模板图形化控件
    /// </summary>
    public class BaseComponent
    {
        /// <summary>
        /// 任务节点名称使用的字体
        /// </summary>
        public Font font;

        /// <summary>
        /// 节点坐标
        /// </summary>
        public int X, Y;

        /// <summary>
        /// 任务节点名称对齐方式
        /// </summary>
        public StringFormat alignVertically;

        /// <summary>
        /// 选定标志
        /// </summary>
        public bool Selected;

        /// <summary>
        /// 任务节点图标边框
        /// </summary>
        public Rectangle bounds;

        /// <summary>
        /// 任务节点名称
        /// </summary>

        public String TaskName;

        /// <summary>
        /// 任务节点的id
        /// </summary>
        public string TaskId;

        /// <summary>
        /// 流程模版的id
        /// </summary>
        public string WorkFlowId;

        /// <summary>
        /// 节点图标
        /// </summary>
        public Icon icon;

        /// <summary>
        /// 对象攫取器,八个方向的。
        /// </summary>				
        public GrabHandles grabHandles;

        /// <summary>
        /// 对象拖拽处理器
        /// </summary>
        public Dragger dragger;

        /// <summary>
        /// //当前位置
        /// </summary>
        public Point LocalPoint;

        /// <summary>
        /// 节点类型
        /// </summary>
        public int TaskType;

        /// <summary>
        /// 判断节点and/or
        /// </summary>
        public string TaskTypeAndOr = "";

        /// <summary>
        /// 反射调用,与控件属性关联的dll文件名
        /// </summary>
        public string DllFileName = "";

        /// <summary>
        /// 反射调用,与控件属性关联的类名(包含命名空间)
        /// </summary>
        public string DllClassName = "";

        /// <summary>
        /// 处理者策略
        /// </summary>
        public string OperRule = "";

        /// <summary>
        /// 备注
        /// </summary>
        public string Description = "";

        /// <summary>
        /// 处理者是本人时跳过处理
        /// </summary>
        public bool IsJumpSelf = false;

        public BaseComponent()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            DllFileName = Application.StartupPath + @"\RDIFramework.WorkFlow.dll";
            font = new Font("Arial", 8);
            alignVertically = new StringFormat {LineAlignment = StringAlignment.Center};
            grabHandles = new GrabHandles(this);
            X = LocalPoint.X; // - panel.AutoScrollPosition.X;
            Y = LocalPoint.Y; // - panel.AutoScrollPosition.Y;
            TaskId = BusinessLogic.NewGuid();
        }

        /// <summary>
        /// 判断给定坐标是否在组件的边界矩形内
        /// </summary>
        /// <param name="thePoint">给定坐标</param>
        /// <returns></returns>
        public bool Contains(Point thePoint)
        {
            if (!Selected)
            {
                return bounds.Contains(thePoint);
            }
            else
            {
                Rectangle selectionRect = bounds;
                selectionRect.Inflate(SystemInformation.FrameBorderSize); //通过各方向的给定值增加矩形的尺寸
                return selectionRect.Contains(thePoint);
            }
        }

        public bool InDragHandle(Point thePoint)
        {
            if (!Selected)
                return false;
            return grabHandles.Contains(thePoint);
        }

        /// <summary>
        /// 用于绘制鼠标指针的图像
        /// </summary>
        /// <param name="thePoint"></param>
        /// <returns></returns>
        public Cursor GetCursor(Point thePoint)
        {
            if (Selected)
            {
                return InDragHandle(thePoint) ? grabHandles.GetCursor(thePoint) : Cursors.SizeAll;
            }
            return Cursors.Default;
        }

        /// <summary>
        /// 绘制图片和任务名称；
        /// 如果选择了组件，它绘制选择框和抓取句柄
        /// </summary>
        /// <param name="e"></param>		
        public void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawIcon(icon, bounds.Left, bounds.Top);
            string displayName = TaskName;
            SizeF sizeF = e.Graphics.MeasureString(displayName, font);
            int Namex = bounds.Left - ((int) sizeF.Width)/2 + bounds.Width/2;
            e.Graphics.DrawString(displayName, font, Brushes.Black, Namex, bounds.Top + 40, alignVertically);
            if (!Selected)
                return;
            Rectangle outerRect = bounds; //paint the selection box
            outerRect.Inflate(SystemInformation.FrameBorderSize);
            ControlPaint.DrawSelectionFrame(e.Graphics, true, outerRect, bounds, SystemColors.ActiveBorder);
            grabHandles.OnPaint(e); //paint the grab handles
        }

        /// <summary>
        /// 判断节点是否存在
        /// </summary>
        /// <returns></returns>
        public bool TaskExist()
        {
            return RDIFrameworkService.Instance.WorkFlowTemplateService.ExistWorkTask(SystemInfo.UserInfo, TaskId);
        }

        /// <summary>
        ///增加任务节点
        /// </summary>
        public void SaveInsertTask()
        {
            if (TaskId.Trim().Length == 0 || TaskId == null)
                throw new Exception("SaveInsertTask方法错误，TaskId 不能为空！");
            try
            {
                var entity = new WorkTaskEntity
                {
                    WorkTaskId = TaskId,
                    TaskCaption = TaskName,
                    TaskTypeId = BusinessLogic.ConvertToString(TaskType),
                    IXPosition = X,
                    IYPosition = Y,
                    WorkFlowId = WorkFlowId,
                    OperRule = OperRule,
                    Description = Description,
                    TaskTypeAndOr = TaskTypeAndOr,
                    IsJumpSelf = IsJumpSelf ? 1 : 0
                };
                RDIFrameworkService.Instance.WorkFlowTemplateService.InsertWorkTask(SystemInfo.UserInfo, entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 修改任务节点
        /// </summary>
        public void SaveUpdateTask()
        {
            if (TaskId.Trim().Length == 0 || TaskId == null)
                throw new Exception("SaveUpdateTask方法错误，TaskId 不能为空！");
            try
            {
                var entity = new WorkTaskEntity
                {
                    WorkTaskId = TaskId,
                    TaskCaption = TaskName,
                    TaskTypeId = BusinessLogic.ConvertToString(TaskType),
                    IXPosition = X,
                    IYPosition = Y,
                    WorkFlowId = WorkFlowId,
                    OperRule = OperRule,
                    Description = Description,
                    TaskTypeAndOr = TaskTypeAndOr,
                    IsJumpSelf = IsJumpSelf ? 1 : 0
                };
                RDIFrameworkService.Instance.WorkFlowTemplateService.UpdateWorkTask(SystemInfo.UserInfo, entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString(CultureInfo.InvariantCulture));
            }
        }
    }

    /// <summary>
    /// 1启动节点
    /// </summary>
    public class StartTask : BaseComponent
    {
        public StartTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmStartNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "启动节点" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 1;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\启动节点.ico");
            bounds = new Rectangle(LocalPoint, icon.Size);
        }
    }

    /// <summary>
    /// 3交互节点
    /// </summary>
    public class AlternateTask : BaseComponent
    {
        public AlternateTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmAlterNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "交互节点" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 3;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\交互节点.ico");
            bounds = new Rectangle(LocalPoint, icon.Size);
        }
    }

    /// <summary>
    /// 4控制节点
    /// </summary>
    public class JudgeTask : BaseComponent
    {
        public JudgeTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmJudgeNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "控制节点" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 4;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\控制节点.ico");
            bounds = new Rectangle(LocalPoint, icon.Size);
        }
    }

    /// <summary>
    /// 6子流程节点
    /// </summary>
    public class SubFlowTask : BaseComponent
    {
        public SubFlowTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmSubWorkFlowNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "子流程节点" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 6;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\子流程节点.ico");
            bounds = new Rectangle(LocalPoint, icon.Size);
        }
    }

    /// <summary>
    /// 6自动接点
    /// </summary>
    public class AutoTask : BaseComponent
    {
        public AutoTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmSubWorkFlowNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "自动节点" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 6;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\自连线.ico");
            bounds = new Rectangle(LocalPoint, icon.Size);
        }
    }

    ///// <summary>
    ///// 7控制节点
    ///// </summary>
    //public class ControlTask: BaseComponent
    //{
    //    public ControlTask(Point localPoint,int orderId)
    //    {
    //        DllClassName="RDIFramework.WorkFlow.fmTaskControl";
    //        LocalPoint=localPoint;
    //        X=LocalPoint.X;
    //        Y=LocalPoint.Y;
    //        TaskName="控制节点"+orderId.ToString(CultureInfo.InvariantCulture);
    //        TaskType=7;
    //        icon = new Icon(Application.StartupPath+@"\Resource\WFImage\控制节点.ico");
    //        bounds=new Rectangle(LocalPoint,icon.Size);
    //    }		
    //}

    /// <summary>
    /// 5查看节点
    /// </summary>
    public class ViewTask : BaseComponent
    {
        public ViewTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmViewTaskNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "查看节点" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 5;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\查看节点.ico");
            bounds = new Rectangle(localPoint, icon.Size);
        }

    }

    /// <summary>
    /// 2终止节点
    /// </summary>
    public class EndTask : BaseComponent
    {
        public EndTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmStartNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "结束节点" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 2;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\终止节点.ico");
            bounds = new Rectangle(localPoint, icon.Size);
        }
    }
}

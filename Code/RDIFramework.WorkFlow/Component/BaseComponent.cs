using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// ������ģ��ͼ�λ��ؼ�
    /// </summary>
    public class BaseComponent
    {
        /// <summary>
        /// ����ڵ�����ʹ�õ�����
        /// </summary>
        public Font font;

        /// <summary>
        /// �ڵ�����
        /// </summary>
        public int X, Y;

        /// <summary>
        /// ����ڵ����ƶ��뷽ʽ
        /// </summary>
        public StringFormat alignVertically;

        /// <summary>
        /// ѡ����־
        /// </summary>
        public bool Selected;

        /// <summary>
        /// ����ڵ�ͼ��߿�
        /// </summary>
        public Rectangle bounds;

        /// <summary>
        /// ����ڵ�����
        /// </summary>

        public String TaskName;

        /// <summary>
        /// ����ڵ��id
        /// </summary>
        public string TaskId;

        /// <summary>
        /// ����ģ���id
        /// </summary>
        public string WorkFlowId;

        /// <summary>
        /// �ڵ�ͼ��
        /// </summary>
        public Icon icon;

        /// <summary>
        /// �����ȡ��,�˸�����ġ�
        /// </summary>				
        public GrabHandles grabHandles;

        /// <summary>
        /// ������ק������
        /// </summary>
        public Dragger dragger;

        /// <summary>
        /// //��ǰλ��
        /// </summary>
        public Point LocalPoint;

        /// <summary>
        /// �ڵ�����
        /// </summary>
        public int TaskType;

        /// <summary>
        /// �жϽڵ�and/or
        /// </summary>
        public string TaskTypeAndOr = "";

        /// <summary>
        /// �������,��ؼ����Թ�����dll�ļ���
        /// </summary>
        public string DllFileName = "";

        /// <summary>
        /// �������,��ؼ����Թ���������(���������ռ�)
        /// </summary>
        public string DllClassName = "";

        /// <summary>
        /// �����߲���
        /// </summary>
        public string OperRule = "";

        /// <summary>
        /// ��ע
        /// </summary>
        public string Description = "";

        /// <summary>
        /// �������Ǳ���ʱ��������
        /// </summary>
        public bool IsJumpSelf = false;

        public BaseComponent()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
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
        /// �жϸ��������Ƿ�������ı߽������
        /// </summary>
        /// <param name="thePoint">��������</param>
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
                selectionRect.Inflate(SystemInformation.FrameBorderSize); //ͨ��������ĸ���ֵ���Ӿ��εĳߴ�
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
        /// ���ڻ������ָ���ͼ��
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
        /// ����ͼƬ���������ƣ�
        /// ���ѡ���������������ѡ����ץȡ���
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
        /// �жϽڵ��Ƿ����
        /// </summary>
        /// <returns></returns>
        public bool TaskExist()
        {
            return RDIFrameworkService.Instance.WorkFlowTemplateService.ExistWorkTask(SystemInfo.UserInfo, TaskId);
        }

        /// <summary>
        ///��������ڵ�
        /// </summary>
        public void SaveInsertTask()
        {
            if (TaskId.Trim().Length == 0 || TaskId == null)
                throw new Exception("SaveInsertTask��������TaskId ����Ϊ�գ�");
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
        /// �޸�����ڵ�
        /// </summary>
        public void SaveUpdateTask()
        {
            if (TaskId.Trim().Length == 0 || TaskId == null)
                throw new Exception("SaveUpdateTask��������TaskId ����Ϊ�գ�");
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
    /// 1�����ڵ�
    /// </summary>
    public class StartTask : BaseComponent
    {
        public StartTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmStartNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "�����ڵ�" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 1;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\�����ڵ�.ico");
            bounds = new Rectangle(LocalPoint, icon.Size);
        }
    }

    /// <summary>
    /// 3�����ڵ�
    /// </summary>
    public class AlternateTask : BaseComponent
    {
        public AlternateTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmAlterNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "�����ڵ�" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 3;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\�����ڵ�.ico");
            bounds = new Rectangle(LocalPoint, icon.Size);
        }
    }

    /// <summary>
    /// 4���ƽڵ�
    /// </summary>
    public class JudgeTask : BaseComponent
    {
        public JudgeTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmJudgeNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "���ƽڵ�" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 4;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\���ƽڵ�.ico");
            bounds = new Rectangle(LocalPoint, icon.Size);
        }
    }

    /// <summary>
    /// 6�����̽ڵ�
    /// </summary>
    public class SubFlowTask : BaseComponent
    {
        public SubFlowTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmSubWorkFlowNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "�����̽ڵ�" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 6;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\�����̽ڵ�.ico");
            bounds = new Rectangle(LocalPoint, icon.Size);
        }
    }

    /// <summary>
    /// 6�Զ��ӵ�
    /// </summary>
    public class AutoTask : BaseComponent
    {
        public AutoTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmSubWorkFlowNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "�Զ��ڵ�" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 6;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\������.ico");
            bounds = new Rectangle(LocalPoint, icon.Size);
        }
    }

    ///// <summary>
    ///// 7���ƽڵ�
    ///// </summary>
    //public class ControlTask: BaseComponent
    //{
    //    public ControlTask(Point localPoint,int orderId)
    //    {
    //        DllClassName="RDIFramework.WorkFlow.fmTaskControl";
    //        LocalPoint=localPoint;
    //        X=LocalPoint.X;
    //        Y=LocalPoint.Y;
    //        TaskName="���ƽڵ�"+orderId.ToString(CultureInfo.InvariantCulture);
    //        TaskType=7;
    //        icon = new Icon(Application.StartupPath+@"\Resource\WFImage\���ƽڵ�.ico");
    //        bounds=new Rectangle(LocalPoint,icon.Size);
    //    }		
    //}

    /// <summary>
    /// 5�鿴�ڵ�
    /// </summary>
    public class ViewTask : BaseComponent
    {
        public ViewTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmViewTaskNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "�鿴�ڵ�" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 5;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\�鿴�ڵ�.ico");
            bounds = new Rectangle(localPoint, icon.Size);
        }

    }

    /// <summary>
    /// 2��ֹ�ڵ�
    /// </summary>
    public class EndTask : BaseComponent
    {
        public EndTask(Point localPoint, int orderId)
        {
            DllClassName = "RDIFramework.WorkFlow.FrmStartNode";
            LocalPoint = localPoint;
            X = LocalPoint.X;
            Y = LocalPoint.Y;
            TaskName = "�����ڵ�" + orderId.ToString(CultureInfo.InvariantCulture);
            TaskType = 2;
            icon = new Icon(Application.StartupPath + @"\Resource\WFImage\��ֹ�ڵ�.ico");
            bounds = new Rectangle(localPoint, icon.Size);
        }
    }
}

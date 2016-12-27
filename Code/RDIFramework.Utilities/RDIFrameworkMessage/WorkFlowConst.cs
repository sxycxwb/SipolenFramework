using System;
using System.Collections.Generic;
using System.Text;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// ͨ�ù�������Ϣ���ƻ���
    /// 
    /// �޸ļ�¼
    ///		2014.06.05 XuWangBin 2.8 ����WorkFlowConst.cs��
    ///	
    /// �汾��2.8
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2014.06.05</date>
    /// </author> 
    /// </summary>
    public class WorkFlowConst
    {

        //�����洢����
        public const string Access_WorkFlow = "1";//���̱���
        public const string Access_WorkTask = "2";//�������

        //        
        public const string SYS_VarFlag       = "System_";//ϵͳ������ ��ʶ��
        public const string SYSVarType_int    = "int";
        public const string SYSVarType_float  = "float";
        public const string SYSVarType_double = "double";
        public const string SYSVarType_string = "string";
        public const string SYSVarType_bool   = "bool";

        //��Ϣ
        public const string SuccessMsg                = "�����ѳɹ�ִ��";
        public const string StartWorkflowInstance     = "��������:{0}��";
        public const string NoFoundOperatorMsg        = "����������ʵ������,����û���ҵ�������,�����Ƿ����ô����ߡ�TaskId={0}";
        public const string NoFoundTaskMsg            = "����next����ʵ��ʱ,δ�ҵ�workTaskId={0} commandName={1},�ĺ�������ڵ㡣";
        public const string WorkflowOverMsg           = "������������";
        public const string ExpressErrorMsg           = "�жϱ��ʽ�Ƿ�ͨ������,condition={0},error={1}";
        public const string CreateNextTaskInstanceMsg = "����next����ʵ��NowWorkTaskId={0} commandName={1}";
        public const string NextTaskCountMsg          = "��Ҫ�ж�n={0}������ڵ��Ƿ����������";
        public const string CreateSubWorkflowInsMsg   = "Create������ʵ���ۼ���";
        public const string CallingSubWorkflowInsMsg  = "Calling ������ʵ����";
        public const string IntoSubWorkflowInsMsg     = "Into �����̡�";
        public const string ExitSubWorkflowMsg        = "Quit ������,���½��������̡�";
        public const string RunAlterTaskMsg           = "Run �����ڵ�,������operRule == {0}��";
        public const string CreateAlterTaskInsMsg     = "Create �����ڵ��ʵ��,EndTaskId={0}";
        public const string ChenkingCtrlTaskMsg       = "Checking ���ƽڵ�taskId={0},�Ƿ�ͨ����";
        public const string ChenkedCtrlTaskMsg        = "Checkedÿ��ʵ�������м��������StartTaskId:{0},allPass={1}";
        public const string ResultCtrlTaskMsg         = "isPass�жϽڵ��Ƿ�ͨ��:allPass={0}�ڵ�����:{1}";
        public const string RunViewTaskMsg            = "Run �鿴�ڵ�,������operRule == {0}��";
        public const string CreateViewTaskInsMsg      = "Create �鿴�ڵ��ʵ��,EndTaskId={0}";
        public const string EngineErrorMsg            = "����ִ�����̴���:{0}";
        public const string WriteLineMsg              = "-----------------";
        public const string TaskBackMsg               = "�˻����ύ��!";//�˴���洢���̶�ӦWorkTaskSubmitBackPro
        public const int TaskMaxCount = 9999;//���ɽ�������ĸ���

        //�������
        public const string SuccessCode              = "000000";//�����ɹ�
        public const string OtherErrorCode           = "111111";//��������
        public const string ExpressErrorCode         = "100000";//���ʽ�жϴ���
        public const string InstanceIsCompletedCode  = "100001";//����ʵ�������
        public const string TaskAssignErrorCode      = "100002";//����ָ�ɴ���
        public const string TaskClaimErrorCode       = "100003";//�����������
        public const string TaskUnClaimErrorCode     = "100004";//���������������
        public const string TaskBackErrorCode        = "100005";//�����˻ش���
        public const string TaskAccreditErrorCode    = "100006";//������Ȩ����
        public const string WorkFlowSuspendErrorCode = "100007";//���̹������
        public const string WorkFlowResumeErrorCode  = "100008";//����ȡ��������� 
        public const string WorkFlowAbnormalErrorCode= "100009";//�����쳣�������� 
        public const string NoFoundOperatorCode      = "000001";//û�����ô�����
        public const string NoFoundTaskCode          = "000002";//û�����ú�������
        public const string NoFoundInstanceCode      = "000003";//û���ҵ�ʵ��
        public const string IsNullUserIdCode         = "200000";//�û�IdΪ��
        public const string IsNullWorkFlowIdCode     = "200001";//����IdΪ��
        public const string IsNullWorkTaskIdCode     = "200002";//����IdΪ��
        public const string IsNullCommandNameCode    = "200003";//����Ϊ��
        public const string IsNullWorkflowInsCaption = "200004";//����ʵ������Ϊ��
        public const string IsNullWorkFlowNoCode     = "200005";//����ʵ�����Ϊ��
        public const string IsNullOperatorInsIdCode  = "200006";//���̴�����IdΪ��
        public const string IsNullWorkFlowInsIdCode  = "200007";//����ʵ��IdΪ��
        public const string IsNullWorkTaskInsIdCode  = "200008";//����ʵ��IdΪ��
        public const string IsNullUser               = "200009";//�û�Ϊ��
    }
}

using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// WorkFlowUserControlService
    /// 工作流程用户表单基础核心服务
    /// 
    /// 修改记录
    ///     
    ///     
    ///		2014-06-10 版本：2.8 XuWangBin 建立。
    ///		
    /// 版本：2.8
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2014-06-10</date>
    /// </author> 
    /// </summary>
    /// <remarks>
    /// 包括了以下流程模版服务实现的合集：
    ///     1、MainUserControl：主表单管理接口实现
    ///     2、UserControls：子表单管理接口实现
    /// </remarks>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public partial class WorkFlowUserControlService : System.MarshalByRefObject, IWorkFlowUserControlService
    {
        private readonly string serviceName = RDIFrameworkMessage.WorkFlowUserControlService;
    }
}

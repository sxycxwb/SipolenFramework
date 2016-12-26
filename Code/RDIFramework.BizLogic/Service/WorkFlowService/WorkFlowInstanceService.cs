using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// WorkFlowInstanceService
    /// 工作流程实例核心服务
    /// 
    /// 修改记录
    ///     
    ///     
    ///		2014-06-10 版本：2.8 EricHu 建立。
    ///		
    /// 版本：2.8
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2014-06-10</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public partial class WorkFlowInstanceService : System.MarshalByRefObject, IWorkFlowInstanceService
    {
        private readonly string serviceName = RDIFrameworkMessage.WorkFlowInstanceService;
    }
}

using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// IWorkFlowTemplateService
    /// 流程模版服务接口
    /// 
    /// 
    /// 修改记录
    ///     
    ///     
    ///		2014-06-12 版本：2.8 XuWangBin 建立。
    ///		
    /// 版本：2.8
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2014-06-12</date>
    /// </author> 
    /// </summary>
    /// <remarks>
    /// 包括了以下模版接口定义的合集：
    ///     1、WorkFlowClass：流程分类管理
    ///     2、WorkFlowTemplate：流程模版管理
    ///     3、WorkLink：流程连线配置管理
    ///     4、WorkTask：流程任务管理
    ///     5、WorkTaskCommands：工作任务命令管理
    ///     6、WorkFlowEvent：事件通知管理
    ///     7、WorkOutTime：超时设置管理
    ///     8、TaskVar：任务变量管理
    ///     9、Operator：处理者管理
    ///     10、SubWorkFlow：子流程节点配置管理
    /// 
    /// 
    /// </remarks>
    [ServiceContract]
    public partial interface IWorkFlowTemplateService
    {
        
    }
}

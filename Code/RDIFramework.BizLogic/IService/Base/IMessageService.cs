using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IMessageService
    /// 消息服务接口
    /// 
    /// 修改记录
    /// 
    ///     2016-01-03 版本：3.0 增加SetDeleted接口方法。
    ///		2014-02-27 版本：2.8 EricHu 建立。
    ///		
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2014-02-27</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IMessageService
    {
        /// <summary>
        /// 获得内部部门（公司的组织机构）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetInnerOrganizeDT(UserInfo userInfo);

        /// <summary>
        /// 按组织机构获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">部门主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserDTByOrganize(UserInfo userInfo, string organizeId);

        /// <summary>
        /// 按角色获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserDTByRole(UserInfo userInfo, string roleId);

        /// <summary>
        /// 发送即时消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverId">接收者主键</param>
        /// <param name="contents">内容</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Send(UserInfo userInfo, string receiverId, string contents);

        /// <summary>
        /// 发送组消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="contents">内容</param>
        /// <returns></returns>
        [OperationContract]
        string SendGroupMessage(UserInfo userInfo, string organizeId, string roleId, string contents);

        /// <summary>
        /// 发送系统提示消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverId">接收者主键</param>
        /// <param name="contents">内容</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Remind(UserInfo userInfo, string receiverId, string contents);

        /// <summary>
        /// 批量发送即时消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverIds">接收者主键组</param>
        /// <param name="organizeIds">组织机构主键组</param>
        /// <param name="roleIds">角色主键组</param>
        /// <param name="messageEntity">消息实体</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSend(UserInfo userInfo, string[] receiverIds, string[] organizeIds, string[] roleIds, CiMessageEntity messageEntity);

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="message">消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Broadcast(UserInfo userInfo, string message);

        /// <summary>
        /// 获取消息状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="onLineState">用户在线状态</param>
        /// <param name="lastChekTime">最后检查时间</param>
        /// <returns>消息状态数组</returns>
        [OperationContract]
        string[] MessageChek(UserInfo userInfo, int onLineState, string lastChekTime);

        /// <summary>
        /// 获取用户的新信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="openId">单点登录标识</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTNew(UserInfo userInfo, out string openId);

        /// <summary>
        /// 获取特定用户的新信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverId">当前交互的用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable ReadFromReceiver(UserInfo userInfo, string receiverId);

        /// <summary>
        /// 阅读短信
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        [OperationContract]
        void Read(UserInfo userInfo, string id);

        /// <summary>
        /// 检查在线状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="onLineState">用户在线状态</param>
        /// <returns>离线人数</returns>
        [OperationContract]
        int CheckOnLine(UserInfo userInfo, int onLineState);

        /// <summary>
        /// 获取在线用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetOnLineState(UserInfo userInfo);

        /// <summary>
        /// 得到指定用户已发送的消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">指定用户主键</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserSentMessagesByPage(UserInfo userInfo, string userId, string whereConditional, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null);

        /// <summary>
        /// 得到指定用户收到的消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">指定用户主键</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserReceivedMessagesByPage(UserInfo userInfo, string userId, string whereConditional, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null);

        /// <summary>
        /// 通过指定条件得到消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="whereConditional">指定条件表达式</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        [OperationContract]        
        DataTable GetMessagesByConditional(UserInfo userInfo, string whereConditional, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null);


        ///<summary>
        ///  批量逻辑删除消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]   
        int SetDeleted(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 取得实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        CiMessageEntity GetEntity(UserInfo userInfo, string id);
    }
}
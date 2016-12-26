
namespace RDIFramework.BizLogic
{
    /// <summary>
    /// 处理者参数
    /// </summary>
    public class OperParameter
    {
        /// <summary>
        /// 处理者id，根据流程模板生成的处理者实例
        /// </summary>
        public string OperContent { get; set; }

        /// <summary>
        /// 处理者的名称
        /// </summary>
        /// <remarks>
        /// 名字，部门或者角色名称，与OperContent对应。
        /// </remarks>
        public string OperContenText { get; set; }

        /// <summary>
        /// 处理者关系，从流程模版中原样复制
        /// </summary>
        public int OperRelation { get; set; }

        /// <summary>
        /// 处理者策略：
        /// </summary>
        /// <remarks>
        /// 1、所有用户共享任务
        /// 2、所有用户处理任务
        /// </remarks>
        public string OperRule { get; set; }

        /// <summary>
        /// 处理者类型
        /// </summary>
        public int OperType { get; set; }

        /// <summary>
        /// 处理者是提交人时是否跳过本处理
        /// </summary>
        public bool IsJumpSelf { get; set; }
    }
}

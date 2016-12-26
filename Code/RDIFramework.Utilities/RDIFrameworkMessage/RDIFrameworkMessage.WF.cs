
namespace RDIFramework.Utilities
{
    public partial class RDIFrameworkMessage
    {
        public static string WFDefineService = "工作流定义服务";
        public static string WFDefineService_GetWFDefineEntity = "得到工作流定义实体";
        public static string WFDefineService_GetWFDefineDT = "获取工作流定义列表";
        public static string WFDefineService_GetWFDefineByCategory = "根据工作流分类得到工作流定义数据";
        public static string WFDefineService_GetWFDefineByUserId = "得到指定用户可以访问的工作流程";
        public static string WFDefineService_GetWFDefineDTByIds = "根据主键数组获取工作流定义数据";
        public static string WFDefineService_GetWFDefineDTByValues = "根据条件获取工作流定义数据";
        public static string WFDefineService_GetWFDefineDTByPage = "分页获取工作流定义列表";
        public static string WFDefineService_AddWFDefine = "新增工作流定义";
        public static string WFDefineService_AddWFCategory = "新增工作流分类";
        public static string WFDefineService_UpdateWFCategory = "更新工作流分类";
        public static string WFDefineService_UpdateWFCategoryByValues = "根据条件更新工作流分类数据";
        public static string WFDefineService_UpdateWFDefine = "更新工作流定义";
        public static string WFDefineService_UpdateWFDefineByValues = "根据条件更新工作流定义";
        public static string WFDefineService_DeleteWFDefine = "删除指定工作流定义数据";
        public static string WFDefineService_BatchDeleteWFDefine = "批量删除指定工作流定义数据";
        public static string WFDefineService_SetWFDefineDeleted = "批量设置工作流定义删除标志";
        public static string WFDefineService_ReleaseWF = "工作流定义发布否";
        public static string WFDefineService_SetWFCategoryDeleted = "批量设置工作流分类删除标志";
        public static string WFDefineService_GetWFCategoryDT = "获取工作流分类列表";
        public static string WFDefineService_GetWFCategoryEntity = "得到工作流分类实体";
        public static string WFDefineService_MoveToWFCategory = "移动工作流分类";

        public static string WFInstanceService = "工作流实例服务";
        public static string WFInstanceService_GetWFInstanceDT = "获取工作流实例列表";
        public static string WFInstanceService_GetWFInstanceEntity = "获取工作流实例实体";
        public static string WFInstanceService_GetWFInstanceDTByIds = "根据主键数组获取工作流实例数据";
        public static string WFInstanceService_GetWFApplyByUserId = "得到指定用户提交的工作流申请列表";
        public static string WFInstanceService_GetToDoListByUserId = "得到指定用户的待办列表";
        public static string WFInstanceService_GetWFInstanceDTByValues = "根据条件获取工作流实例数据 ";
        public static string WFInstanceService_GetWFInstanceDTByPage = "分页获取工作流实例列表";
        public static string WFInstanceService_StartWFInstance = "启动工作流";
        public static string WFInstanceService_UpdateWFInstance = "更新工作流实例";
        public static string WFInstanceService_DeleteWFInstance = "删除指定工作流实例数据";
        public static string WFInstanceService_BatchDeleteWFInstance = "批量删除工作流实例数据";
        public static string WFInstanceService_SetWFInstanceDeleted = "批量设置工作流实例删除标志";

        public static string WFNodeService = "工作流节点服务";
        public static string WFNodeService_GetWFNodeEntity = "得到工作流节点实体";
        public static string WFNodeService_GetWFNodeDT = "获取工作流节点列表";
        public static string WFNodeService_GetNextNodeById = "得到指定节点主键的下一节点";
        public static string WFNodeService_GetWFNodeDTByIds = "根据主键数组获取工作流节点数据";
        public static string WFNodeService_GetWFNodeDTByValues = "根据条件获取工作流节点数据";
        public static string WFNodeService_GetWFNodeDTByWFDefineId = "得到指定工作流定义包含的节点";
        public static string WFNodeService_AddWFNode = "新增工作流节点";
        public static string WFNodeService_UpdateWFNode = "更新工作流节点";
        public static string WFNodeService_DeleteWFNode = "删除指定工作流节点数据";
        public static string WFNodeService_BatchDeleteWFNode = "批量删除工作流节点数据";
        public static string WFNodeService_SetWFNodeDeleted = "批量设置工作流节点删除标志";

        public static string WFNodeInstanceService = "工作流节点实例服务";
        public static string WFNodeInstanceService_GetWFNodeInstanceEntity = "得到工作流节点实例实体";
        public static string WFNodeInstanceService_GetWFNodeInstanceDT = "获取工作流节点实例列表";
        public static string WFNodeInstanceService_GetWFNodeInstanceDTByIds = "根据主键数组获取工作流节点实例数据";
        public static string WFNodeInstanceService_GetWFNodeInstanceDTByValues = "根据条件获取工作流节点实例数据";
        public static string WFNodeInstanceService_AddWFNodeInstance = "新增工作流节点实例";
        public static string WFNodeInstanceService_UpdateWFNodeInstance = "更新工作流节点实例";
        public static string WFNodeInstanceService_DeleteWFNodeInstance = "删除指定工作流节点实例数据";
        public static string WFNodeInstanceService_BatchDeleteWFNodeInstance = "批量删除工作流节点实例数据";
        public static string WFNodeInstanceService_SetWFNodeInstanceDeleted = "批量设置工作流节点实例删除标志";


        public static string WFFormManagerService = "工作流表单管理服务";
        public static string WFFormManagerService_GetWFFormEntity = "得到工作流表单实体";
        public static string WFFormManagerService_GetWFFormDT = "获取工作流表单列表";
        public static string WFFormManagerService_GetWFFormDTByPage = "分页获取工作流表单列表";
        public static string WFFormManagerService_GetWFFormDTByIds = "根据主键数组获取工作流表单数据";
        public static string WFFormManagerService_GetWFFormDTByValues = "根据条件获取工作流表单数据";
        public static string WFFormManagerService_GetDTByFormType = "通过表单分类得到工作流表单列表";
        public static string WFFormManagerService_AddWFForm = "新增工作流表单";
        public static string WFFormManagerService_UpdateWFForm = "更新工作流表单";
        public static string WFFormManagerService_DeleteWFForm = "删除指定工作流表单数据";
        public static string WFFormManagerService_BatchDeleteWFForm = "批量删除工作流表单数据";
        public static string WFFormManagerService_SetWFFormDeleted = "批量设置工作流表单删除标志";

        public static string WFFormManagerService_GetWFFormTypeEntity = "得到工作流表单类型实体";
        public static string WFFormManagerService_GetWFFormTypeDT = "获取工作流表单类型列表";
        public static string WFFormManagerService_GetWFFormTypeDTByIds = "根据主键数组获取工作流表单类型数据";
        public static string WFFormManagerService_GetWFFormTypeDTByValues = "根据条件获取工作流表单类型数据";
        public static string WFFormManagerService_AddWFFormType = "新增工作流表单类型";
        public static string WFFormManagerService_UpdateWFFormType = "更新工作流表单类型";
        public static string WFFormManagerService_DeleteWFFormType = "删除指定工作流表单类型数据";
        public static string WFFormManagerService_BatchDeleteWFFormType = "批量删除工作流表单类型数据";
        public static string WFFormManagerService_SetWFFormTypeDeleted = "批量设置工作流表单类型删除标志";
        public static string WFFormManagerService_MoveToWFFormType = "移动表单分类";

        public static string WFFormManagerService_GetWFFormNodeEntity = "得到工作流表单节点实体";
        public static string WFFormManagerService_GetWFFormNodeDT = "获取工作流表单节点列表";
        public static string WFFormManagerService_GetWFFormNodeDTByIds = "根据主键数组获取工作流表单节点数据";
        public static string WFFormManagerService_GetWFFormNodeDTByValues = "根据条件获取工作流表单节点数据";
        public static string WFFormManagerService_AddWFFormNode = "新增工作流表单节点";
        public static string WFFormManagerService_UpdateWFFormNode = "更新工作流表单节点";
        public static string WFFormManagerService_DeleteWFFormNode = "删除指定工作流表单节点数据";
        public static string WFFormManagerService_BatchDeleteWFFormNode = "批量删除工作流表单节点数据";
        public static string WFFormManagerService_AddFormToWFNode = "增加表单到指定工作流节点定义中";
        public static string WFFormManagerService_RemoveFormFromWFNode = "删除指定工作流节点定义中的表单列表";
    }
}

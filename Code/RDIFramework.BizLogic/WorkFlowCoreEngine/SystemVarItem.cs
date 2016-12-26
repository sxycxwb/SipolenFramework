using System.Collections.Generic;
using System.Linq;
using RDIFramework.Utilities;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// 工作流系统默认变量
    /// </summary>
    public class SystemVarItem
    {
        public string VarName = "";
        public string VarType = "";
    }


    public class SystemVarData
    {
        public List<SystemVarItem> SystemVarItems;
        /// <summary>
        /// 流程运行次数
        /// </summary>
        public const string Sys_FlowRunTime = "System_WorkFlowRunTimes";

        /// <summary>
        /// 任务运行次数
        /// </summary>
        public const string Sys_TaskRunTime = "System_TaskRunTimes";

        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemVarData()
        {
            SystemVarItems = new List<SystemVarItem>();
            var var = new SystemVarItem { VarName = Sys_FlowRunTime, VarType = WorkFlowConst.SYSVarType_int };
            SystemVarItems.Add(var);
            var = new SystemVarItem { VarName = Sys_TaskRunTime, VarType = WorkFlowConst.SYSVarType_int };
            SystemVarItems.Add(var);
        }

        public static SystemVarData GetSystemVarData()
        {
            return new SystemVarData();
        }

        public static List<SystemVarItem> GetSystemVarItems()
        {
            var varData = SystemVarData.GetSystemVarData();
            return varData.SystemVarItems;
        }

        /// <summary>
        /// 判断是否为系统变量
        /// </summary>
        /// <param name="varName">变量名,不带变量两端的修饰符。</param>
        /// <returns>返回true或者false</returns>
        public static bool IsSystemVar(string varName)
        {
            var varflag = varName;
            if (varflag.Length < 7) return false;

            varflag = varName.Substring(0, 7);
            return varflag == WorkFlowConst.SYS_VarFlag;
        }

        private SystemVarItem GetSystemVarItem(string varName)
        {
            return SystemVarItems.FirstOrDefault(var => var.VarName == varName);
        }

        public string GetSysVarValue(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string workTaskInstanceId, string varName)
        {
            var result = "";
            var tmpVarName = "";
            tmpVarName = varName.Substring(2, varName.Length - 7);//去掉两头的<%%>
            var var = GetSystemVarItem(varName);
            switch (tmpVarName)
            {
                case Sys_FlowRunTime:
                    {
                        break;
                    }
                case Sys_TaskRunTime:
                    {
                        break;
                    }
                default:
                    {
                        result = "System_NULL";
                        break;
                    }
            }
            if (var.VarType == WorkFlowConst.SYSVarType_string) result = "'" + result + "'";
            if (string.IsNullOrEmpty(result)) result = "'" + result + "'";
            return result;
        }
    }
}

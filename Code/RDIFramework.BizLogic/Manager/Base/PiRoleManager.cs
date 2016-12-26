//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , gt TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
  
    public partial class PiRoleManager : DbCommonManager, IDbCommonManager
    {
        #region public string Add(PiRoleEntity entity, out string statusCode) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string Add(PiRoleEntity entity, out string statusCode)
        {
            string result = string.Empty;
            // 检查名称是否重复
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiRoleTable.FieldRealName, entity.RealName),
                new KeyValuePair<string, object>(PiRoleTable.FieldDeleteMark, 0)
            };
            if (!string.IsNullOrEmpty(entity.OrganizeId)) //针对岗位的检查
            {
                parameters.Add(new KeyValuePair<string, object>(PiRoleTable.FieldOrganizeId, entity.OrganizeId));
            }
            if (this.Exists(parameters))
            {
                // 名称是否重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                result = this.Add(entity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return result;
        }
        #endregion

        #region public int UpdateEntity(PiRoleEntity entity, out string statusCode) 更新实体
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">状态码</param>
        public int UpdateEntity(PiRoleEntity entity, out string statusCode)
        {
            int returnValue = 0;
            // 检查名称是否重复
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiRoleTable.FieldOrganizeId, entity.OrganizeId),
                new KeyValuePair<string, object>(PiRoleTable.FieldRealName, entity.RealName),
                new KeyValuePair<string, object>(PiRoleTable.FieldDeleteMark, 0)
            };
            if (this.Exists(parameters, entity.Id))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.Update(entity);
                statusCode = returnValue == 1 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public int Delete(string id) 删除实体
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            int returnValue = 0;
            // 删除用户角色表
            returnValue += DbCommonLibary.Delete(DBProvider, PiUserRoleTable.TableName, PiUserRoleTable.FieldRoleId, id);
            // 删除角色表
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiRoleTable.FieldId, id),
                new KeyValuePair<string, object>(PiRoleTable.FieldAllowDelete, 1)
            };
            returnValue += DbCommonLibary.Delete(DBProvider, PiRoleTable.TableName, parameters);
            
            return returnValue;
        }
        #endregion

        #region public int BatchDelete(string id) 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(string[] ids)
        {
            return ids.Sum(t => this.Delete(t));
        }

        #endregion

        #region public int BatchSave(List<BaseRoleEntity> roleEntites) 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="roleEntites">角色实体</param>
        /// <returns>影响行数</returns>
        public int BatchSave(List<PiRoleEntity> roleEntites)
        {
            return roleEntites.Sum(roleEntity => this.UpdateEntity(roleEntity));
        }

        #endregion

        #region public DataTable GetDataTableByOrganize(string organizeId) 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByOrganize(string organizeId)
        {
            var parametersList = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiRoleTable.FieldOrganizeId, organizeId),
                new KeyValuePair<string, object>(PiRoleTable.FieldDeleteMark, 0)
            };
            return this.GetDT(parametersList, PiRoleTable.FieldSortCode);
        }
        #endregion

        #region public int ResetSortCode(string organizeId) 重置排序码
        /// <summary>
        /// 重置排序码
        /// </summary>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>大于0成功</returns>
        public int ResetSortCode(string organizeId)
        {
            int result = 0;
            var dt = this.GetDT();
            string id = string.Empty;
            var sequenceManager = new CiSequenceManager(DBProvider);
            string[] sortCode = sequenceManager.GetBatchSequence(PiRoleTable.TableName, dt.Rows.Count);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                id = dr[PiRoleTable.FieldId].ToString();
                result += this.SetProperty(id, PiRoleTable.FieldSortCode, sortCode[i]);
                i++;
            }
            return result;
        }
        #endregion

        #region public int MoveTo(string id, string targetOrganizeId) 移动
        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="targetOrganizeId">目标组织机构主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(string id, string targetOrganizeId)
        {
            return this.SetProperty(id, PiRoleTable.FieldOrganizeId, targetOrganizeId);
        }
        #endregion
    }
}

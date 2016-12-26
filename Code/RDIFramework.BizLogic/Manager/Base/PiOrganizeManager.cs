/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-3-30 13:00:39
 ******************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{

     /// <summary>
     /// PiOrganizeManager
     /// 组织机构、部门
     ///
     /// 修改纪录
    ///         2014-06-13 版本：2.8 EricHu 修改客户提出的：GetFullNameDepartment方法，访问多业务时扩展的不方便，不方便SOA的部署，解决了交叉依赖。
     ///        2013-05-12 版本：2.5 EricHu 修改客户提出的“Enabled”字段异常问题。
     ///		2012-03-02 版本：1.0 EricHu 创建主键。
     ///
     /// 版本：1.0
     ///
     /// <author>
     ///		<name>EricHu</name>
     ///		<date>2012-03-02</date>
     /// </author>
     /// </summary>
    public partial class PiOrganizeManager
    {
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            PiOrganizeEntity organizeEntity = new PiOrganizeEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[PiOrganizeTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        returnValue += this.DeleteEntity(id);
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[PiOrganizeTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        organizeEntity.GetFrom(dataRow);
                        returnValue += this.UpdateEntity(organizeEntity);
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    organizeEntity.GetFrom(dataRow);
                    returnValue += !string.IsNullOrEmpty(this.AddEntity(organizeEntity)) ? 1 : 0;
                }
                if (dataRow.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                if (dataRow.RowState == DataRowState.Detached)
                {
                    continue;
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="parentId">父级主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(string id, string parentId)
        {
            return this.SetProperty(id, PiOrganizeTable.FieldParentId, parentId);
        }

        public DataTable GetInnerOrganize(string organizeId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiOrganizeTable.FieldIsInnerOrganize, 1),
                new KeyValuePair<string, object>(PiOrganizeTable.FieldDeleteMark, 0)
            };
            return this.GetDT(parameters, PiOrganizeTable.FieldSortCode);
        }

        public DataTable GetCompanyDT(string organizeId)
        {
            return this.GetDT(new KeyValuePair<string, object>(PiOrganizeTable.FieldCategory, "Company"), PiOrganizeTable.FieldSortCode);
        }

        public DataTable GetCompanyDTByName(string organizeName)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiOrganizeTable.FieldCategory, "Company"),
                new KeyValuePair<string, object>(PiOrganizeTable.FieldFullName, organizeName),
                new KeyValuePair<string, object>(PiOrganizeTable.FieldDeleteMark, 0)
            };
            return this.GetDT(parameters, PiOrganizeTable.FieldSortCode);
        }

        public DataTable GetDepartmentDT(string organizeId = null)
        {
            if (String.IsNullOrEmpty(organizeId))
            {
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(PiOrganizeTable.FieldCategory, "Department"),
                    new KeyValuePair<string, object>(PiOrganizeTable.FieldEnabled, 1),
                    new KeyValuePair<string, object>(PiOrganizeTable.FieldDeleteMark, 0)
                };
                return this.GetDT(parameters, PiOrganizeTable.FieldSortCode);
            }
            return this.GetDT(new KeyValuePair<string, object>(PiOrganizeTable.FieldParentId, organizeId), new KeyValuePair<string, object>(PiOrganizeTable.FieldCategory, "Department"), PiOrganizeTable.FieldSortCode);
        }

        public DataTable GetFullNameDepartment(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                //PiOrganizeEntity subCompanyNameEntity = RDIFrameworkService.Instance.OrganizeService.GetEntity(UserInfo, dr[PiOrganizeTable.FieldParentId].ToString());
                //dr[PiOrganizeTable.FieldFullName] = subCompanyNameEntity.FullName.ToString() + "--" + dr[PiOrganizeTable.FieldFullName].ToString();
                //PiOrganizeEntity companyEntity = RDIFrameworkService.Instance.OrganizeService.GetEntity(UserInfo, subCompanyNameEntity.ParentId.ToString());
                //dr[PiOrganizeTable.FieldFullName] = companyEntity.FullName.ToString() + "--" + dr[PiOrganizeTable.FieldFullName].ToString();

                PiOrganizeEntity subCompanyNameEntity = GetEntity(dr[PiOrganizeTable.FieldParentId].ToString());
                dr[PiOrganizeTable.FieldFullName] = subCompanyNameEntity.FullName + "--" + dr[PiOrganizeTable.FieldFullName].ToString();
                PiOrganizeEntity companyEntity = GetEntity(subCompanyNameEntity.ParentId);
                dr[PiOrganizeTable.FieldFullName] = companyEntity.FullName + "--" + dr[PiOrganizeTable.FieldFullName].ToString();
            }
            return dataTable;
        }

        public DataTable GetDepartmentDTByName(string organizeName)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiOrganizeTable.FieldCategory, "Department"),
                new KeyValuePair<string, object>(PiOrganizeTable.FieldFullName, organizeName),
                new KeyValuePair<string, object>(PiOrganizeTable.FieldDeleteMark, 0)
            };
            return this.GetDT(parameters, PiOrganizeTable.FieldSortCode);
        }
    }
}

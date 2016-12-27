/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-18 10:41:47
 ******************************************************************************/

using System;
using System.Data;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
  
    /// <summary>
    /// PiStaffManager
    /// 员工（职员）表
    ///
    /// 修改纪录
    ///
    ///		2012-03-02 版本：1.0 XuWangBin 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author>
    /// </summary>
    public partial class PiStaffManager
    {
        #region public UserInfo ConvertToUserInfo(BaseStaffEntity staffEntity, UserInfo userInfo)
        /// <summary>
        /// 员工实体转换为用户实体
        /// </summary>
        /// <param name="staffEntity">员工实体</param>
        /// <param name="userInfo">用户实体</param>
        /// <returns>用户实体</returns>
        public UserInfo ConvertToUserInfo(PiStaffEntity staffEntity, UserInfo userInfo)
        {
            // userInfo.Id = staffEntity.Id;
            userInfo.StaffId = staffEntity.Id.ToString();
            userInfo.Code = staffEntity.Code;
            if (string.IsNullOrEmpty(userInfo.UserName))
            {
                userInfo.UserName = staffEntity.UserName;
            }
            if (string.IsNullOrEmpty(userInfo.RealName))
            {
                userInfo.RealName = staffEntity.RealName;
            }
            // 需要修正
            // userInfo.CompanyId = staffEntity.CompanyId;
            // userInfo.CompanyCode = staffEntity.CompanyCode;
            // userInfo.CompanyName = staffEntity.CompanyName;
            //userInfo.DepartmentId = staffEntity.DepartmentId;
            // userInfo.DepartmentCode = staffEntity.DepartmentCode;
            // userInfo.DepartmentName = staffEntity.DepartmentName;
            //userInfo.WorkgroupId = staffEntity.WorkgroupId;
            // userInfo.WorkgroupCode = staffEntity.WorkgroupCode;
            // userInfo.WorkgroupName = staffEntity.WorkgroupName;
            return userInfo;
        }
        #endregion

        #region public string Add(BaseStaffEntity staffEntity, out string statusCode)
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="staffEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string Add(PiStaffEntity staffEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            if (!string.IsNullOrEmpty(staffEntity.UserName) && this.Exists(PiStaffTable.FieldUserName, staffEntity.UserName, PiStaffTable.FieldDeleteMark, 0))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorUserExist.ToString();
            }
            else
            {
                // 检查编号是否重复
                if (!string.IsNullOrEmpty(staffEntity.Code) && this.Exists(PiStaffTable.FieldCode, staffEntity.Code, PiStaffTable.FieldDeleteMark, 0))
                {
                    // 编号已重复
                    statusCode = StatusCode.ErrorCodeExist.ToString();
                }
                else
                {
                    returnValue = this.AddEntity(staffEntity);
                    // 运行成功
                    statusCode = StatusCode.OKAdd.ToString();
                }
            }
            return returnValue;
        }
        #endregion

        #region public int Update(BaseStaffEntity staffEntity, out string statusCode)
        /// <summary>
        /// 更新员工
        /// </summary>
        /// <param name="staffEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public int Update(PiStaffEntity staffEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查编号是否重复
            if (!string.IsNullOrEmpty(staffEntity.Code) && this.Exists(PiStaffTable.FieldCode, staffEntity.Code, PiStaffTable.FieldDeleteMark, 0, staffEntity.Id))
            {
                // 编号已重复
                statusCode = StatusCode.ErrorCodeExist.ToString();
            }
            else
            {
                // 用户名是空的，不判断是否重复了
                if (!String.IsNullOrEmpty(staffEntity.RealName) && this.Exists(PiStaffTable.FieldRealName, staffEntity.RealName, PiStaffTable.FieldDeleteMark, 0, staffEntity.Id))
                {
                    // 名称已重复
                    statusCode = StatusCode.ErrorUserExist.ToString();
                }
                else
                {
                    returnValue = this.UpdateEntity(staffEntity);
                    // 按员工的修改信息，把用户信息进行修改
                    this.UpdateUser(staffEntity.Id.ToString());
                    statusCode = returnValue > 0 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
                }
            }
            return returnValue;            
        }
        #endregion

        #region public int UpdateAddress(BaseStaffEntity staffEntity, out string statusCode) 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="staffEntity">实体类</param>
        /// <returns>影响行数</returns>
        public int UpdateAddress(PiStaffEntity staffEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查是否已被其他人修改            
            //if (DbCommonLibary.IsModifed(DBProvider, PiStaffTable.TableName, staffEntity.Id, staffEntity.ModifiedUserId, staffEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}
            //else
            //{
                // 进行更新操作
                returnValue = this.UpdateEntity(staffEntity);
                if (returnValue == 1)
                {
                    // 按员工的修改信息，把用户信息进行修改
                    this.UpdateUser(staffEntity.Id.ToString());
                    statusCode = StatusCode.OKUpdate.ToString();
                }
                else
                {
                    // 数据可能被删除
                    statusCode = StatusCode.ErrorDeleted.ToString();
                }
            //}
            return returnValue;
        }
        #endregion

        #region public DataTable GetDTByOrganizes(string[] organizeIds) 按组织机构获取员工列表
        /// <summary>
        /// 按组织机构获取员工列表
        /// </summary>
        /// <param name="organizeIds">主键数组</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByOrganizes(string[] organizeIds)
        {
            string organizeList = BusinessLogic.ObjectsToList(organizeIds);
            /*
            string sqlQuery = " SELECT "
                + PiStaffTable.TableName + ".* ,"
                + PiUserTable.TableName + ".UserOnLine "
                + " FROM " + PiStaffTable.TableName + " LEFT OUTER JOIN " + PiUserTable.TableName
                + "       ON " + PiStaffTable.TableName + "." + PiStaffTable.FieldUserId + " = " + PiUserTable.TableName + "." + PiUserTable.FieldId
                + " WHERE (" + PiStaffTable.TableName + "." + PiStaffTable.FieldDeleteMark + " = 0 ) "
                + "       AND (" + PiStaffTable.TableName + "." + PiStaffTable.FieldWorkgroupId + " IN ( " + organizeList + ") "
                + "       OR " + PiStaffTable.TableName + "." + PiStaffTable.FieldDepartmentId + " IN (" + organizeList + ") "
                + "       OR " + PiStaffTable.TableName + "." + PiStaffTable.FieldCompanyId + " IN (" + organizeList + ")) "
                + " ORDER BY " + PiStaffTable.TableName + "." + PiStaffTable.FieldSortCode;
             */

            /*
                SELECT  PiStaff.*
                FROM    PiStaff
                WHERE   Id IN ( SELECT  StaffId
                                FROM    PiStaffOrganize
                                WHERE   OrganizeId IN ( '1' ) )
                        AND DeleteMark = 0
                        AND Enabled = 1
                        AND IsDimission = 0
                ORDER BY PiStaff.SortCode
             */

            string sqlQuery = " SELECT "
                + PiStaffTable.TableName + ".* FROM " + PiStaffTable.TableName
                + " WHERE " + PiStaffTable.FieldId  + " IN ( SELECT "
                + PiStaffOrganizeTable.FieldStaffId + " FROM " 
                + PiStaffOrganizeTable.TableName + " WHERE "
                + PiStaffOrganizeTable.FieldOrganizeId + " IN ( " + organizeList + ")) "
                + " AND " + PiStaffTable.FieldDeleteMark + " = 0 " 
               // + " AND " + PiStaffTable.FieldEnabled + " = 1 "
               // + " AND " + PiStaffTable.FieldIsDimission + " = 0 "
                + " ORDER BY " + PiStaffTable.TableName + "." + PiStaffTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        #region public DataTable GetDTByOrganize(string organizeId)
        /// <summary>
        /// 获取部门员工
        /// </summary>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByOrganize(string organizeId)
        {
            string[] organizeIds = new string[] { organizeId };
            return this.GetDTByOrganizes(organizeIds);
        }
        #endregion              	       

        /// <summary>
        /// 得到未设置组织机构的员工列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetStaffDTNotOrganzie()
        {
            string sqlQuery = @"SELECT * FROM " + PiStaffTable.TableName +
                              @" WHERE " + PiStaffTable.FieldDeleteMark + " = 0 " +
                              @" AND ID NOT IN(SELECT STAFFID FROM PISTAFFORGANIZE WHERE DELETEMARK =0 AND ENABLED = 1)
                                ORDER BY SORTCODE";
            return DBProvider.Fill(sqlQuery);
        }

        public DataTable GetChildrenStaffs(string organizeId)
        {
            PiOrganizeManager organizeManager = new PiOrganizeManager(this.DBProvider, this.UserInfo);
            string[] organizeIds = null;
            switch (DBProvider.CurrentDbType)
            {
                case CurrentDbType.Access:
                case CurrentDbType.SqlServer:                    
                    string organizeCode = DbCommonLibary.GetProperty(dbProvider, PiOrganizeTable.TableName, PiOrganizeTable.FieldId, organizeId, PiOrganizeTable.FieldCode);//this.GetCodeById(organizeId);
                    organizeIds = organizeManager.GetChildrensIdByCode(PiOrganizeTable.FieldCode, organizeCode);
                    break;
                case CurrentDbType.Oracle:
                    organizeIds = organizeManager.GetChildrensId(PiOrganizeTable.FieldId, organizeId, PiOrganizeTable.FieldParentId);
                    break;
                case CurrentDbType.MySql:
                    organizeIds = organizeManager.GetMySqlChildrensId(PiOrganizeTable.FieldId, organizeId, PiOrganizeTable.FieldParentId);
                    break;
            }
            return this.GetDTByOrganizes(organizeIds);
        }

        public DataTable GetParentChildrenStaffs(string organizeId)
        {
            string[] organizeIds = null;
            PiOrganizeManager organizeManager = new PiOrganizeManager(this.DBProvider, this.UserInfo);
            string organizeCode = organizeManager.GetCodeById(organizeId);
            organizeIds = organizeManager.GetChildrensIdByCode(PiOrganizeTable.FieldCode, organizeCode);
            return this.GetDTByOrganizes(organizeIds);
        }

        #region public override DataTable GetDT()
        /// <summary>
        /// 获取员工列表
        /// </summary>
        /// <returns>数据表</returns>
        public override DataTable GetDT()
        {
            /*string sqlQuery = " SELECT " + PiStaffTable.TableName + ".* "
                + " , " + PiUserTable.TableName + ".UserOnLine"
                + " ,(SELECT " + PiOrganizeTable.FieldCode + " FROM " + PiOrganizeTable.TableName + " WHERE Id = " + PiStaffTable.TableName + ".CompanyId) AS CompanyCode"
                + " ,(SELECT " + PiOrganizeTable.FieldFullName + " FROM " + PiOrganizeTable.TableName + " WHERE Id = " + PiStaffTable.TableName + ".CompanyId) AS CompanyFullname "

                + " ,(SELECT " + PiOrganizeTable.FieldCode + " From " + PiOrganizeTable.TableName + " WHERE Id = " + PiStaffTable.TableName + ".DepartmentId) AS DepartmentCode"
                + " ,(SELECT " + PiOrganizeTable.FieldFullName + " FROM " + PiOrganizeTable.TableName + " WHERE Id = " + PiStaffTable.TableName + ".DepartmentId) AS DepartmentName "

                + " ,(SELECT " + PiOrganizeTable.FieldCode + " From " + PiOrganizeTable.TableName + " WHERE Id = " + PiStaffTable.TableName + ".WorkgroupId) AS WorkgroupCode"
                + " ,(SELECT " + PiOrganizeTable.FieldFullName + " FROM " + PiOrganizeTable.TableName + " WHERE Id = " + PiStaffTable.TableName + ".WorkgroupId) AS WorkgroupName "

                + " ,(SELECT " + CiItemDetailsTable.FieldItemName + " FROM Items_Duty WHERE Id = " + PiStaffTable.TableName + ".DutyId) AS DutyName "

                + " ,(SELECT " + CiItemDetailsTable.FieldItemName + " FROM Items_Title WHERE Id = " + PiStaffTable.TableName + ".TitleId) AS TitleName "

                + " ,(SELECT " + PiRoleTable.FieldRealName + " FROM " + PiRoleTable.TableName + " WHERE Id = RoleId) AS RoleName "
                // + " ,(SELECT COUNT(*) FROM " + PiUserRoleTable.TableName + " WHERE " + PiUserRoleTable.TableName + ".StaffID = " + PiStaffTable.TableName + ".Id) AS RoleCount "
                + " FROM (" + PiStaffTable.TableName + " LEFT OUTER JOIN " + PiUserTable.TableName
                + " ON " + PiStaffTable.TableName + "." + PiStaffTable.FieldId + " = " + PiUserTable.TableName + "." + PiUserTable.FieldId + ") "
                + "  LEFT OUTER JOIN " + PiOrganizeTable.TableName + " "
                + " ON " + PiStaffTable.TableName + "." + PiStaffTable.FieldDepartmentId + " = " + PiOrganizeTable.TableName + "." + PiOrganizeTable.FieldId
                + " ORDER BY " + PiOrganizeTable.TableName + "." + PiOrganizeTable.FieldSortCode
                + " , " + PiStaffTable.TableName + "." + PiStaffTable.FieldSortCode;*/
            string sqlQuery = " SELECT A.* "
                + " ,(SELECT Code FROM " + PiOrganizeTable.TableName + " WHERE " + PiOrganizeTable.FieldId + " = B.OrganizeId) AS OrganizeCode"
                + " ,(SELECT FullName FROM " + PiOrganizeTable.TableName + " WHERE " + PiOrganizeTable.FieldId + " = B.OrganizeId) AS OrganizeName"
                + " FROM " + PiStaffTable.TableName + " A , " + PiStaffOrganizeTable.TableName + " B "
                + " WHERE A." + PiStaffTable.FieldId + " = B." + PiStaffOrganizeTable.FieldStaffId               
                + " ORDER BY A." + PiStaffTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        #region public DataTable GetDT(string fieldName, string fieldValue) 获取打印列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="fieldName">字段</param>
        /// <param name="fieldValue">内容</param>
        /// <returns>数据表</returns>
        public DataTable GetDT(string fieldName, string fieldValue)
        {
            /*string sqlQuery = " SELECT A.* "

                            + " ,(SELECT Code FROM " + PiOrganizeTable.TableName + " WHERE " + PiOrganizeTable.TableName + ".ID = A.CompanyId) AS CompanyCode"
                            + " ,(SELECT FullName FROM " + PiOrganizeTable.TableName + " WHERE " + PiOrganizeTable.TableName + ".ID = A.CompanyId) AS CompanyName "

                            + " ,(SELECT Code FROM " + PiOrganizeTable.TableName + " WHERE " + PiOrganizeTable.TableName + ".ID = A.DepartmentId) AS DepartmentCode"
                            + " ,(SELECT FullName FROM " + PiOrganizeTable.TableName + " WHERE " + PiOrganizeTable.TableName + ".ID = A.DepartmentId) AS DepartmentName "

                            + " ,(SELECT " + PiOrganizeTable.FieldCode + " From " + PiOrganizeTable.TableName + " WHERE Id = A.WorkgroupId) AS WorkgroupCode"
                            + " ,(SELECT " + PiOrganizeTable.FieldFullName + " FROM " + PiOrganizeTable.TableName + " WHERE Id = A.WorkgroupId) AS WorkgroupName "

                            + " ,(SELECT ItemName FROM Items_Duty WHERE Items_Duty.Id = A.DutyId) AS DutyName "

                            + " ,(SELECT ItemName FROM Items_Title WHERE Items_Title.Id = A.TitleId) AS TitleName "

                            + " FROM " + PiStaffTable.TableName + " A "
                            + " WHERE " + fieldName + " = " + DBProvider.GetParameter(fieldName)
                            + " ORDER BY A.SortCode";
             */
            string sqlQuery = " SELECT A.* "
                + " ,(SELECT Code FROM " + PiOrganizeTable.TableName + " WHERE " + PiOrganizeTable.FieldId + " = B.OrganizeId) AS OrganizeCode"
                + " ,(SELECT FullName FROM " + PiOrganizeTable.TableName + " WHERE " + PiOrganizeTable.FieldId + " = B.OrganizeId) AS OrganizeName"
                + " FROM " + PiStaffTable.TableName + " A , " + PiStaffOrganizeTable.TableName + " B "
                + " WHERE A." + PiStaffTable.FieldId + " = B." + PiStaffOrganizeTable.FieldStaffId
                + " AND A." + fieldName + " = " + DBProvider.GetParameter(fieldName)
                + " ORDER BY A." + PiStaffTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery, new IDbDataParameter[] { DBProvider.MakeParameter(fieldName, fieldValue)});
        }
        #endregion

        #region public int BatchSave(DataTable dataTable) 批量进行保存
        /// <summary>
        /// 批量进行保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[PiStaffTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        returnValue += this.DeleteEntity(id);
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[PiStaffTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        PiStaffEntity staffEntity = BaseEntity.Create<PiStaffEntity>(dataRow); 
                        returnValue += this.UpdateEntity(staffEntity);                       
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    PiStaffEntity staffEntity = BaseEntity.Create<PiStaffEntity>(dataRow); 
                    returnValue += this.AddEntity(staffEntity).Length > 0 ? 1 : 0;
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
            this.ReturnStatusCode = StatusCode.OK.ToString();
            return returnValue;
        }
        #endregion

        #region public int UpdateUser(string staffId) 按员工的修改信息，把用户信息进行修改
        /// <summary>
        /// 按员工的修改信息，把用户信息进行修改
        /// </summary>
        /// <param name="staffId">员工主键</param>
        /// <returns>影响行数</returns>
        public int UpdateUser(string staffId)
        {
            DataTable dataTable = this.GetDT(PiStaffTable.FieldId, staffId);
            PiStaffEntity staffEntity = BaseEntity.Create<PiStaffEntity>(dataTable); //new PiStaffEntity(dataTable);
            if (!string.IsNullOrEmpty(staffEntity.UserId))
            {
                // 员工信息改变时，用户信息也跟着改变。
                PiUserManager userManager = new PiUserManager(DBProvider, UserInfo);
                PiUserEntity userEntity = userManager.GetEntity(staffEntity.UserId.ToString());
                // userEntity.Company = staffEntity.CompanyName;
                // userEntity.Department = staffEntity.DepartmentName;
                // userEntity.Workgroup = staffEntity.WorkgroupName;
                
                userEntity.UserName = staffEntity.UserName;
                userEntity.RealName = staffEntity.RealName;
                userEntity.Code = staffEntity.Code;

                userEntity.Email = staffEntity.Email;
                userEntity.Enabled = int.Parse(staffEntity.Enabled.ToString());
                // userEntity.Duty = staffEntity.DutyName;
                // userEntity.Title = staffEntity.TitleName;
                userEntity.Gender = staffEntity.Gender;
                userEntity.Birthday = BusinessLogic.ConvertToNullableDateTime(staffEntity.Birthday);
                userEntity.Mobile = staffEntity.Mobile;
            }
            return 0;
        }
        #endregion

        #region public int DeleteUser(string staffId) 删除员工关联的用户
        /// <summary>
        /// 删除员工关联的用户
        /// </summary>
        /// <param name="staffId">员工主键</param>
        /// <returns>影响行数</returns>
        public int DeleteUser(string staffId)
        {
            int returnValue = 0;
            string userId = this.GetEntity(staffId).UserId.ToString();
            if (!String.IsNullOrEmpty(userId))
            {
                // 删除用户
                PiUserManager userManager = new PiUserManager(DBProvider, UserInfo);
                returnValue += userManager.SetDeleted(userId);
            }
            // 将员工的用户设置为空
            returnValue += this.SetProperty(staffId, PiStaffTable.FieldUserId, null);
            return returnValue;
        }
        #endregion

        #region public override int SetDeleted(string id) 删除标志
        /// <summary>
        /// 删除标志
        /// 
        /// 删除员工时，需要把用户也给删除掉
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int SetDeleted(string id)
        {
            int returnValue = 0;
            // 先把用户设置为删除标记
            string userId = this.GetProperty(id, PiStaffTable.FieldUserId);
            if (!String.IsNullOrEmpty(userId))
            {
                PiUserManager userManager = new PiUserManager(DBProvider, UserInfo);
                returnValue += userManager.SetDeleted(userId);
            }

            PiStaffOrganizeManager staffOrganizeManager = new PiStaffOrganizeManager(DBProvider, UserInfo);
            returnValue += staffOrganizeManager.SetProperty(PiStaffOrganizeTable.FieldStaffId, id, BusinessLogic.FieldDeleteMark, "1");

            // 再把员工设置为删除标记
            returnValue += this.SetProperty(BusinessLogic.FieldId, id, BusinessLogic.FieldDeleteMark, "1");

            return returnValue;
        }
        #endregion

        #region public override int ResetSortCode() 重置排序码
        /// <summary>
        /// 重置排序码
        /// </summary>
        public override int ResetSortCode()
        {
            int returnValue = 0;
            DataTable dataTable = this.GetDT();
            string id = string.Empty;
            string sortCode = string.Empty;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                id = dataRow[PiStaffTable.FieldId].ToString();
                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider);
                sortCode = sequenceManager.GetSequence(PiStaffTable.TableName);
                returnValue += this.SetProperty(id, PiStaffTable.FieldSortCode, sortCode);
            }
            return returnValue;
        }
        #endregion

        #region public int Delete(string id) 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            int returnValue = 0;
            PiStaffEntity staffEntity = this.GetEntity(id);

            if (!string.IsNullOrEmpty(staffEntity.UserId))
            {
                // 删除角色用户关联表            
                returnValue += DbCommonLibary.Delete(DBProvider, PiUserRoleTable.TableName, PiUserRoleTable.FieldUserId, staffEntity.UserId);

                // 删除用户的权限数据

                // 删除用户的权限范围数据

                // 删除相关的用户数据
                PiUserManager userManager = new PiUserManager(DBProvider, UserInfo);
                returnValue += userManager.DeleteEntity(staffEntity.UserId);
            }

            //删除员工组织关系关联表
            returnValue += DbCommonLibary.Delete(DBProvider, PiStaffOrganizeTable.TableName, PiStaffOrganizeTable.FieldStaffId, id);
            // 删除员工本表
            returnValue += DbCommonLibary.Delete(DBProvider, PiStaffTable.TableName, PiStaffTable.FieldId, id);            
            return returnValue;
        }
        #endregion

        #region public int BatchDelete(string[] ids)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int BatchDelete(string[] ids)
        {
            return ids.Sum(t => this.Delete(t));
        }

        #endregion   
    }
}

/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-20 9:52:34
 ******************************************************************************/

using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// PiUserManager
    /// 用户管理
    /// </summary>
    public partial class PiUserManager:DbCommonManager
    {
        #region public void BeforeAdd(PiUserEntity userEntity, out string statusCode) 用户添加之前执行的方法
        /// <summary>
        /// 用户添加之前执行的方法
        /// </summary>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        public void BeforeAdd(PiUserEntity userEntity, out string statusCode)
        {
            statusCode = StatusCode.OK.ToString();

            if (!string.IsNullOrEmpty(userEntity.UserName) && this.Exists(PiUserTable.FieldUserName, userEntity.UserName, PiUserTable.FieldDeleteMark, "0") || DbCommonLibary.Exists(DBProvider, PiStaffTable.TableName, PiStaffTable.FieldUserName, userEntity.UserName, PiStaffTable.FieldDeleteMark, "0"))
            {
                // 用户名已重复
                statusCode = StatusCode.ErrorUserExist.ToString();
            }
            else
            {
                // 检查编号是否重复
                if (!string.IsNullOrEmpty(userEntity.Code) && this.Exists(PiUserTable.FieldCode, userEntity.Code, PiUserTable.FieldDeleteMark, "0"))
                {
                    // 编号已重复
                    statusCode = StatusCode.ErrorCodeExist.ToString();
                }

                if (userEntity.IsStaff == 1)
                {
                    var parameters = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>(PiStaffTable.FieldUserName, userEntity.UserName),
                        new KeyValuePair<string, object>(PiStaffTable.FieldDeleteMark, 0)
                    };
                    if (DbCommonLibary.Exists(DBProvider, PiStaffTable.TableName, parameters))
                    {
                        // 编号已重复
                        statusCode = StatusCode.ErrorNameExist.ToString();
                    }
                    if (!string.IsNullOrEmpty(userEntity.Code))
                    {
                        parameters = new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>(PiStaffTable.FieldCode, userEntity.Code),
                            new KeyValuePair<string, object>(PiStaffTable.FieldDeleteMark, 0)
                        };
                        if (DbCommonLibary.Exists(DBProvider, PiStaffTable.TableName, parameters))
                        {
                            // 编号已重复
                            statusCode = StatusCode.ErrorCodeExist.ToString();
                        }
                    }
                }
            }
        }
        #endregion

        #region public string Add(PiUserEntity userEntity, out string statusCode) 添加用户
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <returns>主键</returns>
        public string Add(PiUserEntity userEntity, out string statusCode)
        {
            var returnValue = string.Empty;
            this.BeforeAdd(userEntity, out statusCode);
            if (statusCode == StatusCode.OK.ToString())
            {
                returnValue = this.AddEntity(userEntity);
                this.AfterAdd(userEntity, out statusCode);
            }
            return returnValue;
        }
        #endregion

        #region public void AfterAdd(BaseUserEntity userEntity, out string statusCode) 用户添加后执行的方法
        /// <summary>
        /// 用户添加之后执行的方法
        /// </summary>
        /// <param name="entity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        public void AfterAdd(PiUserEntity entity, out string statusCode)
        {
            var userLogOnEntity = new PiUserLogOnEntity
            {
                Id = entity.Id,
                MultiUserLogin = SystemInfo.CheckOnLine ? 0 : 1,
                CheckIPAddress = SystemInfo.EnableCheckIPAddress ? 1 : 0
            };

            if (SystemInfo.EnableEncryptServerPassword)
            {
                userLogOnEntity.UserPassword = this.EncryptUserPassword(entity.UserPassword);
            }

            new PiUserLogOnManager(this.DBProvider, this.UserInfo).Add(userLogOnEntity);
            // 运行成功
            statusCode = StatusCode.OKAdd.ToString();
        }
        #endregion
    }
}

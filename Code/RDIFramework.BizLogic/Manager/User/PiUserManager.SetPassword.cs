/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-18 9:55:35
 ******************************************************************************/
using System;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class PiUserManager:DbCommonManager,IDbCommonManager
    {
        /// <summary>
        /// 用户密码加密处理功能
        /// 2014-06-20 XuWangBin V2.8 增加对修改密码最小长度、字母数字组合等强度检查。
        /// 2014-03-28 XuWangBin 修改用户登录表没有用户记录时设置密码自动增加一条数据。
        /// 用户的密码到底如何加密，数据库中如何存储用户的密码？
        /// 若是明文方式存储，在管理上会有很多漏洞，虽然调试时不方便，当时加密的密码相对是安全的，
        /// 而且最好是密码是不可逆的，这样安全性更高一些，各种不同的系统，这里适当的处理一下就饿可以了。
        /// </summary>
        /// <param name="password">用户密码</param>
        /// <returns>处理后的密码</returns>
        public virtual string EncryptUserPassword(string password)
        {
            return SecretHelper.AESEncrypt(password);
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="userId">被设置的员工主键</param>
        /// <param name="password">新密码</param>
        /// <returns>影响行数</returns>
        public virtual int SetPassword(string userId, string password)
        {
            int returnValue = 0;

            // 密码强度检查
            /*
            if (SystemInfo.EnableCheckPasswordStrength)
            {
                if (password.Length == 0)
                {
                    this.ReturnStatusCode = StatusCode.PasswordCanNotBeNull.ToString();
                    return returnValue;
                }
            }
            */
            // 加密密码
            if (SystemInfo.EnableEncryptServerPassword)
            {
                password = this.EncryptUserPassword(password);
            }

            PiUserLogOnManager userLonOnManager = new PiUserLogOnManager(this.DBProvider, this.UserInfo);
            //先判断是否有记录，没有就增加
            PiUserLogOnEntity logOnEntity = userLonOnManager.GetEntity(userId);
            if (logOnEntity == null || (logOnEntity != null && string.IsNullOrEmpty(logOnEntity.Id)))
            {
                PiUserLogOnEntity entity = new PiUserLogOnEntity()
                {
                    Id = userId,
                    //MultiUserLogin = SystemInfo.CheckOnLine ? 0 : 1,
                    CheckIPAddress = SystemInfo.EnableCheckIPAddress ? 1 : 0,
                    UserPassword = password,
                    OpenId = BusinessLogic.NewGuid()
                };
                string value = userLonOnManager.Add(entity);
                this.ReturnStatusCode = !string.IsNullOrEmpty(value) ? StatusCode.SetPasswordOK.ToString() : StatusCode.ErrorDeleted.ToString();
                returnValue = !string.IsNullOrEmpty(value) ? 1 : 0;
            }
            else
            {
                // 设置密码字段
                string[] targetFields =
                {
                    PiUserLogOnTable.FieldUserPassword, 
                    PiUserLogOnTable.FieldChangePasswordDate,
                    PiUserLogOnTable.FieldOpenId
                };
                Object[] targetValues = {password, null, BusinessLogic.NewGuid()};
                returnValue = new PiUserLogOnManager(this.DBProvider, this.UserInfo).SetProperty(userId, targetFields,targetValues);
                this.ReturnStatusCode = returnValue == 1 ? StatusCode.SetPasswordOK.ToString(): StatusCode.ErrorDeleted.ToString();
            }

            return returnValue;
        }

        /// <summary>
        /// 批量设置密码
        /// </summary>
        /// <param name="userIds">被设置的员工主键</param>
        /// <param name="password">新密码</param>
        /// <returns>影响行数</returns>
        public virtual int BatchSetPassword(string[] userIds, string password)
        {
            int returnValue = 0;

            if (userIds == null || userIds.Length == 0)
            {
                this.ReturnStatusCode = StatusCode.NotFound.ToString();
                return returnValue;
            }

            // 密码强度检查
            /*
            if (SystemInfo.EnableCheckPasswordStrength)
            {
                if (password.Length == 0)
                {
                    statusCode = StatusCode.PasswordCanNotBeNull.ToString();
                    return returnValue;
                }
            }
            */


            returnValue = userIds.Sum(tmId => this.SetPassword(tmId, password));

            /*
            // 加密密码
            if (SystemInfo.EnableEncryptServerPassword)
            {
                password = this.EncryptUserPassword(password);
            }
            string[] targetFields = { PiUserLogOnTable.FieldUserPassword, PiUserLogOnTable.FieldChangePasswordDate, PiUserLogOnTable.FieldOpenId };
            Object[] targetValues = { password, null ,BusinessLogic.NewGuid()};
            // 设置密码字段
            returnValue += new PiUserLogOnManager(this.DBProvider, this.UserInfo).SetProperty(userIds, targetFields,targetValues);
             */
            this.ReturnStatusCode = returnValue > 0 ? StatusCode.SetPasswordOK.ToString() : StatusCode.ErrorDeleted.ToString();
            return returnValue;
        }
      
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="oldPassword">原密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public virtual int ChangePassword(string oldPassword, string newPassword, out string statusCode)
        {
            int returnValue = 0;
            // 密码强度检查
            if (SystemInfo.EnableCheckPasswordStrength)
            {
                if (String.IsNullOrEmpty(newPassword))
                {
                    statusCode = StatusCode.PasswordCanNotBeNull.ToString();
                    return returnValue;
                }
               
                //最小长度、字母数字组合等强度检查
                if (!ValidateUtil.EnableCheckPasswordStrength(newPassword))
                {
                    statusCode = StatusCode.PasswordNotStrength.ToString();
                    return returnValue;
                }
            }

            // 加密密码
            if (SystemInfo.EnableEncryptServerPassword)
            {
                oldPassword = this.EncryptUserPassword(oldPassword);
                newPassword = this.EncryptUserPassword(newPassword);
            }

            // 判断输入原始密码是否正确
            PiUserLogOnEntity entity = new PiUserLogOnManager(this.DBProvider,this.UserInfo).GetEntity(UserInfo.Id);
            if (entity.UserPassword == null)
            {
                entity.UserPassword = string.Empty;
            }

            // 密码错误
            if (!entity.UserPassword.Equals(oldPassword))
            {
                statusCode = StatusCode.OldPasswordError.ToString();
                return returnValue;
            }

            // 更改密码，同时修改密码的修改日期，这里需要兼容多数据库
            var sqlBuilder = new SQLBuilder(this.DBProvider);
            sqlBuilder.BeginUpdate(PiUserLogOnTable.TableName);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldUserPassword, newPassword);
            sqlBuilder.SetDBNow(PiUserLogOnTable.FieldChangePasswordDate);
            sqlBuilder.SetWhere(PiUserLogOnTable.FieldId, UserInfo.Id);
            returnValue = sqlBuilder.EndUpdate();
            statusCode = returnValue == 1 ? StatusCode.ChangePasswordOK.ToString() : StatusCode.ErrorDeleted.ToString();
            return returnValue;
        }
    }
}

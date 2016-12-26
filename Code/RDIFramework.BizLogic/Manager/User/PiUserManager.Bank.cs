using System;
using System.Security.Cryptography;

namespace RDIFramework.ServiceAdapter
{
    using RDIFramework.BusinessEntity;
    using RDIFramework.Utilities;

    /// <summary>
    /// PiUserManager
    /// 用户管理
    /// 
    /// </summary>
    public partial class PiUserManager : DbCommonManager
	{
        public virtual string CreateDigitalSignature(string password, out string statusCode)
        {
            string returnValue = string.Empty;
            statusCode = string.Empty;
            // 1:检查是否已经生成过数字签名
            // 2:加密密码
            password = this.EncryptUserPassword(password);
            // 3:设置密码
            //this.SetProperty(UserInfo.Id, PiUserTable.FieldSignedPassword, password);
            // 4:产生私钥、公钥对
            RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider();
            string publicKey = Convert.ToBase64String(cryptoServiceProvider.ExportCspBlob(false));
            string privateKey = Convert.ToBase64String(cryptoServiceProvider.ExportCspBlob(true));
            // 5:保存公钥
            //this.SetProperty(UserInfo.Id, PiUserTable.FieldPublicKey, publicKey);
            // 6:返回私钥
            returnValue = privateKey;
            // 7:写入正确状态
            statusCode = StatusCode.OK.ToString();
            return returnValue;
        }

        /// <summary>
        /// 获取当前用户的公钥
        /// </summary>
        /// <returns>公钥</returns>
        public string GetPublicKey()
        {
            return string.Empty;
            //return this.GetProperty(this.UserInfo.Id, PiUserTable.FieldPublicKey);
        }

        /// <summary>
        /// 获取当前用户的公钥
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>公钥</returns>
        public string GetPublicKey(string userId)
        {
            return string.Empty;

            //return this.GetProperty(userId, PiUserTable.FieldPublicKey);
        }

        /// <summary>
        /// 更新数字签名密码
        /// </summary>
        /// <param name="oldPassword">原密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public virtual int ChangeSignedPassword(string oldPassword, string newPassword, out string statusCode)
        {
            #if (DEBUG)
            int milliStart = Environment.TickCount;
            #endif

            int returnValue = 0;
            // 密码强度检查
            if (SystemInfo.EnableCheckPasswordStrength)
            {
                if (String.IsNullOrEmpty(newPassword))
                {
                    statusCode = StatusCode.PasswordCanNotBeNull.ToString();
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
            PiUserEntity userEntity = new PiUserEntity();
            userEntity.GetFrom(this.GetDTById(UserInfo.Id));
            //if (userEntity.SignedPassword == null)
            //{
            //    userEntity.SignedPassword = string.Empty;
            //}
            //// 密码错误
            //if (!userEntity.SignedPassword.Equals(oldPassword))
            //{
            //    statusCode = StatusCode.OldPasswordError.ToString();
            //    return returnValue;
            //}
            // 更改密码
           // returnValue = this.SetProperty(UserInfo.Id, PiUserTable.FieldSignedPassword, newPassword);
            statusCode = returnValue == 1 ? StatusCode.ChangePasswordOK.ToString() : StatusCode.ErrorDeleted.ToString();

            // 写入调试信息
            #if (DEBUG)
            int milliEnd = Environment.TickCount;
            Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " " + " BaseUserManager.ChangePassword(" + userEntity.Id + ")");
            #endif

            return returnValue;
        }

        public virtual bool SignedPassword(string signedPassword)
        {
            bool returnValue = false;
            // 密码强度检查
            if (SystemInfo.EnableCheckPasswordStrength && String.IsNullOrEmpty(signedPassword))
            {
                return returnValue;
            }
            // 加密密码
            if (SystemInfo.EnableEncryptServerPassword)
            {
                signedPassword = this.EncryptUserPassword(signedPassword);
            }
            // 判断输入原始密码是否正确
            PiUserEntity userEntity = new PiUserEntity();
            userEntity.GetFrom(this.GetDTById(UserInfo.Id));
            //if (!(userEntity.CommunicationPassword == null && signedPassword.Length == 0))
            //{
            //    if (userEntity.SignedPassword.Equals(signedPassword))
            //    {
            //        returnValue = true;
            //    }
            //}
            return returnValue;
        }

        /// <summary>
        /// 更新通讯密码
        /// </summary>
        /// <param name="oldPassword">原密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public virtual int ChangeCommunicationPassword(string oldPassword, string newPassword, out string statusCode)
        {
            #if (DEBUG)
            int milliStart = Environment.TickCount;
            #endif

            int returnValue = 0;
            // 密码强度检查
            if (SystemInfo.EnableCheckPasswordStrength && String.IsNullOrEmpty(newPassword))
            {
                statusCode = StatusCode.PasswordCanNotBeNull.ToString();
                return returnValue;
            }
            // 加密密码
            if (SystemInfo.EnableEncryptServerPassword)
            {
                oldPassword = this.EncryptUserPassword(oldPassword);
                newPassword = this.EncryptUserPassword(newPassword);
            }
            // 判断输入原始密码是否正确
            PiUserEntity userEntity = new PiUserEntity();
            userEntity.GetFrom(this.GetDTById(UserInfo.Id));
            //if (userEntity.CommunicationPassword == null)
            //{
            //    userEntity.CommunicationPassword = string.Empty;
            //}
            //// 密码错误
            //if (!userEntity.CommunicationPassword.Equals(oldPassword))
            //{
            //    statusCode = StatusCode.OldPasswordError.ToString();
            //    return returnValue;
            //}
            // 更改密码
           // returnValue = this.SetProperty(UserInfo.Id, PiUserTable.FieldCommunicationPassword, newPassword);
            if (returnValue == 1)
            {
                statusCode = StatusCode.ChangePasswordOK.ToString();
            }
            else
            {
                // 数据可能被删除
                statusCode = StatusCode.ErrorDeleted.ToString();
            }

            // 写入调试信息
        #if (DEBUG)
            int milliEnd = Environment.TickCount;
            Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " " + " BaseUserManager.ChangePassword(" + userEntity.Id + ")");
        #endif

            return returnValue;
        }

        public virtual bool CommunicationPassword(string communicationPassword)
        {
            bool returnValue = false;
            // 密码强度检查
            if (SystemInfo.EnableCheckPasswordStrength && String.IsNullOrEmpty(communicationPassword))
            {
                return returnValue;
            }
            // 加密密码
            if (SystemInfo.EnableEncryptServerPassword)
            {
                communicationPassword = this.EncryptUserPassword(communicationPassword);
            }
            // 判断输入原始密码是否正确
            PiUserEntity userEntity = new PiUserEntity();
            userEntity.GetFrom(this.GetDTById(UserInfo.Id));
            //if (userEntity.CommunicationPassword == null)
            //{
            //    userEntity.CommunicationPassword = string.Empty;
            //}
            //if (userEntity.CommunicationPassword.Equals(communicationPassword))
            //{
            //    returnValue = true;
            //}
            return returnValue;
        }
	}
}

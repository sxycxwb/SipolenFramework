/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-18 9:49:17
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 
    /// 2014-03-26 EricHu V2.8 增加对用户（用户名与密码）的验证。
    /// 
    /// </summary>
    public partial class PiUserManager
    {
        #region public UserInfo LogOnByUserName(string userName, string ipAddress = null, string macAddress = null) 通用用户名登录
        /// <summary>
        /// 通用用户名登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="macAddress">Mac地址</param>
        /// <returns>用户信息</returns>
        public UserInfo LogOnByUserName(string userName, string ipAddress = null, string macAddress = null)
        {
            UserInfo userInfo = null;
            // 用户没有找到状态
            this.ReturnStatusCode = StatusCode.UserNotFound.ToString();
            // 检查是否有效的合法的参数
            if (!String.IsNullOrEmpty(userName))
            {
                var parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(PiUserTable.FieldUserName, userName),
                    new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0),
                    new KeyValuePair<string, object>(PiUserTable.FieldEnabled, 1)
                };
                var dt = this.GetDT(parameters);
                if (dt.Rows.Count == 1)
                {
                    var entity = BaseEntity.Create<PiUserEntity>(dt.Rows[0]); 
                    PiUserLogOnEntity userLogOnEntity = new PiUserLogOnManager(this.DBProvider, this.UserInfo).GetEntity(entity.Id);
                    userInfo = this.LogOn(entity.UserName, userLogOnEntity.UserPassword, string.Empty, false, ipAddress, macAddress, false);
                }
            }
            return userInfo;
        }
        #endregion

        #region public UserInfo LogOnByOpenId(string openId, string ipAddress = null, string macAddress = null) 通过单点登录标识登录
        /// <summary>
        /// 通过单点登录标识登录
        /// </summary>
        /// <param name="openId">单点登录标识</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="macAddress">Mac地址</param>
        /// <returns>用户信息</returns>
        public UserInfo LogOnByOpenId(string openId, string ipAddress = null, string macAddress = null)
        {
            UserInfo userInfo = null;
            // 用户没有找到状态
            this.ReturnStatusCode = StatusCode.UserNotFound.ToString();
            // 检查是否有效的合法的参数
            if (!String.IsNullOrEmpty(openId))
            {
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                if (!string.IsNullOrEmpty(openId))
                {
                    parameters.Add(new KeyValuePair<string, object>(PiUserLogOnTable.FieldOpenId, openId));
                }
                // 若是单点登录，那就不能判断ip地址，因为不是直接登录，是间接登录
                if (!string.IsNullOrEmpty(ipAddress))
                {
                    parameters.Add(new KeyValuePair<string, object>(PiUserLogOnTable.FieldIPAddress, ipAddress));
                }
                if (!string.IsNullOrEmpty(macAddress))
                {
                    parameters.Add(new KeyValuePair<string, object>(PiUserLogOnTable.FieldMACAddress, macAddress));
                }

                var dt = new PiUserLogOnManager(this.DBProvider, this.UserInfo).GetDT(parameters);
                if (dt.Rows.Count == 1)
                {
                    PiUserEntity userEntity = this.GetEntity(dt.Rows[0][PiUserLogOnTable.FieldId].ToString());
                    PiUserLogOnEntity userLogOnEntity = new PiUserLogOnManager(this.DBProvider, this.UserInfo).GetEntity(userEntity.Id);
                    userInfo = this.LogOn(userEntity.UserName, userLogOnEntity.UserPassword, openId, false, ipAddress, macAddress, false);
                }
            }
            return userInfo;
        }
        #endregion

        #region public UserInfo LogOn(string userName, string password, string openId = null, bool createNewOpenId = false, string ipAddress = null , string macAddress = null) 进行登录操作
        /// <summary>
        /// 进行登录操作
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="openId">单点登录标识</param>
        /// <param name="createNewOpenId"></param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="macAddress">MAC地址</param>
        /// <param name="checkUserPassword">是否要检查用户密码</param>
        /// <returns>用户信息</returns>
        public UserInfo LogOn(string userName, string password, string openId = null, bool createNewOpenId = false, string ipAddress = null, string macAddress = null, bool checkUserPassword = true)
        {
            UserInfo userInfo = null;

            string realName = string.Empty;
            if (UserInfo != null)
            {
                realName = UserInfo.RealName;
                if (string.IsNullOrEmpty(ipAddress))
                {
                    ipAddress = UserInfo.IPAddress;
                }
                if (string.IsNullOrEmpty(macAddress))
                {
                    macAddress = UserInfo.MACAddress;
                }
            }

            PiUserLogOnManager userLogOnManager = new PiUserLogOnManager(this.DBProvider, this.UserInfo);
            // 01: 系统是否采用了在线用户的限制
            if (SystemInfo.OnLineLimit > 0 && userLogOnManager.CheckOnLineLimit())
            {
                this.ReturnStatusCode = StatusCode.ErrorOnLineLimit.ToString();
               // LogManager.Instance.Add(DBProvider, userName, realName, "LogOn", RDIFrameworkMessage.UserManager,"LogOn", RDIFrameworkMessage.UserManager_LogOn, userName, ipAddress,RDIFrameworkMessage.MSG0089 + SystemInfo.OnLineLimit.ToString());
                return userInfo;
            }

            // 02. 默认为用户没有找到状态，查找用户
            // 这是为了达到安全要求，不能提示用户未找到，那容易让别人猜测到帐户
            this.ReturnStatusCode = SystemInfo.EnableCheckPasswordStrength ? StatusCode.ErrorLogOn.ToString() : StatusCode.UserNotFound.ToString();

            // 03. 查询数据库中的用户数据？只查询未被删除的
            string[] names = { PiUserTable.FieldDeleteMark, PiUserTable.FieldUserName };
            Object[] values = { 0, userName };
            DataTable dataTable = this.GetDT(names, values);
            if (dataTable.Rows.Count == 0)
            {
                //TODO:若没数据再工号、邮件、手机号等方式登录
            }

            PiUserEntity userEntity = null;
            PiUserLogOnEntity userLogOnEntity = null;
            if (dataTable.Rows.Count > 1)
            {
                this.ReturnStatusCode = StatusCode.UserDuplicate.ToString();
            }
            else if (dataTable.Rows.Count == 1)
            {
                // 05. 判断密码，是否允许登录，是否离职是否正确
                userEntity = BaseEntity.Create<PiUserEntity>(dataTable.Rows[0]); 
                if (!string.IsNullOrEmpty(userEntity.AuditStatus) && userEntity.AuditStatus.EndsWith(AuditStatus.WaitForAudit.ToString()))
                {
                    this.ReturnStatusCode = AuditStatus.WaitForAudit.ToString();
                    //LogManager.Instance.Add(DBProvider, userName, realName, "LogOn", RDIFrameworkMessage.UserManager, "LogOn", RDIFrameworkMessage.UserManager_LogOn, userName, ipAddress, RDIFrameworkMessage.MSG0078);
                    return userInfo;
                }

                // 用户无效、已离职的
                if (userEntity.IsDimission == 1 || userEntity.Enabled == 0)
                {
                    this.ReturnStatusCode = StatusCode.LogOnDeny.ToString();
                    return userInfo;
                }

                // 用户是否有效的
                if (userEntity.Enabled == -1)
                {
                    this.ReturnStatusCode = StatusCode.UserNotActive.ToString();
                    //LogManager.Instance.Add(DBProvider, userName, realName, "LogOn", RDIFrameworkMessage.UserManager, "LogOn", RDIFrameworkMessage.UserManager_LogOn, userName, ipAddress, RDIFrameworkMessage.MSG0080);
                    return userInfo;
                }
                userLogOnEntity = userLogOnManager.GetEntity(userEntity.Id);
                if (string.IsNullOrEmpty(userEntity.UserName) || !userEntity.UserName.Equals("Administrator"))
                {
                    // 06. 允许登录时间是否有限制
                    if (userLogOnEntity.AllowEndTime != null)
                    {
                        userLogOnEntity.AllowEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, userLogOnEntity.AllowEndTime.Value.Hour, userLogOnEntity.AllowEndTime.Value.Minute, userLogOnEntity.AllowEndTime.Value.Second);
                    }

                    if (userLogOnEntity.AllowStartTime != null)
                    {
                        userLogOnEntity.AllowStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, userLogOnEntity.AllowStartTime.Value.Hour, userLogOnEntity.AllowStartTime.Value.Minute, userLogOnEntity.AllowStartTime.Value.Second);
                        if (DateTime.Now < userLogOnEntity.AllowStartTime)
                        {
                            this.ReturnStatusCode = StatusCode.UserLocked.ToString();
                            //LogManager.Instance.Add(DBProvider, userName, realName, "LogOn", RDIFrameworkMessage.UserManager, "LogOn", RDIFrameworkMessage.UserManager_LogOn, userName, ipAddress, RDIFrameworkMessage.MSG0081 + userLogOnEntity.AllowStartTime.Value.ToString("HH:mm"));
                            return userInfo;
                        }
                    }

                    if (userLogOnEntity.AllowEndTime != null)
                    {
                        if (DateTime.Now > userLogOnEntity.AllowEndTime)
                        {
                            this.ReturnStatusCode = StatusCode.UserLocked.ToString();
                            //LogManager.Instance.Add(DBProvider, userName, realName, "LogOn", RDIFrameworkMessage.UserManager, "LogOn", RDIFrameworkMessage.UserManager_LogOn, userName, ipAddress, RDIFrameworkMessage.MSG0082 + userLogOnEntity.AllowEndTime.Value.ToString("HH:mm"));
                            return userInfo;
                        }
                    }

                    // 07. 锁定日期是否有限制
                    if (userLogOnEntity.LockStartDate != null && DateTime.Now > userLogOnEntity.LockStartDate)
                    {
                        if (userLogOnEntity.LockEndDate == null || DateTime.Now < userLogOnEntity.LockEndDate)
                        {
                            this.ReturnStatusCode = StatusCode.UserLocked.ToString();
                            //LogManager.Instance.Add(DBProvider, userName, realName, "LogOn",RDIFrameworkMessage.UserManager, "LogOn", RDIFrameworkMessage.UserManager_LogOn,userName, ipAddress,RDIFrameworkMessage.MSG0083 + userLogOnEntity.LockStartDate.Value.ToString("yyyy-MM-dd"));
                            return userInfo;
                        }
                    }

                    if (userLogOnEntity.LockEndDate != null && DateTime.Now < userLogOnEntity.LockEndDate)
                    {
                        this.ReturnStatusCode = StatusCode.UserLocked.ToString();
                        //LogManager.Instance.Add(DBProvider, userName, realName, "LogOn", RDIFrameworkMessage.UserManager,"LogOn", RDIFrameworkMessage.UserManager_LogOn, userName, ipAddress,RDIFrameworkMessage.MSG0084 + userEntity.LockEndDate.Value.ToString("yyyy-MM-dd"));
                        return userInfo;
                    }
                }

                // 08. 是否检查用户IP地址，是否进行访问限制？管理员不检查IP. && !this.IsAdministrator(userEntity.Id.ToString()
                if (SystemInfo.EnableCheckIPAddress && userLogOnEntity .CheckIPAddress == 1 && (!(userEntity.UserName.Equals("Administrator") || userEntity.Code.Equals("Administrator"))))
                {
                    var parameterManager = new CiParameterManager(this.DBProvider);
                    var nameArr = new string[2];
                    var valueArr = new string[2];
                    nameArr[0] = CiParameterTable.FieldParameterId;
                    nameArr[1] = CiParameterTable.FieldCategoryKey;
                    valueArr[0] = userEntity.Id.ToString();
                    // 没有设置IP地址时不检查
                    valueArr[1] = "IPAddress";
                    if (!string.IsNullOrEmpty(ipAddress))
                    {
                        if (parameterManager.Exists(nameArr, valueArr))
                        {
                            if (!this.CheckIPAddress(ipAddress, userEntity.Id.ToString()))
                            {
                                var parameters = new List<KeyValuePair<string, object>>
                                {
                                    new KeyValuePair<string, object>(PiUserLogOnTable.FieldIPAddress, ipAddress)
                                };
                                //this.SetProperty(userEntity.Id, PiUserLogOnTable.FieldIPAddress, ipAddress);
                                this.ReturnStatusCode = StatusCode.ErrorIPAddress.ToString();
                                //LogManager.Instance.Add(DBProvider, userName, realName, "LogOn",RDIFrameworkMessage.UserManager, "LogOn", RDIFrameworkMessage.UserManager_LogOn,ipAddress, ipAddress, RDIFrameworkMessage.MSG0085);
                                return userInfo;
                            }
                        }
                    }

                    // 没有设置MAC地址时不检查
                    valueArr[1] = "MacAddress";
                    if (!string.IsNullOrEmpty(macAddress))
                    {
                        if (parameterManager.Exists(nameArr, valueArr))
                        {
                            if (!this.CheckMacAddress(macAddress, userEntity.Id.ToString()))
                            {
                                this.ReturnStatusCode = StatusCode.ErrorMacAddress.ToString();
                                //this.SetProperty(userEntity.Id, PiUserLogOnTable.FieldMACAddress, macAddress);
                                //LogManager.Instance.Add(DBProvider, userName, realName, "LogOn",RDIFrameworkMessage.UserManager, "LogOn", RDIFrameworkMessage.UserManager_LogOn,macAddress, ipAddress, RDIFrameworkMessage.MSG0086);
                                return userInfo;
                            }
                        }
                    }
                }

                // 10. 只允许登录一次，需要检查是否自己重新登录了，或者自己扮演自己了
                if ((UserInfo != null) && (!UserInfo.Id.Equals(userEntity.Id.ToString())))
                {
                    if (SystemInfo.CheckOnLine && userLogOnEntity.MultiUserLogin == 0 && userLogOnEntity.UserOnLine > 0)
                    {
                        // 自己是否登录了2次，在没下线的情况下
                        bool isSelf = false;
                        if (!string.IsNullOrEmpty(openId))
                        {
                            if (!string.IsNullOrEmpty(userLogOnEntity.OpenId))
                            {
                                if (userLogOnEntity.OpenId.Equals(openId))
                                {
                                    isSelf = true;
                                }
                            }
                        }
                        if (!isSelf)
                        {
                            this.ReturnStatusCode = StatusCode.ErrorOnLine.ToString();
                            //LogManager.Instance.Add(DBProvider, userName, realName, "LogOn",RDIFrameworkMessage.UserManager, "LogOn", RDIFrameworkMessage.UserManager_LogOn,userName, ipAddress, RDIFrameworkMessage.MSG0087);
                            return userInfo;
                        }
                    }
                }

                // 04. 系统是否采用了密码加密策略？
                if (checkUserPassword && SystemInfo.EnableEncryptServerPassword)
                {
                    password = this.EncryptUserPassword(password);
                }


                // 11. 密码是否正确(null 与空看成是相等的)
                if (!(string.IsNullOrEmpty(userLogOnEntity.UserPassword) && string.IsNullOrEmpty(password)))
                {
                    bool userPasswordOK = true;
                    // 用户密码是空的
                    if (string.IsNullOrEmpty(userLogOnEntity.UserPassword))
                    {
                        // 但是输入了不为空的密码
                        if (!string.IsNullOrEmpty(password))
                        {
                            userPasswordOK = false;
                        }
                    }
                    else
                    {
                        // 用户的密码不为空，但是用户是输入了密码、 再判断用户的密码与输入的是否相同
                        userPasswordOK = !string.IsNullOrEmpty(password) && userLogOnEntity.UserPassword.Equals(password);
                    }
                    // 用户的密码不相等
                    if (!userPasswordOK)
                    {
                        userLogOnEntity.PasswordErrorCount = userLogOnEntity.PasswordErrorCount + 1;
                        if (SystemInfo.PasswordErrorLockLimit > 0 &&
                            userLogOnEntity.PasswordErrorCount >= SystemInfo.PasswordErrorLockLimit)

                        {
                            if (SystemInfo.PasswordErrorLockCycle == 0) //密码错误锁定周期若为0，直接设帐号无效，需要管理员审核
                            {
                                string[] names1 = {PiUserTable.FieldEnabled, PiUserTable.FieldAuditStatus};
                                object[] values1 = {"0", AuditStatus.WaitForAudit.ToString()};
                                this.SetProperty(userEntity.Id, names1, values1);
                            }
                            else
                            {
                                //进行帐号锁定
                                userLogOnEntity.LockStartDate = DateTime.Now;
                                userLogOnEntity.LockEndDate = DateTime.Now.AddMinutes(SystemInfo.PasswordErrorLockCycle);
                                string[] names2 ={PiUserLogOnTable.FieldLockStartDate,PiUserLogOnTable.FieldLockEndDate};
                                object[] values2 = {userLogOnEntity.LockStartDate, userLogOnEntity.LockEndDate};
                                userLogOnManager.SetProperty(userEntity.Id, names2, values2);
                            }
                        }
                        else
                        {
                            userLogOnManager.SetProperty(userEntity.Id, PiUserLogOnTable.FieldPasswordErrorCount, userLogOnEntity.PasswordErrorCount);
                        }
                        //密码错误后处理：
                        //  11.1：记录日志
                        //LogManager.Instance.Add(DBProvider, userEntity.Id.ToString(), userEntity.RealName, "LogOn", RDIFrameworkMessage.UserManager, "LogOn", RDIFrameworkMessage.UserManager_LogOn, userEntity.RealName, ipAddress, RDIFrameworkMessage.MSG0088);
                        // TODO: 11.2：看当天（24小时内）输入错误密码多少次了？
                        // TODO: 11.3：若输错密码数量已经超过了系统限制，则用户被锁定系统设定的小时数。
                        // TODO: 11.4：同时处理返回值，由于输入错误密码次数过多导致被锁定，登录时应读取这个状态比较，时间过期后应处理下状态。
                        // 密码强度检查，若是要有安全要求比较高的，返回的提醒消息要进行特殊处理，不能返回非常明确的提示信息。
                        this.ReturnStatusCode = SystemInfo.EnableCheckPasswordStrength ? StatusCode.ErrorLogOn.ToString() : StatusCode.PasswordError.ToString();
                        return userInfo;
                    }
                }

                // 12. 更新IP地址，更新MAC地址
                userLogOnEntity.PasswordErrorCount = 0;
                if (!string.IsNullOrEmpty(ipAddress))
                {
                    userLogOnEntity.IPAddress = ipAddress;
                }
                if (!string.IsNullOrEmpty(macAddress))
                {
                    userLogOnEntity.MACAddress = macAddress;
                }
                userLogOnManager.SetProperty(userEntity.Id,new string[]{PiUserLogOnTable.FieldPasswordErrorCount,PiUserLogOnTable.FieldIPAddress,PiUserLogOnTable.FieldMACAddress}, new object[]{0,ipAddress,macAddress});
                // 可以正常登录了
                this.ReturnStatusCode = StatusCode.OK.ToString();

                // 13. 登录、重新登录、扮演时的在线状态进行更新
                //userLogOnManager.ChangeOnLine(userEntity.Id);

                userInfo = this.ConvertToUserInfo(userEntity,userLogOnEntity);
                userInfo.IPAddress = ipAddress;
                userInfo.MACAddress = macAddress;
                userInfo.Password = password;
                // 这里是判断用户是否为系统管理员的
                userInfo.IsAdministrator = IsAdministrator(userEntity);
                // 数据找到了，就可以退出循环了
                /*
                // 获得员工的信息
                if (userEntity.IsStaff == 1)
                {
                    PiStaffManager staffManager = new PiStaffManager(DBProvider, UserInfo);
                    //这里需要按 员工的用户ID来进行查找对应的员工-用户关系
                    PiStaffEntity staffEntity = new PiStaffEntity(staffManager.GetDT(PiStaffTable.FieldUserId, userEntity.Id));
                    if (!string.IsNullOrEmpty(staffEntity.Id))
                    {
                        userInfo = staffManager.ConvertToUserInfo(staffEntity, userInfo);
                    }

                }*/
            }

            // 14. 记录系统访问日志
            if (this.ReturnStatusCode == StatusCode.OK.ToString())
            {
                //LogManager.Instance.Add(DBProvider, userEntity.Id.ToString(), userEntity.RealName, "LogOn", RDIFrameworkMessage.UserManager, "LogOn", RDIFrameworkMessage.UserManager_LogOn, userEntity.RealName, ipAddress, RDIFrameworkMessage.UserManager_LogOnSuccess);
                if (string.IsNullOrEmpty(userInfo.OpenId))
                {
                    createNewOpenId = true;
                }
                if (createNewOpenId)
                {
                    userInfo.OpenId = userLogOnManager.UpdateVisitDate(userEntity.Id.ToString(), createNewOpenId);
                }
                else
                {
                    userLogOnManager.UpdateVisitDate(userEntity.Id.ToString());
                }
            }
            else
            {
                //LogManager.Instance.Add(DBProvider, userName, realName, "LogOn", RDIFrameworkMessage.UserManager, "LogOn", RDIFrameworkMessage.UserManager_LogOn, userName, ipAddress, RDIFrameworkMessage.MSG0090);
            }
            return userInfo;
        }
        #endregion

        #region public bool ValidateUser(string userName, string password) 进行密码验证
        /// <summary>
        /// 进行密码验证
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>是否通过验证</returns>
        public bool ValidateUser(string userName, string password)
        {
            // 先按用户名登录
            var dt = this.GetDT(new KeyValuePair<string, object>(PiUserTable.FieldUserName, userName)
                , new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0)
                , new KeyValuePair<string, object>(PiUserTable.FieldEnabled, 1));

            if (dt.Rows.Count == 0)
            {
                // 若没数据再按工号登录
                dt = this.GetDT(new KeyValuePair<string, object>(PiUserTable.FieldCode, userName)
                    , new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0)
                    , new KeyValuePair<string, object>(PiUserTable.FieldEnabled, 1));

                if (dt.Rows.Count == 0)
                {
                    // 若没数据再按邮件登录
                    dt = this.GetDT(new KeyValuePair<string, object>(PiUserTable.FieldEmail, userName)
                        , new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0)
                        , new KeyValuePair<string, object>(PiUserTable.FieldEnabled, 1));
                }
                
                if (dt.Rows.Count == 0)
                {
                    // 若没数据再按手机号码登录
                    dt = this.GetDT(new KeyValuePair<string, object>(PiUserTable.FieldMobile, userName)
                        , new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0)
                        , new KeyValuePair<string, object>(PiUserTable.FieldEnabled, 1));
                }
                
                if (dt.Rows.Count == 0)
                {
                    // 若没数据再按手机号码登录
                    dt = this.GetDT(new KeyValuePair<string, object>(PiUserTable.FieldTelephone, userName)
                        , new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0)
                        , new KeyValuePair<string, object>(PiUserTable.FieldEnabled, 1));
                }
            }

            PiUserEntity userEntity = null;
            PiUserLogOnEntity userLogOnEntity = null;
            var parameters = new List<KeyValuePair<string, object>>();
            if (dt.Rows.Count > 1)
            {
                return false;
            }
            else if (dt.Rows.Count == 1)
            {
                // 05. 判断密码，是否允许登录，是否离职是否正确
                userEntity = BaseEntity.Create<PiUserEntity>(dt.Rows[0]);//new PiUserEntity(dt.Rows[0]);                
                if (!string.IsNullOrEmpty(userEntity.AuditStatus)
                    && userEntity.AuditStatus.EndsWith(AuditStatus.WaitForAudit.ToString())
                    && userLogOnEntity.PasswordErrorCount == 0)
                {
                    return false;
                }
                PiUserLogOnManager userLogOnManager = new PiUserLogOnManager(this.DBProvider, this.UserInfo);
                userLogOnEntity = userLogOnManager.GetEntity(userEntity.Id);
                // 06. 允许登录时间是否有限制
                if (userLogOnEntity.AllowEndTime != null)
                {
                    userLogOnEntity.AllowEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, userLogOnEntity.AllowEndTime.Value.Hour, userLogOnEntity.AllowEndTime.Value.Minute, userLogOnEntity.AllowEndTime.Value.Second);
                }
                if (userLogOnEntity.AllowStartTime != null)
                {
                    userLogOnEntity.AllowStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, userLogOnEntity.AllowStartTime.Value.Hour, userLogOnEntity.AllowStartTime.Value.Minute, userLogOnEntity.AllowStartTime.Value.Second);
                    if (DateTime.Now < userLogOnEntity.AllowStartTime)
                    {
                        return false;
                    }
                }
                if (userLogOnEntity.AllowEndTime != null)
                {
                    if (DateTime.Now > userLogOnEntity.AllowEndTime)
                    {
                        return false;
                    }
                }

                // 07. 锁定日期是否有限制
                if (userLogOnEntity.LockStartDate != null)
                {
                    if (DateTime.Now > userLogOnEntity.LockStartDate)
                    {
                        if (userLogOnEntity.LockEndDate == null || DateTime.Now < userLogOnEntity.LockEndDate)
                        {
                            return false;
                        }
                    }
                }
                if (userLogOnEntity.LockEndDate != null)
                {
                    if (DateTime.Now < userLogOnEntity.LockEndDate)
                    {
                        return false;
                    }
                }

                // 03. 系统是否采用了密码加密策略？
                if (SystemInfo.EnableEncryptServerPassword)
                {
                    password = this.EncryptUserPassword(password);
                }

                // 11. 密码是否正确(null 与空看成是相等的)
                if (!(string.IsNullOrEmpty(userLogOnEntity.UserPassword) && string.IsNullOrEmpty(password)))
                {
                    bool userPasswordOK = true;
                    // 用户密码是空的
                    if (string.IsNullOrEmpty(userLogOnEntity.UserPassword))
                    {
                        // 但是输入了不为空的密码
                        if (!string.IsNullOrEmpty(password))
                        {
                            userPasswordOK = false;
                        }
                    }
                    else
                    {
                        // 用户的密码不为空，但是用户是输入了密码
                        userPasswordOK = !string.IsNullOrEmpty(password) && userLogOnEntity.UserPassword.Equals(password);
                    }
                    // 用户的密码不相等
                    if (!userPasswordOK)
                    {
                        // 这里更新用户连续输入错误密码次数
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion
    }
}

//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;

namespace RDIFramework.Utilities
{
	/// <summary>
	/// UserInfo
	/// 用户类
	/// 
	/// 修改纪录
	/// 
	///     2015-04-11 EricHu 版本：2.9 转为自动属性。
    ///     2013.12.20 EricHu 版本: 2.7 对属性增加了说明。
	///		2011.09.12 EricHu 版本：2.1 公司名称、部门名称、工作组名称进行重构。
	///		2011.05.11 EricHu 版本：2.0 增加安全通讯用户名、密码。
	///		2008.08.26 EricHu 版本：1.2 整理主键。
	///		2006.05.03 EricHu 版本：1.1 添加到工程项目中。
	///		2006.01.21 EricHu 版本：1.0 远程传递参数用属性才可以。
	///		
	/// 版本：3.0
	///
	/// <author>
	///		<name>EricHu</name>
	///		<date>2011.09.12</date>
	/// </author> 
	/// </summary>
    [Serializable]
	public class UserInfo
	{
		public UserInfo()
		{
		    CompanyId = null;
		    ServicePassword = "RDIFramework";
		    ServiceUserName = "RDIFramework";
		    SecurityLevel = 0;
		    RoleId = null;
		    WorkgroupId = null;
		    DepartmentId = null;
		    SubCompanyId = null;
		    this.GetUserInfo();
		}

	    /// <summary>
	    /// 远程调用Service用户名（为了提高软件的安全性）
	    /// </summary>		
	    public string ServiceUserName { get; set; }

	    /// <summary>
	    /// 远程调用Service密码（为了提高软件的安全性）
	    /// </summary>        
	    public string ServicePassword { get; set; }

	    /// <summary>
	    /// 单点登录唯一识别标识
	    /// </summary>		
	    public string OpenId { get; set; }

	    /// <summary>
	    /// 目标用户
	    /// </summary>		
	    public string TargetUserId { get; set; }

	    /// <summary>
	    /// 用户主键
	    /// </summary>		
	    public string Id { get; set; }

	    /// <summary>
	    /// 员工主键
	    /// </summary>		
	    public string StaffId { get; set; }

	    /// <summary>
	    /// 用户用户名
	    /// </summary>		
	    public string UserName { get; set; }

	    /// <summary>
	    /// 用户姓名
	    /// </summary>		
	    public string RealName { get; set; }

	    /// <summary>
	    /// 编号
	    /// </summary>		
	    public string Code { get; set; }

	    /// <summary>
	    /// 当前的组织结构公司主键
	    /// </summary>		
	    public string CompanyId { get; set; }

	    /// <summary>
	    /// 当前的组织结构公司编号
	    /// </summary>		
	    public string CompanyCode { get; set; }

	    /// <summary>
	    /// 当前的组织结构公司名称
	    /// </summary>		
	    public string CompanyName { get; set; }

	    /// <summary>
	    /// 当前的组织结构子公司主键
	    /// </summary>		
	    public string SubCompanyId { get; set; }

	    /// <summary>
	    /// 当前的组织结构子公司编号
	    /// </summary>		
	    public string SubCompanyCode { get; set; }

	    /// <summary>
	    /// 当前的组织结构子公司名称
	    /// </summary>		
	    public string SubCompanyName { get; set; }


	    /// <summary>
	    /// 当前的组织结构部门主键
	    /// </summary>		
	    public string DepartmentId { get; set; }

	    /// <summary>
	    /// 当前的组织结构部门编号
	    /// </summary>		
	    public string DepartmentCode { get; set; }

	    /// <summary>
	    /// 当前的组织结构部门名称
	    /// </summary>
	    public string DepartmentName { get; set; }

	    /// <summary>
	    /// 当前的组织结构工作组主键
	    /// </summary>
	    public string WorkgroupId { get; set; }

	    /// <summary>
	    /// 当前的组织结构工作组编号
	    /// </summary>		
	    public string WorkgroupCode { get; set; }

	    /// <summary>
	    /// 当前的组织结构工作组名称
	    /// </summary>		
	    public string WorkgroupName { get; set; }

	    /// <summary>
	    /// 默认角色
	    /// </summary>		
	    public string RoleId { get; set; }

	    /// <summary>
	    /// 安全级别
	    /// </summary>		
	    public int SecurityLevel { get; set; }

	    /// <summary>
	    /// 默认角色名称
	    /// </summary>		
	    public string RoleName { get; set; }

	    /// <summary>
	    /// 是否超级管理员
	    /// </summary>		
	    public bool IsAdministrator { get; set; }

	    /// <summary>
	    /// 密码
	    /// </summary>		
	    public string Password { get; set; }

	    /// <summary>
	    /// IP地址
	    /// </summary>		
	    public string IPAddress { get; set; }

	    /// <summary>
	    /// MAC地址
	    /// </summary>		
	    public string MACAddress { get; set; }

	    /// <summary>
	    /// 当前语言选择
	    /// </summary>		
	    public string CurrentLanguage { get; set; }

	    /// <summary>
	    /// 当前布局风格选择
	    /// </summary>		
	    public string Themes { get; set; }


	    /// <summary>
	    /// 进程名称
	    /// </summary>
	    public string ProcessName { get; set; }

	    /// <summary>
	    /// 进程ID
	    /// </summary>
	    public string ProcessId { get; set; }

	    /// <summary>
	    /// 最后一次访问时间
	    /// </summary>
	    public string LastVisit { get; set; }

	    #region public void GetUserInfo()
		/// <summary>
		/// 获取信息
		/// </summary>
		public void GetUserInfo()
		{
			this.ServiceUserName = SystemInfo.ServiceUserName;
			this.ServicePassword = SystemInfo.ServicePassword;
			this.CurrentLanguage = SystemInfo.CurrentLanguage;
			this.Themes = SystemInfo.Themes;
		}
		#endregion
	}
}
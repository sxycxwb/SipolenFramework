﻿#region RDIFramework.NET-generated
//------------------------------------------------------------------------------
//     RDIFramework.NET（.NET快速信息化系统开发、整合框架）是基于.NET的快速信息化系统开发、整合框架，给用户和开发者最佳的.Net框架部署方案。
//     RDIFramework.NET平台包含基础公共类库、强大的权限控制、模块分配、数据字典、自动升级、各商业级控件库、工作流平台、代码生成器、开发辅助
//工具等，应用系统的各个业务功能子系统，在系统体系结构设计的过程中被设计成各个原子功能模块，各个子功能模块按照业务功能组织成单独的程序集文
//件，各子系统开发完成后，由RDIFramework.NET平台进行统一的集成部署。
//
//	框架官网：http://www.rdiframework.net/
//	框架博客：http://blog.rdiframework.net/
//	交流QQ：406590790 
//	邮件交流：406590790@qq.com
//	其他博客：
//    http://www.cnblogs.com/huyong 
//    http://blog.csdn.net/chinahuyong
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由RDIFramework.NET平台代码生成工具自动生成。
//     运行时版本:4.0.30319.1
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
#endregion

using System;
using System.ComponentModel;

namespace RDIFramework.BizLogic
{
      using RDIFramework.Utilities;

     /// <summary>
     /// PiModuleEntity
     /// 模块（菜单）表
     ///
     /// 修改纪录
    ///         2015-06-18 版本：3.0 XuWangBin 新增MVCNAVIGATEURL
    ///         2014-07-30 版本: 2.8 XuWangBin 以自动属性进行重新组织。
     ///		2012-03-02 版本：1.0 XuWangBin 创建主键。
     ///
     /// 版本：3.0
     ///
     /// <author>
     ///		<name>XuWangBin</name>
     ///		<date>2012-03-02</date>
     /// </author>
     /// </summary>
    [Serializable]
    public partial class PiModuleEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// 父节点主键
        /// </summary>
        [DisplayName("ParentId")]
        public String ParentId { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public String FullName { get; set; }

        /// <summary>
        /// 菜单分类
        /// </summary>
        public String Category { get; set; }

        /// <summary>
        /// 模块类型（1：WinForm、2：WebForm、3：WinForm与WebForm都支持（默认）、6：其他）
        /// </summary>
        public int? ModuleType { get; set; }

        /// <summary>
        /// 图标编号
        /// </summary>
        public String ImageIndex { get; set; }

        /// <summary>
        /// 选中状态图标编号
        /// </summary>
        public String SelectedImageIndex { get; set; }

        /// <summary>
        /// 一个CSS样式来显示一个16*16 的ICON（针对WebForm结构）
        /// </summary>
        public String IconCss { get; set; }

        /// <summary>
        /// 图标地址（针对WebForm结构）
        /// </summary>
        public String IconUrl { get; set; }

        /// <summary>
        /// 导航地址
        /// </summary>
        public String NavigateUrl { get; set; }

        /// <summary>
        /// MVC导航地址
        /// </summary>
        public String MvcNavigateUrl { get; set; }

        /// <summary>
        /// 目标（针对WinForm结构）
        /// </summary>
        public String Target { get; set; }

        /// <summary>
        /// 窗体名称（针对WinForm结构）
        /// </summary>
        public String FormName { get; set; }

        /// <summary>
        /// 程序集名称（针对WinForm结构）
        /// </summary>
        public String AssemblyName { get; set; }

        /// <summary>
        /// 操作权限编号(数据权限范围)
        /// </summary>
        public String PermissionItemCode { get; set; }

        /// <summary>
        /// 需要数据权限过滤的表(,符号分割)
        /// </summary>
        public String PermissionScopeTables { get; set; }

        /// <summary>
        /// 是公开
        /// </summary>
        public int? IsPublic { get; set; }

        /// <summary>
        /// 是菜单
        /// </summary>
        public int? IsMenu { get; set; }

        /// <summary>
        /// 展开状态
        /// </summary>
        public int? Expand { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        public int? AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        public int? AllowDelete { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DeleteMark { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public String CreateUserId { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public String CreateBy { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 修改用户主键
        /// </summary>
        public String ModifiedUserId { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public String ModifiedBy { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PiModuleEntity()
        {
            this.Category = "Application";
            this.ModuleType = 3;
            this.PermissionItemCode = "Resource.AccessPermission";
            this.NavigateUrl = "#";
            this.MvcNavigateUrl = "#";
            this.IsPublic = 0;
            this.IsMenu = 0;
            this.AllowDelete = 0;
            this.Expand = 0;
            this.AllowEdit = 0;
            this.Enabled = 0;
            this.DeleteMark = 0;
            this.SortCode = null;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.Id = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldId]);
            this.ParentId = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldParentId]);
            this.Code = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldCode]);
            this.FullName = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldFullName]);
            this.Category = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldCategory]);
            this.ModuleType = BusinessLogic.ConvertToNullableInt(dataRow[PiModuleTable.FieldModuleType]);
            this.ImageIndex = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldImageIndex]);
            this.SelectedImageIndex = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldSelectedImageIndex]);
            this.NavigateUrl = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldNavigateUrl]);
            this.MvcNavigateUrl = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldMvcNavigateUrl]);
            this.Target = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldTarget]);
            this.IconCss = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldIconCss]);
            this.IconUrl = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldIconUrl]);
            this.FormName = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FiledFormName]);
            this.AssemblyName = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FiledAssemblyName]);
            this.PermissionItemCode = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldPermissionItemCode]);
            this.PermissionScopeTables = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldPermissionScopeTables]);
            this.IsPublic = BusinessLogic.ConvertToNullableInt(dataRow[PiModuleTable.FieldIsPublic]);
            this.IsMenu = BusinessLogic.ConvertToNullableInt(dataRow[PiModuleTable.FieldIsMenu]);
            this.Expand = BusinessLogic.ConvertToNullableInt(dataRow[PiModuleTable.FieldExpand]);
            this.AllowEdit = BusinessLogic.ConvertToNullableInt(dataRow[PiModuleTable.FieldAllowEdit]);
            this.AllowDelete = BusinessLogic.ConvertToNullableInt(dataRow[PiModuleTable.FieldAllowDelete]);
            this.SortCode = BusinessLogic.ConvertToNullableInt(dataRow[PiModuleTable.FieldSortCode]);
            this.DeleteMark = BusinessLogic.ConvertToNullableInt(dataRow[PiModuleTable.FieldDeleteMark]);
            this.Enabled = BusinessLogic.ConvertToNullableInt(dataRow[PiModuleTable.FieldEnabled]);
            this.Description = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldDescription]);
            this.CreateOn = BusinessLogic.ConvertToNullableDateTime(dataRow[PiModuleTable.FieldCreateOn]);
            this.CreateUserId = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldCreateUserId]);
            this.CreateBy = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldCreateBy]);
            this.ModifiedOn = BusinessLogic.ConvertToNullableDateTime(dataRow[PiModuleTable.FieldModifiedOn]);
            this.ModifiedUserId = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldModifiedUserId]);
            this.ModifiedBy = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldModifiedBy]);
            this.Enabled = this.Enabled ?? 0;
            this.IsPublic = this.IsPublic ?? 0;
            this.IsMenu = this.IsMenu ?? 0;
            this.Expand = this.Expand ?? 0;
            return this;
        }
    }
}

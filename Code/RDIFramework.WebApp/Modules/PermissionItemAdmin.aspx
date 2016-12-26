<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PermissionItemAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.PermissionItemAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="layout">
        <div region="west" iconCls="icon16_application_lightning" split="true" title="操作权限项" style="width:220px;padding: 5px" collapsible="false">
            <ul id="permissionItemTree"></ul>
        </div>
        <div region="center" title="操作权限项列表" iconCls="icon16_layout" style="padding: 2px; overflow: hidden">
            <div id="toolbar">
                <%=base.BuildToolBarButtons()%>
            </div>
             <table id="permissionitemGrid"></table>
        </div>
    </div>
    <script type="text/javascript" src="js/PermissionItemAdmin.js?v=3.0"></script>
</asp:Content>
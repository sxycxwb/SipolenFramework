<%@ Page Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="RolePermissionAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.RolePermissionAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content> 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="toolbar">
        <%=base.BuildToolBarButtons()%>
    </div>

   <table id="list"></table>   

   <script type="text/javascript" src="js/RolePermissionAdmin.js?v=3.0"></script>
   <script type="text/javascript" src="js/SetRolePermissionScope.js?v=3.0"></script>
   <script type="text/javascript" src="../Content/Scripts/Business/Search.js"></script> 
</asp:Content>
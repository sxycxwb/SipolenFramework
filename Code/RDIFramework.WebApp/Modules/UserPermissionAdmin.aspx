<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPermissionAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.UserPermissionAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content> 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="toolbar">
        <%=base.BuildToolBarButtons()%>
    </div>

   <table id="list"></table>   
    <script type="text/javascript" src="js/UserPermissionAdmin.js?v=3.0"></script>
    <script type="text/javascript" src="js/SetUserPermissionScope.js?v=3.0"></script>
    <script type="text/javascript" src="../Content/Scripts/Business/Search.js"></script>  
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="DBLinkAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.DBLinkAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
     <div id="toolbar">
        <%=base.BuildToolBarButtons()%>
    </div>


    <table id="dbLinkGrid"></table>

    <script type="text/javascript" src="js/DBLinkAdmin.js?v=30"></script>

</asp:Content>
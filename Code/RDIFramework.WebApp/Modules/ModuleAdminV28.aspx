<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="ModuleAdminV28.aspx.cs" Inherits="RDIFramework.WebApp.Modules.ModuleAdminV28" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
     <div id="toolbar">
        <%=base.BuildToolBarButtons()%>
    </div>


    <table id="navGrid"></table>
    
    <script type="text/javascript" src="../Content/Scripts/Linqjs/linq.min.js"></script>
    <script type="text/javascript" src="../Content/Scripts/Linqjs/linq.jquery.js"></script>
    <script type="text/javascript" src="js/ModuleAdminV28.js?v=29"></script>

</asp:Content>
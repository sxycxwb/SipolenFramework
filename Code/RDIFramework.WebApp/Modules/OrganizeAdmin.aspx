<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrganizeAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.OrganizeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
     <div id="toolbar">
        <%=base.BuildToolBarButtons()%>
    </div>


    <table id="organizeGrid"></table>

 
    <script type="text/javascript" src="js/OrganizeAdmin.js?v=3.0"></script>
    

</asp:Content>
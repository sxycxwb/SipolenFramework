<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExceptionAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.ExceptionAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content> 

<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="toolbar"><%=base.BuildToolBarButtons()%></div>
    <!--用于数据显示-->    
    <table id="list"></table>    
    <div id="w"></div>
     
    <script type="text/javascript" src="js/ExceptionAdmin.js?v=30"></script>
    <script type="text/javascript" src="../Content/Scripts/Business/exportutil.js"></script>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserFormAdmin.aspx.cs" Inherits="RDIFramework.WebApp.WorkFlow.UserFormAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="layout">
        <div region="west" iconCls="icon16_chart_organisation" split="true" title="表单列表树" style="width:220px;padding: 5px" collapsible="false">
            <ul id="formtree"></ul>
        </div>
        <div region="center" title="表单管理" iconCls="icon16_form" style="padding: 2px; overflow: hidden">
            <table id="list"></table>
        </div>
    </div>   
    <script type="text/javascript" src="../Content/Scripts/Linqjs/linq.min.js"></script>
    <script type="text/javascript" src="../Content/Scripts/Linqjs/linq.jquery.js"></script>
    <script type="text/javascript" src="js/UserFormAdmin.js?v=30"></script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QueryEngineAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.QueryEngineAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="layout">
        <div region="west" iconCls="icon16_chart_organisation" split="true" title="查询引擎树" style="width:260px;padding: 5px" collapsible="false">
            <ul id="queryEngineTree"></ul>
        </div>
        <div region="center" title="查询引擎列表" iconCls="icon16_layout" style="padding: 2px; overflow: hidden">
            <div id="toolbar">
                <%=base.BuildToolBarButtons()%>
            </div>
                <table id="queryEngineGrid"></table>
        </div>
    </div> 

    <script type="text/javascript" src="../Content/Scripts/Linqjs/linq.min.js"></script>
    <script type="text/javascript" src="../Content/Scripts/Linqjs/linq.jquery.js"></script>
    <script type="text/javascript" src="js/QueryEngine.js?v=30"></script>
</asp:Content>

﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="ModuleAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.ModuleAdmin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="layout">
         <div region="west" iconCls="icon16_chart_organisation" split="true" title="导航目录" style="width:220px;padding: 5px" collapsible="false">
            <ul id="moduleTree"></ul>
        </div>
        <div region="center" title="模块（菜单）列表" iconCls="icon16_layout" style="padding: 2px; overflow: hidden">
            <div id="toolbar">
                <%=base.BuildToolBarButtons()%>
            </div>
             <table id="moduleGrid"></table>
        </div>
    </div>
 
    <script type="text/javascript" src="../Content/Scripts/Linqjs/linq.min.js"></script>
    <script type="text/javascript" src="../Content/Scripts/Linqjs/linq.jquery.js"></script>
    <script type="text/javascript" src="js/ModuleAdmin.js?v=30"></script>

</asp:Content>
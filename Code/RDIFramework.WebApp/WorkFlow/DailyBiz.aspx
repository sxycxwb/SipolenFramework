﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DailyBiz.aspx.cs" Inherits="RDIFramework.WebApp.WorkFlow.DailyBiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        div#navigation{background:white}
        div#wrapper{float:right;width:100%;margin-left:-185px}
        div#content{margin-left:185px}
        div#navigation{float:left;width:180px}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="layout">
        <div region="west" iconCls="icon16_calendar" split="true" title="可用业务" style="width:220px;padding: 5px" collapsible="false">
            <ul id="myWFBizTree"></ul>
        </div>
        <div region="center" title="日常任务管理" iconCls="icon16_calendar" style="padding: 2px; overflow: hidden">
            <div id="toolbar">
                <a id="startTask" class="easyui-linkbutton" style="float:left"  plain="true" icon="icon16_open_suse"  title="开始任务">开始任务</a>
               <%--<%=base.BuildToolBarButtons()%>         --%>      
            </div>
            <table id="taskList" toolbar="#toolbar"></table>
        </div>
    </div>
    <script type="text/javascript" src="js/DailyBizAdmin.js?v=30"></script>
</asp:Content>

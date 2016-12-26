<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.PostAdmin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"> 
    <style type="text/css">
        div#navigation{background:white}
        div#wrapper{float:right;width:100%;margin-left:-185px}
        div#content{margin-left:185px}
        div#navigation{float:left;width:180px}
    </style>
</asp:Content> 

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">  
    <div id="layout">
            <div region="west" iconCls="icon16_chart_organisation" split="true" title="组织机构" style="width:220px;padding: 5px" collapsible="false">
                <ul id="organizeTree"></ul>
            </div>
            <div region="center" title="岗位列表" iconCls="icon16_list" style="padding: 2px; overflow: hidden">
                <div id="toolbar">
                   <%=base.BuildToolBarButtons()%>               
                </div>
                <table id="postlist" toolbar="#toolbar"></table>
            </div>
    </div>
    <script type="text/javascript" src="js/PostAdmin.js?v=3.0"></script>
</asp:Content>
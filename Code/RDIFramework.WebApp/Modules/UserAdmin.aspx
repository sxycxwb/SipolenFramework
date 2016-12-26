<%@ Page Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true"CodeBehind="UserAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.UserAdmin" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"> 
    <script type="text/javascript">
        var curUserinfo = { "id": '<%=base.UserInfo.Id %>', "name": '<%=base.UserInfo.RealName %>', "username": '<%=base.UserInfo.UserName %>' };
        $(function () {
            $('#a1').linkbutton('disable');
        });
    </script>
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
        <div region="center" title="用户列表" iconCls="icon16_list" style="padding: 2px; overflow: hidden">
             <div id="toolbar">
                <div style="float: left;padding-top:1px;">
                    <%=base.BuildToolBarButtons()%>
                    <div class='datagrid-btn-separator'></div>
                    <div style="float: right; padding-bottom:1px;">
                         搜索值：<input type="text" name="SearchValue" id="txtSearchValue" class="txt03" style="width: 150px;"/>
                        <a id="btnSearch" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_filter" title="查询">查询</a>
                    </div>
                </div>
            </div>
            <div>
                <table id="userlist" toolbar="#toolbar"></table>
            </div>
         </div>
    </div>
    <script type="text/javascript" src="../Content/Scripts/Business/exportutil.js"></script>
    <script type="text/javascript" src="../Content/Scripts/Business/Search.js"> </script>
    <script type="text/javascript" src="js/UserAdmin.js?v=3.0"></script>
</asp:Content>
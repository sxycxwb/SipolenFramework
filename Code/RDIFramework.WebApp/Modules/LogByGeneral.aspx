﻿<%@ Page Title="系统日志" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LogByGeneral.aspx.cs" Inherits="RDIFramework.WebApp.Modules.LogByGeneral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var __c_uinfo = { "id": '<%=base.UserInfo.Id %>', "name": '<%=base.UserInfo.RealName %>' };
    </script>
</asp:Content> 

<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="searchArea">
        <a id="btnRefreash" href="javascript:;" plain="true" style="float: left;" class="easyui-linkbutton" icon="icon16_arrow_refresh" title="重新加载">刷新</a>
        <a id="btnExport" href="javascript:;" plain="true" style="float: left;" class="easyui-linkbutton" icon="icon16_table_export" title="导出">导出</a>
        <div style="float: left;" class='datagrid-btn-separator'></div>  
        <a id="btnClose" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_door_out" title="离开">离开</a>
    </div>  
    <!--用于数据显示-->    
    <table id="list"></table> 
    <script type="text/javascript" src="../Content/Scripts/Business/exportutil.js"></script>
    <script type="text/javascript">
        var grd;
        $(function () {
            autoResize({ dataGrid: '#list', gridType: 'datagrid', callback: mygrid.databind, height: 25 });
            $('#toolbar').css({
                height: '60px'
            });
            $('#btnRefreash').attr('onclick', 'RefreashData();');
            $('#btnExport').attr('onclick', 'ExportData();');
            $('#btnClose').attr('onclick', 'CloseWindow();');
        });

        var mygrid = {
            databind: function (size) {
                grd = $('#list').datagrid({
                    url: 'handler/LogAdminHandler.ashx?action=GetPageListLogByGeneral',
                    toolbar: '#toolbar',
                    width: size.width,
                    height: size.height - 5,
                    idField: 'ID',
                    sortName: 'CREATEON',
                    sortOrder: 'desc',
                    striped: true,
                    pagination: true,
                    singleSelect: false,
                    selectOnCheck: true,
                    checkOnSelect: true,
                    onRowContextMenu: pageContextMenu.createDataGridContextMenu,
                    pageSize: 20,
                    pageList: [20, 10, 30, 50],
                    frozenColumns: [[
                        { field: 'ck', checkbox: true },
                        { title: '用户名', field: 'USERNAME', width: 100 },
                        { title: '姓名', field: 'REALNAME', width: 100 },
                        { title: '部门', field: 'DEPARTMENTNAME', width: 100 }
                    ]],
                    columns: [[
                    { title: '可见', field: 'ISVISIBLE', align: "center", width: 30, formatter: ImageCheckBox },
                    { title: '可用', field: 'ENABLED', align: "center", width: 30, formatter: ImageCheckBox },
                    { title: '限制IP', field: 'CHECKIPADDRESS', align: "center", width: 50, formatter: ImageCheckBox },
                    { title: '多点登录', field: 'MULTIUSERLOGIN', align: "center", width: 50, formatter: ImageCheckBox },
                    { title: '在线', field: 'USERONLINE', align: "center", width: 30, formatter: ImageCheckBox },
                    { title: '首次访问', field: 'FIRSTVISIT', width: 150 },
                    { title: '上次访问', field: 'PREVIOUSVISIT', width: 150 },
                    { title: '最后访问', field: 'LASTVISIT', width: 150 },
                    { title: '登录次数', field: 'LOGONCOUNT', width: 60 },
                    { title: 'IP地址', field: 'IPADDRESS', width: 110 },
                    { title: 'MAC地址', field: 'MACADDRESS', width: 130 },
                    { title: '描述', field: 'DESCRIPTION', width: 300 }
                    ]],
                    onDblClickRow: function (rowIndex, rowData) {
                        showLogInfo(rowData);
                    }
                });
            },
            reload: function () {
                grd.datagrid('reload', {});
            }
        };
        
        var RefreashData = function () {
            mygrid.reload();
        };
        
        var ExportData = function () {
            var exportData = new ExportExcel('list');
            exportData.go(' PIUSER LEFT OUTER JOIN PIUSERLOGON ON PIUSER.ID = PIUSERLOGON.ID ', 'SORTCODE');
        };

        var CloseWindow = function () {
            var currTopTab = top.$('#tabs');
            var currtabTitle = currTopTab.tabs('getSelected').panel('options').title;
            currTopTab.tabs('close', currtabTitle);
        };
    </script>
</asp:Content>

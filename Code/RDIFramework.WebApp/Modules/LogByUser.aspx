﻿<%@ Page Title="系统日志" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LogByUser.aspx.cs" Inherits="RDIFramework.WebApp.Modules.LogByUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var __c_uinfo = { "id": '<%=base.UserInfo.Id %>', "name": '<%=base.UserInfo.RealName %>' };
    </script>
</asp:Content> 

<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="searchArea">			
		操作用户：<input type="text" name="opuser" id="txtOpuser" class="txt03" style="width: 120px;"/>&nbsp;
		操作日期：<input type="text" id="dtOpstart"/> 至 <input type="text" id="dtOpend"/>&nbsp;
		IP地址：<input type="text" id="txtIpAddress" name="IpAddress" class="txt03" style="width: 100px;"/>    
		<a id="btnSearch" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_filter" title="查询">查询</a>  
	</div>  
	<div id="toolbar">
		<div>
			<%=base.BuildToolBarButtons()%>   
            <div style="float: left;" class='datagrid-btn-separator'></div>  
            <a id="btnClose" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_door_out" title="离开">离开</a> 
		</div>
    </div>
    <!--用于数据显示-->    
    <table id="list"></table> 
    <script type="text/javascript" src="../Content/Scripts/Business/exportutil.js"></script>
    <script type="text/javascript">
        var grd;

        $(function () {
            autoResize({ dataGrid: '#list', gridType: 'datagrid', callback: mygrid.databind, height: 25 });
            $('#dtOpstart,#dtOpend').datebox({ width: 100 });
            //$('#dtOpend').datebox('setValue', '2014-12-02'); 设置默认日期
            $('#btnDelete').attr('onclick', 'DeleteLog();');
            $('#btnDeleteAll').attr('onclick', 'ClearLog();');
            $('#btnRefresh').attr('onclick', 'Refreash();');
            $('#btnSearch').attr('onclick', 'Search();');
            $('#btnExport').attr('onclick', 'ExportData();');
            $('#btnClose').attr('onclick', 'CloseWindow();');
            $('#toolbar').css({
                height: '60px'
            });
        });

        var mygrid = {
            databind: function (size) {
                grd = $('#list').datagrid({
                    url: 'handler/LogAdminHandler.ashx?action=GetPageListLogByUser',
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
                    columns: [[
                    { field: 'ck', checkbox: true },
                    { title: '发生日期', field: 'CREATEON', width: 150 },
                    { title: '用户', field: 'CREATEBY', width: 90 },
                    { title: 'IP地址', field: 'IPADDRESS', width: 80 },
                    { title: '服务名称', field: 'PROCESSNAME', width: 120 },
                    { title: '方法名称', field: 'METHODENGNAME', width: 130 },
                    { title: '参数', field: 'PARAMETERS', width: 120 },
                    { title: '操作内容', field: 'METHODNAME', width: 200 },
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

        function Search() {
            var opUser = $('#txtOpuser').val();
            var dtOpstart = $('#dtOpstart').datebox('getValue');
            var dtOpend = $('#dtOpend').datebox('getValue');
            var opIpaddress = $('#txtIpAddress').val();
            var ruleArr = [];
            if (opUser !== '')
                ruleArr.push({ "field": "USERREALNAME", "op": "eq", "data": escape(opUser) });
            if (dtOpstart !== '')
                ruleArr.push({ "field": "CREATEON", "op": "ge", "data": dtOpstart });
            if (dtOpend !== '')
                ruleArr.push({ "field": "CREATEON", "op": "le", "data": dtOpend });
            if (opIpaddress !== '0' && opIpaddress !== '')
                ruleArr.push({ "field": "IPADDRESS", "op": "eq", "data": opIpaddress });

            if (ruleArr.length > 0) {
                var filterObj = { groupOp: 'AND', rules: ruleArr };
                $('#list').datagrid('load', { filter: JSON.stringify(filterObj) });
            } else {
                mygrid.reload();
            }
        }

        var Refreash = function () {
            //mygrid.reload();
            Search();
        };

        var ExportData = function () {
            var exportData = new ExportExcel('list');
            exportData.go('CILOG', 'CREATEON');
        };

        //显示日志详细
        var showLogInfo = function (oLogInfo) {
            //弹窗
            top.$('#w').hWindow({ html: editFormHtml, width: 630, height: 439, title: '系统日志详细信息', iconCls: 'icon16_list', submit: function () { top.$('#w').window('close'); } });
            //初始化相关数据
            top.$('#txtUserName').val(oLogInfo.CREATEBY);
            top.$('#txtCreateOn').val(oLogInfo.CREATEON);
            top.$('#txtIPAddress').val(oLogInfo.IPADDRESS);
            top.$('#txtProcessName').val(oLogInfo.PROCESSNAME);
            top.$('#txtParameters').val(oLogInfo.PARAMETERS);
            top.$('#txtMethodName').val(oLogInfo.METHODNAME);
            top.$('#txtDescription').val(oLogInfo.DESCRIPTION);
        };

        //清空全部日志数据
        var ClearLog = function () {
            if (confirm('确定清空所有日志数据吗？')) {
                $.ajaxtext('handler/LogAdminHandler.ashx', "action=clearalllog", function (data) {
                    if (data == "1") {
                        msg.ok('清空日志数据成功！');
                        mygrid.reload();
                    }
                    else {
                        msg.warning(msg);
                    }
                });
            }
            return false;
        };

        //删除所选日志记录
        var DeleteLog = function () {
            var checkedItems = $('#list').datagrid('getChecked');
            var keys = [];
            $.each(checkedItems, function (index, item) {
                keys.push(item.ID);
            });

            if (keys.length > 0) {
                $.messager.confirm('询问提示', '确认删除所选日志记录吗？', function (data) {
                    if (data) {
                        $.ajaxtext('handler/LogAdminHandler.ashx', "action=deletelog&ids=" + keys.join(','), function (d) {
                            if (d == '1') {
                                msg.ok('所选日志删除成功！');
                                //mygrid.reload();
                                Search();
                            } else {
                                msg.warning(d);
                            }
                        });
                    }
                });
            } else {
                msg.warning('请选择要删除的日志记录。');
            }
            return false;
        };
        
        var CloseWindow = function () {
            var currTopTab = top.$('#tabs');
            var currtabTitle = currTopTab.tabs('getSelected').panel('options').title;
            currTopTab.tabs('close', currtabTitle);
        };

        var editFormHtml = '<form  id="uiform"><table class="grid2"  cellspacing=1 width=100%>';
        editFormHtml += '<tr><td>用户：</td><td><input  id="txtUserName"  name="UserName" required="true" type="text" class="txt03" /></td><td>发生日期：</td><td><input id="txtCreateOn" name="CreateOn"  required="true" type="text" class="txt03" /></td></tr>';
        editFormHtml += '<tr><td>IP地址：</td><td><input id="txtIPAddress" name="IPAddress"  required="true" type="text" class="txt03" /></td><td>模块名称：</td><td><input id="txtProcessName" name="ProcessName"  required="true" type="text" class="txt03" /></td></tr>';
        editFormHtml += '<tr><td>参数：</td><td colspan="3"><textarea  id="txtParameters" style="width:500px; height:30px;" name="PARAMETERS" class="txt03" /></td></tr>';
        editFormHtml += '<tr><td>操作内容：</td><td colspan="3"><textarea  id="txtMethodName" style="width:500px; height:60px;" name="MethodName" class="txt03" /></td></tr>';
        editFormHtml += '<tr><td>描述：</td><td colspan="3"><textarea  id="txtDescription" style="width:500px; height:150px;" name="Description" class="txt03" /></td></tr>';
        editFormHtml += '</table></form>';
    </script>
</asp:Content>

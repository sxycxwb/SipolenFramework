<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DyAssignNext.ascx.cs" Inherits="RDIFramework.WebApp.WorkFlow.Common.DyAssignNext" %>
<link rel="stylesheet" type="text/css" href="../../Content/css/common.css"/>  
<script type="text/javascript" language="javascript">
    var dyAssignNextGrid;
    function showSelectUser() {
        //alert(document.getElementById("tbDyAssignNext").style.display);
        //document.getElementById("tbDyAssignNext").style.display = "none";
        //$("#tbDyAssignNext").css('display', 'block');
        var tmpDialog = top.$.hDialog({
            content: '<div id="usercontent" style="width:100px;"></div>',
            width: 730,
            height: 580,
            title: '用户选择',
            iconCls: 'icon16_group_link',
            onOpen: function () {
                dyAssignNextGrid = top.$('#usercontent').datagrid({
                    url: '../Modules/handler/UserAdminHandler.ashx?action=GetUserListByPage',
                    singleSelect: true,
                    selectOnCheck: true,
                    checkOnSelect: true,
                    width: 700,
                    height: 500,
                    toolbar: "#tbDyAssignNext",
                    idField: 'ID',
                    sortName: 'SORTCODE',
                    sortOrder: 'asc',
                    pagination: true,
                    rownumbers: true,
                    pageSize: 50,
                    pageList: [20, 10, 30, 50],
                    rowStyler: function (index, row) {
                        if (row.ENABLED <= 0) {
                            return 'color:#999;'; //显示为灰色字体
                        }
                    },
                    columns: [[
                        { field: 'ck', checkbox: true },
                        { title: '编号', field: 'CODE', width: 150 },
                        { title: '登录名', field: 'USERNAME', width: 150, sortable: true },
                        { title: '用户名', field: 'REALNAME', width: 150 },
                        { title: '部门', field: 'DEPARTMENTNAME', width: 150 }
                    ]], onLoadSuccess: function (data) {
                        top.$("#tbDyAssignNext").css('display', 'block');
                    }
                });
            },
            submit: function () {
                var curSelectRow = top.$('#usercontent').datagrid('getSelected');
                if (curSelectRow) {
                    $('#txtUsers').val(curSelectRow.ID);
                    tmpDialog.dialog('close');
                } else {
                    tmpDialog.dialog('close');
                }
            }
        });
    };

    function doUserSearch() {
        var tmpUserName = top.$('#UserName').val();
        var tmpRealName = top.$('#RealName').val();
        var ruleArr = [];
        if (tmpUserName !== '')
            ruleArr.push({ "field": "USERNAME", "op": "cn", "data": escape(tmpUserName) });
        if (tmpRealName !== '')
            ruleArr.push({ "field": "REALNAME", "op": "cn", "data": escape(tmpRealName) });

        if (ruleArr.length > 0) {
            var filterObj = { groupOp: 'AND', rules: ruleArr };
            dyAssignNextGrid.datagrid('load', { filter: JSON.stringify(filterObj) });
        } else {
            dyAssignNextGrid.datagrid('reload');
        }
    };
</script>
<div id="tbDyAssignNext" style="padding:3px;display:none;">  
    <span>User Name:</span>  
    <input id="UserName" style="line-height:20px;border:1px solid #ccc">  
    <span>Real Name:</span>  
    <input id="RealName" style="line-height:20px;border:1px solid #ccc">  
    <a href="#" class="easyui-linkbutton" plain="true" onclick="doUserSearch()">Search</a>  
</div>
<table class="grid" style="width: 560px">
    <tr>
        <td style="width: 110px" >
            指定下一任务处理人:
        </td>
        <td style="width: 340px">
            <input id = "txtUsers" type="text" style="width:100%;" name="Users" class="txt03" readonly="readonly" value="<%=Request["currentUserIds"]%>"  />
        </td>
        <td style="width: 63px" >
            <input id="btnSelectUsers" type="button" value="选择用户" style="width: 61px" onclick="showSelectUser();" />
        </td>
    </tr>
</table>


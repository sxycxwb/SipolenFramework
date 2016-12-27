/*
RDIFramework.NET，基于.NET的快速信息化系统开发、整合框架，给用户和开发者最佳的.Net框架部署方案。
框架官网：http://www.rdiframework.net/
框架博客：http://blog.rdiframework.net/
交流QQ：406590790 
邮件交流：406590790@qq.com

其他博客：
    http://www.cnblogs.com/huyong 
    http://blog.csdn.net/chinahuyong
*************************************************************************************
* RDIFramework.NET框架“组织机构”业务界面逻辑
*
* 主要完成操作权限项的增加、修改、删除、移动、导出、用户或角色操作权限的设置等。
* 修改记录：
*   2、 2013-11-23 XuWangBin V2.7 重新设计本界面、改以前的Jqgrid为easy ui的datagrid、增加导出日志功能。
*   1、 2013-08-15 XuWangBin V2.5 新增本业务逻辑的编写。
*/
var grd;

$(function () {
    autoResize({ dataGrid: '#list', gridType: 'datagrid', callback: mygrid.databind, height: 25 });
    $('#dtOpstart,#dtOpend').datebox({ width: 100 });
    //$('#dtOpend').datebox('setValue', '2014-12-02'); 设置默认日期
    $('#btnDelete').attr('onclick', 'deleteLog();');
    $('#btnDeleteAll').attr('onclick', 'clearLog();');
    $('#btnRefresh').attr('onclick', 'Refreash();');
    $('#btnSearch').attr('onclick', 'search();');
    $('#btnExport').attr('onclick', 'ExportData();');
    $('#toolbar').css({
        height: '60px'
    });
});

var mygrid = {
    databind: function (size) {
        grd = $('#list').datagrid({
            url: 'handler/LogAdminHandler.ashx?action=GetList',
            toolbar: '#toolbar',
            width: size.width,
            height: size.height,
            idField: 'ID',
            sortName: 'CREATEON',
            sortOrder: 'desc',
            striped: true,
            pagination: true,
            singleSelect: false,
            selectOnCheck: true,
            checkOnSelect: true,
            onRowContextMenu:pageContextMenu.createDataGridContextMenu,
            pageSize: 20,
            pageList:[20,10,30,50],
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

function search() {
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

var Refreash = function() {
    mygrid.reload();
};

var ExportData = function() {
    var exportData = new ExportExcel('list');
    exportData.go('CILOG', 'CREATEON');
};

//显示日志详细
var showLogInfo = function (oLogInfo) {
    //弹窗
    top.$('#w').hWindow({ html: editFormHtml, width: 630, height: 439, title: '系统日志详细信息', iconCls: 'icon-list', submit: function () { top.$('#w').window('close'); } });
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
var clearLog = function () {
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
var deleteLog = function() {
    var checkedItems = $('#list').datagrid('getChecked');
    var keys = [];
    $.each(checkedItems, function(index, item) {
        keys.push(item.ID);
    });

    if (keys.length > 0) {
        $.messager.confirm('询问提示', '确认删除所选日志记录吗？', function(data) {
            if (data) {
                $.ajaxtext('handler/LogAdminHandler.ashx', "action=deletelog&ids=" + keys.join(','), function(d) {
                    if (d == '1') {
                        msg.ok('所选日志删除成功！');
                        mygrid.reload();
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

var editFormHtml = '<form  id="uiform"><table class="grid2"  cellspacing=1 width=100%>';
    editFormHtml += '<tr><td>用户：</td><td><input  id="txtUserName"  name="UserName" required="true" type="text" class="txt03" /></td><td>发生日期：</td><td><input id="txtCreateOn" name="CreateOn"  required="true" type="text" class="txt03" /></td></tr>';
    editFormHtml += '<tr><td>IP地址：</td><td><input id="txtIPAddress" name="IPAddress"  required="true" type="text" class="txt03" /></td><td>模块名称：</td><td><input id="txtProcessName" name="ProcessName"  required="true" type="text" class="txt03" /></td></tr>';
    editFormHtml += '<tr><td>参数：</td><td colspan="3"><textarea  id="txtParameters" style="width:500px; height:30px;" name="PARAMETERS" class="txt03" /></td></tr>';
    editFormHtml += '<tr><td>操作内容：</td><td colspan="3"><textarea  id="txtMethodName" style="width:500px; height:60px;" name="MethodName" class="txt03" /></td></tr>';
    editFormHtml += '<tr><td>描述：</td><td colspan="3"><textarea  id="txtDescription" style="width:500px; height:150px;" name="Description" class="txt03" /></td></tr>';
    editFormHtml += '</table></form>';
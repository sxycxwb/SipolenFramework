var str_uiFormHtml = '<form  id="uiform"><table class="grid2"  cellspacing=1 width=100%>';
str_uiFormHtml += '<tr><td>用户：</td><td><input  id="txtUserName"  name="UserName" required="true" type="text" class="txt03" /></td><td>发生日期：</td><td><input id="txtCreateOn" name="CreateOn"  required="true" type="text" class="txt03" /></td></tr>';
str_uiFormHtml += '<tr><td>IP地址：</td><td><input id="txtIPAddress" name="IPAddress"  required="true" type="text" class="txt03" /></td><td>模块名称：</td><td><input id="txtProcessName" name="ProcessName"  required="true" type="text" class="txt03" /></td></tr>';
str_uiFormHtml += '<tr><td>操作内容：</td><td colspan="3"><textarea  id="txtMethodName" style="width:500px; height:60px;" name="MethodName" class="txt03" /></td></tr>';
str_uiFormHtml += '<tr><td>描述：</td><td colspan="3"><textarea  id="txtDescription" style="width:500px; height:150px;" name="Description" class="txt03" /></td></tr>';
str_uiFormHtml += '</table></form>';

$(function () {
    autoResize({ dataGrid: '#list', callback: initList });
    $('#btnDelete').click(deleteLog);
    $('#btnDeleteAll').click(clearLog);
    $('#btnRefresh').click(reloadList);
});

var reloadList = function () {
    $("#list").trigger("reloadGrid", [{ page: 1}]);
};
var initList = function (size) {
    $('#list').jqGrid({
        url: "handler/LogAdminHandler.ashx?action=getlist",
        datatype: "json",
        autowidth: true,
        height: size.height,
        width: size.width,
        colNames: ["发生日期", "用户", "IP地址", "模块名称", "操作内容", "描述", "Id"],
        colModel: [
                    { name: "CREATEON", index: "CREATEON", align: "center", width: 70 },
                    { name: "CREATEBY", index: "CREATEBY", align: "center", width: 60 },
                    { name: "IPADDRESS", index: "IPADDRESS", align: "center", width: 70 },
                    { name: "PROCESSNAME", index: "PROCESSNAME", align: "left", width: 90 },
                    { name: "METHODNAME", index: "METHODNAME", align: "left", width: 150 },
                    { name: "DESCRIPTION", index: "DESCRIPTION", align: "left" },
                    { name: "ID", index: "ID", hidden: true }
                ],
        viewrecords: true,
        rowNum: 20,
        rowList: [10, 20, 30],
        sortname: "CREATEON",
        sortorder: "DESC",
        jsonReader: { repeatitems: false },
        pager: "#pager",
        caption: "<span class='icon icon-list'>系统操作日志列表</span>",
        hidegrid: false,
        ondblClickRow: function (rowid) {
            var logObj = jQuery('#list').jqGrid('getRowData', rowid);
            showLogInfo(logObj);
        }, multiselect: true
    });
};
//显示日志详细
var showLogInfo = function (oLogInfo) {
    //弹窗
    top.$('#w').hWindow({ html: str_uiFormHtml, width: 630, height: 410, title: '系统日志详细信息', iconCls: 'icon-list', submit: function () { top.$('#w').window('close'); } });
    //初始化相关数据
    top.$('#txtUserName').val(oLogInfo.CREATEBY);
    top.$('#txtCreateOn').val(oLogInfo.CREATEON);
    top.$('#txtIPAddress').val(oLogInfo.IPADDRESS);
    top.$('#txtProcessName').val(oLogInfo.PROCESSNAME);
    top.$('#txtMethodName').val(oLogInfo.METHODNAME);
    top.$('#txtDescription').val(oLogInfo.DESCRIPTION);
};
//清空全部日志数据
var clearLog = function () {
    if ($(this).linkbutton('options').disabled == true) {
        return;
    }
    if (confirm('确定清空所有日志数据吗？')) {
        $.ajaxtext('handler/LogAdminHandler.ashx', "action=clearalllog", function (msg) {
            if (msg == "1") {
                msg.ok('清空日志数据成功');
                reloadList();
            }
            else {
                alert(msg);
            }
        });
    }
};
//删除所选日志记录
var deleteLog = function () {
    if ($(this).linkbutton('options').disabled == true) {
        return;
    }
    var ids = '';
    var rows = $('#list').jqGrid('getGridParam', 'selarrrow');
    if (rows.length > 0) {
        jQuery.each(rows, function (i, n) {
            ids += $('#list').jqGrid('getRowData', n).ID + ',';
        });
        if (ids != '') {
            ids = ids.substr(0, ids.length - 1);
        }
    }

    if (ids != '') {
        $.messager.confirm('询问提示', '确认删除所选日志记录吗？', function (data) {
            if (data) {
                $.ajaxtext('handler/LogAdminHandler.ashx', "action=deletelog&ids=" + ids, function (msg) {
                    if (msg == '1') {
                        $.messager.alert('成功提示', '所选日志删除成功！');
                        reloadList();
                    } else {
                        $.messager.alert('错误提示', msg, 'error');
                    }
                });
            }
        });       
    }
    else {
        msg.warning('请选择要删除的日志记录');
    }
};
var _gridlist,
    actionURL = '/demo/handler/CaseProductInfo.ashx',
    formurl   = '/demo/html/Case_ProductInfoEdit.html';

$(function () {
    autoResize({ dataGrid: '#list', gridType: 'datagrid', callback: grid.bind, height: 5 });
    $('#a_add').attr('onclick', 'CRUD.add();');
    $('#a_edit').attr('onclick', 'CRUD.edit();');
    $('#a_delete').attr('onclick', 'CRUD.del();');
    $('#btnPrint').attr('onclick', 'CRUD.print();');
    $('#a_export').attr('onclick', 'CRUD.exportData();');
    $('#a_search').attr('onclick', 'CRUD.searchData();');
    $('#a_refresh').attr('onclick', 'CRUD.refreash();');
});

var grid = {
    bind: function (winSize) {
        _gridlist = $('#list').datagrid({
            url: actionURL,
            toolbar: '#toolbar',
            title: "产品列表",
            iconCls: 'icon16_table',
            width: winSize.width,
            height: winSize.height,
            nowrap: false, //折行
            rownumbers: true, //行号
            striped: true, //隔行变色
            idField: 'ID',//主键
            singleSelect: true, //单选
            onRowContextMenu: pageContextMenu.createDataGridContextMenu,
			onDblClickRow:function(rowIndex, rowData){
				document.getElementById('a_edit').click();
			},
            frozenColumns: [[
                { field: 'ck', checkbox: true },
                { title: '产品编码', field: 'PRODUCTCODE', width: 150 },
		        { title: '产品名称', field: 'PRODUCTNAME', width: 300 }
            ]],
            columns: [[
				{ title: '主键', field: 'ID', width: 120, hidden: true },		        
                { title: '产品型号', field: 'PRODUCTMODEL', width: 150 },
                { title: '产品规格', field: 'PRODUCTSTANDARD', width: 75 },
		        { title: '产品类别', field: 'PRODUCTCATEGORY', width: 70 },
                { title: '产品单位', field: 'PRODUCTUNIT', width: 63 },
                { title: '基准价', field: 'MIDDLERATE', width: 60 },
                { title: '基准系数', field: 'REFERENCECOEFFICIENT', width: 60 },
                { title: '单价', field: 'PRODUCTPRICE', width: 60 },
                { title: '批发价', field: 'WHOLESALEPRICE', width: 60 },
                { title: '促销价', field: 'PROMOTIONPRICE', width: 60 },
                { title: '内部价', field: 'INTERNALPRICE', width: 60 },
                { title: '特别价', field: 'SPECIALPRICE', width: 60 },
                {
                    title: '作废标志', field: 'ENABLED', width: 56,
                    align: 'center',
                    formatter: function (v, d, i) {
                        return '<img src="/Content/css/icon/bullet_' + (v ? "tick.png" : "minus.png") + '" />';
                    }
                },
		        { title: '产品描述', field: 'PRODUCTDESCRIPTION', width: 200 }
            ]],
            pagination: true,
            pageSize: 20,
            pageList: [20, 10, 30, 50],
            onLoadSuccess: function (data) {
                var panel = $(this).datagrid('getPanel');
                var tr = panel.find('div.datagrid-body tr');
                refreshCellsStyle(tr);
                var trHead = panel.find('div.datagrid-header tr');
                trHead.each(function () {
                    var tds = $(this).children('td');
                    tds.each(function () {
                        $(this).find('span,div').css({ "font-size": "14px" });
                    });
                });
            }
        });
    },
    getSelectedRow: function () {
        return _gridlist.datagrid('getSelected');
    },
    reload: function () {
        _gridlist.datagrid('clearSelections').datagrid('reload', { filter: '' });
    }
};

function refreshCellsStyle(tr) {
    tr.each(function () {
        var tds = $(this).children('td');
        tds.each(function () {
            if ($(this).attr("field") == "PRODUCTPRICE") {
                var text = $(this).text();
                if (text >= 1000) {
                    $(this).children("div").css({ "background-color": "#CD0000", "text-align": "right", "font-weight": "700", "font-size": "16px" });
                } else if (text < 1000 && text > 500) {
                    $(this).children("div").css({ "background-color": "#CD950C", "text-align": "center" });
                } else {
                    $(this).children("div").css({ "background-color": "#008B00", "text-align": "left" });
                }
            }
        });
    });
}

function guid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

var CRUD = {
    add: function () {
        var hDialog = top.$.hDialog({
            title: '添加', width: 630, height: 450, href: formurl, iconCls: 'icon16_add',
            onLoad: function () {
                var curdate = new Date();
                var strdate = 'CP' + '-' + curdate.getFullYear() + (curdate.getMonth() + 1) + curdate.getDate() + curdate.getHours() + curdate.getMinutes() + curdate.getSeconds();
                top.$('#PRODUCTCODE').val(strdate);
                top.$('#PRODUCTNAME').focus();
            },
            submit: function () {
                if (top.$('#uiform').validate().form()) {
                    var queryString = pageMethod.serializeJson(top.$('#uiform'));
                    $.ajaxjson(actionURL + '?action=SubmitForm', queryString, function (d) {
                        if (d.Success) {
                            msg.ok(d.Message);
                            hDialog.dialog('close');
                            grid.reload();
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
                return false;
            }
        });
        return false;
    },
    edit: function () {
        var row = grid.getSelectedRow();
        if (row) {
            var hDialog = top.$.hDialog({
                title: '编辑', width: 650, height: 450, href: formurl, iconCls: 'icon16_table_edit',
                onLoad: function () {
                    top.$('#PRODUCTCODE').focus();
                    var parm = 'action=GetEntity&key=' + row.ID;
                    $.ajaxjson(actionURL, parm, function (data) {
                        if (data) {
                            SetWebControls(data, true);
                        }
                    });                    
                },
                submit: function () {                     
                    if (top.$('#uiform').validate().form()) {
                        var queryString = pageMethod.serializeJson(top.$('#uiform'));
                        $.ajaxjson(actionURL + '?action=SubmitForm&key=' + row.ID, queryString, function (d) {
                            if (d.Success) {
                                msg.ok(d.Message);
                                hDialog.dialog('close');
                                grid.reload();
                            } else {
                                MessageOrRedirect(d);
                            }
                        });
                    }
                    return false;
                }
            });

        } else {
            msg.warning('请选择要修改的行。');
        }
        return false;
    },
    del: function () {
        var row = grid.getSelectedRow();
        if (row) {
            $.messager.confirm('询问提示', '确认要删除所选数据吗?', function (data) {
                if (data) {
                    var parm = 'key=' + row.ID;
                    $.ajaxjson(actionURL + '?action=Delete', parm, function (d) {
                        if (d.Data > 0) {
                            msg.ok(d.Message);
                            grid.reload();
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            });
        } else {
            msg.warning('请选择要删除的行。');
        }
        return false;
    },
    print: function () {
        window.open('PrintProductInfo.aspx', '打印产品列表', 'fullscreen=1,toolbar=no,menubar=no,scrollbars=yes, resizable=yes,location=no, status=no');
        return false;
    },
    exportData: function () {
        var exportData = new ExportExcel('list');
        exportData.go('CASE_PRODUCTINFO', 'CREATEON');
    },
    searchData: function () {
        search.go('list');
    },
    refreash: function () {
        grid.reload();
    }
};
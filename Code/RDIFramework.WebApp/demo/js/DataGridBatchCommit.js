$(function () {
    autoResize({ dataGrid: '#dg', gridType: 'datagrid', callback: grid.bind, height: 5 });   
});

var $dg = $("#dg");
var grid = {
    bind: function (winSize) {
        $dg.datagrid({
            url: '/demo/handler/DataGridBatchCommit.ashx?action=GridListJson',
            width: winSize.width,
            height: winSize.height,
            rownumbers: true, //行号
            striped: true, //隔行变色
            idField: 'ID', //主键
            singleSelect: true, //单选
            columns: [[{
                field: 'PRODUCTCODE',
                title: '产品编码',
                width: 150,
                editor: "validatebox"
            }, {
                field: 'PRODUCTNAME',
                title: '产品名称',
                width: 380,
                editor: "validatebox"
            }, {
                field: 'PRODUCTUNIT',
                title: '产品单位',
                width: 60,
                editor: "validatebox"
            }, {
                field: 'PRODUCTPRICE',
                title: '产品单价',
                width: 120,
                align: 'right',
                editor: "numberbox"
            }, {
                field: 'PRODUCTDESCRIPTION',
                title: '产品描述',
                width: 350,
                editor: "validatebox"
            }]],
            toolbar: [{
                text: "添加",
                iconCls: "icon16_table_add",
                handler: function () {
                    /* 
                    //在最后面增加一行
                    $dg.datagrid('appendRow', {});
                    var rows = $dg.datagrid('getRows');
                    $dg.datagrid('beginEdit', rows.length - 1);                    
                    */

                    //在最前面增加一行
                    $dg.datagrid('insertRow', {
                        index: 0, row:{}
                    });
                    $dg.datagrid('beginEdit', 0);
                }
            }, {
                text: "编辑",
                iconCls: "icon16_table_edit",
                handler: function () {
                    var row = $dg.datagrid('getSelected');
                    if (row) {
                        var rowIndex = $dg.datagrid('getRowIndex', row);
                        $dg.datagrid('beginEdit', rowIndex);
                    }
                }
            }, {
                text: "删除",
                iconCls: "icon16_table_delete",
                handler: function () {
                    var row = $dg.datagrid('getSelected');
                    if (row) {
                        var rowIndex = $dg.datagrid('getRowIndex', row);
                        $dg.datagrid('deleteRow', rowIndex);
                    }
                }
            }, {
                text: "结束编辑",
                iconCls: "icon16_arrow_undo",
                handler: endEdit
            }, {
                text: "保存",
                iconCls: "icon16_table_save",
                handler: function () {
                    endEdit();
                    if ($dg.datagrid('getChanges').length) {
                        var inserted = $dg.datagrid('getChanges', "inserted");
                        var deleted = $dg.datagrid('getChanges', "deleted");
                        var updated = $dg.datagrid('getChanges', "updated");

                        var effectRow = new Object();
                        if (inserted.length) {
                            effectRow["inserted"] = JSON.stringify(inserted);
                        }
                        if (deleted.length) {
                            effectRow["deleted"] = JSON.stringify(deleted);
                        }
                        if (updated.length) {
                            effectRow["updated"] = JSON.stringify(updated);
                        }

                        $.post("/demo/handler/DataGridBatchCommit.ashx?action=SubmitForm", effectRow, function (rsp) {
                            if (rsp.Success) {
                                msg.ok(rsp.Message);
                                $dg.datagrid('acceptChanges');
                            }
                        }, "JSON").error(function () {
                            msg.error("提交出错了！");
                        });
                    } else {
                        msg.ok("数据未改变！");
                    }
                }
            }]
        });
    }
};

function endEdit() {
    var rows = $dg.datagrid('getRows');
    for (var i = 0; i < rows.length; i++) {
        $dg.datagrid('endEdit', i);
    }
}
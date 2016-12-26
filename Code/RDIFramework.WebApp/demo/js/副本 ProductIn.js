var actionURL = '/demo/handler/ProductIn.ashx';
var formurl = '/demo/html/ProductIn.html';

$(function () {
    product.getCategory(); // 将数据缓存起来先
    autoResize({ dataGrid: '#list', gridType: 'datagrid', callback: grid.bind, height: 5 });

    $('#a_add').click(CRUD.add);
    $('#a_edit').click(CRUD.edit);
    $('#a_delete').click(CRUD.del);
    //高级查询
   $('#a_search').click(function () {
        search.go('list');
    });
});

var grid = {
    bind: function (winSize) {
        $('#list').datagrid({
            url: actionURL,
            toolbar: '#toolbar',
            title: "数据列表",
            iconCls: 'icon16_list',
            width: winSize.width,
            height: winSize.height,
            nowrap: false, //折行
            rownumbers: true, //行号
            striped: true, //隔行变色
            idField: 'ID',//主键
            singleSelect: true, //单选
            frozenColumns: [[]],
            columns: [[
				{ title: '主键', field: 'ID', width: 120, hidden: true },
		        { title:'入库单编码',field:'CODE',width:100},
		        { title: '入库日期', field: 'INDATE', width: 150 },
                { title: '入库类型', field: 'INTYPE', width: 100 },
                { title: '库房', field: 'DEPOT', width: 100 },
		        { title: '保管员', field: 'CUSTODIAN', width: 70 },		        
		        { title: '供货商名称', field: 'SUPPLIERNAME', width: 100 },
                { title: '录入人', field: 'CREATEBY', width: 80 },
		        { title: '录入日期', field: 'CREATEON', width: 150 },
		        { title: '备注', field: 'DESCRIPTION', width: 200 }
            ]],
            pagination: false,
            //pageSize: PAGESIZE,
            pageList: [20, 40, 50]
        });
    },
    getSelectedRow: function () {
        return $('#list').datagrid('getSelected');
    },
    reload: function () {
        $('#list').datagrid('clearSelections').datagrid('reload', { filter: '' });
    }
};

function createParam(action, keyid) {
    var o = {};
    var query = top.$('#uiform').serializeArray();
    query = convertArray(query);
    var products = pgrid.datagrid('getRows');
    query.products = products;
    
    o.jsonEntity = JSON.stringify(query);
    o.action = action;
    o.keyid = keyid;

    alert(JSON.stringify(o));
    return "json=" + JSON.stringify(o);
}

var editIndex = undefined, pgrid;


var product = {
    getCategory:function() {
        $.getJSON('/Modules/handler/ModuleAdminHandler.ashx?action=GetModuleTree', function (data) {
            $('body').data('category', data);
        });
    },

    init: function () {
        editIndex = undefined;
        pgrid = top.$('#products').datagrid({
            toolbar: '#tools',
            width: 610, singleSelect: true,
            height: 220,
            title: '入库明细',
            columns: [[
                { field: 'FULLNAME', title: '品名', width: 160, editor: 'text' },
                {
                    field: 'UNITPRICE', title: '单价', width: 120, editor: {
                    type:'numberbox'
                } },
                {
                    field: 'CATEGORY', title: '类型', width: 120,
                    formatter:function(val, row, index) {
                        if (row.categoryName) {
                            return row.categoryName;
                        } else {
                            return '';
                        }
                    },
                    editor: {
                    type: 'combotree',
                    options: {
                        data: $('body').data('category'),width:120,
                        valueField: 'id', textField: 'text', panelWidth: 180, lines: true,
                    }
                } },
                {
                    field: 'STATE', title: '入库状态', width: 160, align: 'center',
                    editor: { type: 'checkbox', options: { on: '1', off: '0' } },
                    formatter:function(val, row, index) {
                        if (val == "1") {
                            return '√';
                        } else {
                            return 'X';
                        }
                    }
                }
            ]],
            onClickRow: product.onClickRow
        });


       top.$('#a_add1').click(function () {
           product.append();
       });

        top.$('#a_delete1').click(function() {
            var index = pgrid.datagrid('getSelectedIndex');
            if (index == -1) {
                alert('请选择要删除的记录。');
                return false;
            }
            product.remove();
        });
    },


    endEditing:function(){
        if (editIndex == undefined){return true}
        var ed = pgrid.datagrid('getEditor', { index: editIndex, field: 'CATEGORY' });
        var categoryname = top.$(ed.target).combotree('getText');
        pgrid.datagrid('getRows')[editIndex]['categoryName'] = categoryname;
        pgrid.datagrid('endEdit', editIndex);
        editIndex = undefined;
        return true;
    },
    onClickRow:function(index){
        if (editIndex != index){
            if (product.endEditing()) {
                pgrid.datagrid('selectRow', index)
                        .datagrid('beginEdit', index);
                editIndex = index;
            } else {
                pgrid.datagrid('selectRow', editIndex);
            }
        }
    },
    append:function(){
        if (product.endEditing()){
            pgrid.datagrid('appendRow', { FULLNAME: '', UNITPRICE: 0, STATE: 1 });
            editIndex = pgrid.datagrid('getRows').length-1;
            pgrid.datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
        }
    },
    remove:function(){
        if (editIndex == undefined){return}
        pgrid.datagrid('cancelEdit', editIndex)
                .datagrid('deleteRow', editIndex);
        editIndex = undefined;
    },
    accept: function () {
        if (product.endEditing()) {
            pgrid.datagrid('acceptChanges');
        }
    }

}

var CRUD = {
    add: function () {
        var hDialog = top.$.hDialog({
            title: '添加', width: 630, height: 570, href: formurl, iconCls: 'icon16_add',
            onLoad: function () {
                product.init();
            },
            submit: function () {
                // 应用所有修改
                product.accept(); 
                if (top.$('#uiform').form("validate")) {
                    var query = createParam('add', '0');
                    jQuery.ajaxjson(actionURL, query, function (d) {
                        if (parseInt(d) > 0) {
                            msg.ok('添加成功！');
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
       
        top.$('#uiform').validate();
    },
    edit: function () {
        var row = grid.getSelectedRow();
        if (row) {
            var hDialog = top.$.hDialog({
                title: '编辑', width: 630, height: 570, href: formurl, iconCls: 'icon16_table_edit',
                onLoad: function () {
                    
                    top.$('#txt_Code').val(row.CODE);
                    top.$('#txt_InDate').val(row.INDATE);
                    top.$('#txt_InType').val(row.INTYPE);
                    top.$('#txt_Depot').val(row.DEPOT);
                    top.$('#txt_Custodian').val(row.CUSTODIAN);
                    top.$('#txt_SupplierName').val(row.SUPPLIERNAME);
                    top.$('#txt_CreateBy').val(row.CREATEBY);
                    top.$('#txt_CreateOn').val(row.CREATEON);
                    top.$('#txt_Description').val(row.DESCRIPTION);
                    product.init();
                    top.$('#products').datagrid({ url: actionURL + "?action=mx&keyid=" + row.ID });

                },
                submit: function () {
                    if (top.$('#uiform').form("validate")) {
                        pgrid.datagrid('acceptChanges'); // 应用所有修改
                        lastEditRowIndex = -1;
                        var query = createParam('edit', row.ID);;
                        jQuery.ajaxjson(actionURL, query, function (d) {
                            if (parseInt(d) > 0) {
                                msg.ok('修改成功！');
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
    },
    del: function () {
        var row = grid.getSelectedRow();
        if (row) {
            if (confirm('确认要执行删除操作吗？')) {
                var rid = row.ID;
                jQuery.ajaxjson(actionURL, { action: "delete", keyid: rid }, function (d) {
                    if (parseInt(d) > 0) {
                        msg.ok('删除成功！');
                        grid.reload();
                    } else {
                        MessageOrRedirect(d);
                    }
                });
            }
        } else {
            msg.warning('请选择要删除的行。');
        }
    }
};


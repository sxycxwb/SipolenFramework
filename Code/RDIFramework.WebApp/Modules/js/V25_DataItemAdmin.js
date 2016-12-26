var actionUrl = 'handler/DataItemAdminHandler.ashx';

$(function () {
    var size = { width: $(window).width(), height: $(window).height() };
    mylayout.init(size);
    $(window).resize(function () {
        size = { width: $(window).width(), height: $(window).height() };
        mylayout.resize(size);
    });

    ItemsMgr.bindData();
    autoResize({ dataGrid: '#htableItems', gridType: 'datagrid', callback: ItemsMgr.bindData, height: $(window).height() });
    autoResize({ dataGrid: '#htableItemDetail', gridType: 'datagrid', callback: ItemDetailMgr.databind, height: $(window).height() });

    $('#a_addCategory').click(ItemsMgr.addCategory);
    $('#a_delCategory').click(ItemsMgr.delCategory);
    $('#a_editCategory').click(ItemsMgr.editCategory);

    //字典数据
    $('#a_itemdetailadd').click(ItemDetailMgr.add);
    $('#a_itemdetailedit').click(ItemDetailMgr.edit);
    $('#a_itemdetaildelete').click(ItemDetailMgr.del);
    $('#a_refresh').click(function () {
        var row = ItemsMgr.getSelected();
        if (row)
            ItemDetailMgr.reload(row.ID);
        else {
            msg.warning('请选择字典类别。');
        }
    });
});

var mylayout = {
    init: function (size) {
        $('#layout').width(size.width - 4).height(size.height - 4).layout();
        var center = $('#layout').layout('panel', 'center');
        center.panel({
            onResize: function (w, h) {
                $('#htableItemDetail').datagrid('resize', { width: w, height: h });
            }
        });
    },
    resize: function (size) {
        mylayout.init(size);
        $('#layout').layout('resize');
    }
};

var ItemsMgr = {
    bindData: function () {
        $('#htableItems').datagrid({
            //title: '字典类别',
            //iconCls: 'icon icon-book_red',
            noheader: true,
            //width: size.width,
            //height: size.height,
            nowrap: false,
            rownumbers: true,
            //animate: true,
            resizable: true,
            singleSelect: true,
            collapsible: false,
            url: actionUrl + '?action=GetDataItem',
            idfield: 'ID',
            treefield: 'FULLNAME',
            columns: [[
                 { title: '名称', field: 'FULLNAME', width: 90 },
                 { title: '编码', field: 'CODE', width: 130 },
                 { title: 'Id', field: 'ID', hidden: true },
                 { title: 'Category', field: 'CATEGORY', hidden: true },
                 { title: 'IsTree', field: 'ISTREE', hidden: true },
                 { title: 'AllowEdit', field: 'ALLOWEDIT', hidden: true },
                 { title: 'AllowDelete', field: 'ALLOWDELETE', hidden: true },
                 { title: 'Enabled', field: 'ENABLED', hidden: true },
                 { title: 'SortCode', field: 'SORTCODE', hidden: true },
                 { title: 'Description', field: 'DESCRIPTION', hidden: true }
            ]],
            onLoadSuccess: function (data) {
                if (!data) {
                    $('#noCategoryInfo').fadeIn();
                }

                $('body').data('categoryData', data);
            },
            onClickRow: function (rowIndex, rowData) {
                var cc = rowData.ID;
                $('#htableItemDetail').treegrid({
                    url: actionUrl,
                    queryParams: { categoryId: cc }
                });
            }
        });
    },

    reload: function () {
        $('#htableItems').datagrid('reload');
    },

    getSelected: function () {
        return $('#htableItems').datagrid('getSelected');
    },
    bindCategory: function bindCategory() {
        top.$('#txt_Category').combobox({
            url: 'Modules/handler/DataItemAdminHandler.ashx?action=GetCategory&categorycode=DataDictionaryCategory',
            method: 'get',
            valueField: 'ITEMVALUE',
            textField: 'ITEMNAME',
            editable: false,
            panelHeight: 'auto'
        });
    },
    addCategory: function () {
        if ($(this).linkbutton('options').disabled == true) {
            return;
        }
        var addDialog = top.$.hDialog({
            title: '添加字典类别',
            iconCls: 'icon-book_add',
            href: 'Modules/html/DataItem.htm?n=' + Math.random(),
            width: 400,
            height: 350,
            onLoad: function () {
                top.$('#chk_Enabled').attr("checked", true);
                ItemsMgr.bindCategory();
            },
            submit: function () {
                //var query = createDataItemParam("AddDataItem", 0);
                var vcategory = top.$('#txt_Category').combobox('getValue');
                if (top.$('#ItemsEditForm').form("validate")) {
                    $.ajaxjson(actionUrl, 'action=AddDataItem&vcategory=' + vcategory + "&" + top.$('#ItemsEditForm').serialize(), function (d) {
                        if (d.Data > 0) {
                            msg.ok('字典类别添加成功!');
                            addDialog.dialog('close');
                            ItemsMgr.reload();
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            }
        });
    },
    editCategory: function () {
        if ($(this).linkbutton('options').disabled == true) {
            return;
        }
        var row = ItemsMgr.getSelected();
        if (row) {
            var editDialog = top.$.hDialog({
                title: '编辑字典类别',
                iconCls: 'icon-book_edit',
                href: 'Modules/html/DataItem.htm?n=' + Math.random(),
                width: 400,
                height: 350,
                onLoad: function () {
                    ItemsMgr.bindCategory();
                    top.$('#txt_Code').val(row.CODE);
                    top.$('#txt_FullName').val(row.FULLNAME);
                    top.$('#txt_Description').val(row.DESCRIPTION);
                    top.$('#chk_Enabled').attr("checked", row.ENABLED == "1");
                    top.$('#txt_Category').combobox("setValue", row.CATEGORY);
                },
                submit: function () {
                    if (top.$('#ItemsEditForm').form("validate")) {
                        var vcategory = top.$('#txt_Category').combobox('getValue');
                        $.ajaxjson(actionUrl, 'action=EditDataItem&vcategory=' + vcategory + "&" + top.$('#ItemsEditForm').serialize() + '&KeyId=' + row.ID, function (d) {
                            if (d.Data > 0) {
                                msg.ok('字典类别编辑成功!');
                                editDialog.dialog('close');
                                ItemsMgr.reload();
                            } else {
                                MessageOrRedirect(d);
                            }
                        });
                    }
                }
            });
        } else {
            msg.warning('请选择字典类别。');
        }
    },
    delCategory: function () {
        if ($(this).linkbutton('options').disabled == true) {
            return;
        }
        var row = ItemsMgr.getSelected();
        if (row) {
            $.messager.confirm('询问提示', '确认要删除[' + row.FullName + ']字典类别吗?', function (data) {
                if (data) {
                    $.ajaxjson(actionUrl, 'action=DeleteDataItem&KeyId=' + row.ID, function (d) {
                        if (d.Data > 0) {
                            msg.ok('字典类别删除成功。');
                            ItemsMgr.reload();
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            });
        } else {
            msg.warning('请选择选项类别。');
        }
    }
};

function createDataItemParam(action, keyid) {
    var o = {};
    var query = top.$('#ItemsEditForm').serializeArray();
    query = convertArray(query);
    o.jsonEntity = JSON.stringify(query);
    o.action = action;
    o.keyid = keyid;
    return "json=" + JSON.stringify(o);
}

function createParam(action, keyid) {
    var o = {};
    var query = top.$('#ItemDetailEditForm').serializeArray();
    query = convertArray(query);
    o.jsonEntity = JSON.stringify(query);
    o.action = action;
    o.keyid = keyid;
    return "json=" + JSON.stringify(o);
}
var imgcheckbox = function (cellvalue, options, rowObject) {
    return cellvalue ? '<img src="/Content/css/icon/ok.png" alt="正常" title="正常" />' : '<img src="/Content/css/icon/stop.png" alt="禁用" title="禁用" />';
}

var itemDetailDialog;

var ItemDetailMgr = {
    databind: function (winSize) {
        $('#htableItemDetail').treegrid({
            toolbar: '#toolbar',
            title: "字典明细列表",
            iconCls: 'icon icon-list',
            width: winSize.width,
            height: winSize.height,
            nowrap: false, //折行
            rownumbers: true, //行号
            striped: true, //隔行变色
            idfield: 'ID', //主键
            treeField: 'ITEMNAME',
            singleSelect: true, //单选
            frozenColumns: [[]],
            columns: [[
                { title: 'Id', field: 'ID', hidden: true },
                { title: 'ItemId', field: 'ITEMID', hidden: true },
                { title: 'ParentId', field: 'PARENTID', hidden: true },
                { title: '名称', field: 'ITEMNAME', width: 140 },
                { title: '值', field: 'ITEMVALUE', width: 140 },
                { title: '编码', field: 'ITEMCODE', width: 140 },
                { title: '有效', field: 'ENABLED', width: 50, align: 'center', formatter: imgcheckbox },
                { title: '排序', field: 'SORTCODE', width: 80 },
                { title: '公共', field: 'ISPUBLIC', width: 60, formatter: function (v, d, i) {
                    return '<img src="/Content/images/' + (v == '1' ? 'checkmark.gif' : 'checknomark.gif') + '" />';
                }, align: 'center'
                },
                {
                    title: '允许编辑', field: 'ALLOWEDIT', width: 60, formatter: function (v, d, i) {
                        return '<img src="/Content/images/' + (v == '1' ? 'checkmark.gif' : 'checknomark.gif') + '" />';
                }, align: 'center'
                },
                {
                    title: '允许删除', field: 'ALLOWDELETE', width: 60, formatter: function (v, d, i) {
                        return '<img src="/Content/images/' + (v == '1' ? 'checkmark.gif' : 'checknomark.gif') + '" />';
                }, align: 'center'
                },
                { title: '描述', field: 'DESCRIPTION', width: 350 }
            ]]
        });
    },
    reload: function (cc) {
        $('#htableItemDetail').treegrid({
            url: actionUrl,
            queryParams: { categoryId: cc }
        });
    },
    GetSelectedRow: function () {
        return $('#htableItemDetail').treegrid('getSelected');
    },
    initCtrl: function (itemDetailId) {
        //        top.$('#txt_status').combobox({ panelHeight: 'auto', editable: false });
        //        top.$('#txt_sortnum').numberspinner({ min: 0, max: 999 });
        var cateData = $('body').data('categoryData');
        //cateData = JSON.stringify(cateData);
        var comboCategory = top.$('#txt_ItemId').combobox({ data: cateData.rows, valuefield: 'ID', textfield: 'FULLNAME', editable: false, required: true, missingMessage: '请选择类别', disabled: true });
        var vItemsRow = ItemsMgr.getSelected();
        if (vItemsRow)
            comboCategory.combobox('setValue', vItemsRow.ID);

        var vItemDetailData = $("#htableItemDetail").treegrid('getData');
        if (vItemDetailData.length > 0) {
            vItemDetailData = JSON.stringify(vItemDetailData).replace(/ID/g, "id").replace(/ITEMNAME/g, "text");
            vItemDetailData = '[{id:0,text:"== 请选择 =="},' + vItemDetailData.substr(1);
        }
        else
            vItemDetailData = '[{id:0,text:"== 请选择 =="}]';

        var parentTree = top.$('#txt_ParentId').combotree({
            data: eval(vItemDetailData),
            valuefield: 'ID',
            textField: 'text',
            editable: false,
            onSelect: function (item) {
                var nodeId = parentTree.combotree('getValue');
                if (item.id == itemDetailId) {
                    parentTree.combotree('setValue', nodeId);
                    top.$.messager.alert('警告提示', '上级不能与当前字典相同！', 'warning');
                    return false;
                }
            }
        });

        var crow = ItemDetailMgr.GetSelectedRow();
        if (!itemDetailId && itemDetailId != undefined && crow) {
            top.$('#txt_ParentId').combotree('setValue', crow.ID);
        } else
            top.$('#txt_ParentId').combotree('setValue', 0);
    },
    add: function () {
        if ($(this).linkbutton('options').disabled == true) {
            return;
        }
        if (!ItemsMgr.getSelected()) {
            $.messager.alert('警告提示', '请选择字典类别！', 'warning');
            return false;
        }

        itemDetailDialog = top.$.hDialog({
            href: 'Modules/html/DataItemDetail.htm?n=' + Math.random(),
            width: 400,
            height: 430,
            title: '新增选项明细',
            iconCls: 'icon-table_add',
            onLoad: function () {
                ItemDetailMgr.initCtrl();
                top.$(":checkbox").attr("checked", true); //界面上的所有checkbox默认选中（有效、公共、允许编辑、允许删除）
            },
            submit: function () {            
                var vitemId = top.$('#txt_ItemId').combobox('getValue'); //选项类别ID
                var vparentId = top.$('#txt_ParentId').combobox('getValue'); //上级ID
                var query ='action=AddItemDetail&vitemId=' + vitemId + "&vparentId=" + vparentId + "&" + top.$('#ItemDetailEditForm').serialize();
                if (top.$('#ItemDetailEditForm').form('validate')) {
                    $.ajaxjson(actionUrl, query, function (d) {
                        if (d.Data > 0) {
                            msg.ok(d.Message);
                            ItemDetailMgr.reload(top.$('#txt_ItemId').combobox('getValue'));
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            }
        });
    },
    edit: function () {
        if ($(this).linkbutton('options').disabled == true) {
            return;
        }

        var row = ItemDetailMgr.GetSelectedRow();
        if (row == null) {
            $.messager.alert('警告提示', '请选择选项明细数据！', 'warning');
            return false;
        }
        dicDialog = top.$.hDialog({
            href: 'Modules/html/DataItemDetail.htm?n=' + Math.random(),
            width: 400,
            height: 430,
            title: '编辑选项明细',
            iconCls: 'icon16_table_edit',
            onLoad: function () {
                ItemDetailMgr.initCtrl(row.ID);
                top.$('#txt_ItemCode').val(row.ITEMCODE);
                top.$('#txt_ItemName').val(row.ITEMNAME);
                top.$('#txt_ItemValue').val(row.ITEMVALUE);
                top.$('#txt_ParentId').combotree('setValue', row.PARENTID);
                top.$('#chk_Enabled').attr("checked", row.ENABLED == "1");
                top.$('#chk_IsPublic').attr("checked", row.ISPUBLIC == "1");
                top.$('#chk_AllowEdit').attr("checked", row.ALLOWEDIT == "1");
                top.$('#chk_AllowDelete').attr("checked", row.ALLOWDELETE == "1");
                top.$('#txt_Description').val(row.DESCRIPTION);
            },
            submit: function () {                
                if (top.$('#ItemDetailEditForm').form('validate')) {
                    var vitemId = top.$('#txt_ItemId').combobox('getValue'); //选项类别ID
                    var vparentId = top.$('#txt_ParentId').combobox('getValue'); //上级ID
                    var query = 'action=EditItemDetail&vitemId=' + vitemId + "&vparentId=" + vparentId + "&" + top.$('#ItemDetailEditForm').serialize() + '&KeyId=' + row.ID;
                    $.ajaxjson(actionUrl, query, function (d) {
                        if (d.Data > 0) {
                            msg.ok(d.Message);
                            ItemDetailMgr.reload(top.$('#txt_ItemId').combobox('getValue'));
                            dicDialog.dialog('close');
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            }
        });
    },
    del: function () {
        if ($(this).linkbutton('options').disabled == true) {
            return;
        }
        var row = ItemDetailMgr.GetSelectedRow();
        if (row) {
            var childs = $('#htableItemDetail').treegrid('getChildren', row.ID);
            if (childs.length > 0) {
                $.messager.alert('警告提示', '当前选项明细有下级数据，不能删除。<br> 请先删除子节点数据！', 'warning');
                return false;
            }
            $.messager.confirm('询问提示', '确认要删除[' + row.ITEMNAME + ']选项明细项吗?', function (data) {
                if (data) {
                    //var query = createParam("DeleteItemDetail", row.Id);
                    var query = 'action=DeleteItemDetail&KeyId=' + row.ID;
                    $.ajaxjson(actionUrl, query, function (d) {
                        if (d.Data == 1) {
                            msg.ok(d.Message);
                            var row = ItemsMgr.getSelected();
                            if (row)
                                ItemDetailMgr.reload(row.ID);
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            });
        } else {
            $.messager.alert('警告提示', '请选中要删除的选项明细数据。', 'warning');
        }
    }
}
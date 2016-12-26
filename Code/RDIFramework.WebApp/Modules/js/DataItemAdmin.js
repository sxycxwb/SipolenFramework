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
* RDIFramework.NET框架“员工管理”业务界面逻辑
*
* 主要完成员工的增加、修改、删除、移动、导出等。
* 修改记录：
*   3、2015-04-01 EricHu V2.9 对字典类别增加父节点的显示支持
*   2. 2013-12-05 EricHu V2.7 重新设计本界面。
*   1. 2013-08-17 EricHu V2.5 新增本业务逻辑的编写。
*/

var actionUrl = 'handler/DataItemAdminHandler.ashx';

$(function () {    
    pageSizeControl.init({ gridId: 'dicGrid', gridType: 'treegrid' });
    $(window).resize(function () {        
        pageSizeControl.init({ gridId: 'dicGrid', gridType: 'treegrid' });
    });

    DicCategory.bindTree();
    autoResize({ treegrid: '#dicGrid', gridType: 'treegrid', callback: mygrid.databind, height: 35, width: 203 });

    $('#a_addCategory').click(DicCategory.addCategory);
    $('#a_delCategory').click(DicCategory.delCategory);
    $('#a_editCategory').click(DicCategory.editCategory);

    //字典数据
    $('#a_itemdetailadd').click(mygrid.add);
    $('#a_itemdetailedit').click(mygrid.edit);
    $('#a_itemdetaildelete').click(mygrid.del);
    $('#a_refresh').click(function () {
        var node = DicCategory.getSelected();
        if (node)
            mygrid.reload(node.id);
        else {
            msg.warning('请选择字典类别。');
        }
    });
});

var DicCategory = {
    bindTree: function () {
        $('#dataDicType').tree({
            url: 'handler/DataItemAdminHandler.ashx?action=GetDataItemTree',
            onLoadSuccess: function (node, data) {
                if (data.length == 0) {
                    $('#noCategoryInfo').fadeIn();
                }

                $('body').data('categoryData', data);
            },
            onClick: function (node) {
                $(this).tree('toggle', node.target);
                var cc = node.id;
                $('#dicGrid').treegrid({
                    url: actionUrl,
                    queryParams: { categoryId: cc }
                });
            }
        });
    },
    reload: function () {
        $('#dataDicType').tree('reload');
    },
    getSelected: function () {
        return $('#dataDicType').tree('getSelected');
    },
    bindCtrl: function (curId) {
        var treeData = $('body').data('categoryData');
        treeData = JSON.stringify(treeData);
        treeData = '[{"id":0,"selected":true,"text":"请选择上级节点"},' + treeData.substr(1, treeData.length - 1);

        top.$('#txt_ParentId').combotree({
            data: JSON.parse(treeData),
            valueField: 'id',
            textField: 'text',
            panelWidth: '280',
            editable: false,
            lines: true,
            onSelect: function (item) {
                var nodeId = top.$('#txt_ParentId').combotree('getValue');
                if (item.id == curId) {
                    top.$('#txt_ParentId').combotree('setValue', nodeId);
                    top.$.messager.alert('警告提示', '上级节点不能与当前所选相同！', 'warning');
                }
            }
        }).combotree('setValue', 0);
    },
    addCategory: function () {
        var addDialog = top.$.hDialog({
            title: '添加字典类别',
            iconCls: 'icon16_add',
            href: 'Modules/html/DataItem.htm?n=' + Math.random(),
            width: 390,
            height: 350,
            onLoad: function () {
                DicCategory.bindCtrl();
                top.$('#chk_Enabled').attr("checked", true);
                pageMethod.bindCategory('txt_Category', 'DataDictionaryCategory');
            },
            submit: function () {
                var isValid = top.$('#ItemsEditForm').form("validate");
                if (isValid) {
                    var vcategory = top.$('#txt_Category').combobox('getValue');
                    $.ajaxjson(actionUrl, 'action=AddDataItem&vcategory=' + vcategory + "&" + top.$('#ItemsEditForm').serialize(), function (d) {
                        if (d.Data > 0) {
                            msg.ok('亲，字典类别添加成功。');
                            addDialog.dialog('close');
                            DicCategory.reload();
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            }
        });
    },
    editCategory: function () {
        var node = DicCategory.getSelected();
        if (node) {
            var editDialog = top.$.hDialog({
                title: '编辑字典类别',
                iconCls: 'icon16_edit_button',
                href: 'Modules/html/DataItem.htm?n=' + Math.random(),
                width: 390,
                height: 350,
                onLoad: function () {
                    pageMethod.bindCategory('txt_Category', 'DataDictionaryCategory');
                    var parm = 'action=GetItemsEntity&key=' + node.id;
                    $.ajaxjson(actionUrl, parm, function (data) {
                        if (data) {
                            DicCategory.bindCtrl(data.Id);
                            top.$('#txt_ParentId').combotree('setValue', data.ParentId);
                            top.$('#txt_Code').val(data.Code);
                            top.$('#txt_FullName').val(data.FullName);
                            top.$('#txt_Description').val(data.Description);
                            top.$('#txt_Category').combobox("setValue", data.Category);
                            top.$('#chk_Enabled').attr("checked", data.Enabled);
                        }
                    });
                },
                submit: function () {
                    var isValid = top.$('#ItemsEditForm').form("validate");
                    if (isValid) {
                        var vcategory = top.$('#txt_Category').combobox('getValue');
                        $.ajaxjson(actionUrl, 'action=EditDataItem&vcategory=' + vcategory + "&" + top.$('#ItemsEditForm').serialize() + '&KeyId=' + node.id, function (d) {
                            if (d.Data > 0) {
                                msg.ok('亲，字典类别编辑成功啦。');
                                editDialog.dialog('close');
                                DicCategory.reload();
                            } else {
                                MessageOrRedirect(d);
                            }
                        });
                    }
                }
            });
        } else {
            msg.warning('亲,请选择字典类别。');
        }
    },
    delCategory: function () {
        var node = DicCategory.getSelected();
        var rows = $('#dicGrid').treegrid('getData');
        if (rows && rows.length > 0) {
            msg.warning('当前字典有明细数据，不能删除。<br> 请先删除明细数据。');
            return false;
        }
        if (node) {
            if (confirm('亲,确认要删除此类别吗?')) {
                $.ajaxjson(actionUrl, 'action=DeleteDataItem&key=' + node.id, function (d) {
                    if (d.Data > 0) {
                        msg.ok('亲，字典类别删除成功。');
                        DicCategory.reload();
                    } else {
                        MessageOrRedirect(d);
                    }
                });
            }
        } else {
            msg.warning('亲,请选择字典。');
        }
        return false;
    }
};

var dicDialog;
var mygrid = {
    databind: function(winSize) {
        $('#dicGrid').treegrid({
            toolbar: '#toolbar',
            title: "数据字典明细",
            iconCls: 'icon icon-list',
            width: winSize.width,
            height: winSize.height,
            nowrap: false, //折行
            rownumbers: true, //行号
            striped: true, //隔行变色
            idField: 'Id', //主键
            treeField: 'ItemName',
            singleSelect: true, //单选
            frozenColumns: [[]],
            columns: [
                [
                    { title: 'ItemId', field: 'ItemId', hidden: true },
                    { title: 'ParentId', field: 'ParentId', hidden: true },
                    { title: 'ID', field: 'Id', width: 60, hidden: true },
                    { title: '名称', field: 'ItemName', width: 170 },
                    { title: '编码', field: 'ItemCode', width: 130 },
                    { title: '值', field: 'ItemValue', width: 130 },
                    { title: '排序', field: 'SortCode', width: 40 },
                    {
                        title: '有效',
                        field: 'Enabled',
                        width: 40,
                        formatter: function(v, d, i) {
                            return '<img src="/Content/images/' + (v == '1' ? 'checkmark.gif' : 'checknomark.gif') + '" />';
                        },
                        align: 'center'
                    },
                    {
                        title: '公共',
                        field: 'IsPublic',
                        width: 40,
                        formatter: function(v, d, i) {
                            return '<img src="/Content/images/' + (v == '1' ? 'checkmark.gif' : 'checknomark.gif') + '" />';
                        },
                        align: 'center'
                    },
                    {
                        title: '允许编辑',
                        field: 'AllowEdit',
                        width: 40,
                        formatter: function(v, d, i) {
                            return '<img src="/Content/images/' + (v == '1' ? 'checkmark.gif' : 'checknomark.gif') + '" />';
                        },
                        align: 'center'
                    },
                    {
                        title: '允许删除',
                        field: 'AllowDelete',
                        width: 40,
                        formatter: function(v, d, i) {
                            return '<img src="/Content/images/' + (v == '1' ? 'checkmark.gif' : 'checknomark.gif') + '" />';
                        },
                        align: 'center'
                    },
                    { title: '描述', field: 'Description', width: 200 }
                ]
            ],
            pagination: false
        });
    },
    reload: function(cc) {
        $('#dicGrid').treegrid({
            url: actionUrl,
            queryParams: { categoryId: cc }
        });
    },
    GetSelectedRow: function() {
        return $('#dicGrid').treegrid('getSelected');
    },
    initCtrl: function(dicId) {
        var cateData = $('body').data('categoryData');
        //alert(JSON.stringify(cateData));
        var comboCategory = top.$('#txt_ItemId').combobox({ data: cateData.rows, valuefield: 'id', textfield: 'text', editable: false, required: true, missingMessage: '请选择类别', disabled: true });
        var cnode = DicCategory.getSelected();
        if (cnode)
            comboCategory.combobox('setValue', cnode.id);

        var dicData = $("#dicGrid").treegrid('getData');
        if (dicData.length > 0) {
            dicData = JSON.stringify(dicData).replace(/Id/g, "id").replace(/ItemName/g, "text");
            dicData = '[{id:0,text:"== 请选择 =="},' + dicData.substr(1);
        } else
            dicData = '[{id:0,text:"== 请选择 =="}]';

        var parentTree = top.$('#txt_ParentId').combotree({
            data: eval(dicData),
            valuefield: 'id',
            textField: 'text',
            editable: false,
            onSelect: function(item) {
                var nodeId = parentTree.combotree('getValue');
                if (item.id == dicId) {
                    parentTree.combotree('setValue', nodeId);
                    top.$.messager.alert('警告提示', '上级不能与当前字典相同！', 'warning');
                    return false;
                }
            }
        });

        var crow = mygrid.GetSelectedRow();
        if (!dicId && crow) {
            top.$('#txt_ParentId').combotree('setValue', crow.Id);
        } else
            top.$('#txt_ParentId').combotree('setValue', 0);
    },
    add: function() {
        if ($(this).linkbutton('options').disabled == true) {
            return false;
        }
        if (!DicCategory.getSelected()) {
            msg.warning('请选择字典类别！');
            return false;
        }

        dicDialog = top.$.hDialog({
            href: 'Modules/html/DataItemDetail.htm?n=' + Math.random(),
            width: 400,
            height: 400,
            title: '新增选项明细',
            iconCls: 'icon-table_add',
            onLoad: function() {
                mygrid.initCtrl();
                top.$(":checkbox").attr("checked", true); //界面上的所有checkbox默认选中（有效、公共、允许编辑、允许删除）
            },
            submit: function() {
                var vitemId = top.$('#txt_ItemId').combobox('getValue'); //选项类别ID
                var vparentId = top.$('#txt_ParentId').combobox('getValue'); //上级ID
                var query = 'action=AddItemDetail&vitemId=' + vitemId + "&vparentId=" + vparentId + "&" + top.$('#ItemDetailEditForm').serialize();
                if (top.$('#dicForm').form('validate')) {
                    $.ajaxjson(actionUrl, query, function(d) {
                        if (d.Data > 0) {
                            msg.ok(d.Message);
                            mygrid.reload(top.$('#txt_ItemId').combobox('getValue'));
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            }
        });
        return false;
    },
    edit: function() {
        if ($(this).linkbutton('options').disabled == true) {
            return false;
        }
        var row = mygrid.GetSelectedRow();
        if (row == null) {
            msg.warning("请选择字典数据。");
            return false;
        }
        dicDialog = top.$.hDialog({
            href: 'Modules/html/DataItemDetail.htm?n=' + Math.random(),
            width: 400,
            height: 400,
            title: '编辑字典',
            iconCls: 'icon16_edit_button',
            onLoad: function() {
                mygrid.initCtrl(row.Id);
                top.$('#txt_ItemCode').val(row.ItemCode);
                top.$('#txt_ItemName').val(row.ItemName);
                top.$('#txt_ItemValue').val(row.ItemValue);
                top.$('#txt_ParentId').combotree('setValue', row.ParentId);
                top.$('#chk_Enabled').attr("checked", row.Enabled == "1");
                top.$('#chk_IsPublic').attr("checked", row.IsPublic == "1");
                top.$('#chk_AllowEdit').attr("checked", row.AllowEdit == "1");
                top.$('#chk_AllowDelete').attr("checked", row.AllowDelete == "1");
                top.$('#txt_Description').val(row.Description);
            },
            submit: function() {
                if (top.$('#ItemDetailEditForm').form('validate')) {
                    var vitemId = top.$('#txt_ItemId').combobox('getValue'); //选项类别ID
                    var vparentId = top.$('#txt_ParentId').combobox('getValue'); //上级ID
                    var query = 'action=EditItemDetail&vitemId=' + vitemId + "&vparentId=" + vparentId + "&" + top.$('#ItemDetailEditForm').serialize() + '&KeyId=' + row.Id;
                    $.ajaxjson(actionUrl, query, function(d) {
                        if (d.Data > 0) {
                            msg.ok(d.Message);
                            mygrid.reload(top.$('#txt_ItemId').combobox('getValue'));
                            dicDialog.dialog('close');
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            }
        });
        return false;
    },
    del: function() {
        if ($(this).linkbutton('options').disabled == true) {
            return false;
        }
        var row = mygrid.GetSelectedRow();
        if (row) {
            var childs = $('#dicGrid').treegrid('getChildren', row.Id);
            if (childs.length > 0) {
                msg.warning('当前字典有下级数据，不能删除。<br> 请先删除子节点数据。');
                return false;
            }

            if (confirm('确认要删除此条字典数据吗?')) {
                var query = 'action=DeleteItemDetail&key=' + row.Id;
                $.ajaxjson(actionUrl, query, function(d) {
                    if (d.Data == 1) {
                        msg.ok(d.Message);
                        var node = DicCategory.getSelected();
                        if (node)
                            mygrid.reload(node.id);
                    } else {
                        MessageOrRedirect(d);
                    }
                });
            }
        } else {
            msg.warning('请选中要删除的字典数据。');
        }
        return false;
    }
};
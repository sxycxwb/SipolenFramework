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
* RDIFramework.NET框架“操作权限项”业务界面业务逻辑
*
* 主要完成操作权限项的增加、修改、删除、移动、导出、用户或角色操作权限的设置等。
* 修改记录：
* 2. 2013-11-18 EricHU V2.7 新增移动功能。
* 1. 2013-08-21 EricHu 新增本业务逻辑的编写。
*/


var actionUrl = 'handler/PermissionItemAdminHandler.ashx',
    formUrl = "Modules/html/PermissionItemForm.htm?n=" + Math.random(),
    navgrid;

$(function () {
    autoResize({ dataGrid: '#permissionitemGrid', gridType: 'treegrid', callback: mygrid.bindGrid, height: 5 });
    $('#a_add').attr('onclick', 'crud.add();');
    $('#a_edit').attr('onclick', 'crud.edit();');
    $('#a_delete').attr('onclick', 'crud.del();');
    $('#a_setuserpermissionitemepermission').attr('onclick', 'crud.userPermissionItemBatchSet();');
    $('#a_setrolepermissionitemepermission').attr('onclick', 'crud.rolePermissionItemBatchSet();');
    $('#a_move').attr('onclick', 'crud.move();');
    $('#a_refresh').attr('onclick', 'crud.refreash();');
    

    //$('#a_add').click(crud.add);
    //$('#a_edit').click(crud.edit);
    //$('#a_delete').click(crud.del);
    //$('#a_setuserpermissionitemepermission').click(crud.userPermissionItemBatchSet);
    //$('#a_setrolepermissionitemepermission').click(crud.rolePermissionItemBatchSet);
    //$('#a_move').click(crud.move);
    //$('#a_refresh').click(function () { //刷新
    //    mygrid.reload();
    //});
});

var mygrid = {
    bindGrid: function(size) {
        navgrid = $('#permissionitemGrid').treegrid({
            toolbar: '#toolbar',
            title: '操作权限列表',
            iconCls: 'icon icon-layout',
            width: size.width,
            height: size.height,
            nowrap: false,
            rownumbers: true,
            //animate: true,
            resizable: true,
            collapsible: false,
            onContextMenu: pageContextMenu.createTreeGridContextMenu,
            url: actionUrl,
            idField: 'Id',
            treeField: 'FullName',
            frozenColumns: [
                [
                    { title: '操作权限名称', field: 'FullName', width: 300 },
                    { title: '编码', field: 'Code', width: 160 }
                ]
            ],
            columns: [
                [
                    { title: '分类', field: 'CategoryCode', width: 100 },
                    {
                        title: '公共',
                        field: 'IsPublic',
                        width: 50,
                        align: 'center',
                        formatter: function(v, d, i) {
                            return '<img src="/Content/images/' + (v ? "checkmark.gif" : "checknomark.gif") + '" />';
                        }
                    },
                    { title: '有效', field: 'Enabled', width: 50, align: 'center', formatter: imgcheckbox },
                    { title: '排序', field: 'SortCode', width: 80, align: 'right' },
                    { title: '备注', field: 'Description', width: 500 },
                    { title: 'ParentId', field: 'ParentId', hidden: true },
                    { title: 'AllowEdit', field: 'AllowEdit', hidden: true },
                    { title: 'AllowDelete', field: 'AllowDelete', hidden: true },
                    { title: 'IsScope', field: 'IsScope', hidden: true }
                ]
            ]
        });
    },
    reload: function() {
        navgrid.treegrid('reload');
    },
    selected: function() {
        return navgrid.treegrid('getSelected');
    }
};

var imgcheckbox = function(cellvalue, options, rowObject) {
    return cellvalue ? '<img src="/Content/css/icon/bullet_tick.png" alt="正常" title="正常" />' : '<img src="/Content/css/icon/bullet_minus.png" alt="禁用" title="禁用" />';
};

var crud = {
    refreash:function() {
        mygrid.reload();
    },
    add: function () {
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}

        var addDialog = top.$.hDialog({
            href: formUrl, title: '添加操作权限项', iconCls: 'icon16_layout_add', width: 490, height: 310,
            onLoad: function () {
                pubMethod.bindCtrl();
                var row = mygrid.selected();
                if (row) {
                    top.$('#txt_ParentId').combotree('setValue', row.ParentId);
                }
            },
            submit: function () {
                if (top.$('#uiform').validate().form()) {
                    var vparentid = top.$('#txt_ParentId').combobox('getValue');
                    var param = 'action=Add&vparentid=' + vparentid + '&' + top.$('#uiform').serialize();
                    $.ajaxjson(actionUrl, param, function (d) {
                        if (d.Success) {
                            msg.ok(d.Message);
                            addDialog.dialog('close');
                            mygrid.reload();
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            }
        });
        return false;
    },
    edit: function () {
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        var row = mygrid.selected();
        if (row) {
            var editDailog = top.$.hDialog({
                href: formUrl, title: '修改操作权限项', iconCls: 'icon16_layout_edit', width: 490, height: 310,
                onLoad: function () {
                    pubMethod.bindCtrl(row.Id);
                    top.$('#txt_Code').val(row.Code);
                    top.$('#txt_FullName').val(row.FullName);
                    top.$('#txt_ParentId').combotree('setValue', row.ParentId);
                    top.$('#chk_Enabled').attr('checked', row.Enabled == "1");
                    top.$('#chk_IsPublic').attr('checked', row.IsPublic == "1");
                    top.$('#chk_IsScope').attr('checked', row.IsScope == "1");
                    top.$('#chk_AllowEdit').attr('checked', row.AllowEdit == "1");
                    top.$('#chk_AllowDelete').attr('checked', row.AllowDelete == "1");
                    top.$('#txt_Description').val(row.Description);
                },
                submit: function () {
                    if (top.$('#uiform').validate().form()) {

                        //保存时判断当前节点所选的父节点，不能为当前节点的子节点，这样就乱套了....
                        var treeParentId = top.$('#txt_ParentId').combotree('tree'); // 得到树对象
                        var node = treeParentId.tree('getSelected');
                        if (node) {
                            var nodeParentId = treeParentId.tree('find', row.Id);
                            var children = treeParentId.tree('getChildren', nodeParentId.target);
                            var nodeIds = '';
                            var isFind = 'false';
                            for (var index = 0; index < children.length; index++) {
                                if (children[index].id == node.id) {
                                    isFind = 'true';
                                    break;
                                }
                            }

                            if (isFind == 'true') {
                                top.$.messager.alert('温馨提示', '请选择父节点元素！', 'warning');
                                return;
                            }
                        }

                        var vparentid = top.$('#txt_ParentId').combobox('getValue');
                        var query = 'action=Edit&vparentid=' + vparentid + '&KeyId=' + row.Id + '&' + top.$('#uiform').serialize();
                        $.ajaxjson(actionUrl, query, function (d) {
                            if (d.Success) {
                                msg.ok(d.Message);
                                editDailog.dialog('close');
                                mygrid.reload();
                            } else {
                                MessageOrRedirect(d);
                            }
                        });
                    }
                }
            });


        } else {
            msg.warning('请选择要修改菜单!');
            return false;
        }
        return false;
    },
    del: function () {
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}

        var row = mygrid.selected();
        if (row != null) {
            var childs = $('#permissionitemGrid').treegrid('getChildren', row.Id);
            if (childs.length > 0) {
                $.messager.alert('警告提示', '当前所选有子操作权限项数据，不能删除。<br> 请先删除子操作权限项数据！', 'warning');
                return false;
            }
            var query = 'action=Delete&KeyId=' + row.Id;
            $.messager.confirm('询问提示', '确认要删除选中的操作权限项吗？', function (data) {
                if (data) {
                    $.ajaxjson(actionUrl, query, function (d) {
                        if (d.Success) {
                            msg.ok(d.Message);
                            mygrid.reload();
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
                else {
                    return false;
                }
            });
        }
        else {
            msg.warning('请选择要删除的操作权限项!');
            return false;
        }
        return false;
    },
    move: function() {
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        //功能代码逻辑...
        var row = mygrid.selected();
        if (row != null) {
            var ad = top.$.hDialog({
                max: false,
                width: 350,
                height: 500,
                title: '移动操作权限项 ━ ' + row.FullName,
                iconCls: 'icon16_arrow_switch',
                content: '<ul id="tempTree"></ul>',
                submit: function () {
                    var node = top.$('#tempTree').tree('getSelected');
                    if (node) {
                        $.ajaxtext(actionUrl, 'action=MoveTo&keyId=' + row.Id + '&parentId=' + node.id, function (d) {
                            if (d > 0) {
                                msg.ok('移动成功！');
                                mygrid.reload();
                                ad.dialog('close');
                            } else if (d == 0) {
                                msg.warning('移动失败！');
                            } else {
                                msg.error('移动出错！');
                            }
                        });
                    } else {
                        msg.warning('请选择要移动的节点！');
                    }
                }
            });

            top.$(ad).hLoading();
            //初始化tree
            top.$('#tempTree').tree({
                url: 'Modules/handler/PermissionItemAdminHandler.ashx?action=GetPermissionItemTree',
                valuefield: 'id',
                textField: 'text',
                animate: true,
                lines: true,
                onLoadSuccess: function (node, data) {
                    top.$(ad).hLoading.hide(); //加载完毕后隐藏loading
                },
                onSelect: function (node) {
                    if (node.id == row.Id) {
                        top.$.messager.alert('警告提示', '上级操作权限不能与当前所选相同！', 'warning');
                        return;
                    }
                }
            });
        } else {
            msg.warning('请选择要移动的操作权限项!');
            return false;
        }
        return false;
    },
    userPermissionItemBatchSet: function () {
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        var userGrid,
            curUserPermissionItemIds = []; //当前所选用户所拥有的操作权限项ID        
        var setDialog = top.$.hDialog({
            title: '用户操作权限批量设置',
            width: 670, height: 600, iconCls: 'icon16_user_level_filtering', //cache: false,
            href: "Modules/html/PermissionBacthSetForm.htm?n=" + Math.random(),
            onLoad: function () {
                using('panel', function () {
                    top.$('#panelTarget').panel({ title: '操作权限项', iconCls: 'icon-org', height: $(window).height() - 3 });
                });
                userGrid = top.$('#leftnav').datagrid({
                    title: '所有用户',
                    url: 'Modules/handler/UserAdminHandler.ashx',
                    nowrap: false, //折行
                    //fit: true,
                    rownumbers: true, //行号
                    striped: true, //隔行变色
                    idField: 'ID', //主键
                    singleSelect: true, //单选
                    frozenColumns: [[]],
                    columns: [[
                        { title: '登录名', field: 'USERNAME', width: 120, align: 'left' },
                        { title: '用户名', field: 'REALNAME', width: 150, align: 'left' }
                    ]],
                    onLoadSuccess: function (data) {
                        top.$('#rightnav').tree({
                            cascadeCheck: false, //联动选中节点
                            checkbox: true,
                            lines: true,
                            url: 'Modules/handler/PermissionItemAdminHandler.ashx?action=GetPermissionItemTree',
                            onSelect: function (node) {
                                top.$('#rightnav').tree('getChildren', node.target);
                            }
                        });
                        top.$('#leftnav').datagrid('selectRow', 0);
                    },
                    onSelect: function (rowIndex, rowData) {
                        curUserPermissionItemIds = [];
                        var query = 'action=GetPermissionItemsByUserId&userid=' + rowData.ID;
                        $.ajaxtext('handler/PermissionHandler.ashx', query, function (data) {
                            var permissionItemTree = top.$('#rightnav');
                            permissionItemTree.tree('uncheckedAll');
                            if (data == '' || data.toString() == '[object XMLDocument]') {
                                return;
                            }
                            curUserPermissionItemIds = data.split(',');
                            for (var i = 0; i < curUserPermissionItemIds.length; i++) {
                                var node = permissionItemTree.tree('find', curUserPermissionItemIds[i]);
                                if (node)
                                    permissionItemTree.tree("check", node.target);
                            }
                        });
                    }
                });
            },
            submit: function () {
                var allSelectPemissionItemIds = pubMethod.getUserSelectedPermissionItems().split(',');
                var grantPemissionItemIds = '';
                var revokePemissionItemIds = '';
                var flagRevoke = 0;
                var flagGrant = 0;

                while (flagRevoke < curUserPermissionItemIds.length) {
                    if ($.inArray(curUserPermissionItemIds[flagRevoke], allSelectPemissionItemIds) == -1) {
                        revokePemissionItemIds += curUserPermissionItemIds[flagRevoke] + ','; //得到收回的权限列表
                    }
                    ++flagRevoke;
                }

                while (flagGrant < allSelectPemissionItemIds.length) {
                    if ($.inArray(allSelectPemissionItemIds[flagGrant], curUserPermissionItemIds) == -1) {
                        grantPemissionItemIds += allSelectPemissionItemIds[flagGrant] + ','; //得到授予的权限列表
                    }
                    ++flagGrant;
                }

                var query = 'action=SetUserPermissionItem&userid=' + top.$('#leftnav').datagrid('getSelected').ID + '&grantIds=' + grantPemissionItemIds + "&revokeIds=" + revokePemissionItemIds;
                $.ajaxjson('handler/PermissionHandler.ashx', query, function (d) {
                    if (d.Data > 0) {
                        msg.ok('设置成功！');
                    }
                    else {
                        alert(d.Message);
                    }
                });
            }
        });
        return false;
    },
    rolePermissionItemBatchSet: function () {
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        var roleGrid,
            curRolePermissionItemIds = []; //当前所选角色所拥有的操作权限项ID
        var setDialog = top.$.hDialog({
            title: '角色操作权限批量设置',
            width: 670, height: 600, iconCls: 'icon16_group_key', //cache: false,
            href: "Modules/html/PermissionBacthSetForm.htm?n=" + Math.random(),
            onLoad: function () {
                using('panel', function () {
                    top.$('#panelTarget').panel({ title: '操作权限项', iconCls: 'icon-org', height: $(window).height() - 3 });
                });
                roleGrid = top.$('#leftnav').datagrid({
                    title: '所有角色',
                    url: 'Modules/handler/RoleAdminHandler.ashx?action=getrolelist',
                    nowrap: false, //折行
                    //fit: true,
                    rownumbers: true, //行号
                    striped: true, //隔行变色
                    idField: 'ID', //主键
                    singleSelect: true, //单选
                    frozenColumns: [[]],
                    columns: [[
                        { title: '角色编码', field: 'CODE', width: 120, align: 'left' },
                        { title: '角色名称', field: 'REALNAME', width: 150, align: 'left' }
                    ]],
                    onLoadSuccess: function (data) {
                        top.$('#rightnav').tree({
                            cascadeCheck: false, //联动选中节点
                            checkbox: true,
                            lines: true,
                            url: 'Modules/handler/PermissionItemAdminHandler.ashx?action=GetPermissionItemTree',
                            onSelect: function (node) {
                                top.$('#rightnav').tree('getChildren', node.target);
                            }
                        });
                        top.$('#leftnav').datagrid('selectRow', 0);
                    },
                    onSelect: function (rowIndex, rowData) {
                        curRolePermissionItemIds = '';
                        var query = 'action=GetPermissionItemsByRoleId&roleid=' + rowData.ID;
                        $.ajaxtext('handler/PermissionHandler.ashx', query, function (data) {
                            var permissionItemTree = top.$('#rightnav');
                            permissionItemTree.tree('uncheckedAll');
                            if (data == '' || data.toString() == '[object XMLDocument]') {
                                return;
                            }
                            curRolePermissionItemIds = data.split(',');
                            for (var i = 0; i < curRolePermissionItemIds.length; i++) {
                                var node = permissionItemTree.tree('find', curRolePermissionItemIds[i]);
                                if (node)
                                    permissionItemTree.tree("check", node.target);
                            }
                        });
                    }
                });
            },
            submit: function () {
                var allSelectPermissionItemIds = pubMethod.getUserSelectedPermissionItems().split(',');
                var grantIds = '';
                var revokeIds = '';
                var flagRevoke = 0;
                var flagGrant = 0;

                while (flagRevoke < curRolePermissionItemIds.length) {
                    if ($.inArray(curRolePermissionItemIds[flagRevoke], allSelectPermissionItemIds) == -1) {
                        revokeIds += curRolePermissionItemIds[flagRevoke] + ','; //得到收回的权限列表
                    }
                    ++flagRevoke;
                }

                while (flagGrant < allSelectPermissionItemIds.length) {
                    if ($.inArray(allSelectPermissionItemIds[flagGrant], curRolePermissionItemIds) == -1) {
                        grantIds += allSelectPermissionItemIds[flagGrant] + ','; //得到授予的权限列表
                    }
                    ++flagGrant;
                }

                var query = 'action=SetRolePermissionItem&roleid=' + top.$('#leftnav').datagrid('getSelected').ID + '&grantIds=' + grantIds + "&revokeIds=" + revokeIds;
                $.ajaxjson('handler/PermissionHandler.ashx', query, function (d) {
                    if (d.Data > 0) {
                        msg.ok('设置成功！');
                    }
                    else {
                        alert(d.Message);
                    }
                });
            }
        });
        top.$(setDialog).hLoading();
        return false;
    }
};
var pubMethod = {
    bindCtrl: function (navId) {
        var treeData = navgrid.treegrid('getData');
        treeData = JSON.stringify(treeData).replace(/Id/g, 'id').replace(/FullName/g, 'text');
        treeData = '[{"id":0,"selected":true,"text":"请选择父级操作权限项"},' + treeData.substr(1, treeData.length - 1);

        top.$('#txt_ParentId').combotree({
            data: JSON.parse(treeData),
            valueField: 'id',
            textField: 'text',
            panelWidth: '280',
            editable: false,
            lines: true,
            onSelect: function (item) {
                var nodeId = top.$('#txt_ParentId').combotree('getValue');
                if (item.id == navId) {
                    top.$('#txt_ParentId').combotree('setValue', nodeId);
                    top.$.messager.alert('警告提示', '上级操作权限不能与当前所选相同！', 'warning');
                }
            }
        }).combotree('setValue', 0);

        top.$('#txt_Code').focus();
        top.$('#chk_Enabled').attr("checked", true);
        top.$('#chk_AllowEdit').attr("checked", true);
        top.$('#chk_AllowDelete').attr("checked", true);
        top.$('#uiform').validate({
            //此处加入验证
        });
    },
    bindCategory: function bindCategory() {
        top.$('#txt_Category').combobox({
            url: 'Modules/handler/DataItemAdminHandler.ashx?action=GetCategory&categorycode=ModuleCategory',
            method: 'get',
            valueField: 'ITEMVALUE',
            textField: 'ITEMNAME',
            editable: false,
            panelHeight: 'auto'
        });
    },
    getUserSelectedPermissionItems: function () { //得到用户选择的模块       
        var nodes = top.$('#rightnav').tree('getChecked');

        if (nodes.length > 0) {
            var dwg = [];
            for (var i = 0; i < nodes.length; i++) {
                dwg.push(nodes[i].id);
            }
            //alert(dwg.join(','));
            return dwg.join(',');

        } else {
            return "";
        }
    }

};
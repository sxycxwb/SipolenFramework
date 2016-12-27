﻿/*
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
    *   3、 2013-11-20 XuWangBin V2.7 新增移动与导出功能。
    *   2、 2013-08-13 XuWangBin V2.5 增加对“组织机构”增、删、改的业务逻辑。
    *   1、 2013-08-11 XuWangBin V2.5 新增本业务逻辑的编写。
*/

var actionUrl = 'handler/OrganizeAdminHander.ashx',
    formUrl   = "Modules/html/OrganizeForm.htm?n=" + Math.random(),
    navgrid;

$(function () {
    autoResize({ dataGrid: '#organizeGrid', gridType: 'treegrid', callback: mygrid.bindGrid, height: 5 });
    $('#btnAdd').attr('onclick', 'OrganizeAdminMethod.AddOrganize();');//新增组织机构
    $('#btnEdit').attr('onclick', 'OrganizeAdminMethod.EditOrganize();');//修改组织机构
    $('#btnDelete').attr('onclick', 'OrganizeAdminMethod.DeleteOrganize();');//删除组织机构
    $('#btnMoveTo').attr('onclick', 'OrganizeAdminMethod.MoveTo();');//移动组织机构
    $('#btnExport').attr('onclick', 'OrganizeAdminMethod.ExportOrganize();');//导出组织机构数据
    $('#btnUserOrganizePermission').attr('onclick', 'OrganizeAdminMethod.SetUserOrganizePermission();');//设置用户组织机构权限
    $('#btnRoleOrganizePermission').attr('onclick', 'OrganizeAdminMethod.SetRoleOrganizePermission();'); //设置角色组织机构权限
    $('#a_refresh').attr('onclick', 'OrganizeAdminMethod.Refreash();');//刷新
});

var mygrid = {
    bindGrid: function (winsize) {
        navgrid = $('#organizeGrid').treegrid({
            toolbar: '#toolbar',
            //title: '组织机构列表',
            //iconCls: 'icon icon-org',
            width: winsize.width,
            height: winsize.height,
            nowrap: true,
            rownumbers: true,
            animate: true,
            resizable: true,
            collapsible: false,
            onContextMenu: pageContextMenu.createTreeGridContextMenu,
            url: actionUrl,
            idField: 'Id',
            treeField: 'FullName',
			onDblClickRow:function(row){
				document.getElementById('btnEdit').click();
			},
            frozenColumns: [[
                { title: '组织机构名称', field: 'FullName', width: 200 },
                { title: '编码', field: 'Code', width: 100 }
            ]],
            columns: [[
                { title: '简称', field: 'ShortName', width: 120 },
                { title: '主负责人', field: 'Manager', width: 70, align: 'center' },
                { title: '电话', field: 'OuterPhone', width: 100, align: 'center' },
                { title: '传真', field: 'Fax', width: 100, align: 'center' },
                { title: '有效', field: 'Enabled', width: 50, align: 'center', formatter: imgcheckbox },
                { title: '排序', field: 'SortCode', width: 80, align: 'center' },
                { title: '备注', field: 'Description', width: 300 },
                { title: 'ParentId', field: 'ParentId', hidden: true },
                { title: 'Category', field: 'Category', hidden: true },
                { title: 'InnerPhone', field: 'InnerPhone', hidden: true },
                { title: 'Postalcode', field: 'Postalcode', hidden: true },
                { title: 'Address', field: 'Address', hidden: true },
                { title: 'Web', field: 'Web', hidden: true },
                { title: 'AssistantManager', field: 'AssistantManager', hidden: true },
                { title: 'IsInnerOrganize', field: 'IsInnerOrganize', hidden: true }
            ]]
        });
    },
    reload: function () {
        navgrid.treegrid('reload');
    },
    selected: function () {
        return navgrid.treegrid('getSelected');
    }
};
var imgcheckbox = function (cellvalue, options, rowObject) {
    return cellvalue ? '<img src="/Content/css/icon/bullet_tick.png" alt="正常" title="正常" />' : '<img src="/Content/css/icon/bullet_minus.png" alt="禁用" title="禁用" />';
};
var OrganizeAdminMethod = {
    Refreash: function() {
        mygrid.reload();
    },
    AddOrganize: function() { //增加组织机构
        var addDialog = top.$.hDialog({
            href: formUrl,
            title: '添加组织机构',
            iconCls: 'icon16_add',
            width: 750,
            height: 450,
            onLoad: function() {
                pubMethod.bindCtrl();
                pageMethod.bindCategory('Category', 'OrganizeCategory');
                pubMethod.bindComboGrid();
                var row = mygrid.selected();
                if (row) {
                    top.$('#ParentId').combotree('setValue', row.ParentId);
                }
            },
            submit: function() {
                if (top.$('#uiform').validate().form()) {
                    var queryString = pageMethod.serializeJson(top.$('#uiform'));
                    $.ajaxjson(actionUrl + '?action=SubmitForm', queryString, function (d) {
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
    EditOrganize: function() { //修改组织机构
        var row = mygrid.selected();
        if (row) {
            var editDailog = top.$.hDialog({
                href: formUrl,
                title: '修改组织机构',
                iconCls: 'icon16_edit_button',
                width: 750,
                height: 450,
                onLoad: function() {
                    pubMethod.bindCtrl(row.Id);
                    pageMethod.bindCategory('Category', 'OrganizeCategory');
                    pubMethod.bindComboGrid();
                    var parm = 'action=GetEntity&key=' + row.Id;
                    $.ajaxjson(actionUrl, parm, function (data) {
                        if (data) {
                            SetWebControls(data, true);
                        }
                    });
                },
                submit: function() {
                    if (top.$('#uiform').validate().form()) {

                        //保存时判断当前节点所选的父节点，不能为当前节点的子节点，这样就乱套了....
                        var treeParentId = top.$('#ParentId').combotree('tree'); // 得到树对象
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
                        var queryString = pageMethod.serializeJson(top.$('#uiform'));
                        $.ajaxjson(actionUrl + '?action=SubmitForm&key=' + row.Id, queryString, function (d) {
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
            msg.warning('请选择要修改的组织机构!');
            return false;
        }
        return false;
    },
    DeleteOrganize: function() { //删除组织机构
        var row = mygrid.selected();
        if (row != null) {
            var childs = $('#organizeGrid').treegrid('getChildren', row.Id);
            if (childs.length > 0) {
                $.messager.alert('警告提示', '当前所选有子节点数据，不能删除。', 'warning');
                return false;
            }
            var query = 'action=DeleteOrganize&KeyId=' + row.Id;
            $.messager.confirm('询问提示', '确认要删除选中的组织机构吗？', function(data) {
                if (data) {
                    $.ajaxjson(actionUrl, query, function(d) {
                        if (d.Success) {
                            msg.ok(d.Message);
                            mygrid.reload();
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                } else {
                    return false;
                }
            });
        } else {
            msg.warning('请选择要删除的组织机构!');
            return false;
        }
        return false;
    },
    MoveTo: function() { //移动组织机构
        var row = mygrid.selected();
        if (row != null) {
            var ad = top.$.hDialog({
                max: false,
                width: 300,
                height: 500,
                title: '移动组织机构 ━ ' + row.FullName,
                iconCls: 'icon16_arrow_switch',
                content: '<ul id="orgTree"></ul>',
                submit: function () {
                    var node = top.$('#orgTree').tree('getSelected');
                    if (node) {
                        $.ajaxtext(actionUrl, 'action=MoveTo&organizeId=' + row.Id + '&parentId=' + node.id, function (d) {
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
            //var treeData = navgrid.treegrid('getData');
           // treeData = JSON.stringify(treeData).replace(/Id/g, 'id').replace(/FullName/g, 'text');
            //treeData = '[{"id":0,"selected":true,"text":"请选择上级节点"},' + treeData.substr(1, treeData.length - 1);
            //treeData = treeData.substr(1, treeData.length - 1);
            top.$('#orgTree').tree({
                url: 'Modules/handler/OrganizeAdminHander.ashx?action=treedata',
                valuefield: 'id',
                textField: 'text',
                animate: true,
                lines: true,
                onLoadSuccess: function (node, data) {
                    top.$.hLoading.hide(); //加载完毕后隐藏loading
                },
                onClick: function (node) {
                    var selectedId = node.id;
                }
            });

        } else {
            msg.warning('请选择要移动的组织机构!');
            return false;
        }
        return false;
    },
    ExportOrganize: function() { //导出组织机构
        alert('参考其他通用导出模块代码');
        return false;
    },
    SetUserOrganizePermission: function() { //设置用户组织机构权限
        //功能代码逻辑...
        var userGrid;
        var curResourceTargetResourceIds = [];
        var setDialog = top.$.hDialog({
            title: '（用户-组织机构）权限设置',
            width: 670,
            height: 600,
            iconCls: 'icon16_key', //cache: false,
            href: "Modules/html/PermissionBacthSetForm.htm?n=" + Math.random(),
            onLoad: function() {
                using('panel', function() {
                    top.$('#panelTarget').panel({ title: '组织机构列表', iconCls: 'icon-org', height: $(window).height() - 3 });
                });

                userGrid = top.$('#leftnav').datagrid({
                    title: '用户列表',
                    url: 'Modules/handler/UserAdminHandler.ashx',
                    nowrap: false, //折行
                    //fit: true,
                    rownumbers: true, //行号
                    striped: true, //隔行变色
                    idField: 'ID', //主键
                    singleSelect: true, //单选
                    frozenColumns: [[]],
                    columns: [
                        [
                            { title: '登录名', field: 'USERNAME', width: 120, align: 'left' },
                            { title: '用户名', field: 'REALNAME', width: 150, align: 'left' }
                        ]
                    ],
                    onLoadSuccess: function(data) {
                        top.$('#rightnav').tree({
                            cascadeCheck: false, //联动选中节点
                            checkbox: true,
                            lines: true,
                            url: 'Modules/handler/OrganizeAdminHander.ashx?action=treedata',
                            onSelect: function(node) {
                                top.$('#rightnav').tree('getChildren', node.target);
                            }
                        });
                        top.$('#leftnav').datagrid('selectRow', 0);
                    },
                    onSelect: function(rowIndex, rowData) {
                        curResourceTargetResourceIds = [];
                        var query = 'action=GetPermissionScopeTargetIds'
                            + '&resourceCategory=PiUser&resourceId=' + rowData.ID
                            + '&targetCategory=PiOrganize';
                        $.ajaxtext('handler/PermissionHandler.ashx', query, function(data) {
                            var targetResourceTree = top.$('#rightnav');
                            targetResourceTree.tree('uncheckedAll');
                            if (data == '' || data.toString() == '[object XMLDocument]') {
                                return;
                            }
                            curResourceTargetResourceIds = data.split(',');
                            for (var i = 0; i < curResourceTargetResourceIds.length; i++) {
                                var node = targetResourceTree.tree('find', curResourceTargetResourceIds[i]);
                                if (node)
                                    targetResourceTree.tree("check", node.target);
                            }
                        });
                    }
                });
            },
            submit: function() {
                var allSelectTargetResourceIds = permissionMgr.getSelectedResource().split(',');
                var grantResourceIds = '';
                var revokeResourceIds = '';
                var flagRevoke = 0;
                var flagGrant = 0;
                while (flagRevoke < curResourceTargetResourceIds.length) {
                    if ($.inArray(curResourceTargetResourceIds[flagRevoke], allSelectTargetResourceIds) == -1) {
                        revokeResourceIds += curResourceTargetResourceIds[flagRevoke] + ','; //得到收回的权限列表
                    }
                    ++flagRevoke;
                }

                while (flagGrant < allSelectTargetResourceIds.length) {
                    if ($.inArray(allSelectTargetResourceIds[flagGrant], curResourceTargetResourceIds) == -1) {
                        grantResourceIds += allSelectTargetResourceIds[flagGrant] + ','; //得到授予的权限列表
                    }
                    ++flagGrant;
                }

                var query = 'action=GrantRevokePermissionScopeTargets&resourceId=' + top.$('#leftnav').datagrid('getSelected').ID
                    + '&resourceCategory=PiUser&targetCategory=PiOrganize'
                    + '&grantTargetIds=' + grantResourceIds + "&revokeTargetIds=" + revokeResourceIds;
                $.ajaxjson('handler/PermissionHandler.ashx', query, function(d) {
                    if (d.Data > 0) {
                        msg.ok('设置成功！');
                    } else {
                        alert(d.Message);
                    }
                });
            }
        });
        return false;
    },
    SetRoleOrganizePermission: function() { //设置角色组织机构权限
        var userGrid;
        var curResourceTargetResourceIds = [];
        var setDialog = top.$.hDialog({
            title: '（角色-组织机构）权限设置',
            width: 670,
            height: 600,
            iconCls: 'icon16_key', //cache: false,
            href: "Modules/html/PermissionBacthSetForm.htm?n=" + Math.random(),
            onLoad: function() {
                using('panel', function() {
                    top.$('#panelTarget').panel({ title: '组织机构列表', iconCls: 'icon-org', height: $(window).height() - 3 });
                });

                userGrid = top.$('#leftnav').datagrid({
                    title: '角色列表',
                    url: 'Modules/handler/RoleAdminHandler.ashx?action=getrolelist',
                    nowrap: false, //折行
                    //fit: true,
                    rownumbers: true, //行号
                    striped: true, //隔行变色
                    idField: 'ID', //主键
                    singleSelect: true, //单选
                    frozenColumns: [[]],
                    columns: [
                        [
                            { title: '角色编码', field: 'CODE', width: 120, align: 'left' },
                            { title: '角色名称', field: 'REALNAME', width: 150, align: 'left' }
                        ]
                    ],
                    onLoadSuccess: function(data) {
                        top.$('#rightnav').tree({
                            cascadeCheck: false, //联动选中节点
                            checkbox: true,
                            lines: true,
                            url: 'Modules/handler/OrganizeAdminHander.ashx?action=treedata',
                            onSelect: function(node) {
                                top.$('#rightnav').tree('getChildren', node.target);
                            }
                        });
                        top.$('#leftnav').datagrid('selectRow', 0);
                    },
                    onSelect: function(rowIndex, rowData) {
                        curResourceTargetResourceIds = [];
                        var query = 'action=GetPermissionScopeTargetIds'
                            + '&resourceCategory=PiRole&resourceId=' + rowData.ID
                            + '&targetCategory=PiOrganize';
                        $.ajaxtext('handler/PermissionHandler.ashx', query, function(data) {
                            var targetResourceTree = top.$('#rightnav');
                            targetResourceTree.tree('uncheckedAll');
                            if (data == '' || data.toString() == '[object XMLDocument]') {
                                return;
                            }
                            curResourceTargetResourceIds = data.split(',');
                            for (var i = 0; i < curResourceTargetResourceIds.length; i++) {
                                var node = targetResourceTree.tree('find', curResourceTargetResourceIds[i]);
                                if (node)
                                    targetResourceTree.tree("check", node.target);
                            }
                        });
                    }
                });
            },
            submit: function() {
                var allSelectTargetResourceIds = permissionMgr.getSelectedResource().split(',');
                var grantResourceIds = '';
                var revokeResourceIds = '';
                var flagRevoke = 0;
                var flagGrant = 0;
                while (flagRevoke < curResourceTargetResourceIds.length) {
                    if ($.inArray(curResourceTargetResourceIds[flagRevoke], allSelectTargetResourceIds) == -1) {
                        revokeResourceIds += curResourceTargetResourceIds[flagRevoke] + ','; //得到收回的权限列表
                    }
                    ++flagRevoke;
                }

                while (flagGrant < allSelectTargetResourceIds.length) {
                    if ($.inArray(allSelectTargetResourceIds[flagGrant], curResourceTargetResourceIds) == -1) {
                        grantResourceIds += allSelectTargetResourceIds[flagGrant] + ','; //得到授予的权限列表
                    }
                    ++flagGrant;
                }

                var query = 'action=GrantRevokePermissionScopeTargets&resourceId=' + top.$('#leftnav').datagrid('getSelected').ID
                    + '&resourceCategory=PiRole&targetCategory=PiOrganize'
                    + '&grantTargetIds=' + grantResourceIds + "&revokeTargetIds=" + revokeResourceIds;
                $.ajaxjson('handler/PermissionHandler.ashx', query, function(d) {
                    if (d.Data > 0) {
                        msg.ok('设置成功！');
                    } else {
                        alert(d.Message);
                    }
                });
            }
        });
        return false;
    }
};

//公共方法
var pubMethod = {
    bindCtrl: function (navId) {
        var treeData = navgrid.treegrid('getData');
        treeData = JSON.stringify(treeData).replace(/Id/g, 'id').replace(/FullName/g, 'text');
        treeData = '[{"id":0,"selected":true,"text":"请选择上级节点"},' + treeData.substr(1, treeData.length - 1);

        top.$('#ParentId').combotree({
            data: JSON.parse(treeData),
            valueField: 'id',
            textField: 'text',
            panelWidth: '280',
            editable: false,
            lines: true,
            onSelect: function (node) {
                var nodeId = top.$('#ParentId').combotree('getValue');
                if (node.id == navId) {
                    top.$('#ParentId').combotree('setValue', nodeId);
                    top.$.messager.alert('警告提示', '上级节点不能与当前所选相同！', 'warning');
                }
            }
        }).combotree('setValue', 0);

        top.$('#Code').focus();
        top.$('#Enabled').attr("checked", true);
        top.$('#uiform').validate({
            //此处加入验证
        });
    },
    bindComboGrid: function () {
        top.$('#ManagerId,#AssistantManagerId').combogrid({
            panelWidth: 320,
            idField: 'ID',
            textField: 'REALNAME',
            url: 'Modules/handler/UserAdminHandler.ashx?action=GetUserListByPage',
            sortName: 'SORTCODE',
            sortOrder: 'asc',
            showPageList: false,
            striped: true,
            pagination: true,
            rownumbers: true,
            fitColumns: true,
            pageSize: 200,
            pageList: [100, 200, 300, 500],
            method: 'post',
            columns: [[
                { title: '登录名', field: 'USERNAME', width: 60, sortable: true },
                { title: '用户名', field: 'REALNAME', width: 70 }
            ]]
        });
    }
};

var permissionMgr = {
    getSelectedResource: function () {
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


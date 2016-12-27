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
* RDIFramework.NET框架“框架模块（菜单）综合管理”业务界面逻辑
*
* 主要完成模块（菜单）的增加、修改、删除、移动、导出、用户或角色所拥有的模块（菜单）设置等。
* 修改记录：
*   1. 2013-08-19 XuWangBin 新增本业务逻辑的编写。
*/


var actionUrl = 'handler/ModuleAdminHandler.ashx',
    formUrl = "Modules/html/ModuleForm.htm?n=" + Math.random(),
    navgrid;

$(function () {
    autoResize({ dataGrid: '#moduleGrid', gridType: 'treegrid', callback: grid.databind, height: 5 });
    $('#a_add').attr('onclick', 'crud.add();');
    $('#a_edit').attr('onclick', 'crud.edit();');
    $('#a_delete').attr('onclick', 'crud.del();');
    $('#a_refresh').attr('onclick', 'crud.refreash();');
    $('#a_setusermodulepermission').attr('onclick', 'crud.userModulePermissionBatchSet();');
    $('#a_setrolemodulepermission').attr('onclick', 'crud.roleModulePermissionBatchSet();');
    $('#a_moduleconfig').attr('onclick', 'crud.moduleconfig();');

    //$('#a_add').click(crud.add);
    //$('#a_edit').click(crud.edit);
    //$('#a_delete').click(crud.del);
    //$('#a_refresh').click(function () { //刷新
    //    grid.reload();
    //});

    //$('#a_setusermodulepermission').click(crud.userModulePermissionBatchSet);
    //$('#a_setrolemodulepermission').click(crud.roleModulePermissionBatchSet);
    //$('#a_moduleconfig').click(crud.moduleconfig);
});

var grid = {
    databind: function (winsize) {
        navgrid = $('#navGrid').treegrid({
            toolbar: '#toolbar',
            title: '模块（菜单）列表',
            iconCls: 'icon icon-chart_organisation',
            width: winsize.width,
            height: winsize.height,
            nowrap: false,
            rownumbers: true,
            //animate: true,
            resizable: true,
            collapsible: false,
            url: actionUrl,
            onContextMenu: pageContextMenu.createTreeGridContextMenu,
            idField: 'Id',
            treeField: 'FullName',
            frozenColumns: [[
                { title: '模块（菜单）名称', field: 'FullName', width: 200 },
                { title: '编码', field: 'Code', width: 130 }
            ]],
            columns: [[
                { title: 'Id', field: 'Id', hidden: true },
                { title: 'ParentId', field: 'ParentId', hidden: true },
                { title: '模块分类', field: 'Category', width: 100 },
                { title: '图标', field: 'IconCss', width: 130, hidden: true },
                { title: 'Web链接地址', field: 'NavigateUrl', width: 200 },
                { title: 'WinForm程序集', field: 'AssemblyName', width: 150 },
                { title: 'WinForm窗体', field: 'FormName', width: 200 },
                {
                    title: '模块类型', field: 'ModuleType', width: 60, align: 'center', formatter: function (v, d, i) {
                        if (v == 1){
                            return '<img src="/Content/images/' + "winform.png" + '" />';
                        }
                        else if (v == 2) {
                            return '<img src="/Content/images/' + "webform.png" + '" />';
                        }
                        else if (v == 3) {
                            return '<img src="/Content/images/' + "winwebform.png" + '" />';
                        }
                        else {
                            return '<img src="/Content/images/' + "otherform.png" + '" />';
                        }                        
                    }
                },
                {
                    title: '公共', field: 'IsPublic', width: 50, align: 'center', formatter: function (v, d, i) {
                        return '<img src="/Content/images/' + (v ? "checkmark.gif" : "checknomark.gif") + '" />';
                    }
                },                
                { title: '有效', field: 'Enabled', width: 50, align: 'center', formatter: imgcheckbox },                
                { title: '排序', field: 'SortCode', width: 80, align: 'right' },
                { title: '备注', field: 'Description', width: 500 },
                //{ title: 'AllowEdit', field: 'AllowEdit', hidden: true },
                { title: 'AllowDelete', field: 'AllowDelete', hidden: true }
                //{ title: 'ModuleType', field: 'ModuleType', hidden: true }
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

var imgcheckbox = function(cellvalue, options, rowObject) {
    return cellvalue ? '<img src="/Content/css/icon/bullet_tick.png" alt="正常" title="正常" />' : '<img src="/Content/css/icon/bullet_minus.png" alt="禁用" title="禁用" />';
};

var showIcon = function () {
    top.$('#selecticon').click(function () {
        var iconDialog = top.$.hDialog({
            iconCls: 'icon16_application',
            href: '/Content/css/iconModuleList.htm?v=' + Math.random(),
            title: '选取图标', width: 800, height: 600, showBtns: false,
            onLoad: function () {
                top.$('#iconlist li').attr('style', 'float:left;border:1px solid #fff;margin:2px;width:16px;cursor:pointer').click(function () {
                    //var iconCls = top.$(this).find('span').attr('class').replace('icon ', '');
                    var iconCls = top.$(this).find('span').attr('class');
                    top.$('#txt_IconCss').val(iconCls);
                    top.$('#txt_IconUrl').val(top.$(this).attr('title'));
                    //top.$('#smallIcon').attr('class', "icon " + iconCls);
                    top.$('#smallIcon').attr('class', iconCls);

                    iconDialog.dialog('close');
                }).hover(function () {
                    top.$(this).css({ 'border': '1px solid red' });
                }, function () {
                    top.$(this).css({ 'border': '1px solid #fff' });
                });
                //top.$('#btnicon').click(function() {
                //    $.get(actionURL, 'action=buildIcon', function(d) {
                //        top.$.hDialog({
                //            content: '<textarea style="width:100%;height:100%;">' + d + '</textarea>',
                //            max: true
                //        });
                //    });

                //});
            }
        });
    });
};

function createParam(action, keyid, ids) {
    var o = {};
    var query = top.$('#uiform').serializeArray();
    query = convertArray(query);
    o.jsonEntity = JSON.stringify(query);
    o.action = action;
    o.keyid = keyid;
    if (ids)
        o.keyids = ids;
    else {
        o.keyids = '';
    }
    return "json=" + JSON.stringify(o);
}

function getChildNodes(treeNodeId, result) {
    var childrenNodes = navgrid.treegrid('getChildren', treeNodeId);
    if (childrenNodes) {
        for (var i = 0; i < childrenNodes.length; i++) {
            result.push(childrenNodes[i].KeyId);
            result = getChildNodes(childrenNodes[i].KeyId, result);
        }
    }
    return result;
};

var crud = {
    refreash:function() {
        grid.reload();
    },
    bindCtrl: function (navId) {
        var treeData = navgrid.treegrid('getData');
        treeData = JSON.stringify(treeData).replace(/Id/g, 'id').replace(/FullName/g, 'text');
        treeData = '[{"id":0,"selected":true,"text":"请选择父级模块（菜单）"},' + treeData.substr(1, treeData.length - 1);

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
                    top.$.messager.alert('警告提示', '上级模块不能与当前模块相同！', 'warning');
                }
            }
        }).combotree('setValue', 0);
        showIcon(); //选取图标
        //top.$('#txt_SortCode').numberspinner();
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
        top.$('#cbModuleType').combobox({
            url: 'Modules/handler/DataItemAdminHandler.ashx?action=GetCategory&categorycode=ModuleType',
            method: 'get',
            valueField: 'ITEMVALUE',
            textField: 'ITEMNAME',
            editable: false,
            panelHeight: 'auto'
        });
    },
    add: function () {
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        var addDialog = top.$.hDialog({
            href: formUrl, title: '添加模块（菜单）', iconCls: 'icon16_tab_add', width: 500, height: 540,
            onLoad: function () {
                crud.bindCtrl();
                crud.bindCategory();
                top.$('#cbModuleType').combobox('setValue', '2');
                var row = grid.selected();
                if (row) {
                    top.$('#txt_ParentId').combotree('setValue', row.ParentId);
                }
            },
            submit: function () {
                if (top.$('#uiform').validate().form()) {                    
                    //var param = createParam('add', '0');
                    var vcategory = top.$('#txt_Category').combobox('getValue');
                    var vparentid = top.$('#txt_ParentId').combobox('getValue');
                    var vmoduletype = top.$('#cbModuleType').combobox('getValue');
                    var param = 'action=Add&vcategory=' + vcategory + '&vparentid=' + vparentid + '&vmoduletype=' + vmoduletype + "&" + top.$('#uiform').serialize();
                    $.ajaxjson(actionUrl, param, function (d) {
                        if (d.Success) {
                            msg.ok(d.Message);
                            addDialog.dialog('close');
                            grid.reload();
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
        var row = grid.selected();
        if (row) {
            var editDailog = top.$.hDialog({
                href: formUrl, title: '修改模块（菜单）', iconCls: 'icon16_tab_edit', width: 500, height: 540,
                onLoad: function () {
                    crud.bindCtrl(row.Id);
                    crud.bindCategory();
                     var parm = 'action=GetEntity&KeyId=' + row.Id;
                     $.ajaxjson(actionUrl, parm, function(data) {
                        if (data) {
                            top.$('#txt_Code').val(data.Code);
                            top.$('#txt_FullName').val(data.FullName);
                            top.$('#txt_Category').combobox('setValue', data.Category);
                            top.$('#txt_ParentId').combotree('setValue', data.ParentId);
                            top.$('#txt_NavigateUrl').val(data.NavigateUrl);
                            top.$('#txt_MvcNavigateUrl').val(data.MvcNavigateUrl);
                            top.$('#txt_IconCss').val(data.IconCss);
                            //top.$('#smallIcon').attr('class', "icon " + data.IconCss);
                            top.$('#smallIcon').attr('class', data.IconCss);
                            top.$('#txt_AssemblyName').val(data.AssemblyName);
                            top.$('#txt_FormName').val(data.FormName);
                            top.$('#chk_Enabled').attr('checked', data.Enabled == "1");
                            top.$('#chk_IsPublic').attr('checked', data.IsPublic == "1");
                            top.$('#chk_Expand').attr('checked', data.Expand == "1");
                            top.$('#chk_AllowEdit').attr('checked', data.AllowEdit == "1");
                            top.$('#chk_AllowDelete').attr('checked', data.AllowDelete == "1");
                            top.$('#txt_Description').val(data.Description);
                            top.$('#txt_IconUrl').val(data.IconUrl);
                            top.$('#cbModuleType').combobox('setValue', data.ModuleType);
                        }
                    });
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

                        var vcategory = top.$('#txt_Category').combobox('getValue');
                        var vparentid = top.$('#txt_ParentId').combobox('getValue');
                        var vmoduletype = top.$('#cbModuleType').combobox('getValue');
                        if (!vmoduletype || vmoduletype == 'undefined')
                        {
                            top.$.messager.alert('温馨提示', '请选择模块类型！', 'warning');
                            return;
                        }

                        var query = 'action=Edit&vcategory=' + vcategory + '&vparentid=' + vparentid + '&KeyId=' + row.Id + '&vmoduletype=' + vmoduletype + "&" + top.$('#uiform').serialize();
                        $.ajaxjson(actionUrl, query, function (d) {
                            if (d.Success) {
                                msg.ok(d.Message);
                                editDailog.dialog('close');
                                grid.reload();
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
        var row = grid.selected();
        if (row != null) {
            //var nodes = [row.Id];
            //getChildNodes(row.Id, nodes);

            if (row.AllowDelete == '0') {
                msg.warning('该模块不允许被删除～！');
                return false;
            }
            var childs = $('#navGrid').treegrid('getChildren', row.Id);
            if (childs.length > 0) {
                $.messager.alert('警告提示', '当前模块有子模块数据，不能删除。<br><br> 请先删除子模块数据！', 'warning');
                return false;
            }
            //var query = createParam("Delete", row.Id, nodes.join(','));
            var query = 'action=Delete&KeyId=' + row.Id; // + "&SubIds=" + nodes.join(',');
            $.messager.confirm('询问提示', '确认要删除选中的模块（菜单）吗？', function (data) {
                if (data) {
                    $.ajaxjson(actionUrl, query, function (d) {
                        if (d.Success) {
                            msg.ok(d.Message);
                            grid.reload();
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
            msg.warning('请选择要删除的模块!');
            return false;
        }
        return false;
    },
    userModulePermissionBatchSet: function () { //用户模块（菜单）权限批量设置
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        var userGrid;
        var curUserModuleIds = []; //当前所选用户所拥有的模块ID
        var setDialog = top.$.hDialog({
            title: '用户模块（菜单）权限批量设置',
            width: 670, height: 600, iconCls: 'icon16_user_level_filtering', //cache: false,
            href: "Modules/html/PermissionBacthSetForm.htm?n=" + Math.random(),
            onLoad: function () {
                using('panel', function () {
                    top.$('#panelTarget').panel({ title: '模块（菜单）', iconCls: 'icon-org', height: $(window).height() - 3 });
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
                        top.$('#rightnav').hLoading();
                        top.$('#rightnav').tree({
                            cascadeCheck: false, //联动选中节点
                            checkbox: true,
                            lines: true,
                            url: 'Modules/handler/ModuleAdminHandler.ashx?action=GetModuleTree',
                            onSelect: function (node) {
                                top.$('#rightnav').tree('getChildren', node.target);
                            },onLoadSuccess: function(node, data) {
                                top.$('#rightnav').hLoading.hide();
                            }
                        });
                        top.$('#leftnav').datagrid('selectRow', 0);
                    },
                    onSelect: function (rowIndex, rowData) {
                        curUserModuleIds = [];
                        var query = 'action=GetModuleByUserId&userid=' + rowData.ID;
                        $.ajaxtext('handler/PermissionHandler.ashx', query, function (data) {
                            var moduelTree = top.$('#rightnav');
                            moduelTree.tree('uncheckedAll');
                            if (data == '' || data.toString() == '[object XMLDocument]') {
                                return;
                            }
                            curUserModuleIds = data.split(',');
                            for (var i = 0; i < curUserModuleIds.length; i++) {
                                var node = moduelTree.tree('find', curUserModuleIds[i]);
                                if (node)
                                    moduelTree.tree("check", node.target);
                            }
                        });
                    }
                });
            },
            submit: function () {
                var allSelectModuledIds = permissionMgr.getUserSelectedModule().split(',');
                var grantModuleIds = '';
                var revokeModuleIds = '';
                var flagRevoke = 0;
                var flagGrant = 0;
                while (flagRevoke < curUserModuleIds.length) {
                    if ($.inArray(curUserModuleIds[flagRevoke], allSelectModuledIds) == -1) {
                        revokeModuleIds += curUserModuleIds[flagRevoke] + ','; //得到收回的权限列表
                    }
                    ++flagRevoke;
                }

                while (flagGrant < allSelectModuledIds.length) {
                    if ($.inArray(allSelectModuledIds[flagGrant], curUserModuleIds) == -1) {
                        grantModuleIds += allSelectModuledIds[flagGrant] + ','; //得到授予的权限列表
                    }
                    ++flagGrant;
                }

                var query = 'action=SetUserModulePermission&userid=' + top.$('#leftnav').datagrid('getSelected').ID + '&grantIds=' + grantModuleIds + "&revokeIds=" + revokeModuleIds;
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
    roleModulePermissionBatchSet: function () { //角色模块（菜单）权限批量设置
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        var roleGrid;
        var curRoleModuleIds = []; //当前所选角色所拥有的模块ID
        var setDialog = top.$.hDialog({
            title: '角色模块（菜单）权限批量设置',
            width: 670, height: 600, iconCls: 'icon16_group_key', //cache: false,
            href: "Modules/html/PermissionBacthSetForm.htm?n=" + Math.random(),
            onLoad: function () {
                using('panel', function () {
                    top.$('#panelTarget').panel({ title: '模块（菜单）', iconCls: 'icon-org', height: $(window).height() - 3 });
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
                        top.$('#rightnav').hLoading();
                        top.$('#rightnav').tree({
                            cascadeCheck: false, //联动选中节点
                            checkbox: true,
                            lines: true,
                            url: 'Modules/handler/ModuleAdminHandler.ashx?action=GetModuleTree',
                            onSelect: function (node) {
                                top.$('#rightnav').tree('getChildren', node.target);
                            }, onLoadSuccess: function (node, data) {
                                top.$('#rightnav').hLoading.hide();
                            }
                        });
                        top.$('#leftnav').datagrid('selectRow', 0);
                    },
                    onSelect: function (rowIndex, rowData) {
                        curRoleModuleIds = [];
                        var query = 'action=GetModuleByRoleId&roleid=' + rowData.ID;
                        $.ajaxtext('handler/PermissionHandler.ashx', query, function (data) {
                            var moduelTree = top.$('#rightnav');
                            moduelTree.tree('uncheckedAll');
                            if (data == '' || data.toString() == '[object XMLDocument]') {
                                return;
                            }
                            curRoleModuleIds = data.split(',');
                            for (var i = 0; i < curRoleModuleIds.length; i++) {
                                var node = moduelTree.tree('find', curRoleModuleIds[i]);
                                if (node)
                                    moduelTree.tree("check", node.target);
                            }
                        });
                    }
                });
            },
            submit: function () {
                var allSelectModuledIds = permissionMgr.getUserSelectedModule().split(',');
                var grantModuleIds = '';
                var revokeModuleIds = '';
                var flagRevoke = 0;
                var flagGrant = 0;
                while (flagRevoke < curRoleModuleIds.length) {
                    if ($.inArray(curRoleModuleIds[flagRevoke], allSelectModuledIds) == -1) {
                        revokeModuleIds += curRoleModuleIds[flagRevoke] + ','; //得到收回的权限列表
                    }
                    ++flagRevoke;
                }

                while (flagGrant < allSelectModuledIds.length) {
                    if ($.inArray(allSelectModuledIds[flagGrant], curRoleModuleIds) == -1) {
                        grantModuleIds += allSelectModuledIds[flagGrant] + ','; //得到授予的权限列表
                    }
                    ++flagGrant;
                }
                var query = 'action=SetRoleModulePermission&roleid=' + top.$('#leftnav').datagrid('getSelected').ID + '&grantIds=' + grantModuleIds + "&revokeIds=" + revokeModuleIds;
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
    moduleconfig: function () {  //模块配置
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        var setDialog = top.$.hDialog({
            title: '模块（菜单）配置',
            width: 380, height: 500, iconCls: 'icon16_tab_content_vertical',
            content: htmlModuleConfig(),
            submit: function () {

            }
        });
        top.$(setDialog).hLoading();
        var treemodule = top.$('#contentArea').tree({
            cascadeCheck: false, //联动选中节点
            checkbox: true,
            lines: true,
            url: 'Modules/handler/ModuleAdminHandler.ashx?action=GetModuleTree',
            onLoadSuccess: function (node, data) {
                top.$.hLoading.hide(); //加载完毕后隐藏loading
                //alert('模块加载成功，改功能模块尚示完成！');
            },
            onSelect: function (node) {
                top.$('#contentArea').tree('getChildren', node.target);
            },
            onDblClick: function (node) { //双击节点选中节点及期子节点
                var t = top.$('#contentArea');
                t.tree('check', node.target);
                function checkNodes(n) {
                    var childNodes = t.tree('getChildren', n.target);
                    $.each(childNodes, function () {
                        t.tree('check', this.target);
                        t.tree('checkedAll', this.target);
                        checkNodes(this);
                    });
                }

                checkNodes(node);
            }
        });
        return false;
    }
};

function htmlModuleConfig() {
    var html = '<div class="hint-info">';
    html += '<div class="hint-tip icon-tip"></div>';
    html += '<div>温馨提示：设置后请点“确定”按钮保存当前的设置。</div>';
    html += '</div>';
    html += '<div style="margin:10px 0;"></div>';
    html += '<div class="easyui-panel" style="width:330px;padding:5px;">';
    //html += '<div class="easyui-layout" fit=true>';
    //html += '<div region="center" style="width:290px;padding:10px">';
    html += '<table id="contentArea"  style="width:310px;padding-top:2px;"></table></div>';
    //html += '</div> </div>';
    return html;
}

var permissionMgr = {
    getUserSelectedModule: function () { //得到用户选择的模块       
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

var moveGridRow = {
    Up: function (jq) {
        var rowindex = jq.datagrid('getSelectedIndex');
        if (rowindex > -1) {
            var rows = jq.datagrid('getRows');
            var newRowIndex = rowindex - 1;
            if (newRowIndex < 0)
                newRowIndex = 0;

            var targetRow = rows[newRowIndex];
            var currentRow = rows[rowindex];

            rows[newRowIndex] = currentRow;
            rows[rowindex] = targetRow;

            jq.datagrid('loadData', rows);
            jq.datagrid('selectRow', newRowIndex);

        } else
            alert('亲，都到顶啦，在点就可以见到天宫1号啦！');
    },
    Down: function (jq) {
        var rowindex = jq.datagrid('getSelectedIndex');
        var rows = jq.datagrid('getRows');
        if (rowindex < rows.length - 1) {
            var newRowIndex = rowindex + 1;

            var targetRow = rows[newRowIndex];
            var currentRow = rows[rowindex];

            rows[newRowIndex] = currentRow;
            rows[rowindex] = targetRow;

            jq.datagrid('loadData', rows);
            jq.datagrid('selectRow', newRowIndex);

        } else
            alert('亲，到底啦，在点就罢工啦！');
    },
    Insert: function (ljq, rjq) {
        var rows = ljq.datagrid('getSelected');
        if (rows) {
            var currRows = rjq.datagrid('getRows');
            var hasBtns = Enumerable.from(currRows).where("x=>x.KeyId==" + rows.KeyId).select("$").toArray();
            if (hasBtns.length > 0)
                return false;
            else {
                rjq.datagrid('appendRow', rows);
            }
        } else {
            alert('请选择按钮。');
            return false;
        }
        return false;
    },
    Remove: function (jq) {
        var rowindex = jq.datagrid('getSelectedIndex');
        if (rowindex > -1)
            jq.datagrid('deleteRow', rowindex);
        return false;
    }
}
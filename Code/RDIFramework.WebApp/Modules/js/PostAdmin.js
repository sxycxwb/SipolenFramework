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
* RDIFramework.NET框架“岗位管理”业务界面逻辑
*
* 主要完成员工的增加、修改、删除、移动、导出等。
* 修改记录：
*   
*   
*   1. 2014-08-05 XuWangBin V2.8 新增本业务逻辑的编写。
*/

var formUrl = "Modules/html/PostForm.htm",
    actionRoleUrl = 'handler/RoleAdminHandler.ashx',
    actionPostUrl = 'handler/PostAdminHandler.ashx',
    firstCheckModule = '0',
    firstCheckPermissionItem = '0'; //是否为第一次加载时对相应目标资源权限的Check ，访问加载Check事件

$(function () {
	pageSizeControl.init({gridId:'postlist',gridType:'datagrid'});
    organizeTree.init();
    autoResize({ dataGrid: '#postlist', gridType: 'datagrid', callback: mygrid.bindGrid, height: 35, width: 230 });
    $('#post_add').attr('onclick', 'PostAdminMethod.AddPost();'); //添加岗位
    $('#post_edit').attr('onclick', 'PostAdminMethod.EditPost();');//编辑岗位
    $('#post_delete').attr('onclick', 'PostAdminMethod.DeletePost();');//删除岗位
    $('#post_setUser').attr('onclick', 'PostAdminMethod.SetUser();');//设置用户
    $('#post_setPermission').attr('onclick', 'PostAdminMethod.SetPermission();');//设置岗位权限
    $('#post_moveTo').attr('onclick', 'PostAdminMethod.MoveTo();');//移动岗位
    $('#refresh').attr('onclick', 'PostAdminMethod.Refreash();');
    
    $(window).resize(function () {
		pageSizeControl.init({gridId:'postlist',gridType:'datagrid'});
    });
});

var organizeTree = {
    init: function () {
        $('#organizeTree').tree({
            lines: true,
            url: 'handler/OrganizeAdminHander.ashx?action=GetOrganizeTree',
            animate: true,
            onLoadSuccess: function (node, data) {
                $('body').data('depData', data);
            }, 
            onClick: function (node) {
                $('#postlist').datagrid('load', { organizeId: node.id });
            },
            onSelect: function (node) {
                $(this).tree('expand', node.target);
            }
        });
    }, 
    getSelected: function () {
        return $('#organizeTree').tree('getSelected');
    }
};

var navgrid;
var mygrid = {
    bindGrid: function (size) {
        navgrid = $('#postlist').datagrid({
            url: actionRoleUrl + "?action=GetRoleListByOrganize",
            //title: "岗位列表",
            loadMsg: "正在加载岗位数据，请稍等...",
            //iconCls: 'icon icon-list',
            width: size.width,
            height: size.height,
            rownumbers: true, //行号
            striped: true, //隔行变色
            idfield: 'ID', //主键
            singleSelect: true, //单选
            checkOnSelect: true,
            onRowContextMenu: pageContextMenu.createDataGridContextMenu,
            rowStyler: function (index, row) {
                if (row.ENABLED <= 0 ) {
                    return 'color:#999;';
                }
            },
			onDblClickRow:function(rowIndex, rowData){
				document.getElementById('post_edit').click();
			},
            frozenColumns: [[
                { field: 'ck', checkbox: true },
                { title: '编号', field: 'CODE', width: 180 },
                { title: '岗位名称', field: 'REALNAME', width: 200, sortable: true }
            ]],
            columns: [[
                { title: '成员', field: 'Users', width: 400,styler: function (value, row, index) {
                    return 'background-color:#ffee00;color:green;';} 
                },
                { title: '有效', field: 'ENABLED', width: 50, formatter: function (cellvalue, options, rowObject) {

                    return '<img src="/Content/css/icon/bullet_' + (cellvalue ? "tick.png" : "minus.png") + '" />';
                }
                },
                { title: '描述', field: 'DESCRIPTION', width: 300 }
            ]],
            onSelect:function(rowIndex, rowData) {
                if (rowData.ENABLED)
                    $("#post_setUser,#post_setPermission").linkbutton("enable");
                else
                    $("#post_setUser,#post_setPermission").linkbutton("disable");
            }
        });
    },
    reload:function(){
        navgrid.datagrid('reload');
    },
    getSelectedRow: function () {
        return navgrid.datagrid('getSelected'); 
    }
};

var PostAdminMethod = {
    Refreash:function() {
        mygrid.reload();
    },
    AddPost: function () { //添加岗位
        var orgSelected = organizeTree.getSelected();
        if (orgSelected) {
            var addDialog = top.$.hDialog({
                href: formUrl,
                title: '添加岗位',
                width: 490,
                height: 295,
                iconCls: 'icon16_brick_add',
                onLoad: function () {
                    top.$("#txtOrganize").attr("readOnly",true).css("background", "#dddddd"); ;  
                    top.$('#chkEnabled').attr("checked", true);
                    top.$('#txtOrganize').val(orgSelected.text);
                    top.$('#txtDescription').val("");
                    top.$('#txtCode').focus();
                },
                submit: function() {
                    if (top.$('#uiform').validate().form()) {
                        var queryString = 'action=AddPost&' + top.$('#uiform').serialize() + "&OrganizeId=" + orgSelected.id;
                        $.ajaxjson(actionPostUrl, queryString, function (d) {
                            if (d.Success) {
                                msg.ok(d.Message);
                                addDialog.dialog('close');
                                mygrid.reload();
                            } else {
                                MessageOrRedirect(d);
                            }
                        });
                    } else {
                        msg.warning('请输入岗位名称。');
                        top.$('#txtCode').focus();
                    }
                }
            });
        } else {
            msg.warning('请选择一个组织机构!');
        }
        return false;
    },
    EditPost: function () { //修改岗位
        var selectRow = mygrid.getSelectedRow();
        if (selectRow) {
            //弹窗
            var editDailog = top.$.hDialog({
                href: formUrl,
                width: 490,
                height: 295,
                title: '修改岗位',
                iconCls: 'icon16_brick_edit',
                onLoad: function () {
                    //绑定各数据字典
                    var parm = 'action=GetRoleEntity&KeyId=' + selectRow.ID;
                    $.ajaxjson('handler/RoleAdminHandler.ashx', parm, function (data) {
                        if (data) {
                            top.$('#txtCode').val(data.Code);
                            top.$('#txtRealName').val(data.RealName);
                            top.$('#chkEnabled').attr("checked", data.Enabled == "1");
                            top.$('#txtDescription').val(data.Description);
                        }

                        if (data.OrganizeId) {
                            var parmOrganize = 'action=GetOrganizeEntity&KeyId=' + data.OrganizeId;
                            $.ajaxjson('handler/OrganizeAdminHander.ashx', parmOrganize, function (tmpOrgData) {
                                if (tmpOrgData) {
                                    top.$('#txtOrganize').val(tmpOrgData.FullName);
                                }
                            });
                        }
                    });
                    top.$("#txtOrganize").attr("readOnly", true).css("background", "#dddddd"); ;
                    top.$('#txtCode').focus();
                },
                submit: function () {
                    if (top.$('#uiform').validate().form()) {
                        var queryString = '&action=EditPost&' + top.$('#uiform').serialize() + "&KeyId=" + selectRow.ID;
                        $.ajaxjson(actionPostUrl, queryString, function (d) {
                            if (d.Success) {
                                msg.ok(d.Message);
                                editDailog.dialog('close');
                                mygrid.reload();
                            }
                            else {
                                MessageOrRedirect(d);
                            }
                        });
                    }
                }
            });
        }
        else {
            msg.warning('请选择待修改的岗位。');
            return false;
        }
        return false;
    },
    DeletePost: function () { //删除岗位
        var selectRow = mygrid.getSelectedRow();
        if (selectRow) {
            $.messager.confirm('询问提示', '确定要删除岗位【' + selectRow.REALNAME + '】吗？', function (data) {
                if (data) {
                    $.ajaxjson(actionPostUrl, 'action=DeletePost&KeyId=' + selectRow.ID, function (d) {
                        if (d.Data > 0) {
                            msg.ok('所选岗位删除成功！');
                            mygrid.reload();
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            });
        }
        else {
            msg.warning('请选择要删除的岗位。');
            return false;
        }
        return false;
    },
    SetUser: function () { //设置岗位用户
        var selectRow = mygrid.getSelectedRow();
        if (selectRow) {
            var rDialog = top.$.hDialog({
                href: 'Modules/html/PermissionSet/RoleUserSet.htm', width: 600, height: 500, title: '岗位用户关联', iconCls: 'icon16_key',
                onLoad: function () {
                    top.$('#rlayout').layout();
                    top.$('#roleName').text(selectRow.REALNAME);
                    top.$('#allUsers,#selectedUser').datagrid({
                        width: 255,
                        height: 350,
                        iconCls: 'icon-users',
                        nowrap: false, //折行
                        rownumbers: true, //行号
                        striped: true, //隔行变色
                        idField: 'ID', //主键
                        singleSelect: true, //单选
                        columns: [[
                       { title: '登录名', field: 'USERNAME', width: 100 },
                       { title: '用户名', field: 'REALNAME', width: 120 }
                   ]],
                        pagination: false,
                        pageSize: 20,
                        pageList: [20, 40, 50]
                    });

                    top.$('#allUsers').datagrid({
                        url: 'Modules/handler/UserAdminHandler.ashx',
                        onDblClickRow: function (rowIndex, rowData) {
                            top.$('#aSelectUser').click();
                        }
                    });

                    top.$('#selectedUser').datagrid({
                        url: 'Modules/handler/UserAdminHandler.ashx?action=GetDTByRole&roleId=' + selectRow.ID,
                        onDblClickRow: function (rowIndex, rowData) {
                            top.$('#aDeleteUser').click();
                        }
                    });
                    top.$('#aSelectUser').click(function () {
                        var _row = top.$('#allUsers').datagrid('getSelected');
                        if (_row) {
                            var hasUserName = false;
                            var users = top.$('#selectedUser').datagrid('getRows');
                            $.each(users, function (i, n) {
                                if (n.USERNAME == _row.USERNAME) {
                                    hasUserName = true;
                                }
                            });
                            if (!hasUserName) {
                                top.$('#selectedUser').datagrid('appendRow', _row);
                                //添加用户
                                var query = 'action=AddUserToRole&roleId=' + selectRow.ID + '&addUserIds=' + _row.ID;
                                $.ajaxtext('handler/RoleAdminHandler.ashx', query, function (d) {
                                    if (d != "1") {
                                        msg.ok('添加用户失败。');
                                    }
                                });
                            }
                            else {
                                top.$.messager.alert("操作提示", "用户已存在，请不要重复添加。", "warning");
                                return false;
                            }
                        } else {
                            top.$.messager.alert("操作提示", "请选择用户！", "warning");
                        }
                        return false;
                    });
                    top.$('#aDeleteUser').click(function () {
                        var trow = top.$('#selectedUser').datagrid('getSelected');
                        if (trow) {
                            var rIndex = top.$('#selectedUser').datagrid('getRowIndex', trow);
                            top.$('#selectedUser').datagrid('deleteRow', rIndex).datagrid('unselectAll');
                            //移除岗位
                            var query = 'action=removeuserfromrole&roleid=' + selectRow.ID + '&uid=' + trow.ID;
                            $.ajaxtext('handler/RoleAdminHandler.ashx', query, function (d) {
                                if (d != "1") {
                                    msg.ok('移除用户失败。');
                                }
                            });
                        } else {
                            top.$.messager.alert("操作提示", "请选择用户！", "warning");
                        }
                    });
                },
                submit: function () {
                    rDialog.dialog('close');
                    mygrid.reload();
                }
            });
        } else {
            msg.warning('请选择一个岗位哦！');
        }
        return false;
    },
    SetPermission: function () {  //设置设置岗位权限
        var curPost = mygrid.getSelectedRow();
        if (curPost) {
            var formDialog = top.$.hDialog({
                title: '岗位权限设置', width: 660, height: 600, iconCls: 'icon16_lightning',
                href: 'Modules/html/PermissionSet/RolePermissionSet.htm?n=' + Math.random(),
                onLoad: function () {
                    top.$('#FormContent').layout('panel', 'center').panel({ title: '当前岗位：' + curPost.REALNAME });
                    //1、加载模块（菜单）列表
                    top.$('#tableModule').tree({
                        cascadeCheck: false, //联动选中节点
                        checkbox: true,
                        lines: true,
                        url: 'Modules/handler/ModuleAdminHandler.ashx?action=GetModuleTree',
                        onBeforeLoad: function (node, param) {
                            top.$.hLoading.show({ type: 'loading', msg: '加载中' });
                        },
                        onLoadSuccess: function (node, data) {
                            top.$.hLoading.hide();
                            var curPostModuleIds = [];
                            var query = 'action=GetModuleByRoleId&roleid=' + curPost.ID;
                            //1.1、得到当前岗位可以访问的模块菜单主键列表
                            $.ajaxtext('handler/PermissionHandler.ashx', query, function (d) {
                                if (d != '' && d.toString() != '[object XMLDocument]') {
                                    curPostModuleIds = d.split(',');
                                }
                                if (curPostModuleIds && curPostModuleIds.length > 0) {
                                    firstCheckModule = '1';
                                    var moduelTree = top.$('#tableModule');
                                    moduelTree.tree('uncheckedAll');
                                    for (var i = 0; i < curPostModuleIds.length; i++) {
                                        var tmpnode = moduelTree.tree('find', curPostModuleIds[i]);
                                        if (tmpnode)
                                            moduelTree.tree("check", tmpnode.target);
                                    }
                                    firstCheckModule = '0';
                                }
                            });
                        },
                        onCheck: function (node, checked) {
                            if (firstCheckModule == '0') {
                                if (checked) { //授予当前岗位所选模块的访问权限                                           
                                    $.ajaxjson('handler/PermissionHandler.ashx', 'action=SetRoleModulePermission&roleId=' + curPost.ID + '&grantIds=' + node.id, function (d) {
                                        if (d.Data != '1') {
                                            msg.warning('授予岗位模块访问权限失败！');
                                        }
                                    });
                                } else { //回收当前岗位所选模块的访问权限
                                    $.ajaxjson('handler/PermissionHandler.ashx', 'action=SetRoleModulePermission&roleId=' + curPost.ID + '&revokeIds=' + node.id, function (d) {
                                        if (d.Data != '1') {
                                            msg.warning('收回岗位模块访问权限失败！');
                                        }
                                    });
                                }
                            }
                        }
                    });

                    //2、加载框架操作权限项列表。
                    top.$('#tablePermissionItem').tree({
                        cascadeCheck: false, //联动选中节点
                        checkbox: true,
                        lines: true,
                        url: 'Modules/handler/PermissionItemAdminHandler.ashx?action=GetPermissionItemTree',
                        onBeforeLoad: function (node, param) {
                            top.$.hLoading.show({ type: 'loading', msg: '加载中' });
                        },
                        onLoadSuccess: function (node, data) {
                            top.$.hLoading.hide();
                            var curPostPermissionItemIds = [];
                            var query = 'action=GetPermissionItemsByRoleId&roleid=' + curPost.ID;
                            //2.1、得到当前岗位可以访问的操作权限主键列表
                            $.ajaxtext('handler/PermissionHandler.ashx', query, function (d) {
                                if (d != '' && d.toString() != '[object XMLDocument]') {
                                    curPostPermissionItemIds = d.split(',');
                                }
                                if (curPostPermissionItemIds && curPostPermissionItemIds.length > 0) {
                                    firstCheckPermissionItem = '1';
                                    var permissionItemTree = top.$('#tablePermissionItem');
                                    permissionItemTree.tree('uncheckedAll');
                                    for (var i = 0; i < curPostPermissionItemIds.length; i++) {
                                        var tmpnode = permissionItemTree.tree('find', curPostPermissionItemIds[i]);
                                        if (tmpnode)
                                            permissionItemTree.tree("check", tmpnode.target);
                                    }
                                    firstCheckPermissionItem = '0';
                                }
                            });
                        },
                        onCheck: function (node, checked) {
                            if (firstCheckPermissionItem == '0') {
                                if (checked) { //授予当前岗位所选操作权限
                                    $.ajaxjson('handler/PermissionHandler.ashx', 'action=SetRolePermissionItem&roleid=' + curPost.ID + '&grantIds=' + node.id, function (d) {
                                        if (d.Data != '1') {
                                            msg.warning('授予岗位操作权限失败！');
                                        }
                                    });
                                } else {  //回收当前岗位所选操作权限
                                    $.ajaxjson('handler/PermissionHandler.ashx', 'action=SetRolePermissionItem&roleid=' + curPost.ID + '&revokeIds=' + node.id, function (d) {
                                        if (d.Data != '1') {
                                            msg.warning('收回岗位操作权限失败！');
                                        }
                                    });
                                }
                            }
                        }
                    });
                },
                submit: function () {
                    formDialog.dialog('close');
                    return false;
                }
            });
        }
        else {
            msg.warning('请选择岗位!');
            return false;
        }
        return false;
    },
    MoveTo: function () { //移动岗位
        var row = mygrid.getSelectedRow();
        if (row != null) {
            var ad = top.$.hDialog({
                max: false,
                width: 300,
                height: 500,
                title: '移动岗位 ━ ' + row.REALNAME,
                iconCls: 'icon16_arrow_switch',
                content: '<ul id="orgTree"></ul>',
                submit: function () {
                    var node = top.$('#orgTree').tree('getSelected');
                    if (node) {
                        $.ajaxtext(actionPostUrl, 'action=MoveTo&KeyId=' + row.ID + '&OrganizeId=' + node.id, function (d) {
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
            msg.warning('请选择要移动的岗位!');
            return false;
        }
        return false;
    }
};

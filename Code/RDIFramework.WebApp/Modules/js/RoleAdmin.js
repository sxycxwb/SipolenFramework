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
*   1. 2013-08-15 EricHu V2.5 新增本业务逻辑的编写。
*   2. 2013-11-16 EricHU V2.7 新增导出数据功能。
*   3、2015-10-28 EricHu V3.0 重构新增与修改，自动绑定界面控件以及界面控件序列化，减少大量代码。
*/

var actionUrl = 'handler/RoleAdminHandler.ashx',
    formUrl = 'Modules/html/RoleForm.htm?n=' + Math.random();

$(function () {
    autoResize({ dataGrid: '#list', gridType: 'datagrid', callback: mygrid.bindGrid, height: 5 });

    $('#a_refresh').click(function () { //刷新
        mygrid.reload();
    });
    $('#a_add').attr('onclick', 'RoleAdminMethod.AddRole();');
    $('#a_edit').attr('onclick', 'RoleAdminMethod.EditRole();');  //修改角色
    $('#a_del').attr('onclick', 'RoleAdminMethod.DelRole();');  //删除角色
    $('#a_roleuser').attr('onclick', 'RoleAdminMethod.RoleUser();');//角色用户设置
    /*导出角色数据 EXCEL*/
    $('#a_export').attr('onclick', "exportData();");
    $('#a_print').attr('onclick', 'RoleAdminMethod.Print();'); //打印员工（职员）


    //$('#a_add').click(RoleAdminMethod.AddRole); //新增角色
    //$('#a_edit').click(RoleAdminMethod.EditRole);  //修改角色
    //$('#a_del').click(RoleAdminMethod.DelRole);  //删除角色
    //$('#a_roleuser').click(RoleAdminMethod.RoleUser);//角色用户设置
    /*导出角色数据 EXCEL*/
    //$('#a_export').click(function () {
    //    var exportData = new ExportExcel('list');
    //    exportData.go('PIROLE','SORTCODE');
    //});
    //$('#a_print').click(RoleAdminMethod.Print); //打印员工（职员）
    BindCategory();
});

var exportData = function () {
    var exportData = new ExportExcel('list');
    exportData.go('PIROLE','SORTCODE');
};

var BindCategory = function () {
    $('#Category').combobox({
        url: 'handler/RoleAdminHandler.ashx?action=GetRoleCategory&categorycode=RoleCategory',
        method: 'get',
        valueField: 'ITEMVALUE',
        textField: 'ITEMNAME',
        editable: false,
        panelHeight: 'auto',
        onChange: function () {
            var curCategory;
            curCategory = $("#Category").combobox('getValue');
            var ruleArr = [];
            if (curCategory !== '0') {
                ruleArr.push({ "field": "CATEGORY", "op": "eq", "data": escape(curCategory) });
                var filterObj = { groupOp: 'AND', rules: ruleArr };
                $('#list').datagrid('load', { filter: JSON.stringify(filterObj) });
            } else {
                mygrid.reload();
            }
        }
    });
};

var navgrid;
var mygrid = {
    bindGrid: function (size) {
        navgrid = $('#list').datagrid({
            url: 'handler/RoleAdminHandler.ashx?action=GetRoleListByPage',
            toolbar: '#toolbar',
            width: size.width,
            height: size.height,
            idField: 'ID',
            sortName: 'SORTCODE',
            sortOrder: 'asc',
            singleSelect: true,
            striped: true,
			onRowContextMenu:pageContextMenu.createDataGridContextMenu,
            pagination: true,
            rownumbers: true,
            pageSize: 20,
            pageList: [20, 10, 30, 50],
            rowStyler: function (index, row) {
                if (row.ENABLED <= 0) {
                    return 'color:#999;'; //显示为灰色字体
                }
            },
			onDblClickRow:function(rowIndex, rowData){
				document.getElementById('a_edit').click();
			},
            columns: [[
                { field: 'ck', checkbox: true },
                { title: '编号', field: 'CODE', width: 120 },
                { title: '名称', field: 'REALNAME', width: 150 },
                { title: '分类', field: 'CATEGORY', width: 130, sortable: true },
                {title: '有效', field: 'ENABLED', width: 40, align: 'center', formatter: statusFormatter },
                { title: '允许编辑', field: 'ALLOWEDIT', width: 60, align: 'center', formatter: imgcheckbox },
                { title: '允许删除', field: 'ALLOWDELETE', width: 60, align: 'center', formatter: imgcheckbox },
                { title: '排序', field: 'SORTCODE', width: 80, sortable: true },
                { title: '描述', field: 'DESCRIPTION', width: 300 }
            ]]
        });
    },
    reload: function () {
        navgrid.datagrid('reload', {});
    },
    selected: function () {
        return navgrid.datagrid('getSelected');
    }
};

function statusFormatter(value) {
    if (value == 1) {
        return "<div style='font-weight:700;color:yellow;background-color:green;margin:0px;padding:0px;'>有效</div>";
    } else {
        return "<div style='font-weight:700;color:red;background-color:#CCCCCC;text-decoration:line-through'>无效</div>";
    }
}

var imgcheckbox = function (cellvalue, options, rowObject) {
    return cellvalue ? '<img src="/Content/css/icon/bullet_tick.png" alt="正常" title="正常" />' : '<img src="/Content/css/icon/bullet_minus.png" alt="禁用" title="禁用" />';
};

var RoleAdminMethod = {
    AddRole: function () { //新增角色
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        //功能代码逻辑...

        var addDialog = top.$.hDialog({
            title: '添加角色', width: 430, height: 290, href: formUrl, iconCls: 'icon16_group_add',
            onLoad: function () {
                pageMethod.bindCategory('Category', 'RoleCategory');
                top.$('#Enabled').attr("checked", true);
                top.$('#Code').focus();
            },
            submit: function () {
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
                else {
                    m.warning('请输入角色名称');
                    top.$('#RealName').focus();
                }
                return false;
            }
        });
        return false;
    },
    EditRole: function () { //修改角色
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        //功能代码逻辑...
        var curRole = mygrid.selected();
        if (curRole) {
            var editDialog = top.$.hDialog({
                title: '修改角色', width: 430, height: 290, href: formUrl, iconCls: 'icon16_group_edit',
                onLoad: function () {
                    pageMethod.bindCategory('Category', 'RoleCategory');
                    var parm = 'action=GetRoleEntity&key=' + curRole.ID;
                    $.ajaxjson(actionUrl, parm, function (data) {
                        if (data) {
                            SetWebControls(data, true);
                        }
                    });

                    top.$('#Code').focus();
                },
                submit: function () {
                    if (top.$('#uiform').validate().form()) {
                        var queryString = pageMethod.serializeJson(top.$('#uiform'));                        
                        $.ajaxjson('handler/RoleAdminHandler.ashx?action=SubmitForm&key=' + curRole.ID, queryString, function (d) {
                            if (d.Success) {
                                msg.ok(d.Message);
                                editDialog.dialog('close');
                                mygrid.reload();
                            } else {
                                MessageOrRedirect(d);
                            }
                        });
                    }
                }
            });
        } else {
            msg.warning('请选择待修改的数据。');
        }
        return false;
    },
    DelRole: function () {
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        //功能代码逻辑...
        var row = mygrid.selected();
        if (row) {
            $.messager.confirm('询问提示', '确认要删除[' + row.REALNAME + ']角色吗?', function (data) {
                if (data) {
                    $.ajaxjson(actionUrl, 'action=delete&roleid=' + row.ID, function (d) {
                        if (d.Data > 0) {
                            msg.ok('角色删除成功。');
                            mygrid.reload();
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            });
        } else {
            msg.warning('请选择待删除的数据。');
        }
        return false;
    },
    RoleUser: function () { //角色用户设置
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        //功能代码逻辑...
        var currentRole = mygrid.selected();
        if (currentRole) {
            var rDialog = top.$.hDialog({
                href: 'Modules/html/PermissionSet/RoleUserSet.htm', width: 600, height: 500, title: '角色用户关联', iconCls: 'icon16_group_link',
                onLoad: function () {
                    top.$('#rlayout').layout();
                    top.$('#roleName').text(currentRole.REALNAME);
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
                        url: 'Modules/handler/UserAdminHandler.ashx?action=GetDTByRole&roleId=' + currentRole.ID,
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
                                var query = 'action=AddUserToRole&roleId=' + currentRole.ID + '&addUserIds=' + _row.ID;
                                $.ajaxtext('handler/RoleAdminHandler.ashx', query, function (d) {
                                    if (d != "1") {
                                        msg.ok('添加用户失败。');
                                    }
                                });
                            }
                            else {
                                alert('用户已存在，请不要重复添加。');
                                return false;
                            }
                        } else {
                            alert('请选择用户');
                        }
                        return false;
                    });
                    top.$('#aDeleteUser').click(function () {
                        var trow = top.$('#selectedUser').datagrid('getSelected');
                        if (trow) {
                            var rIndex = top.$('#selectedUser').datagrid('getRowIndex', trow);
                            top.$('#selectedUser').datagrid('deleteRow', rIndex).datagrid('unselectAll');
                            //移除角色
                            var query = 'action=removeuserfromrole&roleid=' + currentRole.ID + '&uid=' + trow.ID;
                            $.ajaxtext('handler/RoleAdminHandler.ashx', query, function (d) {
                                if (d != "1") {
                                    msg.ok('移除用户失败。');
                                }
                            });
                        } else {
                            alert('请选择用户');
                        }
                    });
                },
                submit: function () {
                    rDialog.dialog('close');
                }
            });
        } else {
            msg.warning('请选择一个角色哦！');
        }
        return false;
    },
    Print: function () {
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}
        var colModel = $("#list").datagrid('options').columns[0]; //$("#staffGird").datagrid('getColumnFields');
        var dataModel = $("#list").datagrid("getRows");
        var footerData = $("#list").datagrid("getFooterRows");

        var htmlContent = "<table class='grid'><tr>";
        $.each(colModel, function (i) {
            var title = colModel[i].title;
            if (title) {
                var width = colModel[i].width;
                htmlContent += "<td style=\"width:" + (width - 5) + "px;\">" + title + "</td>";
            }
        });
        htmlContent += "</tr>";
        for (var i = 0; i < dataModel.length; i++) {
            htmlContent += "<tr>";
            $.each(colModel, function (j) {
                var title = colModel[j].title;
                if (title) {
                    var width = colModel[j].width;
                    htmlContent += "<td style=\"width:" + (width - 5) + "px;\">" + dataModel[i]["" + colModel[j].field + ""] + "</td>";
                }
            });
            htmlContent += "</tr>";
        }
        if (footerData) {
            htmlContent += "<tr>";
            $.each(colModel, function (j) {
                var title = colModel[j].title;
                if (title) {
                    var width = colModel[j].width;
                    htmlContent += "<td style=\"width:" + (width - 5) + "px;\">" + footerData["" + colModel[j].field + ""] + "</td>";
                }
            });
            htmlContent += "</tr>";
        }
        htmlContent += "</table>";
        $("#divPrint").html(htmlContent);
        $("#divPrint").jqprint();
        return false;
    }
};
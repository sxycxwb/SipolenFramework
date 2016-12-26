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
* RDIFramework.NET框架“数据库连接”业务界面逻辑
*
* 主要完成模块（菜单）的增加、修改、删除、移动、导出、用户或角色所拥有的模块（菜单）设置等。
* 修改记录：
*   1. 2013-08-28 EricHu 新增本业务逻辑的编写。
*   2、2015-03-28 EricHu V2.9 优化本逻辑。
*   3、2015-10-28 EricHu V3.0 重构新增与修改，自动绑定界面控件以及界面控件序列化，减少大量代码。
*/

var navgrid,
    actionUrl = 'handler/DBLinkAdminHandler.ashx',
    formUrl   = "Modules/html/DBLinkForm.htm?n=" + Math.random();

$(function () {
    autoResize({ dataGrid: '#dbLinkGrid', gridType: 'datagrid', callback: grid.databind, height: 0 });
    $('#btnAdd').attr('onclick', 'DBLinkAdminMethod.AddDBLink();');
    $('#btnEdit').attr('onclick', 'DBLinkAdminMethod.EditDBLink();');
    $('#btnDelete').attr('onclick', 'DBLinkAdminMethod.DeleteDBLink();'); 
    $('#btnRefresh').attr('onclick', 'DBLinkAdminMethod.Refreash();');
});

var grid = {
    databind: function (size) {
        navgrid = $('#dbLinkGrid').datagrid({
            title: '数据库连接列表',
            iconCls: 'icon icon-database',
            noheader: true,
            width: size.width,
            height: size.height,
            nowrap: false,
            rownumbers: true,
            resizable: true,
            singleSelect: true,
            collapsible: false,
            onRowContextMenu:pageContextMenu.createDataGridContextMenu,
            url: actionUrl + '?action=GetList',
            idfield: 'ID',
			onDblClickRow:function(rowIndex, rowData){
				document.getElementById('btnEdit').click();
			},
            frozenColumns: [[
               { field: 'ck', checkbox: true },
               { title: '连接名称', field: 'LINKNAME', width: 150 }
            ]],
            columns: [[
                 { title: 'Id', field: 'ID', hidden: true },
                 { title: '数据库类型', field: 'LINKTYPE', width: 90 },                 
                 { title: '有效', field: 'ENABLED', width: 40, align: 'center', formatter: imgcheckbox },
                 { title: '描述', field: 'DESCRIPTION', width: 399 }
            ]]
        });
    },
    reload: function () {
        navgrid.datagrid('reload');
    },
    selected: function () {
        return navgrid.datagrid('getSelected');
    }
};

var imgcheckbox = function (cellvalue, options, rowObject) {
    return cellvalue ? '<img src="/Content/css/icon/bullet_tick.png" alt="正常" title="正常" />' : '<img src="/Content/css/icon/bullet_minus.png" alt="禁用" title="禁用" />';
};

var DBLinkAdminMethod = {
    Refreash: function () {
        grid.reload();
    },
    AddDBLink: function () {
        var addDialog = top.$.hDialog({
            title: '新增数据库连接',
            iconCls: 'icon16_database_add',
            href: formUrl,
            width: 650,
            height: 340,
            onLoad: function () {
                top.$('#Enabled').attr("checked", true);
                pageMethod.bindCategory('LinkType', 'DataBaseType');
                top.$('#LinkName').focus();
            },
            submit: function () {
                if (top.$('#uiform').validate().form()) {
                    var queryString = pageMethod.serializeJson(top.$('#uiform'));
                    $.ajaxjson(actionUrl + '?action=SubmitForm', queryString, function (d) {
                        if (d.Success) {
                            addDialog.dialog('close');
                            msg.ok(d.Message);
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
    EditDBLink: function () {
        var row = grid.selected();
        if (row) {
            var editDialog = top.$.hDialog({
                href: formUrl + '?v=' + Math.random(),
                title: '修改数据库连接',
                iconCls: 'icon16_database_edit',
                width: 650,
                height: 340,
                onLoad: function () {
                    pageMethod.bindCategory('LinkType', 'DataBaseType');            
                    var parm = 'action=GetEntity&key=' + row.ID;
                    $.ajaxjson(actionUrl, parm, function (data) {
                        if (data) {
                            SetWebControls(data, true);
                        }
                    });
                    top.$('#LinkName').focus();
                },
                submit: function () {
                    if (top.$('#uiform').validate().form()) {
                        var queryString = pageMethod.serializeJson(top.$('#uiform'));
                        $.ajaxjson(actionUrl + '?action=SubmitForm&key=' + row.ID, queryString, function (d) {
                            if (d.Success) {
                                msg.ok(d.Message);
                                editDialog.dialog('close');
                                grid.reload();
                            } else {
                                MessageOrRedirect(d);
                            }
                        });
                    }
                }
            });
        }
        else {
            msg.warning('请选择待修改的数据。');
        }
        return false;
    },
    DeleteDBLink: function () {
        var row = grid.selected();
        if (row) {
            $.messager.confirm('询问提示', '确认要删除[' + row.LINKNAME + ']数据库连接吗?', function (data) {
                if (data) {
                    $.ajaxjson(actionUrl, 'action=DeleteDBLink&key=' + row.ID, function (d) {
                        if (d.Data > 0) {
                            msg.ok('数据库连接删除成功。');
                            grid.reload();
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
    }
};
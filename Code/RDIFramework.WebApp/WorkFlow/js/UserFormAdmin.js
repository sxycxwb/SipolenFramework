﻿var actionUrl = 'handler/UserFormAdminHandler.ashx';
$(function () {
    pageSizeControl.init({ gridId: 'list', gridType: 'datagrid' });
    userContorlTree.init();
    autoResize({ dataGrid: '#list', gridType: 'datagrid', height: 35, width: 230 });
    $(window).resize(function () {
        pageSizeControl.init({ gridId: 'list', gridType: 'datagrid' });
    });
});

var userContorlTree = {
    init: function () {
        $('#formtree').tree({
            lines: true,
            url: actionUrl + '?action=GetUserControlClass',
            animate: true,
            onClick: function (node) {
                mygrid.loadGrid(node.id);
            }
        });
    }
};

var navgrid;
var mygrid = {
    loadGrid: function (type) {
        $('#list').datagrid({
                loadMsg: "正在加载数据，请稍等...",
                iconCls: 'icon16_list',
                rownumbers: true, //行号
                striped: true, //隔行变色
                idfield: 'ID', //主键
                singleSelect: true, //单选
                pagination: true,
                pageSize: 20,
                pageList: [20, 10, 30, 50],
                checkOnSelect: true,
                rowStyler: function (index, row) {
                    if (row.ENABLED <= 0) {
                        return 'color:#999;'; //显示为灰色字体
                    }
                }
        });
        if (type == '1') { //加载主表单
            navgrid = $('#list').datagrid({
                url: actionUrl + "?action=GetMainUserControlByPage",
                title: "主表单列表",
                toolbar: [{
                    id: 'btnAddMainForm',
                    iconCls: 'icon16_add',
                    text: '增加主表单',
                    handler: UserFormAdminMethod.AddMainForm
                    },{
	                    id:'btnEditMainForm',
		                iconCls: 'icon16_edit_button',
		                text:'修改主表单',
		                handler: UserFormAdminMethod.EditMainForm 
	                }, {
	                    id:'btnDelMainForm',
	                    iconCls: 'icon16_delete',
	                    text: '删除主表单',
	                    handler: UserFormAdminMethod.DelMainForm
	                },'-',{
	                    id:'btnSetFormLink',
	                    iconCls: 'icon16_layout_link',
	                    text: '主子表单关联',
	                    handler: UserFormAdminMethod.SetFormLink
	                }],
                columns: [[
                    { title: '名称', field: 'FULLNAME', width: 150 },
                    { title: '有效', field: 'ENABLED', width: 50, formatter: function (cellvalue, d, i) {
                        return cellvalue ? '<img src="/Content/css/icon/bullet_tick.png" alt="正常" title="正常" />' : '<img src="/Content/css/icon/bullet_minus.png" alt="禁用" title="禁用" />';
                    }},
                    { title: '描述', field: 'DESCRIPTION', width: 300 },
                    { title: '创建时间', field: 'CREATEON', width: 144 },
                    { title: '创建者', field: 'CREATEBY', width: 200 },
                    { title: '主表单ID', field: 'ID', width: 280 }
                ]]
            });
        }
        
        if (type == '2') {
            navgrid = $('#list').datagrid({
                url: actionUrl + "?action=GetUserControlByPage",
                title: "子表单列表",
                toolbar: [{
                        id:'btnAddChildForm',
		                iconCls: 'icon16_add',
		                text:'增加子表单',
		                handler: UserFormAdminMethod.AddChildForm
	                },{
	                    id:'btnEditChildForm',
		                iconCls: 'icon16_edit_button',
		                text:'修改子表单',
		                handler: UserFormAdminMethod.EditChildForm
	                },'-',{
	                    id:'btnDelChildForm',
		                iconCls: 'icon16_delete',
		                text:'删除子表单',
		                handler: UserFormAdminMethod.DelChildForm
	            }],
                columns: [[
                    { title: '名称', field: 'FULLNAME', width: 150, rowspan: 2},
                    { title: 'Web配置', colspan: 2 }, 
                    { title: 'WinForm配置', colspan: 2},
                    { title: '有效', field: 'ENABLED', width: 50, rowspan: 2, formatter: function (cellvalue, d, i) {
                        return cellvalue ? '<img src="/Content/css/icon/bullet_tick.png" alt="正常" title="正常" />' : '<img src="/Content/css/icon/bullet_minus.png" alt="禁用" title="禁用" />';
                    } },
                    {
                        title: '表单类型',
                        field: 'TYPE',
                        width: 100,
                        rowspan: 2,
                        formatter: function(v, d, i) {
                            if (v == '1') {
                                return '<span style="color:#CCCC66;">WinForm</span>';
                            } else if (v == '2') {
                                return '<span style="color:#660033;">Web</span>';
                            } else if (v == '3') {
                                return '<span style="color:#CC6600;">WinForm/Web</span>';
                            } else {
                                return '<span style="color:#CCCCFF;">unknown</span>';
                            }
                        }
                    },
                    { title: '描述', field: 'DESCRIPTION', width: 300, rowspan: 2 },
                    { title: '创建时间', field: 'CREATEON', width: 144, rowspan: 2 },
                    { title: '创建者', field: 'CREATEBY', width: 200, rowspan: 2 },
                    { title: '子表单ID', field: 'ID', width: 280 , rowspan: 2}],[
                    { title: '位置', field: 'PATH', width: 200, rowspan: 1 },
                    { title: '控件ID', field: 'CONTROLID', width: 150, rowspan: 1 },
                    { title: '表单名称', field: 'FORMNAME', width: 180, rowspan: 1 },
                    { title: '所在程序集', field: 'ASSEMBLYNAME', width: 180, rowspan: 1 } 
                ]]
            });
        }
    },
    reload: function () {
        navgrid.datagrid('reload');
    },
    getSelectedRow: function () {
        return navgrid.datagrid('getSelected');
    }
};

var UserFormAdminMethod = {
    AddMainForm: function () {
        var addDialog = top.$.hDialog({
            title: '增加主表单',iconCls: 'icon16_add',href: 'WorkFlow/html/MainUserControl.htm?n=' + Math.random(),
            width: 430,height: 250,
            onLoad: function () {
                top.$('#chk_Enabled').attr("checked", true);
            },
            submit: function () {
                var isValid = top.$('#idCommonForm').form("validate");
                if (isValid) {
                    $.ajaxjson(actionUrl, 'action=AddMainForm&' + top.$('#idCommonForm').serialize(), function (d) {
                        if (d.Data > 0) {
                            msg.ok('添加主表单成功!');
                            addDialog.dialog('close');
                            mygrid.loadGrid('1');
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            }
        });
        return false;
    },
    EditMainForm: function () {
        var selectRow = mygrid.getSelectedRow();
        if (selectRow) {
            var editDialog = top.$.hDialog({
                title: '修改主表单',iconCls: 'icon16_edit_button',href: 'WorkFlow/html/MainUserControl.htm?n=' + Math.random(),
                width: 430,height: 250,
                onLoad: function () {
                    var parm = 'action=GetMainUserControlEntity&keyId=' + selectRow.ID;
                    $.ajaxjson(actionUrl, parm, function (data) {
                        if (data) {
                            top.$('#txt_FullName').val(data.FullName);
                            top.$('#txt_Description').val(data.Description);
                            top.$('#chk_Enabled').attr('checked', data.Enabled == "1");
                        }                   
                    });
                },
                submit: function () {
                    var isValid = top.$('#idCommonForm').form("validate");
                    if (isValid) {
                        $.ajaxjson(actionUrl, 'action=EditMainForm&' + top.$('#idCommonForm').serialize() + '&keyId=' + selectRow.ID, function (d) {
                            if (d.Data > 0) {
                                msg.ok('修改主表单成功!。');
                                editDialog.dialog('close');
                                mygrid.loadGrid('1');
                            } else {
                                MessageOrRedirect(d);
                            }
                        });
                    }
                }
            });
        } else {
            msg.warning('请选择待修改的主表单！');
        }
        return false;
    },
    DelMainForm: function () {
       var selectRow = mygrid.getSelectedRow();
        if (selectRow) {
            if (confirm('确认要删除所选主表单吗?')) {
                $.ajaxjson(actionUrl, 'action=DelMainForm&keyId=' + selectRow.ID, function (d) {
                    if (d.Data > 0) {
                        msg.ok('成功删除所选主表单!');
                        mygrid.loadGrid('1');
                    } else {
                        MessageOrRedirect(d);
                    }
                });
            }
        } else {
            msg.warning('请选择待删除的主表单！');
        }
        return false;
    },
    SetFormLink: function () {
        var row = mygrid.getSelectedRow();
        var btngrid;
        if (row) {
            var setDialog = top.$.hDialog({
                title: '名称：' + row.FULLNAME,
                width: 440,
                height: 400,
                iconCls: 'icon16_layout_link',
                cache: false,
                href: 'WorkFlow/html/MainUserControlLink.htm?n=' + Math.random(),
                onLoad: function() {
                    btngrid = top.$('#left_btns').datagrid({
                        title: '所有用户表单',
                        url: 'WorkFlow/handler/UserFormAdminHandler.ashx?action=GetAllUserControl',
                        nowrap: false, //折行
                        fit: true,
                        rownumbers: true, //行号
                        striped: true, //隔行变色
                        idField: 'ID',//主键
                        singleSelect: true, //单选
                        frozenColumns: [[]],
                        columns: [[
                            { title: '名称', field: 'FULLNAME', width: 80, align: 'center' },
                            { title: '备注', field: 'DESCRIPTION', width: 180, hidden: true }
                        ]],
                        onDblClickRow: function(rowIndex, rowData) {
//                            var currRows = top.$('#right_btns').datagrid('getRows');
//                            var hasBtns = Enumerable.from(currRows).where("x=>x.ID==" + rowData.ID).select("$").toArray();
//                            if (hasBtns.length > 0)
//                                return false;
//                            else {
//                                top.$('#right_btns').datagrid('appendRow', rowData);
//                            }
                            moveGridRow.Insert(top.$('#left_btns'), top.$('#right_btns'),row.ID);
                        },
                        onLoadSuccess: function(data) {
                            top.$('#right_btns').datagrid({
                                title: '已选用户表单',
                                url:'WorkFlow/handler/UserFormAdminHandler.ashx?action=GetAllChildUserControlsById&mainId=' + row.ID,
                                nowrap: false, //折行
                                fit: true,
                                rownumbers: true, //行号
                                striped: true, //隔行变色
                                idField: 'ID',//主键
                                singleSelect: true, //单选
                                frozenColumns: [[]],
                                columns: [[
//                                    { title: '名称', field: 'UCFULLNAME', width: 80, align: 'center' },
//                                    { title: '备注', field: 'UCDESCRIPTION', width: 180, hidden: true }
                                    { title: '名称', field: 'UCFULLNAME', width: 80, align: 'center' },
                                    { title: '状态', field: 'CONTROLSTATE', width: 40, align: 'center' },
                                    { title: '备注', field: 'UCDESCRIPTION', width: 180, hidden: true }
                                ]],
                                onDblClickRow: function(rowIndex, rowData) {
                                    //top.$('#right_btns').datagrid('deleteRow', rowIndex);
                                    moveGridRow.Remove(top.$('#right_btns'),row.ID);
                                },
                                onRowContextMenu: function (e, rowIndex, rowData) {
                                    UserFormPubMethod.rowCMenu(row.ID,e, rowIndex, rowData);
                                }
                            });
                            
//                            $.ajaxtext(actionUrl, 'action=GetAllChildUserControlsById&mainId=' + row.ID, function (d) {
//                                if (d) {
//                                    d = JSON.parse(d);
//                                    $.each(data.rows, function(i, n) {
//                                        for(var idx=0; idx<d.length; idx++) {
//                                            if (n.ID == d[idx].ID) {
//                                                top.$('#right_btns').datagrid('appendRow', n);
//                                                break;
//                                            }
//                                        } 
//                                    });
//                                }
//                            });

                            //绑定移动按钮事件
                            top.$('#btnUp').click(function() { moveGridRow.Up(top.$('#right_btns')); });
                            top.$('#btnDown').click(function() { moveGridRow.Down(top.$('#right_btns')); });
                            top.$('#btnRight').click(function() { moveGridRow.Insert(top.$('#left_btns'), top.$('#right_btns'),row.ID); });
                            top.$('#btnLeft').click(function() { moveGridRow.Remove(top.$('#right_btns'),row.ID); });
                        }
                    });
                },
                submit: function() {
                    setDialog.dialog('close');
                }
            });
        } else {
            msg.warning('请选择导航菜单');
        }
        return false;
    },
    AddChildForm: function () {
        var addDialog = top.$.hDialog({
            title: '增加子表单',iconCls: 'icon16_add',href: 'WorkFlow/html/UserControlForm.htm?n=' + Math.random(),
            width: 480,height: 430,
            onLoad: function () {
                top.$('#chk_Enabled').attr("checked", true);
            },
            submit: function () {
                var $item = top.$(":radio[name='Type']:checked");
                if ($item.length == 0) {
                    msg.warning('请指定一个表单类型！');
                    return false;
                }
                
                var isValid = top.$('#formUserControl').form("validate");
                if (isValid) {
                    $.ajaxjson(actionUrl, 'action=AddChildForm&' + top.$('#formUserControl').serialize(), function (d) {
                        if (d.Data > 0) {
                            msg.ok('添加子表单成功!');
                            addDialog.dialog('close');
                            mygrid.loadGrid('2');
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            }
        });
        return false;
    },
    EditChildForm: function () {
        var selectRow = mygrid.getSelectedRow();
        if (selectRow) {
            var editDialog = top.$.hDialog({
                title: '修改子表单',iconCls: 'icon16_edit_button',href: 'WorkFlow/html/UserControlForm.htm?n=' + Math.random(),
                width: 480,height: 430,
                onLoad: function () {
                    var parm = 'action=GetChildUserControlEntity&keyId=' + selectRow.ID;
                    $.ajaxjson(actionUrl, parm, function (data) {
                        if (data) {
                            top.$('#txt_FullName').val(data.FullName);
                            top.$('#txt_Path').val(data.Path);
                            top.$('#txt_ControlId').val(data.ControlId);
                            top.$('#txt_FormName').val(data.FormName);
                            top.$('#txt_AssemblyName').val(data.AssemblyName);
                            top.$('#txt_Description').val(data.Description);
                            top.$('#chk_Enabled').attr('checked', data.Enabled == "1");
                            if (data.Type == 1) {
                                top.$("input[name='Type'][value='1']").attr('checked',true);
                            }else if (data.Type == 2) {
                                top.$("input[name='Type'][value='2']").attr('checked', true);
                            } else {
                                top.$("input[name='Type'][value='3']").attr('checked', true);
                            }
                        }                   
                    });
                },
                submit: function () {
                    var isValid = top.$('#formUserControl').form("validate");
                    if (isValid) {
                        $.ajaxjson(actionUrl, 'action=EditChildForm&' + top.$('#formUserControl').serialize() + '&keyId=' + selectRow.ID, function (d) {
                            if (d.Data > 0) {
                                msg.ok('修改子表单成功!。');
                                editDialog.dialog('close');
                                mygrid.loadGrid('2');
                            } else {
                                MessageOrRedirect(d);
                            }
                        });
                    }
                }
            });
        } else {
            msg.warning('请选择待修改的子表单！');
        }
        return false;
    },
    DelChildForm: function () {
       var selectRow = mygrid.getSelectedRow();
        if (selectRow) {
            if (confirm('确认要删除所选子表单吗?')) {
                $.ajaxjson(actionUrl, 'action=DelChildForm&keyId=' + selectRow.ID, function (d) {
                    if (d.Data > 0) {
                        msg.ok('成功删除所选子表单!');
                        mygrid.loadGrid('2');
                    } else {
                        MessageOrRedirect(d);
                    }
                });
            }
        } else {
            msg.warning('请选择待删除的子表单！');
        }
        return false;
    }
};

var moveGridRow = {
    Up: function(jq) {
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
            msg.warning('到第一条了！');
    },
    Down: function(jq) {
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
            msg.warning('到最后一条了！');
    },
    Insert: function(ljq, rjq, mainId) {
        var rows = ljq.datagrid('getSelected');
        if (rows) {
            var currRows = rjq.datagrid('getRows');
            var existsId = 0;
            $.each(currRows, function(rindex, rdata) {
                if (rows.ID == rdata.ID) {
                    existsId = 1;
                }
            });
            if (existsId == 0) {
                //rjq.datagrid('appendRow', rows);
                if (mainId) {
                    var query = 'action=AddUserControlToMain&mainId=' + mainId + '&userControlId=' + rows.ID;
                    $.ajaxjson('handler/UserFormAdminHandler.ashx', query, function(d) {
                        if (d.Data > 0) {
                            rjq.datagrid('reload');
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                } else {
                    msg.warning('请选择主表单！');
                }
            } else {
                msg.warning('已存在！');
            }
        } else {
            msg.warning('请选择用户表单。');
            return false;
        }
    },
    Remove: function(jq, mainId) {
        if (mainId) {
            var rows = jq.datagrid('getSelected');
            if (rows) {
                var query = 'action=RemoveUserControlFromMain&mainId=' + mainId + '&userControlId=' + rows.ID;
                $.ajaxjson('handler/UserFormAdminHandler.ashx', query, function(d) {
                    if (d.Data > 0) {
                        jq.datagrid('reload');
                    } else {
                        MessageOrRedirect(d);
                    }
                });
            } else {
                msg.warning('请选择一个用户表单。');
            }
        } else {
            msg.warning('请选择主表单！');
        }
        return false;
    }
};

var UserFormPubMethod = {
    rowCMenu: function (mainId,e, rowIndex, rowData) { //row 右键菜单
        var createRowMenu = function () {
            var rmenu = top.$('<div id="rmenu" style="width:100px;"></div>').appendTo('body');
            var menus = [
                { title: '状态-查看', iconCls: 'icon16_eye' }, 
                { title: '状态-修改', iconCls: 'icon16_page_white_paintbrush' },
                { title: '状态-新建', iconCls: 'icon16_page_white' },
                '-',
                { title: '移除', iconCls: 'icon16_arrow_left' }
            ];
            for (var i = 0; i < menus.length; i++) {
                if (menus[i].title)
                    top.$('<div iconCls="' + menus[i].iconCls + '"/>').html(menus[i].title).appendTo(rmenu);
                else {
                    top.$('<div class="menu-sep"></div>').appendTo(rmenu);
                }
            }
        };

        e.preventDefault();
        if (top.$('#rmenu').length == 0) { createRowMenu(); }

        top.$('#rmenu').menu({
            onClick: function (item) {
                switch (item.text) {
                    case '状态-查看': UserFormPubMethod.setControlState(mainId,rowData.ID,'查看'); break;
                    case '状态-修改': UserFormPubMethod.setControlState(mainId,rowData.ID,'修改'); break;
                    case '状态-新建': UserFormPubMethod.setControlState(mainId,rowData.ID,'新建'); break;
                    case '移除': moveGridRow.Remove(top.$('#right_btns'),mainId); break;
                    default:
                        break;
                }
            }
        }).menu('show', { left: e.pageX, top: e.pageY });
    },
    setControlState: function(mainUserControlId, userControlId, controlState) {
        if (mainUserControlId) {
            if (userControlId) {
                var query = 'action=EditMainUserControlsState&mainId=' + mainUserControlId + '&userControlId=' + userControlId + '&controlState=' + controlState;
                $.ajaxjson('handler/UserFormAdminHandler.ashx', query, function(d) {
                    if (d.Data > 0) {
                        top.$('#right_btns').datagrid('reload');
                    } else {
                        MessageOrRedirect(d);
                    }
                });
            } else {
                msg.warning('请选择待设置的数据！');
            }
        }else {
            msg.warning('请选择主表单！');
        }
        return false;
    }
};
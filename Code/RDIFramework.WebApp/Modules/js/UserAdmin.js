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
* RDIFramework.NET框架“用户管理”业务界面逻辑
*
* 主要完成员工的增加、修改、删除、移动、导出等。
* 修改记录：
*   5、2016-02-29 EricHu V3.0 增加用户离职、用户界面查看日志。
*   4、2015-04-13 EricHu V2.9 重新设计查询功能、优化整个代码。
*   3、2014-07-07 EricHu V2.8 修改用户管理主界面以组织机构方式进行管理，并用分页的方式展示。
*   2. 2013-12-23 EricHu V2.7 优化代码，提高加载速度、重新设计本界面。
*   1. 2013-08-12 EricHu V2.5 新增本业务逻辑的编写。
*/

var actionUrl = 'handler/UserAdminHandler.ashx',
    formUrl   = "Modules/html/UserForm.html";

$(function () {
    $('#sb').splitbutton({
        iconCls: 'icon16_report_user',
        menu: '#mm'
    });
	pageSizeControl.init({gridId:'userlist',gridType:'datagrid'});
	
    organizeTree.init();
    autoResize({ dataGrid: '#userlist', gridType: 'datagrid', callback: mygrid.bindGrid, height: 35, width: 230 });
    
    $('#a_add').attr('onclick', 'UserAdminMethod.AddUser();');
    $('#a_edit').attr('onclick', 'UserAdminMethod.EditUser();');
    $('#a_delete').attr('onclick', 'UserAdminMethod.DeleteUser();');
    $('#a_editpassword').attr('onclick', 'UserAdminMethod.SetUserPassword();');
    $('#a_refresh').attr('onclick', 'UserAdminMethod.Refreash();');
    $('#btnSearch').attr('onclick', 'UserAdminMethod.SearchData();');
    $('#a_export').attr('onclick', 'UserAdminMethod.ExportData();');
    $('#a_dimission').attr('onclick', 'UserAdminMethod.Dimission();');
    $('#btnLogByUser').attr('onclick', 'UserAdminMethod.LogByUser();');
    $('#btnLogByGeneral').attr('onclick', 'UserAdminMethod.LogByGeneral();');
    $(window).resize(function () {
		pageSizeControl.init({gridId:'userlist',gridType:'datagrid'});
    });
});

var organizeTree = {
    init: function () {
        $('#organizeTree').tree({
            lines: true,
            url: 'handler/OrganizeAdminHander.ashx?action=treedata',
            animate: true,
            onLoadSuccess: function (node, data) {
                $('body').data('depData', data);
            },
            onClick: function (node) {
                var selectedId = node.id;
                $('#userlist').datagrid('load', { organizeId: selectedId });
            },
            onSelect: function (node) {
                $(this).tree('expand', node.target);
            }
        });
    },
    data: function (opr) {
        var d = JSON.stringify($('body').data('depData'));
        if (opr === '1') {
            d = '[{"id":0,"text":"请选择组织机构"},' + d.substr(1);
        }
        return JSON.parse(d);
    },
    getCurrentId: function () {
        return $('#organizeTree').tree('getSelected').id;
    }
};

var navgrid;
var mygrid = {
    bindGrid: function (size) {
        navgrid = $('#userlist').datagrid({
            url: actionUrl + "?action=GetUserPageDTByDepartmentId",
            //title: "系统用户列表",
            loadMsg: "正在加载用户数据，请稍等...",
            //iconCls: 'icon icon-list',
            width: size.width,
            height: size.height,
            rownumbers: true, //行号
            striped: true, //隔行变色
            idfield: 'ID', //主键
            singleSelect: true, //单选
            pagination: true,
            onRowContextMenu: pageContextMenu.createDataGridContextMenu,
            pageSize: 20,
            pageList: [20, 10, 30, 50],
            checkOnSelect: true,  
            rowStyler: function(index, row) {
                if (row.ENABLED <= 0) {
                    return 'color:#999;'; //显示为灰色字体
                }
            },
			onDblClickRow:function(rowIndex, rowData){
				document.getElementById('a_edit').click();
			},
            frozenColumns: [[
                { field: 'ck', checkbox: true, rowspan: 2 },
               { title: '编号', field: 'CODE', width: 150, rowspan: 2 },
                    { title: '登录名', field: 'USERNAME', width: 150, sortable: true, rowspan: 2 },
                    { title: '用户名', field: 'REALNAME', width: 150, rowspan: 2 }
            ]],
            columns: [[
                    { title: '有效', field: 'ENABLED', width: 35, rowspan: 2, formatter: function (v, d, i) {
                            if (d.USERNAME != 'Administrator') { //超级管理员不应该设置其是否有效
                                return '<img style="cursor:pointer" title="设置用户的可用性（启用或禁用）" onclick="javascript:SetUserEnabled(' + "'" + d.ID + "'" + ',' + v + ')" src="/Content/css/icon/bullet_' + (v ? "tick.png" : "minus.png") + '" />';
                            }
                        }
                    },
                    { title: '离职', field: 'ISDIMISSION', align: "center", width: 35, rowspan: 2, formatter: ImageCheckBox },
                    {
                        title: '性别', field: 'GENDER', width: 35, rowspan: 2, formatter: function (v, d, i) {
                            if (d.GENDER === '男'){
                                return '<img src="/Content/css/icon/user_b.png" alt="男" title="男" />';
                            }
                            else if (d.GENDER === '女') {
                                return '<img src="/Content/css/icon/user_green.png" alt="女" title="女" />';
                            } else {
                                return '<img src="/Content/css/icon/question_button.png" alt="性别未知" title="未设置性别" />';
                            }
                        }
                    },
                    { title: '联系方式', colspan: 2 },
                    { title: '组织机构信息', colspan: 5 },
                    { title: '登录信息', colspan: 3 },
                    { title: '描述', field: 'DESCRIPTION', width: 300, rowspan: 2}],
                    [{ title: '邮箱地址', field: 'EMAIL', width: 150, rowspan: 1 },
                    { title: '手机号码', field: 'MOBILE', width: 100, rowspan: 1 },
                    { title: '所在单位/公司', field: 'COMPANYNAME', width: 100, rowspan: 1 },
                    { title: '所在子公司', field: 'SUBCOMPANYNAME', width: 100, rowspan: 1 },
                    { title: '所在部门', field: 'DEPARTMENTNAME', width: 100, rowspan: 1 },
                    { title: '所在子部门', field: 'SUBDEPARTMENTNAME', width: 100, rowspan: 1 },
                    { title: '所在工作组', field: 'WORKGROUPNAME', width: 100, rowspan: 1 },
                    { title: '上次登录时间', field: 'PREVIOUSVISIT', width: 150, sortable: true, rowspan: 1 },
                    { title: '登录次数', field: 'LOGONCOUNT', width: 60, sortable: true, rowspan: 1 },
                    { title: 'IP地址', field: 'IPADDRESS', width: 80, sortable: true, rowspan: 1 }
                ]],
                onLoadSuccess: function (data) {
                    var panel = $(this).datagrid('getPanel');
                    var tr = panel.find('div.datagrid-body tr');
                    refreshCellsStyle(tr);
                    var trHead = panel.find('div.datagrid-header tr');
                    trHead.each(function () {
                        var tds = $(this).children('td');
                        tds.each(function () {
                            $(this).find('span,div').css({ "font-size": "14px" });
                        });
                    });
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

function refreshCellsStyle(tr) {
    tr.each(function () {
        var tds = $(this).children('td');
        tds.each(function () {
            if ($(this).attr("field") == "USERNAME") {
                var text = $(this).text();
                var cssObj = { "text-align": "left" };
                if (text == "Administrator") {
                    cssObj["color"] = "green";
                    cssObj["font-weight"] = "700";
                    cssObj["font-size"] = "16px";
                }
                $(this).children("div").css(cssObj);
            }            
        });
    });
}

var imgcheckbox = function (cellvalue, options, rowObject) {
    return cellvalue ? '<img src="/Content/css/icon/bullet_tick.png" alt="正常" title="正常" />' : '<img src="/Content/css/icon/bullet_minus.png" alt="禁用" title="禁用" />';
};

var date2str = function (cellvalue, options, rowObject) {
    if (cellvalue)
        return $D(cellvalue).strftime("%Y-%m-%d");
    else
        return '';
};
var UserAdminMethod = {
    Refreash:function() {
         $('#userlist').datagrid('reload');
    },
    SearchData:function() {
        var curSearchValue = $('#txtSearchValue').val();
        var curOrganizeId = organizeTree.getCurrentId();
        if (curSearchValue) {
            $('#userlist').datagrid('load', { searchValue: curSearchValue, organizeId: curOrganizeId });
        } else {
            $('#userlist').datagrid('load', { organizeId: curOrganizeId });
        }
    },
    ExportData: function () {
        var fieldList = '[{"title":"编号","field":"CODE"},' +
                        '{"title":"登录名","field":"USERNAME"},' +
                        '{"title":"用户名","field":"REALNAME"},' +
                        '{"title":"性别","field":"GENDER"},' +
                        '{"title":"公司名称","field":"COMPANYNAME"},' +
                        '{"title":"部门名称","field":"DEPARTMENTNAME"},' +
                        '{"title":"邮箱","field":"EMAIL"},' +
                        '{"title":"出生日期","field":"BIRTHDAY"},' +
                        '{"title":"手机","field":"MOBILE"},' +
                        '{"title":"QQ","field":"QICQ"},' +
                        '{"title":"有效","field":"ENABLED"},' +
                        '{"title":"描述","field":"DESCRIPTION"}]';
        var exportData = new ExportExcel('userlist', fieldList);
        exportData.go('PIUSER', 'SORTCODE');
    },
    AddUser: function () { //添加用户
        var addDialog = top.$.hDialog({
            href: formUrl,
            title: '添加用户',
            width: 610,
            height: 640,
            iconCls: 'icon16_user_add',
            onLoad: function () {
                //绑定各数据字典
                pageMethod.bindCategory('txtGender', 'Gender');
                pageMethod.bindCategory('txtRoleId', 'undefined');
                pageMethod.bindCategory('txtCompanyName', 'Company');
                pageMethod.bindCategory('txtSubCompanyName', 'SubCompany');
                pageMethod.bindCategory('txtDepartmentName', 'Department');
                pageMethod.bindCategory('txtSubDepartmentName', 'SubDepartment');
                pageMethod.bindCategory('txtWorkgroupName', 'Workgroup');
                top.$('#chkEnabled').attr("checked", true);
                top.$('#txtDescription').val("");
                top.$('#txtUserName').focus();
            },
            submit: function () {
                if (top.$('#uiform').validate().form()) {
                    var vRoleId = top.$('#txtRoleId').combobox('getValue'),
                        vCompanyId = top.$('#txtCompanyName').combobox('getValue'),
                        vSubCompanyId = top.$('#txtSubCompanyName').combobox('getValue'),
                        vDepartmentId = top.$('#txtDepartmentName').combobox('getValue'),
                        vSubDepartmentId = top.$('#txtSubDepartmentName').combobox('getValue'),
                        vWorkgroupId = top.$('#txtWorkgroupName').combobox('getValue'),
                        vCompanyName = top.$('#txtCompanyName').combobox('getText'),
                        vSubCompanyName = top.$('#txtSubCompanyName').combobox('getText'),
                        vDepartmentName = top.$('#txtDepartmentName').combobox('getText'),
                        vSubDepartmentName = top.$('#txtSubDepartmentName').combobox('getText'),
                        vWorkgroupName = top.$('#txtWorkgroupName').combobox('getText'),
                        queryString = top.$('#uiform').serialize() + '&action=add';
                    
                    queryString = queryString + '&vRoleId=' + vRoleId + '&vCompanyId=' + vCompanyId + '&vSubCompanyId=' + vSubCompanyId + '&vDepartmentId=' + vDepartmentId + '&vSubDepartmentId=' + vSubDepartmentId + '&vWorkgroupId=' + vWorkgroupId;
                    queryString = queryString + '&vCompanyName=' + vCompanyName + '&vSubCompanyName=' + vSubCompanyName + '&vDepartmentName=' + vDepartmentName + '&vSubDepartmentName=' + vSubDepartmentName + '&vWorkgroupName=' + vWorkgroupName;
                    $.ajaxjson('handler/UserAdminHandler.ashx', queryString, function (d) {
                        if (d.Success) {
                            msg.ok(d.Message);
                            addDialog.dialog('close');
                            mygrid.reload();
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                } else {
                    msg.warning('请输入用户名称。');
                    top.$('#txtUserName').focus();
                }
            }
        });
        return false;
    },
    EditUser: function () { //修改用户
        var selectRow = mygrid.getSelectedRow();
        if (selectRow != null) {
            if (selectRow.USERNAME != '' && selectRow.USERNAME == 'Administrator' && curUserinfo.username != 'Administrator') {
                $.messager.alert('警告提示', '你不能修改超级管理员用户！', 'warning');
                return false;
            }

            //弹窗
            var editDailog = top.$.hDialog({
                href: formUrl,
                width: 610,
                height: 640,
                title: '修改用户',
                iconCls: 'icon16_user_edit',
                onLoad: function () {
                    //绑定各数据字典
                    pageMethod.bindCategory('txtGender', 'Gender');
                    pageMethod.bindCategory('txtRoleId', 'undefined');
                    pageMethod.bindCategory('txtCompanyName', 'Company');
                    pageMethod.bindCategory('txtSubCompanyName', 'SubCompany');
                    pageMethod.bindCategory('txtDepartmentName', 'Department');
                    pageMethod.bindCategory('txtSubDepartmentName', 'SubDepartment');
                    pageMethod.bindCategory('txtWorkgroupName', 'Workgroup');

                    var parm = 'action=GetEntity&KeyId=' + selectRow.ID;
                    $.ajaxjson('handler/UserAdminHandler.ashx', parm, function (data) {
                        if (data) {
                            //初始化相关数据
                            top.$('#txtUserName').val(data.UserName);
                            top.$('#txtRealName').val(data.RealName);
                            top.$('#txtCode').val(data.Code);
                            top.$('#txtUserPassword').after('******').remove();
                            top.$('#txtGender').combobox('setValue', data.Gender);
                            top.$('#txtMobile').val(data.Mobile);
                            top.$('#txtBirthday').val(data.Birthday);
                            top.$('#txtTelephone').val(data.Telephone);
                            top.$('#txtDuty').val(data.Duty);
                            top.$('#txtQICQ').val(data.Qicq);
                            top.$('#txtTitle').val(data.Title);
                            top.$('#txtEmail').val(data.Email);
                            top.$('#txtRoleId').combobox('setValue', data.RoleId);
                            top.$('#txtCompanyName').combobox('setValue', data.CompanyId);
                            top.$('#txtSubCompanyName').combobox('setValue', data.SubCompanyId);
                            top.$('#txtDepartmentName').combobox('setValue', data.DepartmentId);
                            top.$('#txtSubDepartmentName').combobox('setValue', data.SubDepartmentId);
                            top.$('#txtWorkgroupName').combobox('setValue', data.WorkgroupId);
                            top.$('#txtHomeAddress').val(data.Homeaddress);
                            top.$('#txtDescription').val(data.Description);
                            top.$('#chkEnabled').attr("checked", data.Enabled == "1");
                        }
                    });
                },
                submit: function () {
                    if (top.$('#uiform').validate().form()) {
                        var vRoleId = top.$('#txtRoleId').combobox('getValue'),
                            vCompanyId = top.$('#txtCompanyName').combobox('getValue'),
                            vSubCompanyId = top.$('#txtSubCompanyName').combobox('getValue'),
                            vDepartmentId = top.$('#txtDepartmentName').combobox('getValue'),
                            vSubDepartmentId = top.$('#txtSubDepartmentName').combobox('getValue'),
                            vWorkgroupId = top.$('#txtWorkgroupName').combobox('getValue'),
                            vCompanyName = top.$('#txtCompanyName').combobox('getText'),
                            vSubCompanyName = top.$('#txtSubCompanyName').combobox('getText'),
                            vDepartmentName = top.$('#txtDepartmentName').combobox('getText'),
                            vSubDepartmentName = top.$('#txtSubDepartmentName').combobox('getText'),
                            vWorkgroupName = top.$('#txtWorkgroupName').combobox('getText'),
                            queryString = top.$('#uiform').serialize() + '&action=edit&id=' + selectRow.ID;
                        
                        queryString = queryString + '&vRoleId=' + vRoleId + '&vCompanyId=' + vCompanyId + '&vSubCompanyId=' + vSubCompanyId + '&vDepartmentId=' + vDepartmentId + '&vSubDepartmentId=' + vSubDepartmentId + '&vWorkgroupId=' + vWorkgroupId;
                        queryString = queryString + '&vCompanyName=' + vCompanyName + '&vSubCompanyName=' + vSubCompanyName + '&vDepartmentName=' + vDepartmentName + '&vSubDepartmentName=' + vSubDepartmentName + '&vWorkgroupName=' + vWorkgroupName;
                        $.ajaxjson('handler/UserAdminHandler.ashx', queryString, function (d) {
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
        } else {
            msg.warning('请选择待修改的用户。');
            return false;
        }
        return false;
    },
    DeleteUser: function () { //删除用户
        var selectRow = mygrid.getSelectedRow();
        if (selectRow) {
            if (selectRow.USERNAME != '' && selectRow.USERNAME == 'Administrator') {
                msg.warning('不能删除超级管理员！');
                return false;
            }

            if (selectRow.ID != '' && selectRow.ID == curUserinfo.id) {
                msg.warning('不能删除当前登录用户！');
                return false;
            }                   

            $.messager.confirm('询问提示', '确认要删除用户【' + selectRow.REALNAME + '】吗？', function (data) {
                if (data) {
                    $.ajaxjson(actionUrl, 'action=delete&id=' + selectRow.ID, function (d) {
                        if (d.Data > 0) {
                            msg.ok('所选用户删除成功！');
                            mygrid.reload();
                        } else {
                            MessageOrRedirect(d);
                        }
                    });
                }
            });
        }
        else {
            msg.warning('请选择要删除的用户。');
            return false;
        }
        return false;
    },
    SetUserPassword: function () { //设置用户密码  
        var selectRow = mygrid.getSelectedRow();
        if (selectRow != null) {
            var tempDialog = top.$.hDialog({
                content: formeditpass,
                width: 300,
                height: 160,
                title: '设置用户密码',
                iconCls: 'icon-key',
                submit: function () {
                    if (top.$('#txtNewPassword').validatebox('isValid')) {
                        $.ajaxjson(actionUrl, "action=setpassword&id=" + selectRow.ID + '&password=' + top.$('#txtNewPassword').val(), function (d) {
                            if (d.Data > 0) {
                                msg.ok('密码修改成功，请牢记新密码！');
                                mygrid.reload();
                                tempDialog.dialog('close');
                            } else {
                                MessageOrRedirect(d);
                            }
                        });
                    } else {
                        msg.warning('新密码不能为空～！');
                        top.$('#txtNewPassword').focus();
                    }
                }           
            });
            top.$('#loginname').text(selectRow.USERNAME + ' | ' + selectRow.REALNAME);
            top.$('#txtNewPassword').validatebox();
            top.$('#txtNewPassword').focus();
        } else {
            msg.warning('请选择要修改密码的用户。');
            return false;
        }
        return false;
    },
    LogByUser: function () {
        var selectRow = mygrid.getSelectedRow();
        if (selectRow) {
            var index = top.layer.msg('加载中', { icon: 16 });
            AddToTab('用户访问详情', 'Modules/LogByUser.aspx', 'icon16_diagnostic_chart', 'pageLogByUser');
            window.setTimeout(function () {
                var test = parent.$("#pageLogByUser")[0].contentWindow;
                test.$('#txtOpuser').val(selectRow.REALNAME);
                test.Search();
            }, 2000);
            layer.close(index);
        } else {
            msg.warning('请选择一个用户！');
        }
        //AddToTab('用户访问详情', '/FrameworkModules/LogAdmin/LogByUser', 'icon16_diagnostic_chart', 'pageLogByUser');
    },
    LogByGeneral: function () {
        AddToTab('用户访问情况', 'Modules/LogByGeneral.aspx', 'icon16_address_block', 'pageLogByGeneral');
    },
    Dimission: function () {
        var selectRow = mygrid.getSelectedRow();
        if (selectRow) {
            if (selectRow.USERNAME && (selectRow.USERNAME == 'Administrator' || selectRow.USERNAME == 'Admin')) {
                msg.warning('请选择非管理员！');
                return false;
            }
            var index = top.layer.msg('加载中', { icon: 16 });
            AddToTab('用户离职', 'Modules/UserDimission.html', 'icon16_aol_messenger', 'pageUserDimission');
            window.setTimeout(function () {
                var test = parent.$("#pageUserDimission")[0].contentWindow;
                test.BindPage(selectRow.ID);
                test.$('#Id').val(selectRow.ID);
            }, 1000);
            layer.close(index);
        } else {
            msg.warning('请选择一个用户！');
        }
    }
};

function SetUserEnabled(id, val) {
    var query = 'action=SetUserEnabled&KeyId=' + id + '&isenabled=' + val;
    $.ajaxjson(actionUrl,query,function(d){
        if(d.Success){
            mygrid.reload();
        }else{
            MessageOrRedirect(d);
        }
    });
}
var formeditpass = '<table class="grid" id="epform">';

formeditpass += '<tr><td>登录名：</td><td><span id="loginname"></span></td></tr>';
formeditpass += '<tr><td>新密码：</td><td><input  validType="safepass"  required="true" id="txtNewPassword" name="password" type="password" class="txt03" /></td></tr>';
formeditpass += '</table>';

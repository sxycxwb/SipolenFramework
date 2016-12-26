$(function () {
    addRole();
    editRole();
    delRole();

    $('#a_edit').click(function () {
        if ($(this).linkbutton('options').disabled == true) {
            return;
        }
        var i = $('table').data('tr_index');
        if (i > -1)
            $('.grid2 tr').eq(i).find("a[rel='edit']").click();
        else
            top.$('#notity').jnotifyAddMessage({ text: '请选择要编辑的数据.', permanent: false, type: 'warning' });
    });

    $('#a_del').click(function () {
        if ($(this).linkbutton('options').disabled == true) {
            return;
        }
        var i = $('table').data('tr_index');
        if (i > -1)
            $('.grid2 tr').eq(i).find("a[rel='delete']").click();
        else
            top.$('#notity').jnotifyAddMessage({ text: '请选择要删除的数据.', permanent: false, type: 'warning' });
    });

    $('#a_roleuser').click(function () {
        if ($(this).linkbutton('options').disabled == true) {
            return;
        }
        var i = $('table').data('tr_index');
        if (i > -1)
            $('.grid2 tr').eq(i).find("a[rel='setuser']").click();
        else
            top.$('#notity').jnotifyAddMessage({ text: '请选择要添加用户的角色.', permanent: false, type: 'warning' });
    });

    $('#a_refresh').click(function () {
        window.location = 'RoleAdmin.aspx';
    });

    using('linkbutton', function () {
        $('#a_roleuser').linkbutton({ text: "成员" });
    });

    accreditUsers(); //授权角色包含的用户
    searchUser();

    $('#txtCategory').combobox({
        onChange: function (newValue, oldValue) {
            $("#hidrolecategory").val(newValue) 
        }
    })
});

function scripthtmlStr() {
    var html = '<form id="uiform"><table cellpadding=5 cellspacing=0 width=100% align="center" class="grid" border=0><tr><td align="right">'
    html += '角色编号：</td><td align="left"><input id="txtCode"  name=Code type="text"  required="true" style="width:280px" class="txt03"/></td></tr><tr><td align="right">';
    html += '角色名称：</td><td align="left"><input id="txtRealName"  name=RealName type="text"  required="true" style="width:280px" class="txt03"/></td></tr><tr><td align="right">';
    html += '角色分类：</td><td align="left"><input id="txtCategory" name=Category type="text"  required="true" style="width:280px" class="txt03" /></td></tr><tr><td align="right">';
    html += '有效性：</td><td align="left"><input id="chkEnabled" type="checkbox" name="Enabled" /><label>有效</label>&nbsp;&nbsp;<span style="color:#666;padding-left:20px;">注：选中则启用该角色。</span></td></tr><tr><td align="right"> ';
    html += '角色描述：</td><td align="left"><textarea rows="3" id="txtDescription"  name=Description style="width:280px;height:50px;" class="txt03"/></td></tr>';
    html += '</table></form>';
    return html;
}

function searchUser() {
    $('#a_search').click(function () {
        var vValue = $('#txtCategory').combobox('getValue') + '|' + $('#txtCategory').combobox('getText');
        top.$('#notity').jnotifyAddMessage({ text: vValue, permanent: false });
    });
}

function addRole() {
    $('#a_add').click(function () {
        if ($(this).linkbutton('options').disabled == true) {
            return;
        }
        top.$('#w').hWindow({ title: '新增角色', iconCls: 'icon16_group_add', width: 450, height: 320, html: scripthtmlStr(), submit: function () {
            top.$('#txtCode').validatebox();
            top.$('#txtRealName').validatebox();
            top.$('#txtCategory').validatebox();

            var $txtrolecode = top.$('#txtCode');
            var $txtrolename = top.$('#txtRealName');
            var enabledSelected = top.$("#chkEnabled").attr("checked");
            var $txtdescription = top.$('#txtDescription');
            var vcategory = top.$('#txtCategory').combobox('getValue');

            if ($txtrolename.val() != '') {
                $.ajaxtext('handler/RoleAdminHandler.ashx?t=' + Math.random(), 'action=add&rolecode=' + $txtrolecode.val() + '&rolename=' + $txtrolename.val() + '&category=' + vcategory + '&enabled=' + enabledSelected + '&description=' + $txtdescription.val(), function (msg) {
                    if (msg == '1') {
                        top.$('#notity').jnotifyAddMessage({ text: '新增角色成功。', permanent: false });
                        top.$('#w').window('close');
                        window.location = 'RoleAdmin.aspx';
                    } else {
                        alert(msg);
                        return false;
                    }
                })

            } else {
                top.$('#notity').jnotifyAddMessage({ text: '请输入角色名称.', permanent: false });
                top.$('#txtRealName').focus();
            }
            return false;
        }
        });
        bindCategory();
        top.$('#txtCode').focus();
        top.$('#chkEnabled').attr("checked", true);
    });
}

function editRole() {
    $("a[rel='edit']").click(function () {
        if ($('#a_edit').linkbutton('options').disabled == true) {
            return;
        }
        var id = $(this).attr('rid');
        var roleCategory = $(this).attr('roleCategory');
        var tds = $(this).parent().siblings();
        top.$('#w').hWindow({ title: '编辑角色信息', iconCls: 'icon16_group_edit', width: 450, height: 320, html: scripthtmlStr(), submit: function () {
            var $txtrolecode = top.$('#txtCode');
            var $txtrealname = top.$('#txtRealName');
            var enabledSelected = top.$("#chkEnabled").attr("checked");
            var $txtdescription = top.$('#txtDescription');
            var vcategory = top.$('#txtCategory').combobox('getValue');

            if ($txtrealname.validatebox('isValid')) {
                $.ajaxtext('handler/RoleAdminHandler.ashx?n=' + Math.random(), 'action=edit&rolecode=' + $txtrolecode.val() + '&rolename=' + $txtrealname.val() + '&category=' + vcategory + '&enabled=' + enabledSelected + '&description=' + $.trim($txtdescription.val()) + '&roleid=' + id,
                function (msg) {
                    if (msg == '1') {
                        top.$('#notity').jnotifyAddMessage({ text: '角色信息修改成功.', permanent: false });
                        top.$('#w').window('close');
                        window.location = 'RoleAdmin.aspx';
                    } else {
                        alert(msg);
                        return false;
                    }
                })
            }
        }
        });

        top.$('#txtRealName').validatebox();
        top.$('#txtCode').val(tds.eq(1).html().replace('&nbsp;', ''));
        top.$('#txtRealName').val(tds.eq(2).html().replace('&nbsp;', ''));
        //top.$('#txtCategory').val(roleCategory);
        top.$('#chkEnabled').attr("checked", tds.eq(3).html().replace('&nbsp;', '') == "1");
        top.$('#txtDescription').val(tds.eq(4).html().replace('&nbsp;', ''));
        bindCategory();
        top.$('#txtCategory').combobox("setValue", roleCategory);
    })
}

function delRole() {
    $("a[rel='delete']").click(function () {
        if ($('#a_del').linkbutton('options').disabled == true) {
            return;
        }
        var rid = $(this).attr('rid');
        if (rid != '') {
            $.messager.confirm('询问提示', '你确认删除当前所选角色吗？', function (data) {
             if (data) {    
                    $.ajax({
                        type: 'post',
                        url: 'handler/RoleAdminHandler.ashx?t=<%=Guid.NewGuid().ToString() %>',
                        data: 'action=delete&roleid=' + rid,
                        beforeSend: function () { $.showLoading(); },
                        complete: function () { $.hideLoading(); },
                        success: function (msg) {
                            if (msg == '1') {
                                top.$('#notity').jnotifyAddMessage({ text: '角色删除成功.', permanent: false });
                                window.location = 'RoleAdmin.aspx';
                            }
                            else
                                top.$('#notity').jnotifyAddMessage({ text: '角色删除失败.', permanent: false, type: 'warning' });
                        }
                    });
                }
            });
           
        }
        else {
            top.$('#notity').jnotifyAddMessage({ text: '请选择要删除的角色。', permanent: false, type: 'warning' });
        }
    });
}

function bindCategory() {
    top.$('#txtCategory').combobox({
        url: 'Modules/handler/DataItemAdminHandler.ashx?action=GetCategory&categorycode=RoleCategory',
        method: 'get',
        valueField: 'ITEMVALUE',
        textField: 'ITEMNAME',
        editable: false,
        panelHeight: 'auto'
    });
}

var formHtml = '<div style="border-bottom:1px solid #CCC; margin-bottom:5px;"><span id="role_name" class="icon32 icon-group32" style="padding-left:48px;font-weight:bold; font-size:14px;color:#666;">角色名称</span> </div>';
    formHtml += '<div style=" margin-bottom:10px;">描述：<input id="txtroleremark" type="text" readonly=true class="txt02" style="width:400px;color:#666;"></div>';
    formHtml += '<div> 成员：</div>';
    formHtml += '<select id="user_groups" size="10" style="width:475px; line-height:30px;height:195px;padding:5px"></select>';
    formHtml += '<div style="margin-top:2px;"><a href="#" id="group_add" class="easyui-linkbutton" plain="true" iconCls="icon16_group_add">添加</a>';
    formHtml += '<a href="#" class="easyui-linkbutton" id="group_delete" plain="true" iconCls="icon-group-delete">移除</a>';
    formHtml += '<a href="#" class="easyui-linkbutton" id="group_clear" plain="true" iconCls="icon16_DeleteRed">清空</a></div>'

var userList = '<table id="sp" cellpadding=5 cellspacing=0 width=100% align="center" ><tr><td><ul class="ul_users checkbox"></ul></td></tr></table><p><input type="checkbox" id="chkall" ><label id="labchkall" for="chkall"><b>全选</b></label></p>';
//授权用户
function accreditUsers() {   
    $("a[rel='setuser']").click(function () {
        if ($('#a_roleuser').linkbutton('options').disabled == true) {
            return;
        }
        var i = $('table').data('tr_index');
        if (i == undefined) {
            top.$('#notity').jnotifyAddMessage({ text: '请选择角色.', permanent: false, type: 'warning' });
            return false;
        }
        var tds = $('.grid2 tr:eq(' + i + ') td');
        var rid = tds.eq(0).find(':hidden').val(); //rid = $(this).attr('rid');

        top.$('#w').hWindow({ html: formHtml, width: 500, height: 400, title: '角色用户', iconCls: 'icon16_group_link', submit: function () {
            var users = new Array();
            var count = top.$('#user_groups').get(0).options.length;
            for (var i = 0; i < count; i++) {
                users.push(top.$('#user_groups').get(0).options[i].value);
            }

            $.ajaxtext('handler/RoleAdminHandler.ashx', 'action=setusers&users=' + users + '&roleid=' + rid, function (msg) {
                if (msg == "1") {
                    top.$('#notity').jnotifyAddMessage({ text: '设置成功。', permanent: false, type: 'message' });
                }
                else
                    alert(msg);

                top.$('#w').window('close');
            });
            return false;
        }
        });

        top.$('a.easyui-linkbutton').linkbutton({ disabled: false });
        top.$('#role_name').text(tds.eq(2).text());
        top.$('#txtroleremark').val(tds.eq(4).text());

        $.getJSON('handler/RoleAdminHandler.ashx?n=' + Math.random(), '&action=usersinrole&roleid=' + rid, function (json) {
            $.each(json, function (i, n) {
                top.$('#user_groups').append('<option value="' + n.Id + '">' + n.UserName + ' | ' + n.RealName + '</option>');
            });
        });


        top.$('#group_add').click(function () {
            top.$('#d').hDialog({ html: userList, title: '选取用户', iconCls: 'icon-users', width: 800, height: 600,
                submit: function () {
                    var selectedUids = '';
                    top.$('#sp :checked').each(function () { //匹配所有sp中被选中的元素(checkbox中被选中的)
                        if (top.$(this).is(':checked'))
                            selectedUids += top.$(this).val() + ',';
                    });
                    if (selectedUids != '')
                        selectedUids = selectedUids.substr(0, selectedUids.length - 1);

                    if (selectedUids.length == 0) {
                        $.messager.alert('请至少选择一个用户！', msg, 'warning');
                        return false;
                    } else {
                        var users = top.$('#sp').data('allusers');
                        var selarr = getSelectedUsers(users, selectedUids);
                        top.$('#user_groups').empty();
                        top.$('#sp').removeData('allusers');
                        $.each(selarr, function (i, n) {
                            top.$('#user_groups').append('<option value="' + n.Id + '">' + n.UserName + ' | ' + n.RealName + '</option>');
                        });

                        top.$('#d').dialog("close");
                    }
                }
            });


            var lis = '';
            $.getJSON('handler/UserAdminHandler.ashx?n=' + Math.random(), '', function (json) {
                $.each(json, function (i, n) {
                    lis += '<li><input type="checkbox" value="' + n.Id + '" /><label>' + n.UserName + ' | ' + n.RealName + '</label></li>';
                });
                top.$('.ul_users').empty().append(lis);
                top.$('#sp').data('allusers', json);
            });



            top.$('#labchkall').click(function () {
                var flag = $(this).prev().is(':checked');
                var pers = $(this).parent().parent().prev();

                if (!flag) {
                    top.$(":checkbox", '#sp').attr("checked", true);
                }
                else {
                    top.$(":checkbox", '#sp').attr("checked", false);
                }
            });
        });

        top.$('#group_delete').click(function () {
            var i = top.$('#user_groups').get(0).selectedIndex;

            if (i > -1) {
                var uid = top.$('#user_groups option:selected').val(); //选中的值或 top.$("#user_groups").find("option:selected").val();
                var uname = top.$('#user_groups option:selected').text(); //选中的文本 或top.$("#user_groups").find("option:selected").text();

                top.$('#user_groups').get(0).remove(i);
                $.ajaxtext('handler/RoleAdminHandler.ashx', 'action=removeuserfromrole&uid=' + uid + '&roleid=' + rid, function (msg) {
                    if (msg == "1") {
                        top.$('#notity').jnotifyAddMessage({ text: '移除成功。', permanent: false, type: 'message' });
                    }
                    else {
                        top.$.messager.alert('提示信息', msg, 'warning');
                    }
                });
            }
            else {
                top.$.messager.alert("操作提示", "请选择要移除的用户！", "info");
            }
        });
        top.$('#group_clear').click(function () {
//            var count = $("#user_groups option").length
//            if (count <= 0) {
//                top.$.messager.alert("操作提示", "当前角色没有用户！", "info");
//                return;
//            }

            top.$.messager.confirm('询问提示', '确认要清除所有用户吗？', function (data) {
                if (data) {
                    top.$('#user_groups').empty();
                }
            });
            return false;
        });
    });
}

function getSelectedUsers(users, selecedVals) {
    var arrUserid = eval('[' + selecedVals + ']');
    var arr = new Array();
    $.each(users, function (i, n) {
        if ($.inArray(n.Id, arrUserid) > -1)
            arr.push(n);
    });
    return arr;
}

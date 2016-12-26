<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ProcessingWorkFlowTask.aspx.cs" Inherits="RDIFramework.WebApp.WorkFlow.ProcessingWorkFlowTask" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head id="Head1" runat="server">
	    <title>处理任务</title>
	    <link rel="stylesheet" type="text/css" href="../Content/Scripts/easyui/themes/icon.css"/>
	    <link rel="stylesheet" type="text/css" href="../Content/Scripts/easyui/themes/default/easyui.css"/>
	    <script type="text/javascript" src="../Content/Scripts/jquery-1.8.3.min.js"></script>
	    <script type="text/javascript" src="../Content/Scripts/easyui/jquery.easyui.min.js"></script>
	    <script type="text/javascript" src="../Content/Scripts/easyui/rdi.easyui-extend.js" ></script>
	    <script type="text/javascript" src="../Content/Scripts/jQuery.Ajax.js"></script>
	    <link rel="stylesheet" type="text/css" href="../Content/css/common.css"/>
	    <script type="text/javascript" language="javascript">
	        $(function () {
	            var workFlowInsId = '<%=Request["workFlowInsId"]%>';
	            var workTaskId = '<%=Request["workTaskId"]%>';
	            var workFlowId = '<%=Request["workFlowId"]%>';
	            var taskInsCaption = '<%=Request["taskInsCaption"]%>';
	            
	            $('#workFlowHistory').datagrid({
	                sortOrder: 'asc',
	                striped: true,
	                pagination: false,
	                singleSelect: true,
	                selectOnCheck: true,
	                checkOnSelect: true
	            }); 
	            
	            $('#workFlowHistory').datagrid({
	                url: 'handler/WorkFlowCommonBizHandler.ashx?action=GetWorkFlowHistory&workFlowInsId=' + workFlowInsId,
	                idField: 'OPERATORINSID',
	                sortName: 'TASKENDTIME',
	                columns: [[
	                        { title: '任务名', field: 'TASKCAPTION', width: 300 },
	                        { title: '处理人', field: 'OPERATEDDES', width: 300 },
	                        { title: '处理时间', field: 'TASKENDTIME', width: 300 }
	                    ]]
	            });
	            $('#workFlowBackCause').datagrid({
	                url: 'handler/WorkFlowCommonBizHandler.ashx?action=GetWorkFlowBack&workFlowInsId=' + workFlowInsId,
	                idField: 'USERID',
	                sortName: 'BACKTIME',
	                columns: [[
	                        { title: '退回人', field: 'USERID', width: 300 },
	                        { title: '退回原因', field: 'BACKYY', width: 300 },
	                        { title: '退回时间', field: 'BACKTIME', width: 300 }
	                    ]]
	            });
	        });
	
	        var TaskBackStr = '<form  id="uiform"><table class="grid2"  width=100%>';
	        TaskBackStr += '<tr><td colspan="4"> 您确定要退回该项吗?请您填写退回原因！</td></tr>';
	        TaskBackStr += '<tr><td>退回原因：</td><td colspan="3"><textarea style="width:350px;height:70px;" class="txt03" required="true" name="BackCause" id="txtBackCause" ></textarea></td></tr>';
	        TaskBackStr += '<tr><td>退回到那一步？：</td><td colspan="3"><input id="cboBackStep" name="BacStep" style="width:350px;" type="text" class="txt03" /></td></tr>';
	        TaskBackStr += '<tr><td colspan="4">如果您对流程还不太了解，请先查看流程图。</td></tr>';
	        TaskBackStr += '</table></form>';
	
	        var showBackTaskForm = function () {
	            //弹窗
	            var addDialog = top.$.hDialog({
	                content: TaskBackStr,
	                width: 450,
	                height: 251,
	                title: '工作流退回',
	                iconCls: 'icon16_list',
	                submit: function () {
	                    var curStep = top.$('#cboBackStep').combobox('getValue');
	                    var curBackCause = top.$('#txtBackCause');
	                    if (!curBackCause.val()) {
	                        $.messager.alert('警告', '退回原因不能为空！', 'warning');
	                        curBackCause.focus();
	                        return;
	                    }
	                    if (curStep) {
	                        var param = 'action=TaskBack&workFlowInsId=' + curStep + '&operatorInsId=' + '<%=Request["operatorInsId"]%>' + '&backCause=' + curBackCause.val();
	                        $.ajax({
	                            type: "POST",
	                            url: 'handler/WorkFlowCommonBizHandler.ashx',
	                            data: param,
	                            dataType: "json",
	                            success: function(d) {
	                                if (d.Success) {
	                                    alert(d.Message);
	                                    addDialog.dialog('close');
	                                    window.opener = null;
	                                    self.close();
	                                } else {
	                                    MessageOrRedirect(d);
	                                }
	                            }
	                        });
	                    } else {
	                        $.messager.alert('警告提示', '请选择要退回的步骤！', 'warning');
	                        return;
	                    }
	                },
	                onOpen: function () {
	                    var paramBackTask = 'workFlowInsId=' + '<%=Request["workFlowInsId"]%>' + "&workTaskId=" + '<%=Request["workTaskId"]%>' + "&workFlowId=" + '<%=Request["workFlowId"]%>' + '&taskInsCaption=' + '<%=Request["taskInsCaption"]%>';
	                    top.$('#cboBackStep').combobox({
	                        url: 'handler/WorkFlowCommonBizHandler.ashx?action=BindTaskBackStep&' + paramBackTask,
	                        method: 'get',
	                        valueField: 'WORKTASKINSID',
	                        textField: 'TASKINSCAPTION',
	                        editable: false,
	                        panelHeight: 'auto'
	                    });
	                }
	            });
	        };
	        
	        var dyAssignTaskGrid;
	        var assignTask = function () {
	            var tmpAssignTaskDialog = top.$.hDialog({
	                content: '<div id="usercontent" style="width:100px;"></div>',
	                width: 730,
	                height: 580,
	                title: '任务指派',
	                iconCls: 'icon16_plugin_go',
	                onOpen: function () {
	                   dyAssignTaskGrid = top.$('#usercontent').datagrid({
	                        url: '../Modules/handler/UserAdminHandler.ashx?action=GetUserListByPage',
	                        singleSelect: true,
	                        selectOnCheck: true,
	                        checkOnSelect: true,
	                        width: 700,
	                        height: 500,
	                        toolbar: "#tbAssignTask",
	                        idField: 'ID',
	                        sortName: 'SORTCODE',
	                        sortOrder: 'asc',
	                        pagination: true,
	                        rownumbers: true,
	                        pageSize: 50,
	                        pageList: [20, 10, 30, 50],
	                        rowStyler: function (index, row) {
	                            if (row.ENABLED <= 0) {
	                                return 'color:#999;'; //显示为灰色字体
	                            }
	                        },
	                        columns: [[
	                            { field: 'ck', checkbox: true },
	                            { title: '编号', field: 'CODE', width: 150 },
	                            { title: '登录名', field: 'USERNAME', width: 150, sortable: true },
	                            { title: '用户名', field: 'REALNAME', width: 150 },
	                            { title: '部门', field: 'DEPARTMENTNAME', width: 150 }
	                        ]], onLoadSuccess: function (data) {
	                            top.$("#tbAssignTask").css('display', 'block');
	                        }
	                    });
	                },
	                submit: function () {
	                    var curSelectRow = dyAssignTaskGrid.datagrid('getSelected');
	                    if (curSelectRow) {
	                        var param = 'action=AssignTask&operatorInsId=' + '<%=Request["operatorInsId"]%>' + '&assginUserId=' + curSelectRow.ID;
	                        $.ajax({
	                            type: "POST",
	                            url: 'handler/WorkFlowCommonBizHandler.ashx',
	                            data: param,
	                            dataType: "json",
	                            success: function (d) {
	                                if (d.Success) {
	                                    alert(d.Message);
	                                    tmpAssignTaskDialog.dialog('close');
	                                    window.opener.location.reload();
	                                    window.opener = null;
	                                    self.close();
	                                } else {
	                                    MessageOrRedirect(d);
	                                }
	                            }
	                        });
	                    } else {
	                        tmpAssignTaskDialog.dialog('close');
	                    }
	                }
	            });
	            return false;
	        }; 
	        
	        function preview() {
	            var bdhtml = window.document.body.innerHTML;
	            var sprnstr = "<!--startprint-->";
	            var eprnstr = "<!--endprint-->";
	            var prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
	            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
	            window.document.body.innerHTML = prnhtml;
	            window.print();
	        }
	
	        function doAssignUserSearch() {
	            var tmpUserName = top.$('#idUserName').val();
	            var tmpRealName = top.$('#idRealName').val();
	            var ruleArr = [];
	            if (tmpUserName !== '')
	                ruleArr.push({ "field": "USERNAME", "op": "cn", "data": escape(tmpUserName) });
	            if (tmpRealName !== '')
	                ruleArr.push({ "field": "REALNAME", "op": "cn", "data": escape(tmpRealName) });
	
	            if (ruleArr.length > 0) {
	                var filterObj = { groupOp: 'AND', rules: ruleArr };
	                dyAssignTaskGrid.datagrid('load', { filter: JSON.stringify(filterObj) });
	            } else {
	                dyAssignTaskGrid.datagrid('reload');
	            }
	        };
	    </script>
	</head>
	<body>
	<form id="form1" runat="server">
	     <!--startprint-->
	     <div class="easyui-accordion" width="100%">
	        <div title="流程基本信息" data-options="iconCls:'icon16_application_put'" style="padding:10px;">
	           <fieldset>
	            <legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">流 程 信 息</font></legend>
	            <table class="grid" width="100%">
	                <tr>
	                    <td  colspan="1" style="width: 82px">
	                        <asp:Label ID="Label1" runat="server" Text="流程模板:" Width="77px"></asp:Label></td>
	                    <td colspan="1" style="width: 43px" align="left" >
	                        <asp:Label ID="lbWorkflowCaption" runat="server" Text="Label" Width="235px"></asp:Label></td>
	                    <td colspan="1" style="width: 96px" >
	                        <asp:Label ID="Label2" runat="server" Text="任务模板:" Width="83px"></asp:Label></td>
	                    <td  colspan="1" style="width: 177px" align="left" >
	                        <asp:Label ID="lbStartTaskCaption" runat="server" Text="Label" Width="172px"></asp:Label></td>
	                </tr>
	            </table>
	        </fieldset>
	        <fieldset>
	            <legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">业 务 信 息</font></legend>
	            <table class="grid" width="100%">
                    <tr>
                        <td colspan="2" style="width: 131px" align="left" class="blueline">
                            <asp:Label ID="lblWFBizName" runat="server" Text="流程业务名" Width="70px"></asp:Label></td>
                        <td colspan="2" style="width: 89px" align="left" class="blueline">
                            <asp:Label ID="lbFlowInsCaption" runat="server" Text="Label" Width="251px"></asp:Label></td>
                        <td colspan="1" style="width: 351px" align="left" class="blueline">
                            <asp:Label ID="Label4" runat="server" Text="任务名" Width="60px"></asp:Label></td>
                        <td colspan="1" style="width: 320px" align="left" class="blueline">
                            <asp:Label ID="lbTaskCaption" runat="server" Text="Label" Width="227px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 131px; height: 17px;" align="left" class="blueline">
                            <asp:Label ID="Label5" runat="server" Text="到达时间" Width="78px"></asp:Label></td>
                        <td colspan="2" style="width: 89px; height: 17px;" align="left" class="blueline">
                            <asp:Label ID="lbTime" runat="server" Text="lbTime" Width="278%"></asp:Label></td>
                        <td colspan="1" style="width: 351px; height: 17px" align="left" class="blueline">
                            <asp:Label ID="Label7" runat="server" Text="提交人" Width="51px"></asp:Label></td>
                        <td colspan="1" style="width: 320px; height: 17px" align="left" class="blueline">
                            <asp:Label ID="lbUser" runat="server" Text="Label" Width="200px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 131px; height: 19px;" align="left" class="blueline">
                            <asp:Label ID="Label8" runat="server" Text="流程编号" ></asp:Label></td>
                        <td colspan="2" style="width: 89px; height: 19px;" align="left" class="blueline">
                            <asp:Label ID="lbFlowNo" runat="server" Text="Label" Width="249px"></asp:Label></td>
                        <td colspan="1" style="width: 351px; height: 19px" align="left" class="blueline">
                            <asp:Label ID="Label9" runat="server" Text="流程级别"></asp:Label></td>
                        <td colspan="1" style="width: 320px; height: 19px" align="left" class="blueline">
                            <asp:DropDownList ID="drpPriority" runat="server" Enabled="False" EnableTheming="True" Width="109px">
                                <asp:ListItem Selected="True" Value="1">普通</asp:ListItem>
                                <asp:ListItem Value="2">紧急</asp:ListItem>
                                <asp:ListItem Value="3">特急</asp:ListItem>
                            </asp:DropDownList></td>
	                    </tr>
	                    <tr>
	                        <td colspan="2" style="width: 131px" align="left" class="blueline">
	                            <asp:Label ID="Label10" runat="server" Text="流程说明" Width="59px"></asp:Label></td>
	                        <td colspan="4" align="left" class="blueline">
	                            <asp:Label ID="lbWorkflowDes" runat="server" Text="Label" Width="520px"></asp:Label></td>
	                    </tr>
	                </table>
	            </fieldset>
	           </div>
	        </div>
	    
	        <div style="margin:20px 0 10px 0;"></div>
	        <div class="easyui-accordion" width="100%">
	            <div title="流程历史" data-options="iconCls:'icon16_application_put'" style="padding:10px;">
	               <table id="workFlowHistory"></table> 
	            </div>
	        </div>
	        <div class="easyui-accordion" width="100%">
	            <div title="退回原因" data-options="iconCls:'icon16_application_put'" style="padding:10px;">
	               <table id="workFlowBackCause"></table> 
	            </div>
	        </div>
	        <div class="easyui-accordion" width="100%">
	            <div title="业务表单" data-options="iconCls:'icon16_application_put'" style="padding:10px;">
	               <asp:PlaceHolder ID="ctrlPlace" runat="server"></asp:PlaceHolder>       
	            </div>
	        </div>
	        <fieldset>
	            <legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">流 程 操 作</font></legend>
	            <asp:PlaceHolder ID="cmdBtnPlace" runat="server"></asp:PlaceHolder>
	            <input id="btn1" type="button" runat="server" value="退回上一人" onclick="showBackTaskForm()" visible="False" />  
	            <asp:PlaceHolder ID="cmdBtnPlacetj" runat="server"></asp:PlaceHolder>   <br />
	            <asp:PlaceHolder ID="DyAssignPlace" runat="server"></asp:PlaceHolder>
	            <asp:Button ID="btnCancel" Text="取消" runat="server"  OnClientClick="window.close();"  />
	            <input type="button" name="print" value="预览并打印" onclick="preview()"/>
	        </fieldset>
	        <div id="w"></div>
	        <!--endprint-->
	        
	        <div id="tbAssignTask" style="padding:3px;display:none;">  
	            <span>User Name:</span>  
	            <input id="idUserName" style="line-height:20px;border:1px solid #ccc"/>  
	            <span>Real Name:</span>  
	            <input id="idRealName" style="line-height:20px;border:1px solid #ccc"/>  
	            <a href="#" class="easyui-linkbutton" plain="true" onclick="doAssignUserSearch()">Search</a>  
	        </div>
	    </form>
	</body>
</html>

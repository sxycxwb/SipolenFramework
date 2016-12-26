<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="StartWorkFlow.aspx.cs" Inherits="RDIFramework.WebApp.WorkFlow.StartWorkFlow" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head id="Head1" runat="server">
	    <title>启动任务</title>
	    <link rel="stylesheet" type="text/css" href="../Content/Scripts/easyui/themes/default/easyui.css"/>
	    <link rel="stylesheet" type="text/css" href="../Content/Scripts/easyui/themes/icon.css"/>
	    <script type="text/javascript" src="../Content/Scripts/jquery-1.8.3.min.js"></script>
	    <script type="text/javascript" src="../Content/Scripts/easyui/jquery.easyui.min.js"></script>
	    <link rel="stylesheet" type="text/css" href="../Content/css/common.css"/>
	    <link rel="stylesheet" type="text/css" href="../Content/css/css3btn.css"/>
	</head>
	<body>
		<form id="form1" runat="server">
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
		                <td colspan="2" style="height: 25px" >
		                    <asp:Label ID="Label3" runat="server" Text="流程业务名:" Width="72px"></asp:Label></td>
		                <td align="left" colspan="2" style="width: 500px; height: 25px" >
		                    <asp:TextBox ID="tbxWorkflowCaption" runat="server" class="txt01" Width="280px"></asp:TextBox><span
		                        style="color: orangered">*</span></td>
		                <td align="left" colspan="1" style="width: 117px; height: 25px" >
		                    <asp:Label ID="Label4" runat="server" Text="流程编号" Width="55px"></asp:Label></td>
		                <td align="left" colspan="1" style="width: 500px; height: 25px" >
		                    <asp:TextBox ID="tbxFlowNo" runat="server" BorderStyle="None" ReadOnly="True">请输入流程编号</asp:TextBox></td>
		            </tr>
		            <tr>
		                <td  colspan="2" style="height: 25px">
		                    <asp:Label ID="Label5" runat="server" Text="流程说明:" ></asp:Label></td>
		                <td align="left"  colspan="2" style="width: 500px; height: 25px">
		                    <asp:TextBox ID="tbxWorkflowDes" class="txt01" runat="server" Width="426px"></asp:TextBox></td>
		                <td align="left"  colspan="1" style="width: 117px; height: 25px">
		                    <asp:Label ID="Label6" runat="server" Text="紧急程度" Width="55px"></asp:Label></td>
		                <td align="left"  colspan="1" style="width: 500px; height: 25px">
		                    <asp:DropDownList ID="drpPriority" runat="server" Width="109px">
		                        <asp:ListItem Selected="True" Value="1">普通</asp:ListItem>
		                        <asp:ListItem Value="2">紧急</asp:ListItem>
		                        <asp:ListItem Value="3">特急</asp:ListItem>
		                    </asp:DropDownList><span style="color: #ff4500">*</span></td>
		            </tr>
		        </table>
		    </fieldset>
		    <div style="margin:10px 0 5px 0;"></div>
		    <div class="easyui-accordion" width="97%">
		        <div title="业务表单" data-options="iconCls:'icon16_application_put'" style="padding:10px;">
		           <asp:PlaceHolder ID="ctrlPlace" runat="server"></asp:PlaceHolder>       
		        </div>
		    </div>
		    <fieldset>
		        <legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">流 程 操 作</font></legend>
		        <asp:PlaceHolder ID="cmdBtnPlace" runat="server"></asp:PlaceHolder><asp:Button ID="btnCancel" Text="取消" runat="server"  OnClientClick="window.close();" />
		    </fieldset>
	    </form>
	</body>
</html>

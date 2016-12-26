<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ViewWorkFlowChart.aspx.cs" Inherits="RDIFramework.WebApp.WorkFlow.ViewWorkFlowChart" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head id="Head1" runat="server">
	    <title>查看流程图</title>
	    <link rel="stylesheet" type="text/css" href="../Content/css/common.css"/>
	</head>
	<body>
	    <form id="form1" runat="server">
	        <fieldset style="width:98%;">
		        <legend><font style="FONT-SIZE: 13px; COLOR: #082c50; FONT-FAMILY: 宋体">业 务 信 息</font></legend>
		        <table class="grid" width="100%">
		            <tr>
		                <td colspan="2" style="height: 25px" >
		                    <asp:Label ID="Label3" runat="server" Text="流程业务名" Width="72px"></asp:Label></td>
		                <td align="left" colspan="2" style="width: 500px; height: 25px" >
		                    <asp:TextBox ID="tbxWorkflowCaption" runat="server" Width="280px" BorderStyle="None" ReadOnly="True"></asp:TextBox></td>
		                <td align="left" colspan="1" style="width: 117px; height: 25px" >
		                    <asp:Label ID="Label4" runat="server" Text="流程编号" Width="55px"></asp:Label></td>
		                <td align="left" colspan="1" style="width: 500px; height: 25px" >
		                    <asp:TextBox ID="tbxFlowNo" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox></td>
		            </tr>
		            <tr>
		                <td  colspan="2" style="height: 25px">
		                    <asp:Label ID="Label5" runat="server" Text="流程说明" ></asp:Label></td>
		                <td align="left"  colspan="2" style="width: 500px; height: 25px">
		                    <asp:TextBox ID="tbxWorkflowDes" runat="server" Width="426px" BorderStyle="None" ReadOnly="True"></asp:TextBox></td>
		                <td align="left"  colspan="1" style="width: 117px; height: 25px">
		                    <asp:Label ID="Label6" runat="server" Text="紧急程度" Width="55px"></asp:Label></td>
		                <td align="left"  colspan="1" style="width: 500px; height: 25px">
		                    <asp:TextBox ID="tbxPriority" runat="server" Width="109px" BorderStyle="None" ReadOnly="True"></asp:TextBox>
		                </td>
		            </tr>
		        </table>
	    	</fieldset>
	        <table class="grid" style="width: 100%" border="1">
	            <tr>
	                <td style="height: 16px; font-size:13px; font-weight:bold; color:#082c50" colspan="3">
	                    流程执行情况</td>
	            </tr>
	            <tr>
	                <td colspan="3" style="width: 100%; height: 16px">
	                    <asp:Image ID="Image1" runat="server" /></td>
	            </tr>
	        </table>
	    </form>
	</body>
</html>

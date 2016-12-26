<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperTips.aspx.cs" Inherits="RDIFramework.WebApp.WorkFlow.OperTips" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
	    <title>流程引擎处理提示</title>
	</head>
	<body onunload="window.opener.location.reload();" onblur="this.focus();">
	<form id="form1" runat="server">
		<div align="center">
			<fieldset style="width: 745px">
				<legend style="FONT-SIZE: 14px; COLOR: #082c50; FONT-FAMILY: 宋体">工作流引擎处理提示</legend>
		        <table style="width: 624px">
		            <tr>
		                <td style="height: 17px; width: 235px;">
		                </td>
		                <td style="width: 141px; height: 141px;">
		                    &nbsp;<img id="Image2" src="/Content/images/loading.jpg" /></td>
		                <td style="width: 271px; height: 17px">
		                </td>
		            </tr>
		            <tr>
		                <td colspan="3" style="height: 14px" align="left">
		                    <asp:Label ID="lbTitle" runat="server" Text="工作流引擎正在处理" Width="609px"></asp:Label></td>
		            </tr>
		            <tr>
		                <td colspan="3" align="left">
		                    <asp:Label ID="lbDescription" runat="server" Text="请稍后..." Width="750px"></asp:Label>&nbsp;
		                    </td>
		            </tr>
		        </table>
		    </fieldset>
		 </div>
	 </form>
	</body>
</html>

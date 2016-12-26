<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAuditForm.ascx.cs" Inherits="RDIFramework.WebApp.WorkFlow.Common.UCAuditForm" %>
<link rel="stylesheet" type="text/css" href="../../Content/css/common.css"/>  
<fieldset>
    <legend><font style="font-size: 12px; color: #082c50; font-family: 宋体">审 批 信 息</font></legend>
    <table class="grid" style="width: 100%">
        <tr>
            <td style="width: 11px; height: 21px">
                <asp:Label ID="Label1" runat="server" Text=" 审批人Id:" Width="71px"></asp:Label></td>
            <td colspan="2" style="height: 21px">
                <asp:Label ID="lbUserId" runat="server" Height="16px" Text="lbUserId" Width="260px"></asp:Label></td>
            <td style="width: 45px; height: 21px">
                <asp:Label ID="Label3" runat="server" Height="15px" Text="审批人:" Width="66px"></asp:Label></td>
            <td style="width: 45px; height: 21px">
                <asp:Label ID="lbUserName" runat="server" Text="lbUserName" Width="159px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 11px; height: 21px">
                <asp:Label ID="Label5" runat="server" Text="部门:" Width="70px"></asp:Label></td>
            <td colspan="2" style="height: 21px">
                <asp:Label ID="lbArch" runat="server" Text="lbArch" Width="104px"></asp:Label></td>
            <td  style="width: 45px; height: 21px">
                <asp:Label ID="Label7" runat="server" Text="职务:"></asp:Label></td>
            <td  style="width: 45px; height: 21px">
                <asp:Label ID="lbDuty" runat="server" Text="lbDuty" Width="160px"></asp:Label></td>
        </tr>
        <tr>
            <td  style="width: 11px; height: 21px">
                <asp:Label ID="Label9" runat="server" Text="审批结果:" Width="67px"></asp:Label></td>
            <td  style="width: 7px; height: 21px"><asp:RadioButton ID="rbtOk" runat="server" Checked="True" Text="同意" Width="50px" GroupName="1" />
            </td>
            <td  style="height: 21px">
                <asp:RadioButton ID="rbtNo" runat="server" Text="拒绝" Width="50px" GroupName="1" />
            </td>
            <td  style="width: 45px; height: 21px">
                <asp:Label ID="Label10" runat="server" Text="审批时间:" Width="75px"></asp:Label></td>
            <td  style="width: 45px; height: 21px">
                <asp:Label ID="lbAuditTime" runat="server" Text="lbAuditTime" Width="160px"></asp:Label></td>
        </tr>
        <tr>
            <td  style="width: 11px; height: 21px">
                <asp:Label ID="Label11" runat="server" Text="审批意见:" Width="74px"></asp:Label></td>
            <td  colspan="4" style="height: 21px;">
            </td>
        </tr>
        <tr>
            <td  style="width: 11px; height: 25px">
            </td>
            <td  colspan="4" style="height: 25px">
                <asp:TextBox ID="tbxMessage" runat="server" Height="133px" Rows="3" CssClass="txt01" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 11px; height: 21px">
            </td>
            <td colspan="4" style="height: 21px">
                <asp:Label ID="lbOperatorInsId" runat="server" Text="lbOperatorInsId" Visible="False"></asp:Label>
                <asp:Label ID="lbWorktaskInsId" runat="server" Text="lbWorktaskInsId" Visible="False"></asp:Label>
                <asp:Label ID="lbWorktaskId" runat="server" Text="lbWorktaskId" Visible="False"></asp:Label>
                <asp:Label ID="lbWorkflowInsId" runat="server" Text="lbWorkflowInsId" Visible="False"></asp:Label>
                <asp:Label ID="lbWorkflowId" runat="server" Text="lbWorkflowId" Visible="False"></asp:Label>
                <asp:Label ID="lbAuditId" runat="server" Text="lbAuditId" Visible="False"></asp:Label></td>
        </tr>
    </table>
</fieldset>

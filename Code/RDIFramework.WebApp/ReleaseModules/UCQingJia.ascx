<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCQingJia.ascx.cs" Inherits="RDIFramework.WebApp.BizModules.UCQingJia" %>
<link rel="stylesheet" type="text/css" href="/Content/css/common.css"/>  
<script type="text/javascript" src="/Content/Scripts/My97DatePicker/WdatePicker.js"></script>
<table class="grid" style="width: 100%" border="1">
    <tr>
        <td style="width: 77px" class="line">
            请假人</td>
        <td style="width: 221px" class="line">
            <asp:Label ID="lbUserId" runat="server" Text="Label" Width="200px"></asp:Label></td>
        <td style="width: 123px" class="line">
            姓名</td>
        <td style="width: 163px" class="line">
            <asp:Label ID="lbUserName" runat="server" Text="Label" Width="200px"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 77px" class="line">
            部门</td>
        <td style="width: 221px" class="line">
            <asp:Label ID="lbArchCaption" runat="server" Text="Label" Width="200px"></asp:Label></td>
        <td style="width: 123px" class="line">
            岗位</td>
        <td style="width: 163px" class="line">
            <asp:Label ID="lbDutyCaption" runat="server" Text="Label" Width="200px"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 77px" class="line">
            开始时间</td>
        <td style="width: 221px" class="line">
            
            &nbsp;<input id="tbxStartTime" class="Wdate" type="text" onFocus="WdatePicker({lang:'zh-cn'})" runat="server"/>
            <%--<input id="tbxStartTime" type="text"  runat="server"/><img onclick="WdatePicker({el:'tbxStartTime'})" src="/Content/Scripts/My97DatePicker/skin/datePicker.gif" width="16" height="22" align="absmiddle">--%>
            </td>
        <td style="width: 123px" class="line">
            结束时间</td>
        <td style="width: 163px" class="line">
            &nbsp;<input id="tbxEndTime" class="Wdate" type="text" onFocus="WdatePicker({lang:'zh-cn'})" runat="server"/>
            <%--<input id="tbxEndTime" type="text" runat="server"/><img onclick="WdatePicker({el:'tbxEndTime'})" src="/Content/Scripts/My97DatePicker/skin/datePicker.gif" width="16" height="22" align="absmiddle">--%>
           </td>
    </tr>
    <tr>
        <td style="width: 77px" class="line">
            类型</td>
        <td style="width: 221px" class="line">
            <asp:DropDownList ID="dplType" runat="server" Width="120px">
                <asp:ListItem>病假</asp:ListItem>
                <asp:ListItem>事假</asp:ListItem>
                <asp:ListItem>婚假</asp:ListItem>
            </asp:DropDownList></td>
        <td style="width: 123px" class="line">
            请假天数</td>
        <td style="width: 163px" class="line">
            <asp:TextBox ID="tbxDays" runat="server" Width="95%" CssClass="txt01">1</asp:TextBox><span
                style="color: #ff3300"><span></span></span></td>
    </tr>
    <tr>
        <td style="width: 77px" class="line">
            事由说明</td>
        <td colspan="3" class="line">
            <span style="color: #ff3300">请假天数超过10天的必须由副总审批!</span></td>
    </tr>
    <tr>
        <td colspan="4" align="center" class="line">
            <asp:TextBox ID="tbxQingjia" runat="server" Height="80px" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
    </tr>
</table>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Evection.ascx.cs" Inherits="RDIFramework.WebApp.BizModules.Evection" %>
<link rel="stylesheet" type="text/css" href="/Content/css/common.css"/>  
<script type="text/javascript" src="/Content/Scripts/My97DatePicker/WdatePicker.js"></script>
<table style="width: 100%" class="grid">
    <tr>
        <td class="style3" style="width: 80px">
            &nbsp;<asp:Label ID="Label1" runat="server" Text="单据编号"></asp:Label></td>
        <td class="style3">
            <asp:TextBox ID="tbxBillCode" runat="server"  ReadOnly="True" Width="183px"></asp:TextBox></td>
        <td class="style3" style="width: 23px">
            &nbsp;<asp:Label ID="Label2" runat="server" Text="提交日期" Width="65px"></asp:Label>
                
            </td>
        <td class="style3" style="width: 5px">
            <%--<yywebcontrol:yysimplecalendar id="YYSubmitDate" runat="server" ReadOnly="True"></yywebcontrol:yysimplecalendar>--%>
            <input id="YYSubmitDate" class="Wdate" type="text" onFocus="WdatePicker({lang:'zh-cn'})" runat="server"/>
        </td>
        <td class="style3">
            &nbsp;<asp:Label ID="Label3" runat="server"  Text="报销人" Width="56px"></asp:Label></td>
        <td class="style3" style="width: 155px">
            <asp:TextBox ID="tbxSubmitUser" runat="server" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="style3" style="width: 80px">
            &nbsp;<asp:Label ID="Label11" runat="server" Text="所属部门" Width="76px"></asp:Label></td>
        <td class="style3">
            <asp:TextBox ID="tbxDept" runat="server" Width="183px" ReadOnly="True"></asp:TextBox></td>
        <td class="style3" style="width: 23px">
            &nbsp;</td>
        <td class="style3" style="width: 5px">
            </td>
        <td class="style3">
            &nbsp;</td>
        <td class="style3" style="width: 155px">
            </td>
    </tr>
    <tr>
        <td class="style3" style="width: 80px">
            <asp:Label ID="Label15" runat="server" Text="出差事由"></asp:Label></td>
        <td class="style3" colspan="5">
            <asp:TextBox ID="tbxReason" runat="server" Width="100%" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan="6">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CaptionAlign="Top" CellPadding="4"  GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:CommandField HeaderText="选中" ShowSelectButton="True" >
                        <ItemStyle Width="60px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="startaddress" HeaderText="起点" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="endaddress" HeaderText="终点" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="vehicle" HeaderText="交通工具" >
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="vehiclecost" HeaderText="车/船/机票费" >
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="citycost" HeaderText="市内交通费">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="livedays" HeaderText="住宿/天数">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="liveprice" HeaderText="住宿/房价(单价)">
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="evectiondays" HeaderText="出差天数">
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="allowance" HeaderText="出差/津贴(每天)">
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="others" HeaderText="其他费用" >
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:CommandField HeaderText="操作" ShowDeleteButton="True" ShowHeader="True" >
                        <ItemStyle Width="60px" />
                    </asp:CommandField>
                </Columns>
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle  BackColor="Azure" Font-Bold="True"/>
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
    </tr>
</table>
<asp:Panel ID="Panel1" runat="server" Width="100%">
    <table width="100%" class="grid">
        <tr>
            <td class="style3" colspan="1" style="width: 85px; height: 27px">
                <asp:Label ID="Label4" runat="server" Text="费用合计" Width="89px"></asp:Label></td>
            <td class="style3" colspan="1" style="width: 183px; height: 27px">
                <asp:TextBox ID="tbxTotal" runat="server"  Width="118px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="减:借款"></asp:Label></td>
            <td class="style3" colspan="1" style="width: 115px; height: 27px">
                <asp:TextBox ID="tbxLendprice" runat="server" Width="98px">0.00</asp:TextBox></td>
            <td class="style3" colspan="1" style="height: 27px; width: 227px;">
                <asp:Label ID="Label12" runat="server" Text="支付金额"></asp:Label>
                <asp:TextBox ID="tbxFactprice" runat="server" Width="111px" ReadOnly="True"></asp:TextBox></td>
            <td class="style3" colspan="1" style="height: 27px">
                (大写)<asp:TextBox ID="tbxCntotal" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style3" colspan="1" style="width: 85px; height: 27px">
                备注</td>
            <td class="style3" colspan="4" style="height: 27px">
                <asp:TextBox ID="tbxRemark" runat="server" Rows="3" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" Width="100%">
    <table width="100%" class="grid">
        <tr>
            <td class="style3" colspan="10">在此处增加或者修改报销信息</td>
        </tr>
        <tr>
            <td class="style3" style="width: 66px">
                &nbsp;<asp:Label ID="Label6" runat="server" Text="起点"></asp:Label></td>
            <td class="style3" style="width: 73px">
                <asp:Label ID="Label13" runat="server" Text="终点"></asp:Label></td>
            <td class="style3" style="width: 74px">
                &nbsp;<asp:Label ID="Label16" runat="server" Text="交通工具" Width="76px"></asp:Label></td>
            <td class="style3" style="width: 59px">
                <asp:Label ID="Label8" runat="server" Text="车/船/机/票费" Width="92px"></asp:Label>
            </td>
            <td class="style3" style="width: 94px">
                &nbsp;<asp:Label ID="Label17" runat="server" Text="市内交通费" Width="88px"></asp:Label></td>
            <td class="style3" style="width: 2px">
                <asp:Label ID="Label7" runat="server"  Text="住宿/天数"
                    Width="72px"></asp:Label></td>
            <td class="style3" style="width: 78px">
                <asp:Label ID="Label9" runat="server"  Text="住宿/房价"
                    Width="76px"></asp:Label><br />
                &nbsp;&nbsp;
                <asp:Label ID="Label18" runat="server"  Text="(单价)"
                    Width="45px"></asp:Label></td>
            <td class="style3" style="width: 76px">
                <p align="center">
                    出差/天数</p>
            </td>
            <td class="style3" style="width: 81px">
                <p align="center">
                    出差/津贴<br />
                    (每天)</p>
            </td>
            <td class="style3">
                <p align="center">
                    其它费用</p>
            </td>
        </tr>
        <tr>
            <td class="style3" style="width: 66px">
                <asp:TextBox ID="tbxStartaddress" runat="server"  Width="74px"></asp:TextBox></td>
            <td class="style3" style="width: 73px">
                <asp:TextBox ID="tbxEndaddress" runat="server" Width="77px"></asp:TextBox></td>
            <td class="style3" style="width: 74px">
                <asp:DropDownList ID="drpVehicle" runat="server" Width="69px">
                    <asp:ListItem Selected="True">火车</asp:ListItem>
                    <asp:ListItem>飞机</asp:ListItem>
                    <asp:ListItem>汽车</asp:ListItem>
                    <asp:ListItem>轮船</asp:ListItem>
                </asp:DropDownList></td>
            <td class="style3" style="width: 59px">
                <asp:TextBox ID="tbxVehicelcost" runat="server" Width="97px">0</asp:TextBox></td>
            <td class="style3" style="width: 94px">
                <asp:TextBox ID="tbxCitycost" runat="server" Width="88px">0</asp:TextBox></td>
            <td class="style3" style="width: 2px">
                <asp:TextBox ID="tbxLivedays" runat="server" Width="71px">0</asp:TextBox></td>
            <td class="style3" style="width: 78px">
                <asp:TextBox ID="tbxLiveprice" runat="server" Width="71px">0</asp:TextBox></td>
            <td class="style3" style="width: 76px">
                <asp:TextBox ID="tbxEvectiondays" runat="server" Width="71px">0</asp:TextBox></td>
            <td class="style3" style="width: 81px">
                <asp:TextBox ID="tbxAllowance" runat="server" Width="71px">0</asp:TextBox></td>
            <td class="style3">
                <asp:TextBox ID="tbxOthers" runat="server" Width="71px">0</asp:TextBox></td>
        </tr>
        <tr>
            <td class="style3" style="width: 66px; height: 31px">
                &nbsp;</td>
            <td class="style3" style="width: 73px; height: 31px">
                <asp:Button ID="btnAdd" runat="server" Text="增加" OnClick="btnAdd_Click" CssClass="inputsubmit-blue" /></td>
            <td class="style3" style="width: 74px; height: 31px">
                &nbsp;<asp:Button ID="btnModify" runat="server" Text="修改" OnClick="btnModify_Click" CssClass="inputsubmit-blue" /></td>
            <td class="style3" style="width: 59px; height: 31px">
                </td>
            <td class="style3" style="width: 94px; height: 31px">
                &nbsp;</td>
            <td class="style3" style="width: 2px; height: 31px">
                </td>
            <td class="style3" style="width: 78px; height: 31px">
            </td>
            <td class="style3" style="width: 76px; height: 31px">
            </td>
            <td class="style3" style="width: 81px; height: 31px">
            </td>
            <td class="style3" style="height: 31px">
            </td>
        </tr>
    </table>
</asp:Panel>
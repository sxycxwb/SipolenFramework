<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAuditList.ascx.cs" Inherits="RDIFramework.WebApp.WorkFlow.Common.UCAuditList" %>
<link rel="stylesheet" type="text/css" href="../../Content/css/common.css"/>  
<fieldset>
    <legend><font style="font-size: 12px; color: #082c50; font-family: 宋体">审 批 信 息</font></legend>
    <table class="grid">
        <tr valign="top">
            <td align="left" colspan="2" valign="top">
                <asp:GridView ID="gvAuditMessage" runat="server" AutoGenerateColumns="False" 
                    Width="100%">
                    <Columns>
                        <asp:BoundField DataField="AUDITUSERID" HeaderText="审批人Id" Visible="False" >
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AUDITUSERNAME" HeaderText="审批人" >
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AUDITARCH" HeaderText="部门" >
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AUDITDUTY" HeaderText="职务" >
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AUDITRESULT" HeaderText="审批结果" >
                            <ItemStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MESSAGE" HeaderText="审批意见">
                            <ItemStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AUDITTIME" HeaderText="审批时间" >
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="gridHead" HorizontalAlign="Left" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</fieldset>

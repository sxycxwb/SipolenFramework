<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAttachment.ascx.cs" Inherits="RDIFramework.WebApp.WorkFlow.Common.UCAttachment" %>
<link rel="stylesheet" type="text/css" href="../../Content/css/common.css"/>  
<fieldset>
		<legend>
		<font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">附 件 信 息</font></legend>
		<table class="grid">
			<tr>
				<td align="left">
				    <div id="FileCollection"><input id="inputFile" type="file" size="50" name="File" runat="server"/>&nbsp;
                    <asp:button id="ButtonConfirm" Text="确认上传" Width="100px" runat="server" CausesValidation="False"
							OnClick="ButtonConfirm_Click"></asp:button></div>
					<asp:label id="labelUpResult" Font-Size="9pt" runat="server" Width="179px"></asp:label><br>
                    <asp:GridView ID="gvAffixfiles" runat="server" AutoGenerateColumns="False" Width="522px" OnRowDataBound="gvAffixfiles_RowDataBound">
                        <Columns>
                            <asp:HyperLinkField DataTextField="ATTACHMENTNAME" HeaderText="文件名">
                                <ItemStyle Width="300px" />
                            </asp:HyperLinkField>
                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName=""
                                        Text="删除" CommandArgument='<%#Eval("ID")+","+Eval("ATTACHMENTPATH")%>' OnClick="LinkButton2_Click"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="下载" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName=""
                                        Text="下载" OnClick="LinkButton1_Click" CommandArgument='<%#Eval("ID")+","+Eval("ATTACHMENTNAME")%>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
			</tr>
		</table>
	</fieldset>

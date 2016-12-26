<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MessageAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.MessageAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="layout" class="easyui-layout">
            <div region="west" iconCls="icon16_email_trace" split="true" title="消息分类列表" style="width:220px;padding: 5px" collapsible="false">
                <ul id="messageCategoryTree"></ul>
            </div>
            <div region="center" title="消息列表" iconCls="icon16_list" style="padding: 2px; overflow: hidden">       
		        <div id="toolbar">
                    <div style="float: left;padding-top:2px;">   
                        <%=base.BuildToolBarButtons()%>          
                    </div>
                </div> 
                   
                <table id="messageList" toolbar="#toolbar"></table> 
            </div>       
    </div>
    <script type="text/javascript" src="js/MessageAdmin.js"></script>
</asp:Content>

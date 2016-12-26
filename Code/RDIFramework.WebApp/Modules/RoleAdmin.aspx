<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoleAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.RoleAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="toolbar">
        <div style="float: left;padding-top:2px;">
            <%=base.BuildToolBarButtons()%>
            <div class='datagrid-btn-separator'></div>
            <div style="float: right; margin-top:3px;">
                角色分类：<input type="text" id="Category" name="Category" class="txt03" style="width: 160px;"/> 
            </div>
        </div>
    </div>

   <table id="list"></table> 
   <div id="divPrint"></div>  
   <script type="text/javascript" src="js/RoleAdmin.js?v=29"></script>
   <script type="text/javascript" src="../Content/Scripts/Business/exportutil.js"></script>
   <script type="text/javascript" src="../Content/Scripts/jqprint/jquery.jqprint-0.3.js"></script>
</asp:Content>
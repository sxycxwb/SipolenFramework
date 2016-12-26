<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataItemAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.DataItemAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div id="layout">
        <div region="west" title = '字典类别' split="true" iconCls="icon16_book"  style="width:200px;" border="true">
            <div class="toolbar">
                <a id="a_addCategory" style="float:left" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_add" title="添加字典类别">添加</a>
                <a id="a_editCategory" style="float:left" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_edit_button" title="修改字典类别">修改</a>
                <a id="a_delCategory" style="float:left" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_delete" title="删除字典类别">删除</a>
             </div>                
             <table id = "dataDicType"></table>
        </div>
        <div region="center" border="false" style="overflow: hidden;">
            <div id="toolbar">
                <%=base.BuildItemDetailToolBarButtons()%>
            </div>
             <table id="dicGrid"></table>
        </div>
    </div>
    <script type="text/javascript" src="js/DataItemAdmin.js?v=30"></script>    
</asp:Content>

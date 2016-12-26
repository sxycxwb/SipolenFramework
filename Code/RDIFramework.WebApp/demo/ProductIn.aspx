<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="ProductIn.aspx.cs" Inherits="RDIFramework.WebApp.demo.ProductIn" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div id="toolbar">
	    <a id="a_add" style="float:left" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_add" title="新增">新增</a>
	    <div class='datagrid-btn-separator'>
	    </div>
	    <a id="a_edit" style="float:left" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon-pencil" title="修改">修改</a>
	    <div class='datagrid-btn-separator'></div>
        <a id="a_delete" style="float:left" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_delete" title="删除">删除</a>
        <div class='datagrid-btn-separator'></div>
		<a id="a_search" style="float:left" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_filter" title="查询">查询</a>
	</div>

     <table id="list"></table>  
    
    <script type="text/javascript" src="../Content/Scripts/Business/Search.js"></script>  
    <script type="text/javascript" src="js/ProductIn.js"></script>

</asp:Content>
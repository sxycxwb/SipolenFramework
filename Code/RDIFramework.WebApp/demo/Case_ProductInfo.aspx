<%@ Page Language="C#"  MasterPageFile="~/Site.Master"   AutoEventWireup="true" CodeBehind="Case_ProductInfo.aspx.cs" Inherits="RDIFramework.WebApp.Case_ProductInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div id="toolbar">
	     <%=base.BuildToolBarButtons()%>
         <a id="btnPrint" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_printer" title="打印">打印</a>
	</div>
    
    <table id="list"></table>  
    <div id="win"></div>
    <script type="text/javascript" src="../Content/Scripts/Business/Search.js"></script>  
    <script type="text/javascript" src="../Content/Scripts/Business/exportutil.js"></script>
    <script type="text/javascript" src="js/CaseProductInfo.js"></script>    
</asp:Content>
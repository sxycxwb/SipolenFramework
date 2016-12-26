<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PDFReader.aspx.cs" Inherits="RDIFramework.WebApp.demo.PDFReader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="layout" class="easyui-layout">
        <div region="west" iconCls="icon-computer" split="true" title="PDF目录列表" style="width:220px;padding: 5px" collapsible="false">
            <ul id="pdfTree"></ul>
        </div>
         <div id="mainPanle" title="PDF阅读器" region="center" style="background: #eee; overflow-y:hidden" border="false">
		    <div id="pdftabs" class="easyui-tabs"  fit="true"></div>   
	    </div>      
    </div>
    <script type="text/javascript" src="js/PDFReader.js?v=29"></script>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TableFieldAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.TableFieldAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content> 
<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="layout">
        <div region="west" iconCls="icon16_able" split="true" title="数据表" style="width:280px;padding: 5px" collapsible="false">
            <ul id="tbData"></ul>
        </div>
        <div region="center" title="表字段明细" iconCls="icon16_column_double" style="padding: 2px; overflow: hidden">
            <div id="toolbar">
               <%=base.BuildToolBarButtons()%>               
            </div>
            <table id="tableFieldGird" toolbar="#toolbar"></table>

        </div>
    </div>
    <script type="text/javascript" src="../Content/Scripts/Linqjs/linq.min.js"></script>
    <script type="text/javascript" src="../Content/Scripts/Linqjs/linq.jquery.js"></script>
    <script type="text/javascript" src="../Content/Scripts/Business/exportutil.js"></script>
    <script type="text/javascript" src="js/TableFieldAdmin.js?v=3.0"></script>
</asp:Content>

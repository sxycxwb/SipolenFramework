<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SequenceAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.SequenceAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="toolbar">
        <div style="float: left;padding-top:2px;">
            <%=base.BuildToolBarButtons()%>
        </div>
    </div>

   <table id="list"></table> 
   <div id="divPrint"></div>  
   <script type="text/javascript" src="js/SequenceAdmin.js?v=3.0"></script>
   <script type="text/javascript" src="../Content/Scripts/Business/exportutil.js"></script>
</asp:Content>

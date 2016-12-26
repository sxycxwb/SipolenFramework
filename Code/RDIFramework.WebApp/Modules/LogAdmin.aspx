<%@ Page Title="系统日志" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LogAdmin.aspx.cs" Inherits="RDIFramework.WebApp.Modules.LogAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var __c_uinfo = { "id": '<%=base.UserInfo.Id %>', "name": '<%=base.UserInfo.RealName %>' };
    </script>
</asp:Content> 

<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="searchArea">			
		操作用户：<input type="text" name="opuser" id="txtOpuser" class="txt03" style="width: 120px;"/>&nbsp;
		操作日期：<input type="text" id="dtOpstart"/> 至 <input type="text" id="dtOpend"/>&nbsp;
		IP地址：<input type="text" id="txtIpAddress" name="IpAddress" class="txt03" style="width: 100px;"/>    
		<a id="btnSearch" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_filter" title="查询">查询</a>  
	</div>  
	<div id="toolbar">
		<div>
			<%=base.BuildToolBarButtons()%>    
		</div>
    </div>
    <!--用于数据显示-->    
    <table id="list"></table>    

    <script type="text/javascript" src="js/LogAdmin.js?v=30"></script>
    <script type="text/javascript" src="../Content/Scripts/Business/exportutil.js"></script>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataItemAdminV28.aspx.cs" Inherits="RDIFramework.WebApp.Modules.DataItemAdminV28" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="layout" style="padding:0px;" >
        <div region="west" style="width:200px;border-right: 0px;" border="true">
            <div class="easyui-panel" title="字典类别" border="false" iconCls="icon-book_red" >
                <div class="toolbar" style="background:#efefef;border-bottom:1px solid #ccc">
                    <a id="a_addCategory" style="float:left" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_add" title="添加字典类别">添加</a>
                    <a id="a_editCategory" style="float:left" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_edit_button" title="修改字典类别">修改</a>
                    <a id="a_delCategory" style="float:left" href="javascript:;" plain="true" class="easyui-linkbutton" icon="icon16_delete" title="删除字典类别">删除</a>
                </div>
                <div style="padding:5px;">
                    <ul id="dataDicType"></ul>
                </div>
            </div>
            <div id="noCategoryInfo" style="font-family:微软雅黑; font-size: 18px; color:#BCBCBC; padding: 40px 5px;display:none;">
                　　亲，还没有字典类别哦，点击 添加 按钮创建新的类别。
            </div>
        </div>
        <div region="center" border="false" style="overflow: hidden;">
            <div class="toolbar">
                <%=base.BuildItemDetailToolBarButtons()%>
            </div>
             <table id="dicGrid"></table>
        </div>
    </div>
    <script type="text/javascript" src="js/DataItemAdminV28.js?v=29"></script>    
</asp:Content>

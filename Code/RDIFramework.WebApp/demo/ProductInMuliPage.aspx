<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="ProductInMuliPage.aspx.cs" Inherits="RDIFramework.WebApp.demo.ProductInMuliPage" %>


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
	</div>

     <table id="list1"></table>  
    
    <script type="text/javascript">
        $(function () {           
            autoResize({ dataGrid: '#list1', gridType: 'datagrid', callback: grid.bind, height: 0 });
        });

        var grid = {
            bind: function (winSize) {
                $('#list1').datagrid({
                    url: '/demo/handler/ProductIn.ashx?action=GetMultiPage',
                    toolbar: '#toolbar',
                    title: "数据列表",
                    iconCls: 'icon icon-list',
                    width: winSize.width,
                    height: winSize.height,
                    nowrap: false, //折行
                    rownumbers: true, //行号
                    striped: true, //隔行变色
                    idField: 'ID', //主键
                    sortName: 'CREATEON',
                    sortOrder: 'desc',
                    singleSelect: true, //单选
                    onRowContextMenu: pageContextMenu.createDataGridContextMenu,
                    frozenColumns: [[]],
                    columns: [[
				{ title: '主键', field: 'ID', width: 120, hidden: true },
		        { title: '入库单编码', field: 'CODE', width: 130 },
		        { title: '入库日期', field: 'INDATE', width: 150 },
                { title: '入库类型', field: 'INTYPE', width: 100 },
		        { title: '保管员', field: 'CUSTODIAN', width: 70 },
		        { title: '品名', field: 'FULLNAME', width: 100 },
                { title: '数量', field: 'AMOUNT', width: 80 },
		        { title: '单价', field: 'UNITPRICE', width: 150 }
                ]],
                    pagination: true,
                    pageSize: 5,
                    pageList: [5, 10, 20]
                });
            },
            getSelectedRow: function () {
                return $('#list1').datagrid('getSelected');
            },
            reload: function () {
                $('#list1').datagrid('clearSelections').datagrid('reload', { filter: '' });
            }
        };
    </script>

</asp:Content>
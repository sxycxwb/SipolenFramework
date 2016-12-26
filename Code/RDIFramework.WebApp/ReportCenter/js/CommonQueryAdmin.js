/*
RDIFramework.NET，基于.NET的快速信息化系统开发、整合框架，给用户和开发者最佳的.Net框架部署方案。
框架官网：http://www.rdiframework.net/
框架博客：http://blog.rdiframework.net/
交流QQ：406590790 
邮件交流：406590790@qq.com

其他博客：
    http://www.cnblogs.com/huyong 
    http://blog.csdn.net/chinahuyong
*************************************************************************************
* RDIFramework.NET框架“查询引擎定义”业务界面逻辑
*
* 修改记录：
*   1. 2015-12-07 EricHu V3.0 新增本业务逻辑的编写。
*/
var commonQueryGrid,
    controlQueryEngineUrl = 'handler/CommonQueryAdminHandler.ashx';

$(function () {
    pageSizeControl.init({ gridId: 'commonQueryGrid', gridType: 'datagrid' });
    queryEngineTree.init();
    //autoResize({ dataGrid: '#commonQueryGrid', gridType: 'datagrid', callback: grid.databind, height: 35, width: 230 });    
    autoResize({ dataGrid: '#commonQueryGrid', gridType: 'datagrid', callback: grid.databind, height: 35, width: 0 });    
    $('#a_refresh').attr('onclick', 'crud.refreash();');
    $('#a_prviewData').attr('onclick', 'crud.prviewData();');    
    $(window).resize(function () {
        pageSizeControl.init({ gridId: 'commonQueryGrid', gridType: 'datagrid' });
    });
});

var queryEngineTree = {
    init: function () {
        $('#queryEngineTree').tree({
            lines: true,
            url: '../Modules/handler/QueryEngineAdminHandler.ashx?action=GetQueryEngineTreeJson&isTree=1',
            animate: true,
            onLoadSuccess: function (node, data) {
                if (data.length && data.length > 0) {
                    $('body').data('queryEngineData', data);
                }
            },
            onClick: function (node) {
                $(this).tree('toggle', node.target);
            },
            onSelect: function (node) {                
                $('#commonQueryGrid').datagrid({
                    url: controlQueryEngineUrl + '?action=GetEngineDefinePageDTByEngineIds',
                    queryParams: { queryEngineId: node.id }
                });

                //清空上次的选择
                $('#detailGrid').datagrid('loadData', { total: 0, rows: []});  
                $('#commonQueryGrid').datagrid('clearSelections');
            }
        });
    },
    selected: function () {
        return $('#queryEngineTree').tree('getSelected');
    },    
    reLoad: function () {
        return $('#queryEngineTree').tree('reload');
    }
};

var grid = {
    databind: function (winsize) {
        commonQueryGrid = $('#commonQueryGrid').datagrid({
            toolbar: '#toolbar',
            width: winsize.width,
            height: winsize.height,
            striped: true,
            fit: true,
            singleSelect: true,
            selectOnCheck: true,
            checkOnSelect: true,
            loadMsg: '正在努力加载中....',            
            onRowContextMenu: pageContextMenu.createDataGridContextMenu,
            idField: 'ID',
            sortName: 'SORTCODE',
            sortOrder: 'asc',
            pagination: true,
            rownumbers: true,
            pageSize: 20,
            pageList: [20, 10, 30, 50],
            onDblClickRow: function (rowIndex, rowData) {
                //document.getElementById('a_edit').click(); //弹出修改     
                $('#detailGrid').datagrid('loadData', { total: 0, rows: []});
                crud.prviewData();
            },
            onLoadSuccess: function (data) {
                if (data.total == 0) {
                    //添加一个新数据行，第一列的值为你需要的提示信息，然后将其他列合并到第一列来，注意修改colspan参数为你columns配置的总列数
                    $(this).datagrid('appendRow', { CODE: '<div style="text-align:center;color:red">没有相关记录！</div>' }).datagrid('mergeCells', { index: 0, field: 'CODE', colspan: 10 })
                    //隐藏分页导航条，这个需要熟悉datagrid的html结构，直接用jquery操作DOM对象，easyui datagrid没有提供相关方法隐藏导航条
                    $(this).closest('div.datagrid-wrap').find('div.datagrid-pager').hide();
                }
                //如果通过调用reload方法重新加载数据有数据时显示出分页导航容器
                else $(this).closest('div.datagrid-wrap').find('div.datagrid-pager').show();
            },
            columns: [[
                { title: '编码', field: 'CODE', width: 130 },
                { title: '名称', field: 'FULLNAME', width: 200 },
                { title: 'Id', field: 'ID', hidden: true },
                { title: 'QueryEngineId', field: 'QUERYENGINEID', hidden: true },
                { title: '连接名称', field: 'LINKNAME_CHS', width: 150 },
                { title: '数据源类型', field: 'DATASOURCETYPE', width: 80, align: 'center', formatter: function (v, d, i) {
                    if (v == '1') { return '<span style="color:#0066CC;">表或视图</span>'; }
                    else if (v == '2') { return '<span style="color:#CC3366;">存储过程</span>'; }
                    else { return '<span style="color:#666666;">未知</span>'; }
                }
                },
                { title: '数据源名称', field: 'DATASOURCENAME', width: 120 },
                {
                    title: '有效', field: 'ENABLED', width: 50, align: 'center', formatter: function (v, d, i) {
                        return '<img src="/Content/images/' + (v ? "checkmark.gif" : "checknomark.gif") + '" />';
                    }
                },
                {
                    title: '可编辑', field: 'ALLOWEDIT', width: 50, align: 'center', formatter: function (v, d, i) {
                        return '<img src="/Content/images/' + (v ? "checkmark.gif" : "checknomark.gif") + '" />';
                    }
                },
				{
				    title: '可删除', field: 'ALLOWDELETE', width: 50, align: 'center', formatter: function (v, d, i) {
				        return '<img src="/Content/images/' + (v ? "checkmark.gif" : "checknomark.gif") + '" />';
				    }
				},
                { title: '排序', field: 'SORTCODE', width: 60, align: 'right' },
                { title: '备注', field: 'DESCRIPTION', width: 500 }
            ]]
        });
    },
    reload: function (treeNode) {
        if (treeNode) {
            commonQueryGrid.datagrid({
                url: controlQueryEngineUrl + "?action=GetEngineDefinePageDTByEngineIds",
                queryParams: { queryEngineId: treeNode.id }
            });
        }
    },
    selected: function () {
        return commonQueryGrid.datagrid('getSelected');
    }
};

var crud = {
    refreash: function () {
        grid.reload(queryEngineTree.selected());
    },    
    prviewData: function () { //预览数据
        $('#hid_pageNumber').val(1);
        var row = grid.selected();
        if (!row || !row.ID) {
            return false;
        }
        $('#p2').panel({ title: '数据样例：' + row.FULLNAME });
        loadPreviewData(row.ID);
    }
};

function loadPreviewData(id) {
    var parm = 'queryEngineDefineId=' + id + '&pageNumber=' + $('#hid_pageNumber').val() + '&pageSize=' + $('#hid_pageSize').val();
    $.post(controlQueryEngineUrl + '?action=GetDynamicJsonByQueryEngineDefineId', parm, showGrid, "json")
    .error(function () {
        msg.error("加载数据出错，请检查连接定义或网络连接等！"); 
    });
}

//处理返回结果，并显示数据表格（分页还是有问题，待处理）
function showGrid(data) {
    if (data.data[0].rows.length == 0) {
        msg.warning("没有数据!");
    }
    var options = {
        width: "auto",
        height: "auto",
        fit: true,
        singleSelect: true,
        pagination: true,
        loadMsg: '正在努力加载中....',
        rownumbers: true
    };
    options.columns = eval(data.columns); //把返回的数组字符串转为对象，并赋于datagrid的column属性  
    var tmpGrid = $("#detailGrid");
    tmpGrid.datagrid(options); //根据配置选项，生成datagrid  
    tmpGrid.datagrid("loadData", data.data[0].rows); //载入本地json格式的数据  

    var p = tmpGrid.datagrid('getPager');
    $(p).pagination({
        total: data.data[0].total,
        pageNumber: data.data[0].page,
        //pageSize: 10, //每页显示的记录条数，默认为10 
        pageList: [20, 10, 30, 50], //可以设置每页记录条数的列表 
        beforePageText: '第', //页数文本框前显示的汉字 
        afterPageText: '页    共 {pages} 页',
        displayMsg: '显示 {from} 到 {to}    共 {total} 条记录',
        onSelectPage: function (pageNumber, pageSize) {
            $(this).pagination('loading');
            $(this).pagination('loaded');
            $('#hid_pageNumber').val(pageNumber);
            $('#hid_pageSize').val(pageSize);
            loadPreviewData(grid.selected().ID);
        },
        onChangePageSize: function (pageSize) {
            $('#hid_pageSize').val(pageSize);
            loadPreviewData(grid.selected().ID);
        }
    });
}  
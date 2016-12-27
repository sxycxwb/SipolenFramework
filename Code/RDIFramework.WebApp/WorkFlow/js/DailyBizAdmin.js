/*
RDIFramework.NET，基于.NET的快速信息化系统开发、整合框架，给岗位和开发者最佳的.Net框架部署方案。

博客：[CSDN]http://blog.csdn.net/chinahuyong	
[CNBLOGS]http://www.cnblogs.com/huyong 

交流QQ：406590790 
邮箱：406590790@qq.com
*************************************************************************************
* RDIFramework.NET框架“日常业务”业务界面逻辑
*
* 当前登录用户的可用流程业务并做相应的处理。
* 修改记录：
*   
*   
*   1. 2014-08-07 XuWangBin V2.8 新增本业务逻辑的编写。
*/

var actionRoleUrl = 'handler/DailyBizAdminHandler.ashx';


$(function () {
    pageSizeControl.init({ gridId: 'taskList', gridType: 'datagrid' });
    myWFBizTree.init();
    autoResize({ dataGrid: '#taskList', gridType: 'datagrid', callback: mygrid.bindGrid, height: 35, width: 230 });
    $('#startTask').attr('onclick', 'DailyBizAdminMethod.StartTask();');//开始任务
    //$('#startTask').click(DailyBizAdminMethod.StartTask); //开始任务
    $(window).resize(function () {
        pageSizeControl.init({ gridId: 'taskList', gridType: 'datagrid' });
    });
});

var myWFBizTree = {
    init: function () {
        $('#myWFBizTree').tree({
            lines: true,
            //url: '../Modules/handler/OrganizeAdminHander.ashx?action=GetOrganizeTree',
            url: actionRoleUrl + '?action=GetAvailableBizClass',
            animate: true,
            onLoadSuccess: function (node, data) {
                $('body').data('depData', data);
            }, onClick: function (node) {
                showProcess(true, '温馨提示', '加载中...');
                $('#taskList').datagrid('load', { classId: node.id });
            }
        });
    }, 
    getSelected: function () {
        return $('#myWFBizTree').tree('getSelected');
    }
};

var navgrid;
var mygrid = {
    bindGrid: function (size) {
        navgrid = $('#taskList').datagrid({
            url: actionRoleUrl + "?action=GetWorkFlowByClassId",
            title: "任务列表",
            //loadMsg: "正在加载业务流程数据，请稍等...",
            iconCls: 'icon16_list',
            width: size.width,
            height: size.height,
            rownumbers: true, 
            striped: true, 
            idfield: 'WFCLASSID', 
            singleSelect: true, 
            checkOnSelect: true,
            onRowContextMenu: pageContextMenu.createDataGridContextMenu,
            frozenColumns: [[
                { title: '流程名称', field: 'FLOWCAPTION', width: 200, sortable: true, styler: function (value, row, index) {
                    return 'background-color:#ffee00;color:green;';} 
                }
            ]], 
            columns: [[
                { title: '工作流ID', field: 'WORKFLOWID', width: 350 },
                { title: '工作任务ID', field: 'WORKTASKID', width: 350 }
            ]],
            onLoadSuccess:function(data) {
                showProcess(false);
            }
        });
    },
    reload:function(){
        navgrid.datagrid('reload');
    },
    getSelectedRow: function () {
        return navgrid.datagrid('getSelected'); 
    }
};

var DailyBizAdminMethod = {
    StartTask: function () { //启动任务
        //if ($(this).linkbutton('options').disabled == true) {
        //    return false;
        //}

        var selectRow = mygrid.getSelectedRow();
        if (selectRow) {
            var workFlowId = selectRow.WORKFLOWID;
            var workTaskId = selectRow.WORKTASKID;
            window.open('StartWorkFlow.aspx?workFlowId=' + workFlowId + '&workTaskId=' + workTaskId, selectRow.FLOWCAPTION.replace(/\-/g, ""), 'fullscreen=1,toolbar=no,menubar=no,scrollbars=yes, resizable=yes,location=no, status=no');
//            var tmpDailog = top.$.hWindow({
//                href: '/WorkFlow/StartWorkFlow.aspx?workFlowId=' + workFlowId + '&workTaskId=' + workTaskId,
//                width: 800,
//                height: 600,
//                maximizable: true,
//                //max:true, //最大化
//                title: '启动流程',
//                iconCls: 'icon16_brick_edit',
//                fit:true,
//                onLoad: function () {
//                   
//                }
//           });
           
        } else {
            msg.warning('请选择待启动的业务流程。');
            return false;
        }
        return false;
    }
};
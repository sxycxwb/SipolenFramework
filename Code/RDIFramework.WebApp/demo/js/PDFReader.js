$(function () {
    pageSizeControl.init({ gridId: 'pdfReader', gridType: 'datagrid' });
    pdfTree.init();
    //autoResize({ dataGrid: '#pdfReader', gridType: 'datagrid', height: 35, width: 230 });  
});

var pdfTree = {
    init: function () {
        $('#pdfTree').tree({
            lines: true,
            //url: '/Modules/handler/OrganizeAdminHander.ashx?action=treedata',
            data: [{
		        text: '本地PDF文件',
		        state: 'open',
		        iconCls: 'icon16_computer',
		        children: [{
		            id: '/Resource/PDF/test.swf',
                    text: '测试PDF文件.pdf',
                    iconCls: 'icon16_file_extension_pdf'
		        },{
		            id: '/Resource/PDF/RDI_FBSM.swf',
		            text: 'RDIFramework.NET-V2.8版本发布说明.pdf',
		            iconCls: 'icon16_file_extension_pdf'
		        }, {
		            id: '/Resource/PDF/test.swf',
		            text: '测试PDF文件3.pdf',
		            iconCls: 'icon16_file_extension_pdf'
		        }, {
		            id: '/Resource/PDF/test.swf',
		            text: '测试PDF文件4.pdf',
		            iconCls: 'icon16_file_extension_pdf'
		        }, {
		            id: '/Resource/PDF/test.swf',
		            text: '测试PDF文件5.pdf',
		            iconCls: 'icon16_file_extension_pdf'
		        }, {
		            id: '/Resource/PDF/test.swf',
		            text: '测试PDF文件6.pdf',
		            iconCls: 'icon16_file_extension_pdf'
		        }]
	        }],
            animate: true,
            onClick: function (node) {
                addTab(node.text, 'PDFViewer.aspx', "icon16_file_extension_pdf", node.id);
            },
            onSelect: function (node) {
                $(this).tree('expand', node.target);
            }
        });
    },
    getCurrentId: function () {
        return $('#pdfTree').tree('getSelected').id;
    }
};

function createFrame(url) {
    var s = '<iframe name="pdfViewerForm" scrolling="no" frameborder="0"  style="width:100%;height:100%;" src="' + url + '" ></iframe>';
    return s;
}

function addTab(subtitle, url, icon,id) {    
    if (!url) {
        url = errorUrl;       
    }
    var tabCount = $('#pdftabs').tabs('tabs').length;
    var hasTab = $('#pdftabs').tabs('exists', subtitle);
    var add = function () {
        if (!hasTab && id) {
            url = url + "?1=1&pdfFileUrl=" + id;
            $('#pdftabs').tabs('add', {
                title: subtitle,
                content: createFrame(url),
                closable: true,
                fit: true,
                icon: icon
            });
        } else {
            $('#pdftabs').tabs('select', subtitle);
        }
    };

    if (tabCount > 5) {
        var msg = '<b>打开页面过多，可能会影响程序程序的展现效率，继续打开？</b>';
        $.messager.confirm("系统提示", msg, function (b) {
            if (b) {
                add();
            } else {
                return false;
            }
        });
    } else {
        add();
    }
    return false;
}
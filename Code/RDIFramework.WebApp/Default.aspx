<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RDIFramework.WebApp._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" />
	    <title><% = RDIFramework.Utilities.SystemInfo.SoftFullName %></title> 
        <link rel="stylesheet" type="text/css" href="Content/Scripts/showloading/showLoading.css" />
        <link rel="stylesheet" type="text/css" href="Content/css/sexybuttons.css" />
        <link rel="stylesheet" type="text/css" href="Content/css/common.css" /> 
        <script type="text/javascript" src="Modules/handler/SysConfigHandler.ashx?action=js"></script>
        <link rel="stylesheet" type="text/css" href="Content/Scripts/easyui/themes/<%=base.Theme %>/easyui.css" />
        <%--<link rel="stylesheet" type="text/css" href="Content/css/icon.css" />--%>
        <link rel="stylesheet" type="text/css" href="Content/css/iconNew16.css" />
        <!--<link rel="stylesheet" type="text/css" href="Content/Scripts/jnotify/jquery.jnotify.css" />-->
        <link rel="stylesheet" type="text/css" href="Content/css/css3btn.css" />    
        
    </head>

    <body class="easyui-layout" style="overflow-y: hidden; "  fit="true"   scroll="no" oncontextmenu="return false" ondragstart="return false" oncopy="document.selection.empty()" onbeforecopy="return false">
        <%-- <body class="easyui-layout" style="overflow-y: hidden; "  fit="true"   scroll="no">--%>
        <div id="loading" style="position: fixed;top: -50%;left: -50%;width: 200%;height: 200%;background: #fff;z-index: 100;overflow: hidden;">
            <img src="Content/images/ajax-loader.gif" style="position: absolute;top: 0;left: 0;right: 0;bottom: 0;margin: auto;"/>
        </div>

        <noscript>
        <div style=" position:absolute; z-index:100000; height:2046px;top:0px;left:0px; width:100%; background:white; text-align:center;">
            <img src="Content/images/noscript.gif" alt='抱歉，请开启脚本支持！' />
        </div>
        </noscript>

        <%=navContent %>
        <div region="south" split="true" style="height: 30px;">
		    <div class="footer">Copyright &copy; RDIFramework.NET V3.0, All Rights Reserved</div>
	    </div>

        <div id="mainPanle" region="center" style="background: #eee; overflow-y:hidden" border="false">
		    <div id="tabs" class="easyui-tabs"  fit="true"></div>   
	    </div>	    

	    <div id="closeMenu" class="easyui-menu" style="width:150px;">
		    <div id="refresh" iconCls="icon16_refresh_all">刷新</div>
		    <div class="menu-sep"></div>
		    <div id="close">关闭</div>
		    <div id="closeall">全部关闭</div>
		    <div id="closeother">除此之外全部关闭</div>
		    <div class="menu-sep"></div>
		    <div id="closeright">关闭右侧窗口</div>
		    <div id="closeleft">关闭左侧窗口</div>
		    <div class="menu-sep"></div>
		    <div id="exit">退出</div>
	    </div>

        <div id="w"></div><div id="i"></div><div id="d"></div>
    
        <!--<div id="notity"></div>-->

        <iframe height="0" width="0" src="UserOnLineState.aspx"></iframe>
        <iframe height="0" width="0" src="MessageCheck.aspx"></iframe>

        <script type="text/javascript" src="Content/Scripts/jquery-1.8.3.min.js"></script>   
        <script type="text/javascript" src="Content/Scripts/easyui/jquery.easyui.min.js"></script> 
        <script type="text/javascript" src="Content/Scripts/easyui/locale/easyui-lang-zh_CN.js"></script>
        <script type="text/javascript" src="Content/Scripts/jQuery.Ajax.js"></script>
        <script type="text/javascript" src="Content/Scripts/easyui/rdi.easyui-extend.js?v=29" ></script>
        <script type="text/javascript" src="Content/Scripts/rdiframework-core.js?v=29" ></script>
	    <script type="text/javascript">
	        var theme = '<%=base.Theme%>';
	        var _menus = <%=menuJSON %>;
	        $(function () {
			    $('#loginOut').click(function () {
				    $.messager.confirm('系统提示', '您确定要退出本次登录吗?', function (r) {
					    if (r) {
						    location.href = '/ajax/loginout.ashx';
					    }
				    });
			    });
                
                /*
                $('#notity').jnotifyInizialize({
                        oneAtTime: true,
                        appendType: 'append'
                    })
                    .css({ 'position': 'absolute',
                         '-top':'2px','left':'50%',
                         'margin':'20px 0px 0px -120px',
                         '-margin':'0px 0px 0px -120px',
                        'width': '240px',
                        'z-index': '9999'
                    });
                */

                $(window).load(function () {
                    $('#loading').fadeOut();
                });

                /*
                var timerSpan = $("#timerSpan"), 
                interval = function () { timerSpan.text(formatDate(new Date(),'yyyy-MM-dd hh:mm:ss')); };
                interval();
                window.setInterval(interval, 1000);
                */
		    });
	    </script>
        <script type="text/javascript" src="Content/Scripts/layer/layer.js"></script>
        <script type="text/javascript" src='Content/Scripts/Business/newlayout.js?&v=29'> </script>
        <script type="text/javascript" src="Content/Scripts/qqmsg/jQuery.qqmsg.js"></script>
        <!--<script type="text/javascript" src="Content/Scripts/jnotify/jquery.jnotify.js"></script>-->
		<script type="text/javascript" src="Content/Scripts/showloading/jquery.showLoading.min.js"></script>
        <script type="text/javascript" src="/Content/Scripts/easyui/jquery.validate.min.js" ></script>
        <script type="text/javascript" src="/Content/Scripts/easyui/jquery.validate.messages_zh.js" ></script>
    </body>    
</html>
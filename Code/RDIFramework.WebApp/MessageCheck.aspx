<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageCheck.aspx.cs" Inherits="RDIFramework.WebApp.MessageCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>弹出消息</title>
        <script language="javascript" src="Content/Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>
    
    
        <script type="text/javascript" src="Content/Scripts/easyui/jquery.easyui.min.js"></script>
        <link rel="stylesheet" type="text/css" href="Content/Scripts/easyui/themes/default/easyui.css"/>
        <link rel="stylesheet" type="text/css" href="Content/Scripts/easyui/themes/icon.css"/>


        <script language="javascript" type="text/javascript">
            /**
            //* 
            **    ================================================================================================== 
            **    类名：ClassMsnMessage 
            **    功能：提供类似MSN消息框 
            **    示例： 
            --------------------------------------------------------------------------------------------------- 

            var MSG = new ClassMsnMessage("aa",200,120,"短消息提示：","您有1封消息","请使用正版！"); 
            MSG.show(); 

            --------------------------------------------------------------------------------------------------- 

            **    ================================================================================================== 
            **/


            /**
            //* 
            *    消息构造 
            */
            function ClassMsnMessage(id, width, height, caption, title, message, target, action) {
                this.id = id;
                this.title = title;
                this.caption = caption;
                this.message = message;
                this.target = target;
                this.action = action;
                this.width = width ? width : 200;
                this.height = height ? height : 120;
                this.timeout = 100;
                this.speed = 20;
                this.step = 1;
                this.right = screen.width - 1;
                this.bottom = screen.height;
                this.left = this.right - this.width;
                this.top = this.bottom - this.height;
                this.timer = 0;
                this.pause = false;
                this.close = false;
                this.autoHide = true;
            }

            /**
            //* 
            *    隐藏消息方法 
            */
            ClassMsnMessage.prototype.hide = function () {
                if (this.onunload()) {

                    var offset = this.height > this.bottom - this.top ? this.height : this.bottom - this.top;
                    var me = this;

                    if (this.timer > 0) {
                        window.clearInterval(me.timer);
                    }

                    var fun = function () {
                        if (me.pause == false || me.close) {
                            var x = me.left;
                            var y = 0;
                            var width = me.width;
                            var height = 0;
                            if (me.offset > 0) {
                                height = me.offset;
                            }

                            y = me.bottom - height;

                            if (y >= me.bottom) {
                                window.clearInterval(me.timer);
                                me.Pop.hide();
                            } else {
                                me.offset = me.offset - me.step;
                            }
                            me.Pop.show(x, y, width, height);
                        }
                    };
                    this.timer = window.setInterval(fun, this.speed);
                }
            };
            /**
            //* 
            *    消息卸载事件，可以重写 
            */
            ClassMsnMessage.prototype.onunload = function () {
                return true;
            };
            /**
            //* 
            *    消息命令事件，要实现自己的连接，请重写它 
            * 
            */
            //ClassMsnMessage.prototype.oncommand = function(){ 
            //    //this.close = true;
            //    this.hide(); 
            //window.open("Default2.aspx","mainFrame");
            //   
            //} 
            /**
            //* 
            *    消息显示方法 
            */
            ClassMsnMessage.prototype.show = function () {

                var oPopup = window.createPopup(); //IE5.5+ 

                this.Pop = oPopup;

                var w = this.width;
                var h = this.height;
                var ddd = "dfdfdfadfa";
                var str = "<DIV style='BORDER-RIGHT: #455690 1px solid; BORDER-TOP: #a6b4cf 1px solid; Z-INDEX: 99999; LEFT: 0px; BORDER-LEFT: #a6b4cf 1px solid; WIDTH: " + w + "px; BORDER-BOTTOM: #455690 1px solid; POSITION: absolute; TOP: 0px; HEIGHT: " + h + "px; BACKGROUND-COLOR: #c9d3f3'>";
                str += "<TABLE style='BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid' cellSpacing=0 cellPadding=0 width='100%' bgColor=#cfdef4 border=0>";
                str += "<TR>";
                str += "<TD style='FONT-SIZE: 12px;COLOR: #0f2c8c' width=30 height=24></TD>";
                str += "<TD style='PADDING-LEFT: 4px; FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #1f336b; PADDING-TOP: 4px' valign=middle width='100%'>" + this.caption + "</TD>";
                str += "<TD style='PADDING-RIGHT: 2px; PADDING-TOP: 2px' valign=middle align=right width=19>";
                str += "<SPAN title=关闭 style='FONT-WEIGHT: bold; FONT-SIZE: 12px; CURSOR: hand; COLOR: red; MARGIN-RIGHT: 4px' id='btSysClose' >×</SPAN></TD>";
                str += "</TR>";
                str += "<TR>";
                str += "<TD style='PADDING-RIGHT: 1px;PADDING-BOTTOM: 1px' colSpan=3 height=" + (h - 28) + ">";
                str += "<DIV style='BORDER-RIGHT: #b9c9ef 1px solid; PADDING-RIGHT: 8px; BORDER-TOP: #728eb8 1px solid; PADDING-LEFT: 8px; FONT-SIZE: 12px; PADDING-BOTTOM: 8px; BORDER-LEFT: #728eb8 1px solid; WIDTH: 100%; COLOR: #1f336b; PADDING-TOP: 8px; BORDER-BOTTOM: #b9c9ef 1px solid; HEIGHT: 100%'>" + this.title + "<BR><BR>";
                str += "<DIV style='WORD-BREAK: break-all' align='left'><A href='javascript:' hidefocus=false id='btCommand'><FONT color=#ff0000>" + this.message + "</FONT></A></DIV>";
                str += "</DIV>";
                str += "</TD>";
                str += "</TR>";
                str += "</TABLE>";
                str += "</DIV>";
                oPopup.document.body.innerHTML = str;


                this.offset = 0;
                var me = this;

                oPopup.document.body.onmouseover = function () { me.pause = true; };
                oPopup.document.body.onmouseout = function () { me.pause = false; };
                var fun = function () {
                    var x = me.left;
                    var y = 0;
                    var width = me.width;
                    var height = me.height;

                    if (me.offset > me.height) {
                        height = me.height;
                    } else {
                        height = me.offset;
                    }

                    y = me.bottom - me.offset;
                    if (y <= me.top) {
                        me.timeout--;
                        if (me.timeout == 0) {
                            window.clearInterval(me.timer);
                            if (me.autoHide) {
                                me.hide();
                            }
                        }
                    } else {
                        me.offset = me.offset + me.step;
                    }
                    me.Pop.show(x, y, width, height);

                };
                this.timer = window.setInterval(fun, this.speed);
                var btClose = oPopup.document.getElementById("btSysClose");

                btClose.onclick = function () {
                    me.close = true;
                    me.hide();
                };
                var btCommand = oPopup.document.getElementById("btCommand");
                btCommand.onclick = function () {
                    me.close = true;
                    me.hide();
                    parent.location.href = location.href = "WorkFlow/UnClaimedTask.aspx";

                };
            };
            /**
            //* 
            ** 设置速度方法 
            **/
            ClassMsnMessage.prototype.speed = function (s) {
                var t = 20;
                try {
                    t = praseInt(s);
                } catch (e) { }
                this.speed = t;
            };
            /**
            //* 
            ** 设置步长方法 
            **/
            ClassMsnMessage.prototype.step = function (s) {
                var t = 1;
                try {
                    t = praseInt(s);
                } catch (e) { }
                this.step = t;
            };
            ClassMsnMessage.prototype.rect = function (left, right, top, bottom) {
                try {
                    this.left = left != null ? left : this.right - this.width;
                    this.right = right != null ? right : this.left + this.width;
                    this.bottom = bottom != null ? (bottom > screen.height ? screen.height : bottom) : screen.height;
                    this.top = top != null ? top : this.bottom - this.height;
                } catch (e) { }
            };
            if (!GetMessageCount) {
                var GetMessageCount = {};
            }

            $(document).ready(
                function () {
                    GetMessageCount.FindMessage();
                }
            );

            GetMessageCount.FindMessage = function () {
                $.ajax({
                    //处理ajax请求
                    url: 'ajax/messageHandler.ashx',
                    data: { functionCode: 'Remind' },
                    cache: false,
                    success: function (response) {
                        var count = response;
                        if (count > 0) {
                            top.$.messager.show({
                                width: 300,
                                height:80,
                                title: '消息提示',
                                msg: '您有' + response + '条未处理任务,请进入未认领任务页面处理',
                                timeout: 5000,
                                showType: 'slide'
                            });
                        
                            //以下方法在IE下可用，晕
    //                        var msg1 = new ClassMsnMessage("aa", 200, 120, "消息提示", "您有" + response + "条未处理任务", "进入未认领任务页面");
    //                        msg1.rect(null, null, null, screen.height - 40);
    //                        msg1.speed = 10;
    //                        msg1.step = 5;
    //                        msg1.show();
                        }
                    },
                    error: function (data) {
                        alert("加载失败");
                    }
                });
                //每隔1分钟递归调用一次，刷新未读短信数目
                window.setTimeout(GetMessageCount.FindMessage, 60000); //核心语句
            };
        </script>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
    
        </div>
        </form>
    </body>
</html>

﻿<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SysConfig.aspx.cs" Inherits="RDIFramework.WebApp.Modules.SysConfig" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"> 
    <style type="text/css">
        #sysconfig h1
        {
            font-size:18px;font-family:'Microsoft YaHei';padding:0px;padding-left:20px; color:#A2A2A2; margin-bottom:5px;
        }
        #sysconfig .c
        {
            margin:5px;border-top:2px solid #1382CE; margin-bottom:15px; padding-top:10px;
        }
        #sysconfig ul
        {
            list-style:none;
        }
        #sysconfig li
        {
            line-height:30px;height:30px;
        }
        #sysconfig li div
        {
            width:140px;float:left; text-align:right;padding-right:10px;
        }
    </style>
    <link href="../Content/css/css3btn.css" rel="stylesheet" />
</asp:Content> 
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">  
   <div id="sysconfig" style="margin:10px;">
    <h1>界面皮肤设置</h1>
    <div class="c">
        <ul>
            <li><div>默认皮肤：</div><input type="text" id="txtTheme" name="theme" /></li>
        </ul>
    </div>
    <h1>导航菜单</h1>
    <div class="c">
        <ul>
            <li><div>展现形式：</div><input type="text" id="txtNavShowType" name="navshowtype"/></li>
        </ul>
    </div>
    <h1>数据表格设置</h1>
    <div class="c">
        <ul>
            <li><div>每页记录数：</div><input type="text" id="txtGridRows" name="gridRows" /></li>
        </ul>
    </div>
</div>

<div style="margin:140px;width:160px; margin-top:40px; font-family:'Microsoft YaHei'">
    <a id="btnok" href="javascript:;" class="buttonHuge button-blue">保存设置</a>
</div>
    <script src="handler/SysConfigHandler.ashx?action=js" type="text/javascript"></script>
    <script src="js/SysConfig.js?v=3.0" type="text/javascript"></script>
</asp:Content>
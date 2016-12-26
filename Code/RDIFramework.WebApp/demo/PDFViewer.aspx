<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PDFViewer.aspx.cs" Inherits="RDIFramework.WebApp.demo.PDFViewer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <script type="text/javascript" src="/Content/Scripts/jquery-1.8.3.min.js"></script>
        <script type="text/javascript" src="/Content/Scripts/FlexPaper/flexpaper_flash.js"></script>
        <script type="text/javascript" src="/Content/Scripts/rdiframework-core.js"></script>
        <script>
            $(function () {
                $("#viewerPlaceHolder").height($(window).height() - 20);
                $("#viewerPlaceHolder").width($(window).width() - 20);
            })
        </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <a id="viewerPlaceHolder" style="width: 1000px; height: 700px; display: block; z-index: 100;"></a>     
                <script type="text/javascript">                    
                    var pdfFileUrl = GetQuery('pdfFileUrl');//escape('/Resource/PDF/测试PDF文件.swf');
                    if(!pdfFileUrl || pdfFileUrl == ''){
                        pdfFileUrl = escape('/Resource/PDF/测试PDF文件.swf');
                    }
                    var fp = new FlexPaperViewer('../Content/Scripts/FlexPaper/FlexPaperViewer', 'viewerPlaceHolder', {
                        config: {                            
                            SwfFile: pdfFileUrl,
                            //Scale: 0.6,
                            Scale: 1,
                            ZoomTransition: 'easeOut',
                            ZoomTime: 0.5,
                            ZoomInterval: 0.2,
                            FitPageOnLoad: false,
                            FitWidthOnLoad: false,
                            PrintEnabled: true,
                            FullScreenAsMaxWindow: false,
                            ProgressiveLoading: false,
                            MinZoomSize: 0.2,
                            MaxZoomSize: 5,
                            SearchMatchAll: false,
                            InitViewMode: 'Portrait',
                            ViewModeToolsVisible: true,
                            ZoomToolsVisible: true,
                            NavToolsVisible: true,
                            CursorToolsVisible: true,
                            SearchToolsVisible: true,
                            localeChain: 'en_US'
                        }
                    });
                </script>
            </div>          
        </form>
    </body>
</html>

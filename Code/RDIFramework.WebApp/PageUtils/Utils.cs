using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using RDIFramework.Utilities;
using RDIFramework.BizLogic;

public partial class Utils
{
    /// <summary>
    /// 上传文件的路径定义
    /// </summary>
    public static string UploadFiles = "UploadFiles";

    /// <summary>
    /// 是否显示提示信息
    /// </summary> 
    public static bool ShowInformation = true;

    /// <summary>
    /// 您确认要保存吗
    /// </summary>
    public static string LangSaveConfirm = " You confirm must preserve? ";

    /// <summary>
    /// 您确认要删除吗
    /// </summary>
    public static string LangDeleteConfirm = " You confirm must delete? ";

    /// <summary>
    /// 请仔细核对数据，确认输入的正确吗？
    /// </summary>
    public static string LangConfirm = " Please careful checkup data! The confirmation input is correct? ";

    /// <summary>
    /// 公司名称
    /// </summary>
    public static string CompanyName = string.Empty;
    /// <summary>
    /// 软件名称
    /// </summary>
    public static string SoftFullName = string.Empty;

    /// <summary>
    /// 版本号
    /// </summary>
    public static string Version = string.Empty;

    /// <summary>
    ///  IE下载地址
    /// </summary>
    public static string IEDownloadUrl = string.Empty;

    /// <summary>
    /// 设计者
    /// </summary>
    public static string Designed = string.Empty;

    /// <summary>
    /// 更新
    /// </summary>
    public static string Update = string.Empty;

    /// <summary>
    /// 默认页面
    /// </summary>
    public static string DefaultPage = @"~/Default.aspx";

    /// <summary>
    /// 内容未找到页面
    /// </summary>
    public static string NotFindPage = @"~/Default.aspx";

    /// <summary>
    /// 用户未登录页面
    /// </summary>
    public static string UserNotLogOn = @"Login.aspx";

    /// <summary>
    /// 访问没有权限被拒绝页面
    /// </summary>
    public static string AccessDenyPage = @"~/Modules/Common/System/AccessDeny.aspx";

    /// <summary>
    /// 当前操作员不是系统管理员页面
    /// </summary>
    public static string UserIsNotAdminPage = @"~/Modules/Common/System/AccessDeny.aspx";

    /// <summary>
    /// 有效显示字符串定义
    /// </summary>
    public static string EnableState = "<font color=\"#CC0000\">√<font>";

    /// <summary>
    /// 无效显示字符串定义
    /// </summary>
    public static string DisableState = "<font color=\"#CC0000\">-<font>";

    /// <summary>
    /// 选择是简易管理模式，是否部门管理权限管理角色管理等页面很复杂？
    /// </summary>
    protected bool SimpleManagerMode = true;

    #region public static void GetConfiguration() 读取一些基本配置信息
    /// <summary>
    /// 读取一些基本配置信息
    /// </summary>
    public static void GetConfiguration()
    {
        // 获取一些显示信息
        Utils.CompanyName = ConfigurationManager.AppSettings["CustomerCompanyName"];
        Utils.SoftFullName = ConfigurationManager.AppSettings["SoftFullName"];
        Utils.Version = ConfigurationManager.AppSettings["Version"];
        Utils.IEDownloadUrl = ConfigurationManager.AppSettings["IEDownloadUrl"];
        Utils.Designed = ConfigurationManager.AppSettings["Designed"];
        Utils.Update = ConfigurationManager.AppSettings["Update"];
    }
    #endregion

    #region private string GetSession(string sessionName) 安全获取Session的值
    /// <summary>
    /// 安全获取Session的值
    /// </summary>
    /// <param name="sessionName">变量名</param>
    /// <returns>字符串</returns>
    private string GetSession(string sessionName)
    {
        string returnValue = string.Empty;
        if (HttpContext.Current.Session != null && HttpContext.Current.Session[sessionName] != null)
        {
            returnValue = HttpContext.Current.Session[sessionName].ToString();
        }
        return returnValue;
    }
    #endregion

    #region protected string CheckCodeImage 登录验证码读取
    /// <summary>
    /// 登录验证码读取
    /// </summary>
    protected string CheckCodeImage
    {
        get
        {
            return this.GetSession("LogOnCheckCode");
        }
        set
        {
            HttpContext.Current.Session["LogOnCheckCode"] = value;
        }
    }
    #endregion

    #region public static UserInfo GetUserInfo() 获取用户信息
    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <returns></returns>
    public static UserInfo GetUserInfo()
    {
        UserInfo userInfo = null;

        if (HttpContext.Current.Session == null) return userInfo;
        if (SessionUtils.GetSession(SessionName) != null)
        {
            userInfo = (UserInfo)SessionUtils.GetSession(SessionName);
        }
        if (userInfo != null) return userInfo;
        // 从 Session 读取 当前操作员信息
        if (HttpContext.Current.Session["UserInfo"] == null)
        {
            userInfo = new UserInfo();
            // 获得IP 地址                   
            //string clientIPAddress = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].ToString();
            string clientIPAddress = RDIFramework.WebCommon.RequestHelper.GetIP();
            userInfo.Id = clientIPAddress;
            userInfo.RealName = clientIPAddress;
            userInfo.UserName = clientIPAddress;
            userInfo.IPAddress = clientIPAddress;
            // 设置操作员类型，防止出现错误，因为不小心变成系统管理员就不好了
            // if (string.IsNullOrEmpty(userInfo.RoleId))
            // {
            //     userInfo.RoleId = DefaultRole.User.ToString();
            // }
        }
        return userInfo;
    }
    #endregion

    #region public DataTable DTPermission 当前操作员的权限数据，一个页面里只读取一次就可以了，不用反复读取权限，可以在 Session 里缓存起来
    /// <summary>
    /// 当前操作员的权限数据，一个页面里只读取一次就可以了，不用反复读取权限，可以在 Session 里缓存起来
    /// </summary>
    public DataTable DTPermission
    {
        get
        {
            return Utils.GetFromSession("DTPermission") as DataTable;
        }
        set
        {
            Utils.AddSession("DTPermission", value);
        }
    }
    #endregion

    #region public static void AddSession(string key, Object myObject) 添加Session
    /// <summary>
    /// 添加Session
    /// </summary>
    /// <param name="key">键值</param>
    /// <param name="myObject">值</param>
    public static void AddSession(string key, Object myObject)
    {
        HttpContext.Current.Session.Add(key, myObject);
    }
    #endregion

    #region public static Object GetFromSession(string key) 获取Session
    /// <summary>
    /// 获取Session
    /// </summary>
    /// <param name="key">键值</param>
    /// <returns></returns>
    public static Object GetFromSession(string key)
    {
        return HttpContext.Current.Session[key];
    }
    #endregion

    //
    // 上传下载文件部分
    //

    #region public static string UpLoadFile(string categoryId, string objectId, System.Web.HttpPostedFile httpPostedFile, ref string loadDirectory, bool deleteFile) 上传文件
    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="categoryId">分类代码</param>
    /// <param name="objectId">实物代码</param>
    /// <param name="httpPostedFile">被上传的文件</param>
    /// <param name="loadDirectory">上传目录</param>
    /// <param name="deleteFile">是否删除原文件夹</param>
    /// <param name="fileName">fileName</param>
    /// <returns>上传的文件位置</returns>
    public static string UpLoadFile(string categoryId, string objectId, System.Web.HttpPostedFile httpPostedFile, ref string loadDirectory, bool deleteFile, string fileName)
    {
        // 服务器上的绝对路径
        string rootPath = HttpContext.Current.Server.MapPath("~/") + Utils.UploadFiles + "\\";
        // 图片重新指定，这里主要是为了起备份的作用，按日期把新的照片备份好就可以了。
        if (loadDirectory.Length == 0)
        {
            // 当前日期
            // string dateTime = DateTime.Now.ToString(BaseSystemInfo.DateFormat).ToString();
            // loadDirectory = categoryId + "\\" + dateTime + "\\" + objectId;
            loadDirectory = categoryId + "\\" + objectId;
        }
        // 需要创建的目录，图片放在这里，为了保存历史纪录，使用了当前日期做为目录
        string makeDirectory = rootPath + loadDirectory;
        if (deleteFile)
        {
            // 删除原文件
            if (Directory.Exists(makeDirectory))
            {
                // Directory.Delete(makeDirectory, true);
            }
        }
        Directory.CreateDirectory(makeDirectory);
        // 获得文件名
        string postedFileName = string.Empty;
        postedFileName = string.IsNullOrEmpty(fileName) ? HttpContext.Current.Server.HtmlEncode(Path.GetFileName(httpPostedFile.FileName)) : fileName;
        // 图片重新指定，虚拟的路径
        // 这里还需要更新学生的最新照片
        string fileUrl = loadDirectory + "\\" + postedFileName;
        // 文件复制到相应的路径下
        string copyToFile = makeDirectory + "\\" + postedFileName;
        httpPostedFile.SaveAs(copyToFile);
        return fileUrl;
    }
    #endregion

    #region public static string UpLoadFile(string categoryId, string objectId, string loadDirectory, bool deleteFile) 上传文件
    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="categoryId">分类代码</param>
    /// <param name="objectId">实物代码</param>
    /// <param name="loadDirectory">上传目录</param>
    /// <param name="deleteFile">是否删除原文件夹</param>
    /// <returns>上传的文件位置</returns>
    public static string UpLoadFile(string categoryId, string objectId, string loadDirectory, bool deleteFile)
    {
        return UpLoadFile(categoryId, objectId, HttpContext.Current.Request.Files[0], ref loadDirectory, deleteFile,string.Empty);
    }
    #endregion

    #region public static string UpLoadFiles(string categoryId, string objectId, string upLoadDirectory) 上传文件
    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="categoryId">分类代码</param>
    /// <param name="objectId">实物代码</param>
    /// <param name="upLoadDirectory">上传的目录</param>
    /// <returns>上传目录</returns>
    public static string UpLoadFiles(string categoryId, string objectId, string upLoadDirectory)
    {
        // 上传文件的复制文件部分
        string upLoadFilePath = string.Empty;
        for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
        {
            if (HttpContext.Current.Request.Files[i].ContentLength > 0)
            {
                // 获取文件名
                string fileName = HttpContext.Current.Server.HtmlEncode(Path.GetFileName(HttpContext.Current.Request.Files[i].FileName));
                upLoadFilePath = UpLoadFile(categoryId, objectId, HttpContext.Current.Request.Files[i], ref upLoadDirectory, false,string.Empty);
            }
        }
        return upLoadFilePath;
    }
    #endregion

    //
    // 表格选择记录功能部分 GridView
    //

    #region public static string[] GetSelecteIds(GridView gridView) 获得已选的表格行代码数组
    /// <summary>
    /// 获得已选的表格行代码数组
    /// </summary>
    /// <param name="gridView">表格</param>
    /// <returns>代码数组</returns>
    public static string[] GetSelecteIds(GridView gridView)
    {
        return GetSelecteIds(gridView, true);
    }
    #endregion

    #region public static string[] GetUnSelecteIds(GridView gridView) 获得未选的表格行代码数组
    /// <summary>
    /// 获得未选的表格行代码数组
    /// </summary>
    /// <param name="gridView">表格</param>
    /// <returns>代码数组</returns>
    public static string[] GetUnSelecteIds(GridView gridView)
    {
        return GetSelecteIds(gridView, false);
    }
    #endregion

    #region public static string[] GetSelecteIds(GridView gridView, bool paramChecked)
    /// <summary>
    /// 获得表格行代码数组
    /// </summary>
    /// <param name="gridView">表格</param>
    /// <param name="paramChecked">选中状态</param>
    /// <returns>代码数组</returns>
    public static string[] GetSelecteIds(GridView gridView, bool paramChecked)
    {
        return GetSelecteIds(gridView, paramChecked, "chkSelected");
    }
    #endregion

    #region public static string[] GetSelecteIds(GridView gridView, bool paramChecked, string paramControl) 获取表格行代码数组
    /// <summary>
    /// 获取表格行代码数组
    /// </summary>
    /// <param name="gridView">表格</param>
    /// <param name="paramChecked">选中状态</param>
    /// <param name="paramControl">控件名称</param>
    /// <returns></returns>
    public static string[] GetSelecteIds(GridView gridView, bool paramChecked, string paramControl)
    {
        return GetSelecteIds(gridView, paramChecked, paramControl, string.Empty);
    }
    #endregion

    #region public static string[] GetSelecteIds(GridView gridView, bool paramChecked, string paramControl, string key)
    /// <summary>
    /// 获得已选的表格行代码数组
    /// </summary>
    /// <param name="gridView">表格</param>
    /// <param name="paramChecked">选中状态</param>
    /// <param name="paramControl">控件名称</param>
    /// <returns>代码数组</returns>
    public static string[] GetSelecteIds(GridView gridView, bool paramChecked, string paramControl, string key)
    {
        string[] ids = new string[0];
        string idList = string.Empty;
        for (int i = 0; i < gridView.Rows.Count; i++)
        {
            // 得到选中的ID
            if (gridView.Rows[i].RowType == DataControlRowType.DataRow)
            {
                TableCell tableCell = gridView.Rows[i].Cells[0];
                CheckBox checkBox = (CheckBox)tableCell.FindControl(paramControl);
                if (checkBox != null)
                {
                    if (checkBox.Checked == paramChecked)
                    {
                        // 把选中的ID保存到字符串
                        string id = string.Empty;
                        if (string.IsNullOrEmpty(key))
                        {
                            id = gridView.DataKeys[gridView.Rows[i].RowIndex].Value.ToString();
                        }
                        else
                        {
                            id = gridView.DataKeys[gridView.Rows[i].RowIndex].Values[key].ToString();
                        }

                        if (id.Length > 0)
                        {
                            idList += id + ",";
                        }
                    }
                }
            }
        }
        // 切分ID
        if (idList.Length > 1)
        {
            idList = idList.Substring(0, idList.Length - 1);
            ids = idList.Split(',');
        }
        return ids;
    }
    #endregion

    //
    // 表格选择记录功能部分 DataGrid
    //

    #region public static string[] GetSelecteIds(DataGrid dataGrid) 获得已选的表格行代码数组
    /// <summary>
    /// 获得已选的表格行代码数组
    /// </summary>
    /// <param name="dataGrid">表格</param>
    /// <returns>代码数组</returns>
    public static string[] GetSelecteIds(DataGrid dataGrid)
    {
        return GetSelecteIds(dataGrid, true);
    }
    #endregion

    #region public static string[] GetUnSelecteIds(DataGrid dataGrid) 获得未选的表格行代码数组
    /// <summary>
    /// 获得未选的表格行代码数组
    /// </summary>
    /// <param name="dataGrid">表格</param>
    /// <returns>代码数组</returns>
    public static string[] GetUnSelecteIds(DataGrid dataGrid)
    {
        return GetSelecteIds(dataGrid, false);
    }
    #endregion

    #region public static string[] GetSelecteIds(DataGrid dataGrid, bool paramChecked)
    /// <summary>
    /// 获得表格行代码数组
    /// </summary>
    /// <param name="dataGrid">表格</param>
    /// <param name="paramChecked">选中状态</param>
    /// <returns>代码数组</returns>
    public static string[] GetSelecteIds(DataGrid dataGrid, bool paramChecked)
    {
        return GetSelecteIds(dataGrid, paramChecked, "chkSelected");
    }
    #endregion

    #region public static string[] GetSelecteIds(DataGrid dataGrid, bool paramChecked, string paramControl)
    /// <summary>
    /// 获得已选的表格行代码数组
    /// </summary>
    /// <param name="gridView">表格</param>
    /// <param name="paramChecked">选中状态</param>
    /// <param name="paramControl">控件名称</param>
    /// <returns>代码数组</returns>
    public static string[] GetSelecteIds(DataGrid dataGrid, bool paramChecked, string paramControl)
    {
        string[] paramIDs = new string[0];
        string IDs = string.Empty;
        for (int i = 0; i < dataGrid.Items.Count; i++)
        {
            // 得到选中的ID
            TableCell myTableCell = dataGrid.Items[i].Cells[0];
            CheckBox myCheckBox = (CheckBox)myTableCell.FindControl(paramControl);
            if (myCheckBox != null)
            {
                if (myCheckBox.Checked == paramChecked)
                {
                    // 把选中的ID保存到字符串
                    string ID = dataGrid.DataKeys[dataGrid.Items[i].ItemIndex].ToString();
                    if (ID.Length > 0)
                    {
                        IDs += ID + ",";
                    }
                }
            }
        }
        // 切分ID
        if (IDs.Length > 1)
        {
            IDs = IDs.Substring(0, IDs.Length - 1);
            paramIDs = IDs.Split(',');
        }
        return paramIDs;
    }
    #endregion

    //
    // 获取图标地址
    //

    #region public static string GetFileIcon(string fileName) 获取图标地址
    /// <summary>
    /// 获取图标地址
    /// </summary>
    /// <param name="fileName">文件名</param>
    /// <returns>图标地址</returns>
    public static string GetFileIcon(string fileName)
    {
        // 这里是默认的图标
        string imageUrl = "Themes/Default/Images/Download.gif";
        // 截取后缀名,GetExtension读出来的后缀带"."的
        string extension = Path.GetExtension(fileName).ToLower().Substring(1);
        // 这里查找是否有指定的图标
        if (File.Exists(HttpContext.Current.Server.MapPath("~/") + "Themes/Default/Images/" + extension + ".png"))
        {
            // 获取图标地址
            imageUrl = "Themes/Default/Images/" + extension + ".png";
        }
        return imageUrl;
    }
    #endregion

    #region public static bool CheckLAN()
    /// <summary>
    /// 当前电脑是否在局域网络里
    /// </summary>
    /// <returns></returns>
    public static bool CheckLAN()
    {
        string ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        return (ipAddress.Substring(0, 3) == "127") || (ipAddress.Substring(0, 3) == "192") || (ipAddress.Substring(0, 3) == "10.");
    }
    #endregion

    #region public static void CloseWindow(bool refreshOpener = null)
    /// <summary>
    /// 关闭窗体
    /// </summary>
    /// <param name="refreshOpener">是否刷新父窗体</param>
    public static void CloseWindow(bool refreshOpener)
    {
        HttpContext.Current.Response.Write("<script language=\"JavaScript\">" + System.Environment.NewLine);
        if (refreshOpener)
        {
            // window.opener != null 这个错误的调用方法
            HttpContext.Current.Response.Write("if(window.opener && !window.opener.closed){" + System.Environment.NewLine);
            HttpContext.Current.Response.Write("window.opener.location.href=window.opener.location.href;" + System.Environment.NewLine);
            HttpContext.Current.Response.Write("}" + System.Environment.NewLine);
        }
        HttpContext.Current.Response.Write("window.opener=null;" + System.Environment.NewLine);
        HttpContext.Current.Response.Write("window.open('','_self');" + System.Environment.NewLine);
        HttpContext.Current.Response.Write("window.close();");
        HttpContext.Current.Response.Write("</script>" + System.Environment.NewLine);
    }
    #endregion

    #region public static string GetItemName(string itemsTableName,string itemValue) 获取选项名称
    /// <summary>
    /// 将选项值转换为名称
    /// </summary>
    /// <param name="itemsTableName"></param>
    /// <param name="itemValue"></param>
    /// <returns></returns>
    public static string GetItemName(string itemsTableName, string itemValue)
    {
        return string.IsNullOrEmpty(itemValue) ? null : new CiItemDetailsManager(itemsTableName).GetProperty(new KeyValuePair<string, object>(CiItemDetailsTable.FieldItemValue, itemValue), CiItemDetailsTable.FieldItemName);
    }

    #endregion

    /// <summary>
    /// 查找 ParentId 字段的值是否在 Id字段 里
    /// </summary>
    /// <param name="dataTable">数据表</param>
    /// <param name="fieldId">主键字段</param>
    /// <param name="fieldParentId">父节点字段</param>
    public static void CheckTreeParentId(DataTable dataTable, string fieldId, string fieldParentId)
    {
        if (dataTable == null)
        {
            return;
        }

        for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
        {
            var dataRow = dataTable.Rows[i];
            string value = BusinessLogic.ConvertToString(dataRow[fieldParentId]);
            if (!string.IsNullOrEmpty(value))
            {
                if (dataTable.Select(fieldId + " = '" + dataRow[fieldParentId].ToString() + "'").Length == 0)
                {
                    dataRow[fieldParentId] = "#";
                }
            }
            else
            {
                dataRow[fieldParentId] = "#";
            }
        }
    }
}
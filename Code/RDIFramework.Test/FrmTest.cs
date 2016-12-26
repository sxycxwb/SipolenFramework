using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace RDIFramework.Test
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;


    public partial class FrmTest : BaseForm
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        //string ConnRdiframework = @"Data Source=YONGHU\SQLINSTANCE;Initial Catalog=RDIFrameworkV2.0;uid=sa;password=qaz";
        //string ConnDAGL = @"Data Source=YONGHU\SQLINSTANCE;Initial Catalog=DAGL;uid=sa;password=qaz";

        private void btnTest_Click(object sender, EventArgs e)
        {
            //RDIFramework.NET.FrmMsg wfDefine = new RDIFramework.NET.FrmMsg();
            //wfDefine.DbLinks = this.DbLinks;
            //wfDefine.ShowDialog();
            FrmProductAdmin productAdmin = new FrmProductAdmin {DbLinks = this.DbLinks};
            productAdmin.ShowDialog();
        }

        private void FrmTest_Shown(object sender, EventArgs e)
        {
            SystemInfo.StartupPath = Application.StartupPath;
            this.GetAllDbLinks();
        }

        //调试修改添加
        private void GetAllDbLinks()
        {
            UserConfigHelper.GetConfig();
            //RDIFramework.Utilities.UserInfo user = new RDIFramework.Utilities.UserInfo();
            this.UserInfo.OpenId = "7d46323d-0091-4bf5-8a13-67fef63a4cd4";
            this.UserInfo.Id = "26F43BC9-AE6D-42D2-BAC9-F4237A949484";
            this.UserInfo.Code = "Administrator";
            this.UserInfo.RealName = "Administrator";
            this.UserInfo.IsAdministrator = true;
            DataTable dtDbLinks = RDIFrameworkService.Instance.DbLinkDefineService.GetDT(this.UserInfo);
            if (dtDbLinks != null && dtDbLinks.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dtDbLinks.Rows)
                {
                    ConnectString connStr = new ConnectString
                    {
                        LinkName = dataRow[CiDbLinkDefineTable.FieldLinkName].ToString()
                    };
                    string dbType = dataRow[CiDbLinkDefineTable.FieldLinkType].ToString();
                    switch (dbType.ToUpper())
                    {
                        case "ACCESS":
                            connStr.DbType = CurrentDbType.Access;
                            break;
                        case "ORACLE":
                            connStr.DbType = CurrentDbType.Oracle;
                            break;
                        case "MYSQL":
                            connStr.DbType = CurrentDbType.MySql;
                            break;
                        case "SQLLITE":
                            connStr.DbType = CurrentDbType.SQLite;
                            break;
                        case "DB2":
                            connStr.DbType = CurrentDbType.DB2;
                            break;
                        default:
                            connStr.DbType = CurrentDbType.SqlServer;
                            break;

                    }
                    connStr.DbLink = dataRow[CiDbLinkDefineTable.FieldLinkData].ToString();
                    DbLinks.Add(connStr);
                }
            }
        }

        /// <summary>
        /// 获取用户的角色名称
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>角色名称列表</returns>
        protected string GetUserRoleNames(string userId)
        {
            string roleName = string.Empty;
            var entityIds = RDIFrameworkService.Instance.UserService.GetUserRoleIds(this.UserInfo, userId);

            foreach (var id in entityIds)
            {
                try
                {
                    roleName += RDIFrameworkService.Instance.RoleService.GetEntity(this.UserInfo, id).RealName + "  ";
                }
                catch (Exception ex)
                {
                    this.Invoke(new MethodInvoker(() => this.rtfLog.AppendText(ex.Message + "\n")));
                    continue;
                }
            }
            this.Invoke(new MethodInvoker(() => this.rtfLog.AppendText("用户主键:" + userId + ";角色列表：" + roleName + "\n")));
            return roleName;
        }

        private void GetUserRoleName()
        {
            UserService service = new UserService();
            var dtUser = service.GetDT(this.UserInfo);
            foreach (DataRow dr in dtUser.Rows)
            {
                try
                {
                    GetUserRoleNames(BusinessLogic.ConvertToString(dr[PiUserTable.FieldId]));
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }

        private void btnTestMethod_Click(object sender, EventArgs e)
        {
            // 控制按钮状态
            this.btnTestMethod.Enabled = false;
            
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    // 并发启动多线程
                    var thread = new Thread(GetUserRoleName);
                    thread.Start();
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Invoke(new MethodInvoker(() => this.rtfLog.AppendText(ex.Message + "\n")));
                    continue;
                }
            }
           
            this.btnTestMethod.Enabled = true;
        }

        private void btnTestDgvSummary_Click(object sender, EventArgs e)
        {
            FrmTestDgvSummary productAdmin = new FrmTestDgvSummary { DbLinks = this.DbLinks };
            productAdmin.ShowDialog();
        }

        private void btnFormBinding_Click(object sender, EventArgs e)
        {
            FrmFormBindingTest testForm = new FrmFormBindingTest { DbLinks = this.DbLinks };
            testForm.ShowDialog();
        }
    }
}

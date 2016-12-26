using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;

namespace RDIFramework.NET
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;


    /// <summary>
    /// FrmMsg
    /// 企业通
    /// 
    /// </summary>
    public partial class FrmMsg : BaseForm
    {
        /// <summary>
        /// 用户表
        /// </summary>
        private DataTable DTUser = new DataTable(PiUserTable.TableName);

        /// <summary>
        /// 业务角色
        /// </summary>
        private DataTable DTRole = new DataTable(PiRoleTable.TableName);

        /// <summary>
        /// 组织机构表
        /// </summary>
        private DataTable DTOrganize = new DataTable(PiOrganizeTable.TableName);

        /// <summary>
        /// 消息检测的线程
        /// </summary>
        private Thread MessageThread = null;

        /// <summary>
        /// 在线检测的线程
        /// </summary>
        private Thread OnLineThread = null;


        public FrmMsg()
        {
            InitializeComponent();
        }

        public delegate bool OnReceiveMessageEventHandler(CiMessageEntity messageEntity);

        // 已打开的窗口列表
        private ArrayList receiveUserList = new ArrayList();
        public ArrayList ReceiveUserList
        {
            get
            {
                return receiveUserList;
            }
            set
            {
                receiveUserList = value;
            }
        }

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加载树</param>
        private void BindData(bool reloadTree)
        {
            // 加载树
            if (reloadTree)
            {
                this.LoadOrganizeTree();
                this.LoadApplicationRole();
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.TopMost = true;
            this.Left = 600;
            //设置控件的角度
            this.Region = new DrawUtil().SetControlRegion(this, 6);
            // 设置按钮状态
            // this.SetControlState();
            // 若是在忙碌状态，退出本程序
            // if (!this.FormLoaded || this.Busyness)
            //{
            //    return;
            //}

            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 设置开关变量
            this.Busyness = true;
            this.FormLoaded = false;

            // 设置窗体的显示位置
            if (this.WindowState == FormWindowState.Normal)
            {
                var rectangle = System.Windows.Forms.SystemInformation.VirtualScreen;
                var width = rectangle.Width;
                var height = rectangle.Height;
                this.Left = width - this.Width;
            }

            try
            {
                var serviceInstance = new RDIFrameworkService();
                this.DTOrganize = serviceInstance.MessageService.GetInnerOrganizeDT(this.UserInfo);
                //this.DTRole = serviceInstance.RoleService.GetDT(this.UserInfo);
                CloseCommunicationObject(serviceInstance.MessageService);
                // 过滤数据
                // BusinessLogic.SetFilter(this.DTOrganize, PiOrganizeTable.FieldEnabled, "1");
                // 只显示内部部门
                // BUBusinessLogic.SetFilter(this.DTOrganize, PiOrganizeTable.FieldIsInnerOrganize, "1");
                // this.DTOrganize.AcceptChanges();
                // 绑定屏幕数据
                this.BindData(true);
                if (this.tvOrganize.Nodes.Count > 0)
                {
                    this.tvOrganize.Nodes[0].Expand();
                }
                // 阅读消息
                // this.timerMessage.Enabled = true;
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }

            if (SystemInfo.UseMessage)
            {
                this.MessageThread = new Thread(new ThreadStart(this.CheckNewMessage));
                MessageThread.Start();
                this.OnLineThread = new Thread(new ThreadStart(this.CheckOnLineState));
                OnLineThread.Start();
            }

            this.FormLoaded = true;
            this.Busyness = false;
        }
        #endregion

        #region private void LoadOrganizeTree() 加载树
        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadOrganizeTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            var treeNode = new TreeNode();
            this.LoadOrganizeTree(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvOrganize.EndUpdate();
        }
        #endregion

        #region private void LoadOrganizeTree(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadOrganizeTree(TreeNode treeNode)
        {
            // 消息组件默认不按权限范围过滤内部用户
            this.LoadTreeNodes(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId, PiOrganizeTable.FieldFullName, this.tvOrganize, treeNode);
        }
        #endregion

        #region private void LoadTreeNodes(DataTable dataTable, string fieldId, string fieldParentId, string fieldFullName, TreeView treeView, TreeNode treeNode, bool loadTree = true)
        /// <summary>
        /// 加载树型结构的主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldId">主键</param>
        /// <param name="fieldParentId">上级字段</param>
        /// <param name="fieldFullName">全称</param>
        /// <param name="treeNode">当前树结点</param>
        private void LoadTreeNodes(DataTable dataTable, string fieldId, string fieldParentId, string fieldFullName, TreeView treeView, TreeNode treeNode, bool loadTree = true)
        {
            var organizeEntity = new PiOrganizeEntity();
            // 查找 ParentId 字段的值是否在 Id字段 里
            // 一般情况是简单的数据过滤，就没必要进行严格的检查了，进行了严格的检查，反而降低运行效率
            DataRow[] dataRows = null;
            if (treeNode.Tag == null)
            {
                if (dataTable.Columns[fieldId].DataType == typeof(int)
                    || (dataTable.Columns[fieldId].DataType == typeof(Int16))
                    || (dataTable.Columns[fieldId].DataType == typeof(Int32))
                    || (dataTable.Columns[fieldId].DataType == typeof(Int64))
                    || dataTable.Columns[fieldId].DataType == typeof(decimal))
                {
                    dataRows = dataTable.Select(fieldParentId + " IS NULL OR " + fieldParentId + " = 0");
                }
                else
                {
                    dataRows = dataTable.Select(fieldParentId + " IS NULL OR " + fieldParentId + " = ''");
                }
            }
            else
            {
                dataRows = dataTable.Select(fieldParentId + "='" + ((PiOrganizeEntity)treeNode.Tag).Id + "'");
            }

            foreach (var dataRow in dataRows)
            {
                // 节点不为空，并且是当前节点的子节点
                if ((treeNode.Tag != null) && !(((PiOrganizeEntity)treeNode.Tag).Id.ToString().Equals(dataRow[fieldParentId].ToString())))
                {
                    continue;
                }
                // 当前节点的子节点, 加载根节点
                if (dataRow.IsNull(fieldParentId)
                    || (dataRow[fieldParentId].ToString() == "0")
                    || (dataRow[fieldParentId].ToString().Length == 0)
                    || ((treeNode.Tag != null) && (((PiOrganizeEntity)treeNode.Tag).Id.ToString().Equals(dataRow[fieldParentId].ToString()))))
                {
                    var newTreeNode = new TreeNode
                    {
                        Text = dataRow[fieldFullName].ToString(),
                        Tag = BaseEntity.Create<PiOrganizeEntity>(dataRow)
                    };
                    if ((treeNode.Tag == null))
                    {
                        // 树的根节点加载
                        treeView.Nodes.Add(newTreeNode);
                    }
                    else
                    {
                        // 节点的子节点加载，第一层节点需要展开                        
                        treeNode.Nodes.Add(newTreeNode);
                    }
                    if (loadTree)
                    {
                        // 递归调用本函数
                        LoadTreeNodes(dataTable, fieldId, fieldParentId, fieldFullName, treeView, newTreeNode, loadTree);
                    }
                }
            }
        }
        #endregion

        #region private void LoadRole() 加载业务角色
        /// <summary>
        /// 加载业务角色
        /// </summary>
        private void LoadApplicationRole()
        {
            var serviceInstance = new RDIFrameworkService();
            this.DTRole = serviceInstance.RoleService.GetDT(this.UserInfo);
            CloseCommunicationObject(serviceInstance.RoleService);
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvRole.BeginUpdate();
            this.tvRole.Nodes.Clear();

            foreach (DataRow dataRow in this.DTRole.Rows)
            {
                PiRoleEntity roleEntity = BaseEntity.Create<PiRoleEntity>(dataRow);
                // 当前节点的子节点, 加载根节点
                var treeNode = new TreeNode {Text = roleEntity.RealName, Tag = roleEntity.Id};
                treeNode.Tag = roleEntity;
                this.tvRole.Nodes.Add(treeNode);
            }
            this.tvRole.EndUpdate();
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.lblCurentUser.Text = UserInfo.RealName;
        }
        #endregion

        // 定义与方法同签名的委托
        private delegate void CallFormOnLoad();

        // 监测新信息
        delegate void SetGetNewMessage();

        #region private void CheckNewMessage() 检查新消息
        /// <summary>
        /// 检查新消息
        /// </summary>
        private void CheckNewMessage()
        {
            while (!this.ExitApplication)
            {
                if (this.FormLoaded && (!this.Busyness))
                {
                    this.GetNewMessage();
                    Thread.Sleep(4 * 1000 + RandomHelper.GetRandom(100, 1000));
                }
                Thread.Sleep(1000 + RandomHelper.GetRandom(100, 1000));
            }
        }
       
        /// <summary>
        /// 得到新消息
        /// </summary>
        private void GetNewMessage()
        {
            if (this.ExitApplication) return;
            if (!this.FormLoaded || (this.Busyness)) return;

            if (this.tvOrganize.InvokeRequired)
            {
                if (this.ExitApplication) return;
                SetGetNewMessage getNewMessage = this.GetNewMessage;
                this.Invoke(getNewMessage);
            }
            else
            {
                try
                {
                    // 获取最新即时通讯消息
                    var serviceInstance = new RDIFrameworkService();
                    //  这里获取用户的登录凭证，看与本地的是否一致？
                    var openId = string.Empty;
                    var dataTable = serviceInstance.MessageService.GetDTNew(this.UserInfo, out openId);
                    if ((dataTable != null) && (dataTable.Rows.Count > 0))
                    {
                        var messageEntity = new CiMessageEntity();
                        for (var i = 0; i < dataTable.Rows.Count; i++)
                        {
                            messageEntity.GetFrom(dataTable.Rows[i]);
                            if (messageEntity.FunctionCode.Equals("UserMessage"))
                            {
                                this.ShowMessage(messageEntity);
                            }
                            else
                            {
                                this.ShowRemind(messageEntity);
                            }
                            //TODO:系统推送的...

                            // 将信息标记为已阅读
                            serviceInstance.MessageService.Read(UserInfo, messageEntity.Id);
                        }
                        if (serviceInstance.MessageService is ICommunicationObject)
                        {
                            ((ICommunicationObject)serviceInstance.MessageService).Close();
                        }
                    }
                    // 若检查在线状态，根本就无法登录了，所以加上这样的判断
                    if (SystemInfo.CheckOnLine && !UserInfo.OpenId.Equals(openId))
                    {
                        if (AppStart.frmMsg != null)
                        {
                            AppStart.frmMsg.ExitApplication = true;
                            AppStart.frmMsg.AbortThread();
                            AppStart.frmMsg.Close();
                            AppStart.frmMsg.Dispose();
                        }
                        // 修改当前用户的登录状态
                        SystemInfo.LogOned = false;
                        if (MessageBox.Show(RDIFrameworkMessage.MSG0300, RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.OK)
                        {
                            Application.Exit();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    // 在本地记录异常
                    FileHelper.WriteException(UserInfo, ex);
                }
            }
        }
        #endregion

        private void CheckOnLineState()
        {
            while (!this.ExitApplication)
            {
                if (this.FormLoaded && (!this.Busyness))
                {
                    // 若已经是最小化、或者被隐藏起来了，就不用获取在线状态，可以提高效率
                    if (this.WindowState != FormWindowState.Minimized || this.Visible)
                    {
                        this.GetOnLineState();
                        Thread.Sleep(10 * 1000 + RandomHelper.GetRandom(100, 20000));
                    }
                }
                //当在线人数过多时会影响性能
                Thread.Sleep(10 * 1000 + RandomHelper.GetRandom(100, 20000));
            }
        }

        #region private bool UserLoaded(TreeNode treeNode) 是否已经加载了用户
        /// <summary>
        /// 是否已经加载了用户
        /// </summary>
        /// <param name="treeNode">目标节点</param>
        /// <returns>是否</returns>
        private bool UserLoaded(TreeNode treeNode)
        {
            var returnValue = false;
            for (var i = 0; i < treeNode.Nodes.Count; i++)
            {
                if (treeNode.Nodes[i].ImageIndex >= 2)
                {
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region private void GetUserList(TreeNode selectedNode) 获得表格里的用户
        /// <summary>
        /// 获得表格里的用户
        /// </summary>
        private void GetUserList(TreeNode selectedNode)
        {
            // 当前是空节点
            if (selectedNode == null)
            {
                return;
            }
            // 当前节点是用户节点
            if (selectedNode.StateImageIndex >= 2)
            {
                return;
            }
            // 是否已经加了用户节点
            if (selectedNode.Nodes.Count != 0)
            {
                // return;
            }
            // 检查是否已经加载了用户
            if (this.UserLoaded(selectedNode))
            {
                selectedNode.Nodes.Clear();
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var id = string.Empty;
                if (selectedNode.Tag is PiOrganizeEntity)
                {
                    id = ((PiOrganizeEntity)selectedNode.Tag).Id.ToString();
                }
                else if (selectedNode.Tag is PiRoleEntity)
                {
                    id = ((PiRoleEntity) selectedNode.Tag).Id.ToString();
                }
                else
                {
                    id = selectedNode.Tag.ToString();
                }

                var serviceInstance = new RDIFrameworkService();
                this.DTUser = this.tcMsg.SelectedTab == this.tpOrganize
                    ? serviceInstance.MessageService.GetUserDTByOrganize(UserInfo, id)
                    : serviceInstance.MessageService.GetUserDTByRole(UserInfo, id);
                CloseCommunicationObject(serviceInstance.MessageService);
                if (this.DTUser == null || this.DTUser.Rows.Count <= 0) return;

                var tmpCurNodeText = selectedNode.Text;
                selectedNode.Text = @"加载中...";
                Application.DoEvents();
                foreach (DataRow dataRow in this.DTUser.Rows)
                {
                    if (!String.IsNullOrEmpty(dataRow[PiUserTable.FieldId].ToString()))
                    {
                        var treeNode = new TreeNode
                        {
                            Tag = BaseEntity.Create<PiUserEntity>(dataRow),
                            Text = dataRow[PiUserTable.FieldRealName].ToString()
                        };
                        this.SetTreeNodeState(treeNode, dataRow[PiUserLogOnTable.FieldUserOnLine].ToString());
                        selectedNode.Nodes.Add(treeNode);
                    }
                }
                selectedNode.Text = tmpCurNodeText;
                Application.DoEvents();
                selectedNode.Expand();
            }
            catch (System.Exception ex)
            {
                this.WriteException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        private void tvTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                var treeView = (TreeView)sender;
                if (treeView.SelectedNode == null || treeView.SelectedNode.Tag == null) return;
                // 当前节点是用户节点
                if ((treeView.SelectedNode.SelectedImageIndex <= 1) && !this.UserLoaded(treeView.SelectedNode))
                {
                    this.GetUserList(treeView.SelectedNode);
                }
            }
        }

        FrmMsgRemind frmMsgRemind = null;

        public void ShowRemind(CiMessageEntity messageEntity)
        {
            if (this.frmMsgRemind == null || !this.frmMsgRemind.Visible)
            {
                this.frmMsgRemind = new FrmMsgRemind();
                frmMsgRemind.Show(this);
            }
            this.frmMsgRemind.OnReceiveMessage(messageEntity);
        }
        
        public FrmUserMsgRead ShowMessageRead(string receiverId, IWin32Window owner, FormStartPosition formStartPosition)
        {
            FrmUserMsgRead frmMsgRead = null;
            if (!string.IsNullOrEmpty(receiverId))
            {
                foreach (var curForm in this.OwnedForms)
                {
                    if (!(curForm is FrmUserMsgRead)) continue;

                    if (((FrmUserMsgRead) curForm).ReceiverId.Equals(receiverId))
                    {
                        frmMsgRead = (FrmUserMsgRead) curForm;
                        frmMsgRead.FrmMsgOwner = this;
                        frmMsgRead.Activate();
                        break;
                    }
                }

                if (frmMsgRead == null)
                {
                    frmMsgRead = new FrmUserMsgRead(receiverId)
                    {
                        FrmMsgOwner = this,
                        Owner = this,
                        StartPosition = formStartPosition
                    };
                    frmMsgRead.Show();
                }
            }

            return frmMsgRead;
        }

        public FrmGroupMsgRead ShowGroupMessageRead(string receiverId, string organizeId, string roleId, IWin32Window owner, FormStartPosition formStartPosition)
        {
            // 若窗口还没打开，就需要打开相应的窗口
            FrmGroupMsgRead frmGroupMsgRead = null;
            if (!string.IsNullOrEmpty(receiverId) || !string.IsNullOrEmpty(organizeId) || !string.IsNullOrEmpty(roleId))
            {
                for (var i = 0; i < this.OwnedForms.Length; i++)
                {
                    if (!(this.OwnedForms[i] is FrmGroupMsgRead)) continue;
                    if (!string.IsNullOrEmpty(organizeId) || !string.IsNullOrEmpty(roleId))
                    {
                        if (((FrmGroupMsgRead)this.OwnedForms[i]).OrganizeId.Equals(organizeId)
                            || ((FrmGroupMsgRead)this.OwnedForms[i]).RoleId.Equals(roleId))
                        {
                            frmGroupMsgRead = (FrmGroupMsgRead)this.OwnedForms[i];
                            frmGroupMsgRead.FrmMsgOwner = this;
                            frmGroupMsgRead.Activate();
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(organizeId) && frmGroupMsgRead == null)
                {
                    frmGroupMsgRead = new FrmGroupMsgRead(string.Empty, organizeId, string.Empty)
                    {
                        FrmMsgOwner = this,
                        Owner = this,
                        StartPosition = formStartPosition
                    };
                    frmGroupMsgRead.Show();
                }
                if (!string.IsNullOrEmpty(roleId) && frmGroupMsgRead == null)
                {
                    frmGroupMsgRead = new FrmGroupMsgRead(string.Empty, string.Empty, roleId)
                    {
                        FrmMsgOwner = this,
                        Owner = this,
                        StartPosition = formStartPosition
                    };
                    frmGroupMsgRead.Show();
                }
            }
            return frmGroupMsgRead;
        }

        public FrmUserMsgRead ShowMessageRead(string receiverId, IWin32Window owner)
        {
            return this.ShowMessageRead(receiverId, owner, FormStartPosition.WindowsDefaultLocation);
        }

        public FrmUserMsgRead ShowMessageRead(string receiverId)
        {
            return this.ShowMessageRead(receiverId, this);
        }

        public void ShowMessage(CiMessageEntity messageEntity)
        {
            if (messageEntity.FunctionCode.Equals(MessageFunction.UserMessage.ToString()) )
            {
                if (!string.IsNullOrEmpty(messageEntity.CreateUserId))
                {
                    // 检查窗体，是否已经打开了窗体
                    var frmMessageRead = this.ShowMessageRead(messageEntity.CreateUserId, this);
                    if (frmMessageRead != null)
                    {
                        frmMessageRead.OnReceiveMessage(messageEntity);
                    }
                }
            }
            else if (messageEntity.FunctionCode.Equals(MessageFunction.OrganizeMessage.ToString())
                || messageEntity.FunctionCode.Equals(MessageFunction.RoleMessage.ToString()))
            {
                var organizeId = string.Empty;
                if (messageEntity.FunctionCode.Equals(MessageFunction.OrganizeMessage.ToString()))
                {
                    organizeId = messageEntity.ObjectId;
                }
                var roleId = string.Empty;
                if (messageEntity.FunctionCode.Equals(MessageFunction.RoleMessage.ToString()))
                {
                    roleId = messageEntity.ObjectId;
                }
                // 检查窗体，是否已经打开了窗体
                var frmGroupMsgRead = this.ShowGroupMessageRead(string.Empty, organizeId, roleId, this, FormStartPosition.WindowsDefaultLocation);
                if (frmGroupMsgRead != null)
                {
                    frmGroupMsgRead.OnReceiveMessage(messageEntity);
                }
            }
        }

        private void tvTree_DoubleClick(object sender, EventArgs e)
        {
            var treeView = (TreeView)sender;
            if (treeView.SelectedNode == null || treeView.SelectedNode.Tag == null) return;
            // 当前节点是用户节点
            if (treeView.SelectedNode.SelectedImageIndex > 1)
            {
                // 不允许自己跟自己通讯
                if (!UserInfo.Id.Equals(((PiUserEntity) treeView.SelectedNode.Tag).Id.ToString()))
                {
                    this.ShowMessageRead(((PiUserEntity) treeView.SelectedNode.Tag).Id.ToString(), this,FormStartPosition.CenterScreen);
                }
            }
        }

        private void tvTree_Click(object sender, EventArgs e)
        {
            var treeView = (TreeView)sender;
            if ((treeView.SelectedNode != null) && (treeView.SelectedNode.Tag != null) && (treeView.SelectedNode.SelectedImageIndex > 1))
            {
                // 当前节点是用户节点
                treeView.ContextMenuStrip = this.cMnuUser;
            }
            else
            {
                treeView.ContextMenuStrip = null;
            }
        }

        #region private void MoveUserTo(string userId, TreeNode targetTreeNode) 移动选择的用户
        /// <summary>
        /// 移动选择的用户
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="targetTreeNode">目录节点</param>
        private void MoveUserTo(string userId, TreeNode targetTreeNode)
        {
            // 目标机构信息
            string companyId = null;
            var companyName = string.Empty;
            string departmentId = null;
            var departmentName = string.Empty;
            string workgroupId = null;
            var workgroupName = string.Empty;
            
            var userEntity = RDIFrameworkService.Instance.UserService.GetEntity(this.UserInfo, userId);
            var staffId = RDIFrameworkService.Instance.StaffService.GetId(this.UserInfo, PiStaffTable.FieldUserId, userEntity.Id);
            PiStaffEntity staffEntity = null;
            if (!string.IsNullOrEmpty(staffId))
            {
                staffEntity = RDIFrameworkService.Instance.StaffService.GetEntity(this.UserInfo, staffId);
            }
            // 获得目标节点公司信息,其实只要从当前节点一直往上遍历就可以了，直接被拖到公司的，部门、工作自然就null了
            while (targetTreeNode != null)
            {
                var targetOrganizeCategory = ((PiOrganizeEntity)targetTreeNode.Tag).Category;
                if (!string.IsNullOrEmpty(targetOrganizeCategory))
                {
                    if (targetOrganizeCategory == "WorkGroup")
                    {
                        workgroupId = ((PiOrganizeEntity)targetTreeNode.Tag).Id.ToString();
                        workgroupName = ((PiOrganizeEntity)targetTreeNode.Tag).FullName;
                    }

                    if ((targetOrganizeCategory == "Department" || targetOrganizeCategory == "SubDepartment") && string.IsNullOrEmpty(departmentName))
                    {
                        departmentId = ((PiOrganizeEntity)targetTreeNode.Tag).Id.ToString();
                        departmentName = ((PiOrganizeEntity)targetTreeNode.Tag).FullName;
                    }

                    if ((targetOrganizeCategory == "Company" || targetOrganizeCategory == "SubCompany") && string.IsNullOrEmpty(companyName))
                    {
                        companyId = ((PiOrganizeEntity)targetTreeNode.Tag).Id;
                        companyName = ((PiOrganizeEntity)targetTreeNode.Tag).FullName;
                        break;
                    }
                }
                targetTreeNode = targetTreeNode.Parent;
            }

            userEntity.CompanyId = companyId;
            userEntity.CompanyName = companyName;
            userEntity.DepartmentId = departmentId;
            userEntity.DepartmentName = departmentName;
            userEntity.WorkgroupId = workgroupId;
            userEntity.WorkgroupName = workgroupName;

            var statusCode = string.Empty;
            var statusMessage = string.Empty;
            RDIFrameworkService.Instance.UserService.UpdateUser(this.UserInfo, userEntity, out statusCode, out statusMessage);
            if (staffEntity != null)
            {
                var organizeId = string.Empty;
                if (!string.IsNullOrEmpty(companyId))
                {
                    organizeId = companyId;
                }
                if (!string.IsNullOrEmpty(departmentId))
                {
                    organizeId = departmentId;
                }
                if (!string.IsNullOrEmpty(workgroupId))
                {
                    organizeId = workgroupId;
                }

                if(!string.IsNullOrEmpty(organizeId))
                {
                    RDIFrameworkService.Instance.StaffService.MoveTo(this.UserInfo, staffEntity.Id.ToString(), organizeId);
                }
            }
        }

        private void tvOrganize_DragDrop(object sender, DragEventArgs e)
        {
            if (this.UserInfo.IsAdministrator != true) return;

            // 定义一个中间变量
            TreeNode treeNode;
            // 判断拖动的是否为TreeNode类型，不是的话不予处理
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                // 定义一个位置点的变量，保存当前光标所处的坐标点
                Point point;
                // 拖放的目标节点
                TreeNode targetTreeNode;
                // 获取当前光标所处的坐标
                point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                // 根据坐标点取得处于坐标点位置的节点
                targetTreeNode = ((TreeView)sender).GetNodeAt(point);
                // 是公司节点或部门节点时才可以使用。
                if ((targetTreeNode.SelectedImageIndex <= 1) && (targetTreeNode.Parent != null))
                {
                    // 获取被拖动的节点
                    treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                    // 判断拖动的节点与目标节点是否是同一个,同一个不予处理
                    if (BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                    {
                        if (SystemInfo.ShowInformation)
                        {
                            // 是否移动模块
                            if (MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0038, treeNode.Text, targetTreeNode.Text), RDIFrameworkMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        this.MoveUserTo(((PiUserEntity)treeNode.Tag).Id.ToString(), targetTreeNode);
                        // 往目标节点中加入被拖动节点的一份克隆
                        this.tvOrganize.SelectedNode = targetTreeNode;
                        //刷新拖入的节点用户
                        if (targetTreeNode != null)
                        {
                            if (targetTreeNode.Tag != null)
                            {
                                // 当前节点是用户节点
                                if (targetTreeNode.SelectedImageIndex <= 1)
                                {
                                    this.GetUserList(targetTreeNode);
                                }
                            }
                        }
                        // 将被拖动的节点移除
                        treeNode.Remove();
                    }
                }
            }
        }

        private void tvOrganize_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvOrganize_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // 开始进行拖放操作，并将拖放的效果设置成移动,只有用户节点可以拖动,只有管理员可以操作。
            if ((this.tvOrganize.SelectedNode.SelectedImageIndex > 1) && this.UserInfo.IsAdministrator)
                this.DoDragDrop(e.Item, DragDropEffects.Move);
        }
        #endregion

        private void SetTreeNodeState(TreeNode treeNode, string onLineState)
        {
            var imageIndex = 2; // 默认为离线状态

            if (!string.IsNullOrEmpty(onLineState))
            {
                var onLine = int.Parse(onLineState);
                if (onLine > 0)
                {
                    imageIndex = 2 + onLine;
                }
            }

            treeNode.ImageIndex = imageIndex;
            treeNode.SelectedImageIndex = imageIndex;
        }

        private void SetTreeViewOnLineState(DataTable dataTable, TreeView treeView)
        {
            TreeNode treeNode = null;
            for (var i = 0; i < treeView.Nodes.Count; i++)
            {
                treeNode = treeView.Nodes[i];
                var state = "0";
                while (treeNode != null)
                {
                    if (treeNode.ImageIndex > 1)
                    {
                        state = "0";
                        var dataRow = dataTable.Select(PiUserTable.FieldId + "='" + ((PiUserEntity)treeNode.Tag).Id.ToString() + "'");
                        for (var j = 0; j < dataRow.Length; j++)
                        {
                            if (dataRow[j][PiUserTable.FieldId].ToString() == ((PiUserEntity)treeNode.Tag).Id.ToString())
                            {
                                state = dataRow[j][PiUserLogOnTable.FieldUserOnLine].ToString();
                                break;
                            }
                        }
                        this.SetTreeNodeState(treeNode, state);
                    }
                    if (!this.ExitApplication)
                    {
                        treeNode = treeNode.NextVisibleNode;
                    }
                }
            }
        }

        // 在线状态检查
        delegate void SetGetOnLineState();

        private void GetOnLineState()
        {
            if (!this.Visible) return;
           
            if (!this.FormLoaded || (this.Busyness)) return;

            if (this.tvOrganize.InvokeRequired)
            {
                SetGetOnLineState onLineState = this.GetOnLineState;
                this.Invoke(onLineState);
            }
            else
            {
                try
                {
                    var serviceInstance = new RDIFrameworkService();
                    var dataTable = serviceInstance.MessageService.GetOnLineState(this.UserInfo);
                    CloseCommunicationObject(serviceInstance.MessageService);
                    if (this.tcMsg.SelectedTab == this.tpOrganize)
                    {
                        this.SetTreeViewOnLineState(dataTable, this.tvOrganize);
                    }
                    if (this.tcMsg.SelectedTab == this.tpRole)
                    {
                        this.SetTreeViewOnLineState(dataTable, this.tvRole);
                    }
                }
                catch (System.Exception ex)
                {
                    // 在本地记录异常
                    FileHelper.WriteException(UserInfo, ex);
                }
            }
        }

        private void bwGetNewMessage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Busyness = true;
            this.GetNewMessage();
            this.Busyness = false;
        }

        private void bwGetOnLineState_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Busyness = true;
            this.GetOnLineState();
            this.Busyness = false;
        }

        /// <summary>
        /// 强制终止多线程
        /// </summary>
        public void AbortThread()
        {
            if (this.MessageThread != null)
            {
                this.MessageThread.Abort();
            }
            if (this.OnLineThread != null)
            {
                this.OnLineThread.Abort();
            }
        }

        private void FrmMsg_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowAPI.ShowWindow(this.Handle, 1);
            if (this.ExitApplication)
            {
                this.AbortThread();
            }
            else
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.ExitApplication)
            {
                this.AbortThread();
            }
            else
            {
                this.Hide();
            }
        }

        //
        // 快捷菜单部分
        //
        private TreeView GetSelectedTreeView()
        {
            TreeView treeView = null;
            if (this.tcMsg.SelectedTab == this.tpOrganize)
            {
                treeView = this.tvOrganize;
            }
            if (this.tcMsg.SelectedTab == this.tpRole)
            {
                treeView = this.tvRole;
            }
            return treeView;
        }

        private void tvTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            var treeView = this.GetSelectedTreeView();
            if (treeView.GetNodeAt(e.X, e.Y) != null)
            {
                treeView.SelectedNode = treeView.GetNodeAt(e.X, e.Y);
            }
        }

        private void FrmMsg_Activated(object sender, EventArgs e)
        {
            this.lblCurentUser.Text = UserInfo.RealName;
        }

        private void FrmMsg_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.Green), 0, 0, this.Width - 1, this.Height - 1);
        }

        private void FrmMsg_MouseDown(object sender, MouseEventArgs e)
        {
            WindowAPI.MouseMoveWindow(this.Handle);
        }
       
        private void timerFrmMsg_Tick(object sender, EventArgs e)
        {
            //如果鼠标在窗体上，则根据停靠位置显示整个窗体
            if (this.Bounds.Contains(Cursor.Position))
            {
                switch (this.Anchor)
                {
                    case AnchorStyles.Top:
                        this.Location = new Point(this.Location.X, 0);
                        break;
                    case AnchorStyles.Bottom:
                        this.Location = new Point(this.Location.X, Screen.PrimaryScreen.Bounds.Height - this.Height);
                        break;
                    case AnchorStyles.Left:
                        this.Location = new Point(0, this.Location.Y);
                        break;
                    case AnchorStyles.Right:
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.Location.Y);
                        break;
                }
            }
            else  //如果鼠标离开窗体，则根据停靠位置隐藏窗体，但须留出部分窗体边缘以便鼠标选中窗体
            {
                switch (this.Anchor)
                {
                    case AnchorStyles.Top:
                        this.Location = new Point(this.Location.X, (this.Height - 3) * (-1));
                        break;
                    case AnchorStyles.Bottom:
                        this.Location = new Point(this.Location.X, Screen.PrimaryScreen.Bounds.Height - 5);
                        break;
                    case AnchorStyles.Left:
                        this.Location = new Point((-1) * (this.Width - 3), this.Location.Y);
                        break;
                    case AnchorStyles.Right:
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 2, this.Location.Y);
                        break;
                }
            }
        }

        private void FrmMsg_LocationChanged(object sender, EventArgs e)
        {
            if (this.Top <= 0)
            {
                this.Anchor = AnchorStyles.Top;
            }
            else if (this.Bottom >= Screen.PrimaryScreen.Bounds.Height)
            {
                this.Anchor = AnchorStyles.Bottom;
            }
            else if (this.Left <= 0)
            {
                this.Anchor = AnchorStyles.Left;
            }
            else if (this.Left >= Screen.PrimaryScreen.Bounds.Width - this.Width)
            {
                this.Anchor = AnchorStyles.Right;
            }
            else
            {
                this.Anchor = AnchorStyles.None;
            }
        }
    }
}

//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , XuWangBin. 
//-----------------------------------------------------------------

using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using RDIFramework.Controls;

namespace RDIFramework.WinForm.Utilities
{
    using RDIFramework.Utilities;

	/// <summary>
    ///	BasePageLogic
	/// 通用页面控制类
	/// 
	/// 修改纪录
	///     
	///	
	/// 版本：2.9
	///
	/// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2010.02.03</date>
	/// </author> 
	/// </summary>
    public partial class BasePageLogic
    {
        #region public static int SetLanguageResource(Form targetForm) 设置页面控件上的多语言信息
        public static int SetLanguageResource(UserControl userControl)
        {
            int returnValue = 0;
            string key = string.Empty;
            string language = string.Empty;
            FieldInfo[] fieldInfo = userControl.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                if ((fieldInfo[i].FieldType.Name.Equals("Label")) || (fieldInfo[i].FieldType.Name.Equals("CheckBox")) || (fieldInfo[i].FieldType.Name.Equals("Button")) || (fieldInfo[i].FieldType.Name.Equals("GroupBox")) || (fieldInfo[i].FieldType.Name.Equals("RadioButton")))
                {
                    var control = (Control)fieldInfo[i].GetValue(userControl);
                    // 窗体上的控件多语言处理
                    key = userControl.GetType().Name + "_" + control.Name;
                    language = ResourceManagerWrapper.Instance.Get(key);
                    if (language.Length > 0)
                    {
                        control.Text = language;
                        returnValue++;
                    }
                }
                // 对表格的列名多语言处理
                if (fieldInfo[i].FieldType.Name.Equals("DataGridView"))
                {
                    var targetDataGridView = (DataGridView)fieldInfo[i].GetValue(userControl);
                    for (int j = 0; j < targetDataGridView.ColumnCount; j++)
                    {
                        key = userControl.Name + "_" + targetDataGridView.Columns[j].Name;
                        language = ResourceManagerWrapper.Instance.Get(key);
                        if (language.Length > 0)
                        {
                            targetDataGridView.Columns[j].HeaderText = language;
                            returnValue++;
                        }
                    }
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 设置页面控件上的多语言信息
        /// </summary>
        /// <param name="targetForm">目标页面</param>
        /// <returns>设置多语言的控件个数</returns>
        public static int SetLanguageResource(Form targetForm)
        {
            int returnValue = 0;
            string key = string.Empty;
            string language = string.Empty;

            // 窗体的名字
            key = targetForm.Name;
            language = ResourceManagerWrapper.Instance.Get(key);
            if (!string.IsNullOrEmpty(language))
            {
                targetForm.Text = language;
            }
            //控件ContextMenuStrip不在controls集合里，所以必须用反射取得；
            System.Reflection.FieldInfo[] fieldInfo = targetForm.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                if (fieldInfo[i].FieldType.Name.Equals("UcOrganizeSelect") 
                    || fieldInfo[i].FieldType.Name.Equals("UcUserSelect") 
                    || fieldInfo[i].FieldType.Name.Equals("UcPagerEx")
                    || fieldInfo[i].FieldType.Name.Equals("UCStartPage")
                    )
                {
                    UserControl userControl = (UserControl)fieldInfo[i].GetValue(targetForm);
                    returnValue += SetLanguageResource(userControl);
                }
                
                if (fieldInfo[i].FieldType.Name.Equals("ToolStripMenuItem") 
                    || fieldInfo[i].FieldType.Name.Equals("ToolStripButton")
                    || fieldInfo[i].FieldType.Name.Equals("ToolStripDropDownButton")
                    || fieldInfo[i].FieldType.Name.Equals("ToolStripLabel"))
                {
                    ToolStripItem toolStripMenuItem = (ToolStripItem)fieldInfo[i].GetValue(targetForm);
                    key = targetForm.Name + "_" + toolStripMenuItem.Name;
                    language = ResourceManagerWrapper.Instance.Get(key);
                    if (!string.IsNullOrEmpty(language))
                    {
                        toolStripMenuItem.Text = language;
                        toolStripMenuItem.ToolTipText = Regex.Replace(language,@"\([^\)]+\)","",RegexOptions.IgnoreCase);
                        returnValue++;
                    }
                }
                if (fieldInfo[i].FieldType.Name.Equals("NotifyIcon"))
                {
                    NotifyIcon notifyIcon = (NotifyIcon)fieldInfo[i].GetValue(targetForm);
                    key = targetForm.Name + "_notifyIcon";
                    language = ResourceManagerWrapper.Instance.Get(key);
                    if (!string.IsNullOrEmpty(language))
                    {
                        notifyIcon.BalloonTipText = language;
                        notifyIcon.BalloonTipTitle = language;
                        notifyIcon.Text = language;
                        returnValue++;
                    }
                }
                if ((fieldInfo[i].FieldType.Name.Equals("Label")) || (fieldInfo[i].FieldType.Name.Equals("LinkLabel")) 
                    || (fieldInfo[i].FieldType.Name.Equals("CheckBox"))
                    || (fieldInfo[i].FieldType.Name.Equals("Button")) || (fieldInfo[i].FieldType.Name.Equals("GroupBox"))
                    || (fieldInfo[i].FieldType.Name.Equals("RadioButton")) || (fieldInfo[i].FieldType.Name.Equals("TabPage"))
                    || (fieldInfo[i].FieldType.Name.Equals("UcButton")))
                {
                    returnValue += ControlCommonLanageSet<Control>(targetForm, fieldInfo[i]);
                }

                if (fieldInfo[i].FieldType.Name.Equals("ButtonItem"))
                {
                    returnValue += DevControlCommonLanageSet<ButtonItem>(targetForm, fieldInfo[i]);
                }

                if (fieldInfo[i].FieldType.Name.Equals("LabelItem"))
                {
                    returnValue += DevControlCommonLanageSet<LabelItem>(targetForm, fieldInfo[i]);
                }

                if (fieldInfo[i].FieldType.Name.Equals("TabItem"))
                {
                    TabItem control = (TabItem)fieldInfo[i].GetValue(targetForm);
                    key = targetForm.Name + "_" + control.Name;
                    language = ResourceManagerWrapper.Instance.Get(key);
                    if (!string.IsNullOrEmpty(language))
                    {
                        control.Text = language;
                        returnValue++;
                    }
                }

                if (fieldInfo[i].FieldType.Name.Equals("SuperTabItem"))
                {
                    BaseItem control = (BaseItem)fieldInfo[i].GetValue(targetForm);
                    key = targetForm.Name + "_" + control.Name;
                    language = ResourceManagerWrapper.Instance.Get(key);
                    if (!string.IsNullOrEmpty(language))
                    {
                        control.Text = language;
                        returnValue++;
                    }
                }

                // 对表格的列名多语言处理 及列宽处理
                if (fieldInfo[i].FieldType.Name.Equals("DataGridView"))
                {
                    DataGridView targetDataGridView = (DataGridView)fieldInfo[i].GetValue(targetForm);
                    for (int j = 0; j < targetDataGridView.ColumnCount; j++)
                    {
                        key = targetForm.Name + "_" + targetDataGridView.Columns[j].Name;
                        language = ResourceManagerWrapper.Instance.Get(key);
                        if (!string.IsNullOrEmpty(language))
                        {
                            targetDataGridView.Columns[j].HeaderText = language;
                            returnValue++;
                        }
                    }
                }

                if (fieldInfo[i].FieldType.Name.Equals("UcDataGridView"))
                {
                    UcDataGridView targetDataGridView = (UcDataGridView)fieldInfo[i].GetValue(targetForm);
                    for (int j = 0; j < targetDataGridView.ColumnCount; j++)
                    {
                        key = targetForm.Name + "_" + targetDataGridView.Columns[j].Name;
                        language = ResourceManagerWrapper.Instance.Get(key);
                        if (!string.IsNullOrEmpty(language))
                        {
                            targetDataGridView.Columns[j].HeaderText = language;
                            returnValue++;
                        }
                    }
                }
            }

            return returnValue;
        }
        #endregion

        private static int ControlCommonLanageSet<T>(Form targetForm, FieldInfo fieldInfo) where T : System.Windows.Forms.Control
        {
            int returnValue = 0;
            T control = (T)fieldInfo.GetValue(targetForm);
            string key = targetForm.Name + "_" + control.Name;
            string language = ResourceManagerWrapper.Instance.Get(key);
            if (!string.IsNullOrEmpty(language))
            {
                control.Text = language;
                returnValue++;
            }
            return returnValue;
        }

        private static int DevControlCommonLanageSet<T>(Form targetForm, FieldInfo fieldInfo) where T : DevComponents.DotNetBar.BaseItem
        {
            int returnValue = 0;
            T control = (T)fieldInfo.GetValue(targetForm);
            string key = targetForm.Name + "_" + control.Name;
            string language = ResourceManagerWrapper.Instance.Get(key);
            if (!string.IsNullOrEmpty(language))
            {
                control.Text = language;
                returnValue++;
            }
            return returnValue;
        }
    }
}
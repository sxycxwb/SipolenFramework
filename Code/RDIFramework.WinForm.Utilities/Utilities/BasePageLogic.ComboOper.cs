using System.Data;
using System.Windows.Forms;
using RDIFramework.BizLogic;
using RDIFramework.Utilities;

namespace RDIFramework.WinForm.Utilities
{
    public partial class BasePageLogic
    {
        #region public static void BindCategory(UserInfo userInfo,ComboBox comboBox, string categoryCode) 绑定字典项（下拉列表框）
        /// <summary>
        /// 绑定字典项（下拉列表框）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="comboBox">组合框控件</param>
        /// <param name="categoryCode">编号</param>
        public static void BindCategory(UserInfo userInfo, ComboBox comboBox, string categoryCode)
        {
            DataTable dtItemDetail = RDIFrameworkService.Instance.ItemDetailsService.GetDTByCode(userInfo, categoryCode);
            DataRow dataRow = dtItemDetail.NewRow();
            dtItemDetail.Rows.InsertAt(dataRow, 0);
            comboBox.Items.Clear();
            comboBox.DisplayMember = CiItemDetailsTable.FieldItemName;
            comboBox.ValueMember = CiItemDetailsTable.FieldItemValue;
            comboBox.DataSource = dtItemDetail.DefaultView;
        }
        #endregion

        #region public static void BindCategory(UserInfo userInfo, ComboBox comboBox, string categoryCode,bool addNew = true) 绑定字典项（下拉列表框）
        /// <summary>
        /// 绑定字典项（下拉列表框）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="comboBox">组合框控件</param>
        /// <param name="categoryCode">编号</param>
        /// <param name="addNew">是否增加一个空间选择项在顶部</param>
        public static void BindCategory(UserInfo userInfo, ComboBox comboBox, string categoryCode, bool addNew = true)
        {
            var dtItemDetail = RDIFrameworkService.Instance.ItemDetailsService.GetDTByCode(userInfo, categoryCode);
            if (addNew)
            {
                DataRow dataRow = dtItemDetail.NewRow();
                dtItemDetail.Rows.InsertAt(dataRow, 0);
            }
            comboBox.Items.Clear();
            comboBox.DisplayMember = CiItemDetailsTable.FieldItemName;
            comboBox.ValueMember = CiItemDetailsTable.FieldItemValue;
            comboBox.DataSource = dtItemDetail.DefaultView;
        }
        #endregion

        #region  public static object GetComboSelectedValue(ComboBox combox, ComboBoxValueType valueType):根据指定类型得到当前ComboBox的取值
        /// <summary>
        /// 根据指定类型得到当前ComboBox的取值
        /// </summary>
        /// <param name="combox">ComboBox</param>
        /// <param name="valueType">ComboBoxValueType</param>
        /// <returns>返回相应的值</returns>
        public static object GetComboSelectedValue(ComboBox combox, ComboBoxValueType valueType)
        {
            object returnValue = null;

            if (combox.Items.Count > 0)
            {
                switch (valueType)
                {
                    case ComboBoxValueType.SelectItem:
                        returnValue = combox.SelectedItem;
                        break;
                    case ComboBoxValueType.SelectValue:
                        returnValue = combox.SelectedValue;
                        break;
                    case ComboBoxValueType.Text:
                        returnValue = combox.Text;
                        break;
                }
            }

            return returnValue;
        }

        public enum ComboBoxValueType
        {
            SelectValue,
            SelectItem,
            Text
        }
        #endregion

        #region public static void BindCombo(ComboBox cb, DataTable dt, string valueMember, string displayMember) 绑定Combox
        /// <summary>
        /// 绑定Combox
        /// </summary>
        /// <param name="cb">ComboBox</param>
        /// <param name="dt">DataTable</param>
        /// <param name="valueMember">valueMember字段</param>
        /// <param name="displayMember">displayMember字段</param>
        public static void BindCombo(ComboBox cb, DataTable dt, string valueMember, string displayMember)
        {
            string text = "";
            string value = "";
            cb.Items.Clear();
            var l = new ExListItem("请选择...", "###");
            cb.Items.Add(l);
            foreach (DataRow dr in dt.Rows)
            {
                text = dr[displayMember].ToString();
                value = dr[valueMember].ToString();
                l = new ExListItem(text, value);
                cb.Items.Add(l);
            }
            cb.DisplayMember = "Text";
            cb.ValueMember = "Value";
        }
        #endregion
    }

    /// <summary>
    /// 选择项类，用于ComboBox或者ListBox添加项
    /// </summary>
    public class ExListItem
    {
        private string _value = string.Empty;
        private string _text = string.Empty;
        public ExListItem(string sname, string sid)
        {
            Value = sid;
            Text = sname;
        }

        public override string ToString()
        {
            return this._text;
        }
        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
            }
        }
    }
}
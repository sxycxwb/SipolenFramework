using System;
using System.Windows.Forms;
using RDIFramework.Controls;
using RDIFramework.Utilities;

namespace RDIFramework.WinForm.Utilities
{
    public partial class BasePageLogic
    {
        //
        //容器包含控件属性控制
        //

        #region public static void EmptyControlValue(Control parContainer):清除容器里面指定控件的值(通过控件的AccessibleName属性设置为"EmptyValue")
        /// <summary>
        /// 清除容器里面指定控件的值(通过控件的AccessibleName属性设置为"EmptyValue")
        /// </summary>
        /// <param name="parContainer">容器控件</param>
        public static void EmptyControlValue(Control parContainer)
        {
            for (int index = 0; index < parContainer.Controls.Count; index++)
            {
                //如果是容器类控件，递归调用自己
                if (parContainer.Controls[index].HasChildren && !parContainer.Controls[index].GetType().Name.ToLower().StartsWith("uc"))
                {
                    EmptyControlValue(parContainer.Controls[index]);
                }
                else
                {
                    if (parContainer.Controls[index].AccessibleName == null ||
                        !parContainer.Controls[index].AccessibleName.ToLower().Contains("emptyvalue"))
                    {
                        continue;
                    }

                    switch (parContainer.Controls[index].GetType().Name)
                    {
                        case "Label":
                            break;
                        //case "ComboBox":
                        //    ((ComboBox)(parContainer.Controls[index])).Text = "";                           
                        //    break;
                        case "TextBox":
                            ((TextBox)(parContainer.Controls[index])).Text = "";
                            break;
                        case "UcTextBox":
                            ((UcTextBox)(parContainer.Controls[index])).Text = "";
                            break;
                        case "RichTextBox":
                            ((RichTextBox)(parContainer.Controls[index])).Text = "";
                            break;
                        case "MaskedTextBox":
                            ((MaskedTextBox)(parContainer.Controls[index])).Text = "";
                            break;
                        case "UcMaskTextBox":
                            ((UcMaskTextBox)(parContainer.Controls[index])).Text = "";
                            break;
                        case "RadioButton":
                            ((RadioButton)(parContainer.Controls[index])).Checked = false;
                            break;
                        case "CheckBox":
                            ((CheckBox)(parContainer.Controls[index])).Checked = false;
                            break;
                    }
                }
            }
        }
        #endregion

        #region public static bool ControlValueIsEmpty(Control parContainer):判断一容器控件内某控件的值是否可以为空(通过控件的AccessibleName属性设置为"NotNull")
        /// <summary>
        /// 判断一容器控件内某控件的值是否可以为空(通过控件的AccessibleName属性设置为"NotNull")
        /// <remarks>
        ///     说明：
        ///         此方法显示提示信息，对于相应取值不能为空的控件，应设置其“Tag”属性，以友好提示信息。
        /// </remarks>
        /// </summary>
        /// <param name="parContainer">容器控件</param>
        public static bool ControlValueIsEmpty(Control parContainer)
        {
            bool returnValue = true;
            string hintInfo = string.Empty;
            for (int index = 0; index < parContainer.Controls.Count; index++)
            {
                //如果是容器类控件，递归调用自己

                if (parContainer.Controls[index].HasChildren && !parContainer.Controls[index].GetType().Name.ToLower().StartsWith("uc"))
                {
                    ControlValueIsEmpty(parContainer.Controls[index]);
                }
                else
                {
                    if (string.IsNullOrEmpty(parContainer.Controls[index].AccessibleName))
                    {
                        continue;
                    }

                    if (!parContainer.Controls[index].AccessibleName.ToLower().Contains("notnull")
                        && !parContainer.Controls[index].GetType().Name.ToLower().Contains("mask"))
                    {
                        continue;
                    }

                    switch (parContainer.Controls[index].GetType().Name)
                    {
                        case "Label"://排除Label
                            break;
                        case "ComboBox":
                        case "ComboBoxEx":
                        case "UcComboBoxEx":
                            if (parContainer.Controls[index] is ComboBox)
                            {
                                if (((ComboBox)(parContainer.Controls[index])).Text.Trim() == string.Empty)
                                {
                                    hintInfo += GetControlName((ComboBox)parContainer.Controls[index]) + "\n";
                                    //ShowInfo((ComboBox)parContainer.Controls[index], " 不能为空!");
                                    //((ComboBox)(parContainer.Controls[index])).Focus();
                                    returnValue = false;
                                }
                            }
                            else
                            {
                                if (((UcComboBoxEx)(parContainer.Controls[index])).Text.Trim() == string.Empty)
                                {
                                    hintInfo += GetControlName((UcComboBoxEx)parContainer.Controls[index]) + "\n";
                                    //ShowInfo((UcComboBoxEx)parContainer.Controls[index], " 不能为空!");
                                    //((UcComboBoxEx)(parContainer.Controls[index])).Focus();
                                    returnValue = false;
                                }
                            }
                            break;
                        case "TextBox":
                        case "UcTextBox":
                            if (parContainer.Controls[index] is TextBox)
                            {
                                if (((TextBox)(parContainer.Controls[index])).Text.Trim() == string.Empty)
                                {
                                    hintInfo += GetControlName((TextBox)parContainer.Controls[index]) + "\n";
                                    //ShowInfo((TextBox)parContainer.Controls[index], " 不能为空!");
                                    //((TextBox)(parContainer.Controls[index])).Focus();
                                    returnValue = false;
                                }
                            }
                            else
                            {
                                if (((UcTextBox)(parContainer.Controls[index])).Text.Trim() == string.Empty)
                                {
                                    hintInfo += GetControlName((UcTextBox)parContainer.Controls[index]) + "\n";
                                    //ShowInfo((UcTextBox)parContainer.Controls[index], " 不能为空!");
                                    //((UcTextBox)(parContainer.Controls[index])).Focus();
                                    returnValue = false;
                                }
                            }
                            break;
                        case "RichTextBox":
                            if (((RichTextBox)(parContainer.Controls[index])).Text.Trim() == string.Empty)
                            {
                                hintInfo += GetControlName((RichTextBox)parContainer.Controls[index]) + "\n";
                                //ShowInfo((RichTextBox)parContainer.Controls[index], " 不能为空!");
                                //((RichTextBox)(parContainer.Controls[index])).Focus();
                                returnValue = false;
                            }
                            break;
                        case "MaskedTextBox":
                        case "UcMaskTextBox":
                            string mskTxtValue = string.Empty;
                            object controlChinaeseName = null;
                            if (parContainer.Controls[index] is MaskedTextBox)
                            {
                                mskTxtValue = ((MaskedTextBox)(parContainer.Controls[index])).Text;
                                controlChinaeseName = ((MaskedTextBox)(parContainer.Controls[index])).Tag ?? ((MaskedTextBox)(parContainer.Controls[index])).Name;
                            }
                            else
                            {
                                mskTxtValue = ((UcMaskTextBox)(parContainer.Controls[index])).Text;
                                controlChinaeseName = ((UcMaskTextBox)(parContainer.Controls[index])).Tag ?? ((UcMaskTextBox)(parContainer.Controls[index])).Name;
                            }

                            if (mskTxtValue.Substring(0, 4).Trim().Length > 0) //如果有有值，则要对输入的日期进行格式判断
                            {
                                if (DateTimeHelper.IsDate(mskTxtValue))
                                {
                                    //把用户输入的日期数据控制在(1754-01-01 至 9999-12-31这间)，这主要解决SqlServer与C#日期范围的冲突
                                    if (DateTimeHelper.ToDate(mskTxtValue) < DateTimeHelper.ToDate("1754-01-01") ||
                                        DateTimeHelper.ToDate(mskTxtValue) >= DateTimeHelper.ToDate("9999-12-31"))
                                    {
                                        MessageBoxHelper.ShowErrorMsg("[" + controlChinaeseName + "] 日期范围不正确! /n正确日期范围为:1754-01-01 至 9999-12-31");
                                        returnValue = false;
                                    }
                                }
                                else
                                {
                                    MessageBoxHelper.ShowErrorMsg("[" + controlChinaeseName + "] 日期格式不正确! 正确格式如:2012-01-01");
                                    returnValue = false;
                                }
                            }
                            else
                            {
                                if (mskTxtValue.Substring(0, 5).Equals("    -") && parContainer.Controls[index].AccessibleName.ToLower() == "notnull")
                                {
                                    MessageBoxHelper.ShowErrorMsg("[" + controlChinaeseName + "]不能为空!");
                                    returnValue = false;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(hintInfo.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg(hintInfo + "不能为空！");
            }
            return returnValue;
        }

        private static string GetControlName(Control ctr)
        {
            if (ctr.Tag == null)
            {
                return ctr.Name;
            }
            else
            {
                return ctr.Tag.ToString();
            }
        }

        private static void ShowInfo(Control ctr, string info)
        {
            if (ctr.Tag == null)
            {
                MessageBoxHelper.ShowWarningMsg(ctr.Name + info);
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(ctr.Tag + info);
            }
        }
        #endregion

        #region public static void SetControlReadOnly(Control parContainer, bool isReadOnly):设置容器控件中包含的控件为只读(通过控件的AccessibleName属性设置为"CanReadOnly")
        /// <summary>
        /// 设置容器控件中包含的控件为只读(通过控件的AccessibleName属性设置为"CanReadOnly")
        /// </summary>
        /// <param name="parContainer">容器控件</param>
        /// <param name="isReadOnly">是否为只读，true是只读,false则相反</param>>
        public static void SetControlReadOnly(Control parContainer, bool isReadOnly)
        {
            for (int index = 0; index < parContainer.Controls.Count; index++)
            {
                //如果是容器类控件，递归调用自己
                if (parContainer.Controls[index].HasChildren)
                {
                    SetControlReadOnly(parContainer.Controls[index], isReadOnly);
                }
                else
                {
                    if (parContainer.Controls[index].AccessibleName == null &&
                      !parContainer.Controls[index].AccessibleName.ToLower().Contains("canreadonly"))
                    {
                        continue;
                    }

                    switch (parContainer.Controls[index].GetType().Name)
                    {
                        case "TextBox":
                        case "UcTextBox":
                            if (parContainer.Controls[index] is TextBox)
                            {
                                ((TextBox)(parContainer.Controls[index])).ReadOnly = isReadOnly;
                            }
                            else
                            {
                                ((UcTextBox)(parContainer.Controls[index])).ReadOnly = isReadOnly;
                            }

                            break;
                        case "RichTextBox":
                            ((RichTextBox)(parContainer.Controls[index])).ReadOnly = isReadOnly;
                            break;
                        case "MaskedTextBox":
                        case "UcMaskTextBox":
                            if (parContainer.Controls[index] is MaskedTextBox)
                            {
                                ((MaskedTextBox)(parContainer.Controls[index])).ReadOnly = isReadOnly;
                            }
                            else
                            {
                                ((UcMaskTextBox)(parContainer.Controls[index])).ReadOnly = isReadOnly;
                            }
                            break;
                        case "ComboBox":
                            ((ComboBox)(parContainer.Controls[index])).Enabled = !isReadOnly;
                            break;
                        case "Button":
                        case "UcButton":
                            if (parContainer.Controls[index] is Button)
                            {
                                ((Button)(parContainer.Controls[index])).Enabled = !isReadOnly;
                            }
                            else
                            {
                                ((UcButton)(parContainer.Controls[index])).Enabled = !isReadOnly;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion

        #region public static void SetControlEnabled(Control parContainer, bool isEnabled):设置容器控件中包含的控件是否可用(通过控件的AccessibleName属性设置为"Enabled")
        /// <summary>
        /// 设置容器控件中包含的控件是否可用(通过控件的AccessibleName属性设置为"Enabled")
        /// </summary>
        /// <param name="parContainer">容器控件</param>
        /// <param name="isEnabled">是否为用可，true:可用,false:不可用</param>>
        public static void SetControlEnabled(Control parContainer, bool isEnabled)
        {
            for (int index = 0; index < parContainer.Controls.Count; index++)
            {
                //如果是容器类控件，递归调用自己
                if (parContainer.Controls[index].HasChildren)
                {
                    SetControlEnabled(parContainer.Controls[index], isEnabled);
                }
                else
                {
                    if (parContainer.Controls[index].AccessibleName == null &&
                       !parContainer.Controls[index].AccessibleName.ToLower().Contains("Enabled"))
                    {
                        continue;
                    }

                    //(parContainer.Controls[index]).BackColor = System.Drawing.Color.White;//设置当前控件的背景色为白色

                    switch (parContainer.Controls[index].GetType().Name)
                    {
                        case "Label":
                            break;
                        default:
                            parContainer.Controls[index].Enabled = isEnabled;
                            break;
                    }
                }
            }
        }
        #endregion

        #region public static void InputControl(object sender, KeyPressEventArgs e) 只能输入数据与退格键
        /// <summary>
        /// 输入格式控制(主要是对KeyPress事件进行控制,只能输入数据和退格键)
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public static void InputControl(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) //小数点的话再加 e.KeyChar != '.'
            {
                e.Handled = true; //只能输入数据和退格键
            }
        }

        /// <summary>
        /// 输入格式控制(主要是对KeyPress事件进行控制，只能输入数据和退格键和小数点)
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">KeyPressEventArgs</param>
        /// <param name="Char">如：小数点的话则传'.'</param>
        public static void InputControl(object sender, KeyPressEventArgs e, char Char)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != Char) //小数点的话再加 e.KeyChar != '.'
            {
                e.Handled = true; //只能输入数据和退格键
            }
        }


        /// <summary>
        /// 输入格式控制(只能输入数据和退格键和小数点) 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">KeyPressEventArgs</param>
        /// <param name="sText">文本现在的内容</param>
        public static void InputControl(object sender, KeyPressEventArgs e, string sText)
        {
            bool isdig = sText.Contains(".");
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (isdig && (e.KeyChar == '.')) //如果输入了小数点，不能再次输入 
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
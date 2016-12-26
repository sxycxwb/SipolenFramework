using System;
using System.Windows.Forms;
using System.Reflection;

namespace RDIFramework.WinForm.Utilities
{
    /// <summary>
    /// 将业务对象与窗体或控件容器互绑定
    /// </summary>
    public sealed class FormBinding
    {
        /// <summary>
        /// 将业务对象绑定到窗体或控件容器
        /// </summary>
        /// <param name="obj">业务对象</param>
        /// <param name="container">窗体或控件容器</param>
        public static void BindObjectToControls(object obj, Control container)
        {
            if (obj == null) return;
            Type objType = obj.GetType();
            PropertyInfo[] objPropertiesArray = objType.GetProperties();
            foreach (PropertyInfo objProperty in objPropertiesArray)
            {
                Control control = FindControl(container, objProperty.Name);
                if (control == null) continue;
                if (control is DateTimePicker)
                {
                    DateTimePicker dateTimePicker = (DateTimePicker)control;
                    dateTimePicker.Value = (DateTime)objProperty.GetValue(obj, null);
                }
                else
                {
                    //获取控件的属性
                    Type controlType = control.GetType();
                    PropertyInfo[] controlPropertiesArray = controlType.GetProperties();
                    //通用属性
                    bool success = false;
                    success = FindAndSetControlProperty(obj, objProperty, control, controlPropertiesArray, "Checked", typeof(bool));
                    if (!success)
                        success = FindAndSetControlProperty(obj, objProperty, control, controlPropertiesArray, "Value", typeof(String));
                    if (!success)
                        success = FindAndSetControlProperty(obj, objProperty, control, controlPropertiesArray, "Text", typeof(String));
                    if (!success)
                        success = FindAndSetControlProperty(obj, objProperty, control, controlPropertiesArray, "SelectedValue", typeof(String));
                }
            }
        }

        /// <summary>
        /// 根据控件名找出容器中的控件，考虑有些控件放在窗体的容器中，采用了递归查找。
        /// </summary>
        /// <param name="container">控件容器</param>
        /// <param name="controlName">控件名称</param>
        /// <returns></returns>
        private static Control FindControl(Control container, string controlName)
        {
            Control findControl = null;
            foreach (Control control in container.Controls)
            {
                if (control.Controls.Count == 0)
                {                    
                    if (control.Name == controlName)
                    {
                        findControl = control;
                        break;
                    }
                }
                else
                {
                    findControl = FindControl(control, controlName);
                    if (findControl != null)
                    {
                        return findControl;
                    }
                }
            }
            return findControl;
        }

        /// <summary>
        /// 设置控件的值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="objProperty"></param>
        /// <param name="control"></param>
        /// <param name="controlPropertiesArray"></param>
        /// <param name="propertyName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool FindAndSetControlProperty(object obj, PropertyInfo objProperty, Control control, PropertyInfo[] controlPropertiesArray, string propertyName, Type type)
        {
            foreach (PropertyInfo controlProperty in controlPropertiesArray)
            {
                if (controlProperty.Name == propertyName && controlProperty.PropertyType == type)
                {
                    controlProperty.SetValue(control, Convert.ChangeType(objProperty.GetValue(obj, null), type), null);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 将窗体或控件容器中的控件绑定到业务对象
        /// </summary>
        /// <param name="obj">业务对象(一般是实体)</param>
        /// <param name="container"></param>
        public static void BindControlsToObject(object obj, Control container)
        {
            if (obj == null) return;
            //获取业务对象的属性   
            Type objType = obj.GetType();
            PropertyInfo[] objPropertiesArray = objType.GetProperties();
            foreach (PropertyInfo objProperty in objPropertiesArray)
            {
                Control control = FindControl(container, objProperty.Name);
                if (control == null) continue;
                if (control is DateTimePicker)
                {
                    DateTimePicker dateTimePicker = (DateTimePicker)control;
                    objProperty.SetValue(obj, ChangeType(dateTimePicker.Value, objProperty.PropertyType), null);
                }
                else
                {
                    Type controlType = control.GetType();
                    PropertyInfo[] controlPropertiesArray = controlType.GetProperties();
                    bool success = false;
                    success = FindAndGetControlProperty(obj, objProperty, control, controlPropertiesArray, "Checked", typeof(bool));
                    if (!success)
                        success = FindAndGetControlProperty(obj, objProperty, control, controlPropertiesArray, "Value", typeof(String));
                    if (!success)
                        success = FindAndGetControlProperty(obj, objProperty, control, controlPropertiesArray, "Text", typeof(String));
                    if (!success)
                        success = FindAndGetControlProperty(obj, objProperty, control, controlPropertiesArray, "SelectedValue", typeof(String));
                }
            }
        }

        private static bool FindAndGetControlProperty(object obj, PropertyInfo objProperty, Control control, PropertyInfo[] controlPropertiesArray, string propertyName, Type type)
        {
            // 在整个控件属性中进行迭代
            foreach (PropertyInfo controlProperty in controlPropertiesArray)
            {
                // 检查匹配的名称和类型
                if (controlProperty.Name == "Text" && controlProperty.PropertyType == typeof(String))
                {
                    // 将控件的属性设置为业务对象属性值
                    try
                    {

                        if (control.GetType().Name == "CheckBoxX")
                        {
                            objProperty.SetValue(obj, ((DevComponents.DotNetBar.Controls.CheckBoxX)control).Checked ? 1  : 0, null);
                            return true;
                        }
                        else if (control.GetType().Name == "CheckBox")
                        {
                            objProperty.SetValue(obj, RDIFramework.Utilities.BusinessLogic.ConvertToInt(((CheckBox)control).Checked ? 1 : 0), null);
                            return true;
                        }
                        else
                        {
                            //objProperty.SetValue(obj, Convert.ChangeType(controlProperty.GetValue(control, null), objProperty.PropertyType), null);
                            objProperty.SetValue(obj, ChangeType(controlProperty.GetValue(control, null),objProperty.PropertyType), null);
                            return true;
                        }
                    }
                    catch
                    {
                        // 无法将来自窗体控件 
                        // 的数据转换为 
                        // objProperty.PropertyType
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 转换类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ChangeType(object value, Type type)
        {
            if (value == null && type.IsGenericType) return Activator.CreateInstance(type);
            if (value == null) return null;
            if (type == value.GetType()) return value;
            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, value as string);
                return Enum.ToObject(type, value);
            }
            if (!type.IsInterface && type.IsGenericType)
            {
                Type innerType = type.GetGenericArguments()[0];
                object innerValue = ChangeType(value, innerType);
                return Activator.CreateInstance(type, new object[] { innerValue });
            }
            if (value is string && type == typeof(Guid)) return new Guid(value as string);
            if (value is string && type == typeof(Version)) return new Version(value as string);
            if (!(value is IConvertible)) return value;
            return Convert.ChangeType(value, type);
        } 
    }
}

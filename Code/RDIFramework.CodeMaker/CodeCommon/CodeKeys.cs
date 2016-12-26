using System.Collections.Generic;

namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// �����У��������ݿ�������������ֶ�
    /// </summary>
    public class CodeKey
    {
        private string _keyName;
        private string _keyType;
        private bool _isPK;
        private bool _isIdentity;

        /// <summary>
        /// �ֶ���
        /// </summary>
        public string KeyName
        {
            set { _keyName = value; }
            get { return _keyName; }
        }
        /// <summary>
        /// �ֶ�����
        /// </summary>
        public string KeyType
        {
            set { _keyType = value; }
            get { return _keyType; }
        }
        /// <summary>
        /// �Ƿ�������
        /// </summary>
        public bool IsPK
        {
            set { _isPK = value; }
            get { return _isPK; }
        }
        /// <summary>
        /// �Ƿ��Ǳ�ʶ��
        /// </summary>
        public bool IsIdentity
        {
            set { _isIdentity = value; }
            get { return _isIdentity; }
        }
    }

    /// <summary>
    /// �����ֶκ������ֶβ�����
    /// </summary>
    public class CodeKeyMaker
    { 
        /// <summary>
        /// �õ��������б�(���磺����Exists  Delete  GetModel �Ĳ�������)
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string GetParameter(List<CodeKey> keys)
        {
            StringPlus strclass = new StringPlus();
            foreach (CodeKey key in keys)
            {
                strclass.Append(CodeCommon.DbTypeToCS(key.KeyType) + " " + key.KeyName + ",");                
            }
            strclass.DelLastComma();
            return strclass.Value;
        }

        ///// <summary>
        ///// �õ�Where�������-SQL��ʽ (���磺����Exists  Delete  GetModel ��where)
        ///// </summary>
        ///// <param name="keys"></param>
        ///// <returns></returns>
        //public static string GetParameter(List<CodeKey> keys)
        //{
        //    StringPlus strclass = new StringPlus();
        //    foreach (CodeKey key in keys)
        //    {
        //        if (CodeCommon.IsAddMark(key.KeyType))
        //        {
        //            strclass.Append(key.KeyName + "='\"+" + key.KeyName + "+\"'\"");
        //        }
        //        else
        //        {
        //            strclass.Append(key.KeyName + "=\"+" + key.KeyName );
        //        }
                
        //    }            
        //    return strclass.Value;
        //}
        ///// <summary>
        ///// �õ�Where�������-SqlParameter��ʽ (���磺����Exists  Delete  GetModel ��where)
        ///// </summary>
        ///// <param name="keys"></param>
        ///// <returns></returns>
        //public static string GetParameter(List<CodeKey> keys)
        //{
        //    StringPlus strclass = new StringPlus();
        //    foreach (CodeKey key in keys)
        //    {
        //        if (CodeCommon.IsAddMark(key.KeyType))
        //        {
        //            strclass.Append(key.KeyName + "='\"+" + key.KeyName + "+\"'\"");
        //        }
        //        else
        //        {
        //            strclass.Append(key.KeyName + "=\"+" + key.KeyName);
        //        }

        //    }
        //    return strclass.Value;
        //}




    }

}

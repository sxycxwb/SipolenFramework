using System.Collections.Generic;

namespace RDIFramework.CodeMaker
{
	/// <summary>
	/// IDbScriptBuilder ��ժҪ˵����
	/// </summary>
	public interface IDbScriptBuilder
	{
		#region ����
        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
		string DbConnectStr
		{
			get;
			set;
		}

        /// <summary>
        /// ���ݿ�����
        /// </summary>
		string DbName
		{
			get;
			set;
		}

        /// <summary>
        /// ������
        /// </summary>
		string TableName
		{
			get;
			set;
		}
        	

        /// <summary>
        /// �洢����ǰ׺
        /// </summary>
        string ProcPrefix
        {
            set;
            get;
        }  
     
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        string ProjectName
        {
            set;
            get;
        }
        /// <summary>
        /// ѡ����ֶμ���
        /// </summary>
        List<ColumnInfo> Fieldlist
        {
            set;
            get;
        }
        /// <summary>
        /// ѡ����ֶμ����ַ���
        /// </summary>
        string Fields
        {
            get;
        }
        /// <summary>
        /// �����������ֶ�
        /// </summary>
        List<ColumnInfo> Keys
        {
            set;
            get;
        }
		#endregion	

		#region �������ݿ�����ű�
        /// <summary>
        /// �������ݿ����б�Ĵ����ű�
        /// </summary>
        /// <param name="dbName">���ݿ�����</param>
        /// <returns></returns>
        string CreateDBTabScript(string dbName);
		
        /// <summary>
        /// �������ݿ�����ű�
        /// </summary>
        /// <param name="dbName">���ݿ�����</param>
        /// <param name="tableName">������</param>
        /// <returns>���ݿ�����ű�</returns>
		string CreateTabScript(string dbName,string tableName);

        /// <summary>
        /// ����SQL��ѯ��� �������ݴ����ű�
        /// </summary>
        /// <param name="dbName">���ݿ�����</param>
        /// <param name="strSql">Sql���</param>
        /// <returns>���ݴ����ű�</returns>
        string CreateTabScriptBySQL(string dbName, string strSql);

        /// <summary>
        /// �������ݿ�����ű����ļ�
        /// </summary>
        /// <param name="dbName">���ݿ�����</param>
        /// <param name="tableName">������</param>
        /// <param name="filename">�ļ���</param>
        /// <param name="progressBar">������</param>
		void CreateTabScript(string dbName,string tableName,string filename,System.Windows.Forms.ProgressBar progressBar);
        		
		#endregion

		#region �����洢����

		string CreatPROCGetMaxID();

        string CreatPROCIsHas();

		string CreatPROCADD();

		string CreatPROCUpdate();

        string CreatPROCDelete();

        string CreatPROCGetEntity();

		string CreatPROCGetList();
		
		/// <summary>
		/// �õ�ĳ����Ĵ洢���̣�ѡ�����ɵķ�����
		/// </summary>
		/// <param name="Maxid"></param>
		/// <param name="Ishas"></param>
		/// <param name="Add"></param>
		/// <param name="Update"></param>
		/// <param name="Delete"></param>
        /// <param name="GetEntity"></param>
		/// <param name="List"></param>
		/// <param name="dtColumn">�����������Ϣ</param>
		/// <returns></returns>
        string GetPROCCode(bool Maxid, bool Ishas, bool Add, bool Update, bool Delete, bool GetEntity, bool List);
		
		/// <summary>
		/// �õ�ĳ����Ĵ洢����
		/// </summary>
		/// <param name="dbName">����</param>
		/// <param name="tableName">����</param>
		/// <returns></returns>
		string GetPROCCode(string dbName,string tableName);
		/// <summary>
		/// �õ�һ���������б�Ĵ洢����
		/// </summary>
		/// <param name="DbName"></param>
		/// <returns></returns>
		string GetPROCCode(string dbName);
		#endregion

        #region ����SQL��ѯ���

        /// <summary>
        /// ����Select��ѯ���
        /// </summary>
        /// <param name="dbName">����</param>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        string GetSQLSelect(string dbName, string tableName);
       

        /// <summary>
        /// ����update��ѯ���
        /// </summary>
        /// <param name="dbName">����</param>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        string GetSQLUpdate(string dbName, string tableName);
        
        /// <summary>
        /// ����update��ѯ���
        /// </summary>
        /// <param name="dbName">����</param>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        string GetSQLDelete(string dbName, string tableName);

        /// <summary>
        /// ����INSERT��ѯ���
        /// </summary>
        /// <param name="dbName">����</param>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        string GetSQLInsert(string dbName, string tableName);

        /// <summary>
        /// �������ݿ����Drop���
        /// </summary>
        /// <param name="dbName">���ݿ�����</param>
        /// <param name="dbObjectName">���ݿ��������</param>
        /// <param name="dbobjType">���ݿ�������ͣ�����ͼ���洢���̡������ȣ�</param>
        /// <returns></returns>
        string GetSqlDrop(string dbName, string dbObjectName,DBObjectType dbobjType);
        #endregion
	}
}

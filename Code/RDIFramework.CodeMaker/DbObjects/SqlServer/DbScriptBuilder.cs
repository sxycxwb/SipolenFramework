using System;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace RDIFramework.CodeMaker.DbObjects.SqlServer
{
	/// <summary>
	/// ���ݿ�ű������ࡣScript
	/// </summary>
	public class DbScriptBuilder:IDbScriptBuilder
	{
        #region ˽�б���
        protected string _key = "ID";//��ʶ�У��������ֶ�		
        protected string _keyType = "int";//��ʶ�У��������ֶ�����        
        #endregion

		#region ����
		private string _dbconnectStr;
		private string _dbName;
		private string _tableName;		
        private string _procprefix;
        private string _projectname;
        private List<ColumnInfo> _fieldList;
        private List<ColumnInfo> _keys; //�����������ֶ��б� 
        

		public string DbConnectStr
		{
			set{_dbconnectStr=value;}
			get{return _dbconnectStr;}
		}
		public string DbName
		{
			set{ _dbName=value;}
			get{return _dbName;}
		}
		public string TableName
		{
			set{ _tableName=value;}
			get{return _tableName;}
		}
        //public string ID
        //{
        //    set{ _id=value;}
        //    get{return _id;}
        //}
        //public string IDType
        //{
        //    set{ _idType=value;}
        //    get{return _idType;}
        //}
        /// <summary>
        /// �洢����ǰ׺ 
        /// </summary>       
        public string ProcPrefix
        {
            set { _procprefix = value; }
            get { return _procprefix; }
        }
        /// <summary>
        /// ��Ŀ���� 
        /// </summary>        
        public string ProjectName
        {
            set { _projectname = value; }
            get { return _projectname; }
        }

        public List<ColumnInfo> Keys
        {
            set { _keys = value; }
            get { return _keys; }
        }
        /// <summary>
        /// ѡ����ֶμ���
        /// </summary>
        public List<ColumnInfo> Fieldlist
        {
            set { _fieldList = value; }
            get { return _fieldList; }
        }         
		#endregion

        #region ��������
        /// <summary>
        /// ѡ����ֶμ��ϵ�-�ַ���
        /// </summary>
        public string Fields
        {
            get
            {
                StringPlus _fields = new StringPlus();
                foreach (ColumnInfo obj in Fieldlist)
                {
                    _fields.Append("'" + obj.ColumnName + "',");
                }
                _fields.DelLastComma();
                return _fields.Value;
            }
        }
        /// <summary>
        /// �ֶε� select * �б�
        /// </summary>
        public string Fieldstrlist
        {
            get
            {
                StringPlus _fields = new StringPlus();
                foreach (ColumnInfo obj in Fieldlist)
                {
                    _fields.Append(obj.ColumnName + ",");
                }
                _fields.DelLastComma();
                return _fields.Value;
            }
        }
        /// <summary>
        /// �����Ƿ��б�ʶ��
        /// </summary>
        public bool IsHasIdentity
        {
            get
            {
                bool isid = false;
                if (_keys.Count > 0)
                {
                    foreach (ColumnInfo key in _keys)
                    {
                        if (key.IsIdentity)
                        {
                            isid = true;
                        }
                    }
                }
                return isid;
            }
        }
        #endregion

        DbObject dbobj=new DbObject();
		public DbScriptBuilder()
		{

        }

        #region ��������

        /// <summary>
        /// �õ���������������б� (���磺����Exists  Delete  GetModel �Ĳ�������)
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public string GetInParameter(List<ColumnInfo> fieldList, bool output)
        {
            StringPlus strclass = new StringPlus();

            foreach (ColumnInfo field in fieldList)
            {
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                bool IsIdentity = field.IsIdentity;
                bool IsPK = field.IsPK;
                string Length = field.Length;
                string Preci = field.Preci;
                string Scale = field.Scale;
                //if (Length.Trim() == "-1")
                //{
                //    Length = "MAX";
                //}
                switch (columnType.ToLower())
                {
                    case "decimal":
                    case "numeric":
                        strclass.Append("@" + columnName + " " + columnType + "(" + Preci + "," + Scale + ")");
                        break;                    
                    case "char":
                    case "varchar":
                    case "varbinary":
                    case "binary":
                    case "nchar":
                    case "nvarchar":    
                        {
                            strclass.Append("@" + columnName + " " + columnType + "(" + CodeCommon.GetDataTypeLenVal(columnType.ToLower(), Length) + ")");
                        }
                        break;                       
                    default:
                        strclass.Append("@" + columnName + " " + columnType);
                        break;
                }
                if ((IsIdentity) && (output))
                {
                    strclass.AppendLine(" output,");                    
                    continue;
                }
                strclass.AppendLine(",");
            }
            strclass.DelLastComma();
            return strclass.Value;
        }

        /// <summary>
        /// �õ�Where������� - Parameter��ʽ (���磺����Exists  Delete  GetModel ��where)
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public string GetWhereExpression(List<ColumnInfo> keys)
        {
            StringPlus strclass = new StringPlus();
            foreach (ColumnInfo key in keys)
            {
                strclass.Append(key.ColumnName + "=@" + key.ColumnName + " and ");
            }
            strclass.DelLastChar("and");
            return strclass.Value;
        }

        
        #endregion

        #region �������ݿ�����ű�

        #region public string CreateDBTabScript(string dbName) �������ݿ����б�Ĵ����ű�
        /// <summary>
        /// �������ݿ����б�Ĵ����ű�
        /// </summary>
        /// <param name="dbName">���ݿ�����</param>
        /// <returns>���ݿ����б�Ĵ����ű�</returns>
        public string CreateDBTabScript(string dbName)
        {
            dbobj.DbConnectStr = this.DbConnectStr;
            StringPlus strclass = new StringPlus();
            List<string> tabNames = dbobj.GetTables(dbName);
            if (tabNames.Count > 0)
            {
                foreach (string tabname in tabNames)
                {
                    strclass.AppendLine(CreateTabScript(dbName, tabname));
                }
            }
            return strclass.Value;
        }
        #endregion 

        #region public string CreateTabScript(string dbName,string tableName) �������ݿ�����ű�
        /// <summary>
        /// �������ݿ�����ű�
        /// </summary>
        /// <param name="dbName">���ݿ�����</param>
        /// <param name="tableName">������</param>
        /// <returns>ָ����Ĵ����ű�</returns>
		public string CreateTabScript(string dbName,string tableName)
		{
			dbobj.DbConnectStr=_dbconnectStr;
            //DataTable dt=dbobj.GetColumnInfoList(dbName,tableName);

            List<ColumnInfo> collist =dbobj.GetColumnInfoList(dbName,tableName);
            DataTable dt = CodeCommon.GetColumnInfoDt(collist);
			StringPlus strclass=new StringPlus();
			strclass.AppendLine("if exists (select * from sysobjects where id = OBJECT_ID('"+tableName+"') and OBJECTPROPERTY(id, 'IsUserTable') = 1) ");
			strclass.AppendLine("DROP TABLE "+tableName+"");
			
			string PKfild="";//�����ֶ�
			bool IsIden=false;//�Ƿ��Ǳ�ʶ�ֶ�
			StringPlus ColdefaVal=new StringPlus();//�ֶε�Ĭ��ֵ�б�			
			
			Hashtable FildtabList=new Hashtable();//�ֶ��б�
			StringPlus FildList=new StringPlus();//�ֶ��б�
			//��ʼ������
			strclass.AppendLine("");
			strclass.AppendLine("CREATE TABLE "+tableName+" (");
			if(dt!=null)
			{
                DataRow[] dtrows;
                dtrows = Fieldlist.Count > 0 ? dt.Select("ColumnName in (" + Fields + ")", "colorder asc") : dt.Select();

                foreach (DataRow row in dtrows)
				{					
					string columnName=row["ColumnName"].ToString();	
					string columnType=row["TypeName"].ToString();				
					string IsIdentity=row["IsIdentity"].ToString();	
					string Length=row["Length"].ToString();
					string Preci=row["Preci"].ToString();
					string Scale=row["Scale"].ToString();
					string ispk=row["isPK"].ToString();	
					string isnull=row["IsNull"].ToString();
					string defaultVal=row["defaultVal"].ToString();
                    //if (Length.Trim() == "-1")
                    //{
                    //    Length = "MAX";
                    //}

					strclass.Append("["+columnName+"] ["+columnType+"] ");
					if(IsIdentity=="��")
					{
						IsIden=true;
						strclass.Append(" IDENTITY (1, 1) ");
					}
					switch(columnType.Trim())
					{
                        case "varchar":
                        case "char":
                        case "nchar":
                        case "binary":                            
                        case "nvarchar":
                        case "varbinary":
                            {
                                string len = CodeCommon.GetDataTypeLenVal(columnType.Trim(), Length);
                                strclass.Append(" (" + len + ")");
                            }
                            break;
						case "decimal":	
						case "numeric":		
							strclass.Append(" ("+Preci+","+Scale+")");
							break;						
					}
				    strclass.Append(isnull == "��" ? " NULL" : " NOT NULL");
				    if(defaultVal!="")
					{
						strclass.Append(" DEFAULT "+defaultVal);
					}
					strclass.AppendLine(",");

					FildtabList.Add(columnName,columnType);
					FildList.Append("["+columnName+"],");
					
					//if(defaultVal!="")
					//{
					//	ColdefaVal.Append("CONSTRAINT [DF_"+tableName+"_"+columnName+"] DEFAULT "+defaultVal+" FOR ["+columnName+"],");
					//}

					if((ispk=="��")&&(PKfild==""))
					{						
						PKfild=columnName;//�õ�����
					}
				}
			}
			strclass.DelLastComma();
			FildList.DelLastComma();
			strclass.AppendLine(")");
			strclass.AppendLine("");

			if(PKfild!="")
			{
				strclass.AppendLine("ALTER TABLE "+tableName+" WITH NOCHECK ADD  CONSTRAINT [PK_"+tableName+"] PRIMARY KEY  NONCLUSTERED ( ["+PKfild+"] )");
			}

			#region
			//��������
			//			if((PKfild!="")||(ColdefaVal.Value!=""))
			//			{				
			//				strclass.AppendLine("ALTER TABLE "+tableName+" WITH NOCHECK ADD ");
			//				if(ColdefaVal.Value!="")
			//				{
			//					strclass.Append(ColdefaVal.Value);
			//				}
			//				if(PKfild!="")
			//				{
			//					strclass.Append(" CONSTRAINT [PK_"+tableName+"] PRIMARY KEY  NONCLUSTERED ( ["+PKfild+"] )");
			//				}
			//				else
			//				{
			//					strclass.DelLastComma();
			//				}
			//			}
			#endregion

			//���Զ�������
			if(IsIden)
			{
				strclass.AppendLine("SET IDENTITY_INSERT "+tableName+" ON");
				strclass.AppendLine("");
			}

			//��ȡ����
			DataTable dtdata=dbobj.GetTabData(dbName,tableName);
			if(dtdata!=null)
			{				
				foreach(DataRow row in dtdata.Rows)//ѭ��������
				{	
					StringPlus strfild=new StringPlus();
					StringPlus strdata=new StringPlus();
					string [] split= FildList.Value.Split(new Char [] { ','});

					foreach(string fild in split)//ѭ��һ�����ݵĸ����ֶ�
					{
						string colname=fild.Substring(1,fild.Length-2);
						string coltype="";
						foreach (DictionaryEntry myDE in FildtabList.Cast<DictionaryEntry>().Where(myDE => myDE.Key.ToString()==colname))
						{
						    coltype=myDE.Value.ToString();
						}	
						string strval="";
						switch(coltype)
						{
							case "binary":
							{
								byte[] bys=(byte[])row[colname];
								strval=CodeCommon.ToHexString(bys);
							}
								break;
							case "bit":
							{
								strval=(row[colname].ToString().ToLower()=="true")?"1":"0";
							}
								break;
							default:
								strval=row[colname].ToString().Trim();
								break;
						}
						if(strval!="")
						{
                            if (CodeCommon.IsAddMark(coltype))
							{
								strdata.Append("'"+strval+"',");
							}
							else
							{
								strdata.Append(strval+",");
							}	
							strfild.Append("["+colname+"],");
						}

					}					
					strfild.DelLastComma();
					strdata.DelLastComma();
					//��������INSERT���
					strclass.Append("INSERT "+tableName+" (");
					strclass.Append(strfild.Value);
					strclass.Append(") VALUES ( ");
					strclass.Append(strdata.Value);//����ֵ
					strclass.AppendLine(")");
				}
			}
			if(IsIden)
			{
				strclass.AppendLine("");
				strclass.AppendLine("SET IDENTITY_INSERT "+tableName+" OFF");
			}

			return strclass.Value;

		}
        #endregion

        #region public string CreateTabScriptBySQL(string dbName, string strSQL) ����SQL��ѯ����������ݴ����ű�
        /// <summary>
        /// ����SQL��ѯ����������ݴ����ű�
        /// </summary>
        /// <param name="dbName">���ݿ�����</param>
        /// <param name="strSql">sql���</param>
        /// <returns></returns>
        public string CreateTabScriptBySQL(string dbName, string strSql)
        {
            dbobj.DbConnectStr = _dbconnectStr;                      
            string PKfild = "";//�����ֶ�
            bool IsIden = false;//�Ƿ��Ǳ�ʶ�ֶ�
            string tableName = "TableName";
            StringPlus strclass = new StringPlus();

            #region ��ѯ����
            int ns = strSql.IndexOf(" from ");
            if (ns > 0)
            {
                string sqltemp = strSql.Substring(ns + 5).Trim();
                int ns2 = sqltemp.IndexOf(" ");
                if (sqltemp.Length > 0)
                {
                    tableName = ns2 > 0 ? sqltemp.Substring(0, ns2).Trim() : sqltemp.Substring(0).Trim();
                }
            }
            tableName=tableName.Replace("[", "").Replace("]", "");

            #endregion

            #region ���ݽű�
            //��ȡ����
            DataTable dtdata = dbobj.GetTabDataBySQL(dbName, strSql);  
           
            if (dtdata != null)
            {
                DataColumnCollection dtcols=dtdata.Columns;

                foreach (DataRow row in dtdata.Rows)//ѭ��������
                {                    
                    StringPlus strfild = new StringPlus();
                    StringPlus strdata = new StringPlus();
                    foreach (DataColumn col in dtcols)//ѭ��һ�����ݵĸ����ֶ�
                    {
                        string colname = col.ColumnName;
                        string coltype = col.DataType.Name;
                        if (col.AutoIncrement)
                        {
                            IsIden = true;
                        }
                        string strval = "";
                        switch (coltype.ToLower())
                        {
                            case "binary":
                            case "byte[]":
                                {
                                    byte[] bys = (byte[])row[colname];
                                    strval = CodeCommon.ToHexString(bys);
                                }
                                break;
                            case "bit":
                            case "boolean":
                                {
                                    strval = (row[colname].ToString().ToLower() == "true") ? "1" : "0";
                                }
                                break;
                            default:
                                strval = row[colname].ToString().Trim();
                                break;
                        }
                        if (strval != "")
                        {
                            if (CodeCommon.IsAddMark(coltype))
                            {
                                strdata.Append("'" + strval + "',");
                            }
                            else
                            {
                                strdata.Append(strval + ",");
                            }
                            strfild.Append("[" + colname + "],");
                        }

                    }
                    strfild.DelLastComma();
                    strdata.DelLastComma();
                    //��������INSERT���
                    strclass.Append("INSERT [" + tableName + "] (");
                    strclass.Append(strfild.Value);
                    strclass.Append(") VALUES ( ");
                    strclass.Append(strdata.Value);//����ֵ
                    strclass.AppendLine(")");
                }
            }
       
            StringPlus strclass0 = new StringPlus();
            if (IsIden)
            {
                strclass0.AppendLine("SET IDENTITY_INSERT [" + tableName + "] ON");
                strclass0.AppendLine("");
            }
            strclass0.AppendLine(strclass.Value);
            if (IsIden)
            {               
                strclass0.AppendLine("");
                strclass0.AppendLine("SET IDENTITY_INSERT [" + tableName + "] OFF");
            }
            #endregion

            return strclass0.Value;
        }
        #endregion

        #region public void CreateTabScript(string dbName,string tableName,string filename,System.Windows.Forms.ProgressBar progressBar) �������ݿ�����ű����ļ�
        /// <summary>
        /// �������ݿ�����ű����ļ�
		/// </summary>
        /// <param name="dbName">���ݿ�����</param>
        /// <param name="tableName">������</param>
		/// <param name="filename">�ļ�����</param>
		/// <param name="progressBar">������</param>
		public void CreateTabScript(string dbName,string tableName,string filename,System.Windows.Forms.ProgressBar progressBar)
		{
            using (StreamWriter sw = new StreamWriter(filename, true, Encoding.Default))
            {
                dbobj.DbConnectStr = _dbconnectStr;
                //DataTable dt=dbobj.GetColumnInfoList(dbName,tableName);

                List<ColumnInfo> collist = dbobj.GetColumnInfoList(dbName, tableName);

                StringPlus strclass = new StringPlus();
                strclass.AppendLine("if exists (select * from sysobjects where id = OBJECT_ID('[" + tableName + "]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) ");
                strclass.AppendLine("DROP TABLE [" + tableName + "]");

                string PKfild = "";//�����ֶ�
                bool IsIden = false;//�Ƿ��Ǳ�ʶ�ֶ�
                StringPlus ColdefaVal = new StringPlus();//�ֶε�Ĭ��ֵ�б�			
                Hashtable FildtabList = new Hashtable();//�ֶ��б�
                StringPlus FildList = new StringPlus();//�ֶ��б�

                #region �����Ľű�

                //��ʼ������
                strclass.AppendLine("");
                strclass.AppendLine("CREATE TABLE [" + tableName + "] (");
                if ((collist != null) && (collist.Count > 0))
                {
                    int i = 0;
                    progressBar.Maximum = collist.Count;
                    foreach (ColumnInfo col in collist)
                    {
                        i++;
                        progressBar.Value = i;

                        string columnName = col.ColumnName;
                        string columnType = col.TypeName;
                        bool IsIdentity = col.IsIdentity;
                        string Length = col.Length;
                        string Preci = col.Preci;
                        string Scale = col.Scale;
                        bool ispk = col.IsPK;
                        bool isnull = col.IsNull;
                        string defaultVal = col.DefaultVal;

                        strclass.Append("[" + columnName + "] [" + columnType + "] ");
                        if (IsIdentity)
                        {
                            IsIden = true;
                            strclass.Append(" IDENTITY (1, 1) ");
                        }
                        switch (columnType.Trim())
                        {
                            case "varchar":
                            case "char":
                            case "nchar":
                            case "binary":
                            case "nvarchar":
                            case "varbinary":
                                {
                                    string len = CodeCommon.GetDataTypeLenVal(columnType.Trim(), Length);
                                    strclass.Append(" (" + len + ")");
                                }
                                break;
                            case "decimal":
                            case "numeric":
                                strclass.Append(" (" + Preci + "," + Scale + ")");
                                break;
                        }
                        if (isnull)
                        {
                            strclass.Append(" NULL");
                        }
                        else
                        {
                            strclass.Append(" NOT NULL");
                        }
                        if (defaultVal != "")
                        {
                            strclass.Append(" DEFAULT " + defaultVal);
                        }
                        strclass.AppendLine(",");

                        FildtabList.Add(columnName, columnType);
                        FildList.Append("[" + columnName + "],");

                        if ((ispk) && (PKfild == ""))
                        {
                            PKfild = columnName;//�õ�����
                        }
                    }
                }
                strclass.DelLastComma();
                FildList.DelLastComma();
                strclass.AppendLine(")");
                strclass.AppendLine("");

                if (PKfild != "")
                {
                    strclass.AppendLine("ALTER TABLE [" + tableName + "] WITH NOCHECK ADD  CONSTRAINT [PK_" + tableName + "] PRIMARY KEY  NONCLUSTERED ( [" + PKfild + "] )");
                }

                #endregion

                #region
                //��������
                //			if((PKfild!="")||(ColdefaVal.Value!=""))
                //			{				
                //				strclass.AppendLine("ALTER TABLE "+tableName+" WITH NOCHECK ADD ");
                //				if(ColdefaVal.Value!="")
                //				{
                //					strclass.Append(ColdefaVal.Value);
                //				}
                //				if(PKfild!="")
                //				{
                //					strclass.Append(" CONSTRAINT [PK_"+tableName+"] PRIMARY KEY  NONCLUSTERED ( ["+PKfild+"] )");
                //				}
                //				else
                //				{
                //					strclass.DelLastComma();
                //				}
                //			}
                #endregion

                //���Զ�������
                if (IsIden)
                {
                    strclass.AppendLine("SET IDENTITY_INSERT [" + tableName + "] ON");
                    strclass.AppendLine("");
                }
                sw.Write(strclass.Value);

                #region �������ݽű�

                //��ȡ����
                DataTable dtdata = dbobj.GetTabData(dbName, tableName);
                if (dtdata != null)
                {
                    int i = 0;
                    progressBar.Maximum = dtdata.Rows.Count;
                    foreach (DataRow row in dtdata.Rows)//ѭ��������
                    {
                        i++;
                        progressBar.Value = i;

                        StringPlus rowdata = new StringPlus();

                        StringPlus strfild = new StringPlus();
                        StringPlus strdata = new StringPlus();
                        string[] split = FildList.Value.Split(new Char[] { ',' });

                        foreach (string fild in split)//ѭ��һ�����ݵĸ����ֶ�
                        {
                            string colname = fild.Substring(1, fild.Length - 2);
                            string coltype = "";
                            foreach (DictionaryEntry myDe in FildtabList.Cast<DictionaryEntry>().Where(myDE => myDE.Key.ToString() == colname))
                            {
                                coltype = myDe.Value.ToString();
                            }
                            string strval = "";
                            switch (coltype)
                            {
                                case "binary":
                                    {
                                        byte[] bys = (byte[])row[colname];
                                        strval = CodeCommon.ToHexString(bys);
                                    }
                                    break;
                                case "bit":
                                    {
                                        strval = (row[colname].ToString().ToLower() == "true") ? "1" : "0";
                                    }
                                    break;
                                default:
                                    strval = row[colname].ToString().Trim();
                                    break;
                            }
                            if (strval != "")
                            {
                                if (CodeCommon.IsAddMark(coltype))
                                {
                                    strdata.Append("'" + strval + "',");
                                }
                                else
                                {
                                    strdata.Append(strval + ",");
                                }
                                strfild.Append("[" + colname + "],");
                            }

                        }
                        strfild.DelLastComma();
                        strdata.DelLastComma();

                        //��������INSERT���
                        rowdata.Append("INSERT [" + tableName + "] (");
                        rowdata.Append(strfild.Value);
                        rowdata.Append(") VALUES ( ");
                        rowdata.Append(strdata.Value);//����ֵ
                        rowdata.AppendLine(")");

                        sw.Write(rowdata.Value);
                    }
                }

                #endregion

                if (IsIden)
                {
                    StringPlus strend = new StringPlus();
                    strend.AppendLine("");
                    strend.AppendLine("SET IDENTITY_INSERT [" + tableName + "] OFF");
                    sw.Write(strend.Value);
                }
                sw.Flush();
                sw.Close();
            }
		}
        #endregion

        #endregion

        #region �����洢����
        /// <summary>
        /// �õ�һ���������б�Ĵ洢����
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public string GetPROCCode(string dbName)
        {
            dbobj.DbConnectStr = this.DbConnectStr;
            StringPlus strclass = new StringPlus();
            List<string> tabNames = dbobj.GetTables(dbName);
            if (tabNames.Count > 0)
            {
                foreach (string tabname in tabNames)
                {
                    strclass.AppendLine(GetPROCCode(dbName, tabname));
                }
            }
            return strclass.Value;
        }
        /// <summary>
        /// �õ�ĳ����Ĵ洢����
        /// </summary>
        /// <param name="dbName">����</param>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        public string GetPROCCode(string dbName, string tableName)
        {
            dbobj.DbConnectStr = _dbconnectStr;           
            Fieldlist = dbobj.GetColumnInfoList(dbName, tableName);
            DataTable dtkey = dbobj.GetKeyName(dbName, tableName);
            DbName = dbName;
            TableName = tableName;
            //Fieldlist = CodeCommon.GetColumnInfos(dt);
            Keys = CodeCommon.GetColumnInfos(dtkey);
            foreach (ColumnInfo key in Keys)
            {
                _key = key.ColumnName;
                _keyType = key.TypeName;
                if (key.IsIdentity)
                {
                    _key = key.ColumnName;
                    _keyType = CodeCommon.DbTypeToCS(key.TypeName);
                    break;
                }
            }            
            return GetPROCCode(true, true, true, true, true, true, true);
        }

        /// <summary>
        /// �õ�ĳ����Ĵ洢���̣�ѡ�����ɵķ�����
        /// </summary>
        public string GetPROCCode(bool Maxid, bool Ishas, bool Add, bool Update, bool Delete, bool GetModel, bool List)
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("/******************************************************************");
            strclass.AppendLine("* ������" + _tableName);
            strclass.AppendLine("* ʱ�䣺" + DateTime.Now.ToString());
            strclass.AppendLine("* Made by RDIFramework.NET ƽ̨����������");
            strclass.AppendLine("******************************************************************/");
            strclass.AppendLine("");
            #region  ��������
            if (Maxid)
            {
                strclass.AppendLine(CreatPROCGetMaxID());
            }
            if (Ishas)
            {
                strclass.AppendLine(CreatPROCIsHas());
            }
            if (Add)
            {
                strclass.AppendLine(CreatPROCADD());
            }
            if (Update)
            {
                strclass.AppendLine(CreatPROCUpdate());
            }
            if (Delete)
            {
                strclass.AppendLine(CreatPROCDelete());
            }
            if (GetModel)
            {
                strclass.AppendLine(CreatPROCGetEntity());
            }
            if (List)
            {
                strclass.AppendLine(CreatPROCGetList());
            }            
            #endregion
            return strclass.Value;
        }        
        
        public string CreatPROCGetMaxID()
		{
            StringPlus strclass = new StringPlus();
            if (_keys.Count > 0)
            {
                string keyname = "";
                foreach (ColumnInfo obj in _keys)
                {
                    if (CodeCommon.DbTypeToCS(obj.TypeName) == "int")
                    {
                        keyname = obj.ColumnName;
                        if (obj.IsPK)
                        {
                            strclass.Append("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[");
                            strclass.Append("" + ProcPrefix + "" + _tableName + "_GetMaxId");
                            strclass.AppendLine("]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
                            strclass.AppendLine("drop procedure [dbo].[" + ProcPrefix + "" + _tableName + "_GetMaxId]");
                            strclass.AppendLine("GO");
                            strclass.AppendLine("------------------------------------");
                            strclass.AppendLine("--��;���õ������ֶ����ֵ ");
                            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
                            strclass.AppendLine("--˵����");
                            strclass.AppendLine("--ʱ�䣺" + DateTime.Now.ToString());
                            strclass.AppendLine("------------------------------------");
                            strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + "" + _tableName + "_GetMaxId");
                            strclass.AppendLine("AS");
                            strclass.AppendSpaceLine(1, "DECLARE @TempID int");
                            strclass.AppendSpaceLine(1, "SELECT @TempID = max([" + keyname + "])+1 FROM [" + _tableName+"]");
                            strclass.AppendSpaceLine(1, "IF @TempID IS NULL");
                            strclass.AppendSpaceLine(2, "RETURN 1");
                            strclass.AppendSpaceLine(1, "ELSE");
                            strclass.AppendSpaceLine(2, "RETURN @TempID");
                            strclass.AppendLine("");
                            strclass.AppendLine("GO");		
                            break;
                        }
                    }
                }
            }
            return strclass.ToString();			
		}
        public string CreatPROCIsHas()
		{						
			StringPlus strclass=new StringPlus();			
			
			strclass.Append("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[");
			strclass.Append("" + ProcPrefix + ""+_tableName+"_Exists");
			strclass.AppendLine("]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
			strclass.AppendLine("drop procedure [dbo].[" + ProcPrefix + ""+_tableName+"_Exists]");
			strclass.AppendLine("GO");
            strclass.AppendLine("------------------------------------");
            strclass.AppendLine("--��;���Ƿ��Ѿ����� ");
            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
            strclass.AppendLine("--˵����");
            strclass.AppendLine("--ʱ�䣺" + DateTime.Now.ToString());
            strclass.AppendLine("------------------------------------");
			strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + ""+_tableName+"_Exists");

            strclass.AppendLine(GetInParameter(Keys, false));
                       
			strclass.AppendLine("AS");
			strclass.AppendSpaceLine(1,"DECLARE @TempID int");
            strclass.AppendSpaceLine(1, "SELECT @TempID = count(1) FROM [" + _tableName + "] WHERE " + GetWhereExpression(Keys));
			strclass.AppendSpaceLine(1,"IF @TempID = 0");
			strclass.AppendSpaceLine(2,"RETURN 0");		
			strclass.AppendSpaceLine(1,"ELSE");		
			strclass.AppendSpaceLine(2,"RETURN 1");		
			strclass.AppendLine("");	
			strclass.AppendLine("GO");		
			return strclass.Value;
		}
		public string CreatPROCADD()
		{						
			StringPlus strclass=new StringPlus();
			StringPlus strclass1=new StringPlus();
			StringPlus strclass2=new StringPlus();			
			
			strclass.Append("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[");
			strclass.Append("" + ProcPrefix + ""+_tableName+"_ADD");
			strclass.AppendLine("]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
			strclass.AppendLine("drop procedure [dbo].[" + ProcPrefix + ""+_tableName+"_ADD]");
			strclass.AppendLine("GO");
            strclass.AppendLine("------------------------------------");
            strclass.AppendLine("--��;������һ����¼ ");
            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
            strclass.AppendLine("--˵����");
            strclass.AppendLine("--ʱ�䣺" + DateTime.Now.ToString());
            strclass.AppendLine("------------------------------------");
			strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + ""+_tableName+"_ADD");

            strclass.AppendLine(GetInParameter(Fieldlist, true));

            foreach (ColumnInfo field in Fieldlist)
            {
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                bool IsIdentity = field.IsIdentity;
                bool IsPK = field.IsPK;
                string Length = field.Length;
                string Preci = field.Preci;
                string Scale = field.Scale;                			
				
                if (IsIdentity)
                {
                    _key = columnName;
                    _keyType = columnType;
                    continue;
                }
                strclass1.Append("[" + columnName + "],");
                strclass2.Append("@" + columnName + ",");
			}			
			
			strclass1.DelLastComma();
			strclass2.DelLastComma();
			strclass.AppendLine("");
			strclass.AppendLine(" AS ");
			strclass.AppendSpaceLine(1,"INSERT INTO ["+_tableName+"](");
			strclass.AppendSpaceLine(1,strclass1.Value);
			strclass.AppendSpaceLine(1,")VALUES(");
			strclass.AppendSpaceLine(1,strclass2.Value);		
			strclass.AppendSpaceLine(1,")");
            if (IsHasIdentity) 
			{
                strclass.AppendSpaceLine(1, "SET @" + _key + " = @@IDENTITY");		
			}
			strclass.AppendLine("");	
			strclass.AppendLine("GO");		
			return strclass.Value;
		}
		public string CreatPROCUpdate()
		{						
			StringPlus strclass=new StringPlus();
			StringPlus strclass1=new StringPlus();						
			
			strclass.Append("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[");
			strclass.Append("" + ProcPrefix + ""+_tableName+"_Update");
			strclass.AppendLine("]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
			strclass.AppendLine("drop procedure [dbo].[" + ProcPrefix + ""+_tableName+"_Update]");
			strclass.AppendLine("GO");
            strclass.AppendLine("------------------------------------");
            strclass.AppendLine("--��;���޸�һ����¼ ");
            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
            strclass.AppendLine("--˵����");
            strclass.AppendLine("--ʱ�䣺" + DateTime.Now.ToString());
            strclass.AppendLine("------------------------------------");
			strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + ""+_tableName+"_Update");

            foreach (ColumnInfo field in Fieldlist)
			{				
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                bool IsIdentity = field.IsIdentity;
                bool IsPK = field.IsPK;
                string Length = field.Length;
                string Preci = field.Preci;
                string Scale = field.Scale;
                //if (Length == "-1")
                //{
                //    Length = "max";
                //}
				switch(columnType.ToLower())
				{
					case "decimal":
					case "numeric":
						strclass.AppendLine("@"+columnName+" "+columnType+"("+Preci+","+Scale+"),");
						break;
                    case "varchar":
                    case "char":
                    case "nchar":
                    case "binary":
                    case "nvarchar":
                    case "varbinary":
                        {
                            string len = CodeCommon.GetDataTypeLenVal(columnType.Trim(), Length);
                            strclass.AppendLine("@" + columnName + " " + columnType + "(" + len + "),");
                        }
                        break;
					default:
						strclass.AppendLine("@"+columnName+" "+columnType+",");
						break;
				}
                if ((IsIdentity) || (IsPK))
				{					
					continue;					
				}					
				strclass1.Append("["+columnName+"] = @"+columnName+",");
			}			
			strclass.DelLastComma();
			strclass1.DelLastComma();
			strclass.AppendLine();
			strclass.AppendLine(" AS ");
			strclass.AppendSpaceLine(1,"UPDATE ["+_tableName+"] SET ");
			strclass.AppendSpaceLine(1,strclass1.Value);
            strclass.AppendSpaceLine(1, "WHERE " + GetWhereExpression(Keys));	
			strclass.AppendLine();	
			strclass.AppendLine("GO");		
			return strclass.Value;
		}

        public string CreatPROCDelete()
		{					
			StringPlus strclass=new StringPlus();
						
			strclass.Append("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[");
			strclass.Append("" + ProcPrefix + ""+_tableName+"_Delete");
			strclass.AppendLine("]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
			strclass.AppendLine("drop procedure [dbo].[" + ProcPrefix + ""+_tableName+"_Delete]");
			strclass.AppendLine("GO");
            strclass.AppendLine("------------------------------------");
            strclass.AppendLine("--��;��ɾ��һ����¼ ");
            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
            strclass.AppendLine("--˵����");
            strclass.AppendLine("--ʱ�䣺" + DateTime.Now.ToString());
            strclass.AppendLine("------------------------------------");
			strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + ""+_tableName+"_Delete");

            strclass.AppendLine(GetInParameter(Keys, false));

			strclass.AppendLine(" AS ");
			strclass.AppendSpaceLine(1,"DELETE ["+_tableName+"]");
            strclass.AppendSpaceLine(1, " WHERE " + GetWhereExpression(Keys));	
			strclass.AppendLine("");	
			strclass.AppendLine("GO");		
			return strclass.Value;
			
		}
        public string CreatPROCGetEntity()
		{		
			StringPlus strclass=new StringPlus();			
			strclass.Append("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[");
            strclass.Append("" + ProcPrefix + "" + _tableName + "GetEntity");
			strclass.AppendLine("]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
            strclass.AppendLine("drop procedure [dbo].[" + ProcPrefix + "" + _tableName + "GetEntity]");
			strclass.AppendLine("GO");
            strclass.AppendLine("------------------------------------");
            strclass.AppendLine("--��;���õ�ʵ��������ϸ��Ϣ ");
            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
            strclass.AppendLine("--˵����");
            strclass.AppendLine("--ʱ�䣺" + DateTime.Now.ToString());
            strclass.AppendLine("------------------------------------");

            strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + "" + _tableName + "GetEntity");

            strclass.AppendLine(GetInParameter(Keys, false));
            
			strclass.AppendLine(" AS ");
            strclass.AppendSpaceLine(1, "SELECT ");
            strclass.AppendSpaceLine(1, Fieldstrlist);
            strclass.AppendSpaceLine(1, " FROM [" + _tableName+"]");
            strclass.AppendSpaceLine(1, " WHERE " + GetWhereExpression(Keys));	
			strclass.AppendLine("");	
			strclass.AppendLine("GO");		
			return strclass.Value;
			
		}
		public string CreatPROCGetList()
		{						
			StringPlus strclass=new StringPlus();
						
			strclass.Append("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[");
			strclass.Append("" + ProcPrefix + ""+_tableName+"_GetList");
			strclass.AppendLine("]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
			strclass.AppendLine("drop procedure [dbo].[" + ProcPrefix + ""+_tableName+"_GetList]");
			strclass.AppendLine("GO");
            strclass.AppendLine("------------------------------------");
            strclass.AppendLine("--��;����ѯ��¼��Ϣ ");
            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
            strclass.AppendLine("--˵����");
            strclass.AppendLine("--ʱ�䣺" + DateTime.Now.ToString());
            strclass.AppendLine("------------------------------------");                        
			strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + ""+_tableName+"_GetList");						
			strclass.AppendLine(" AS ");
			strclass.AppendSpaceLine(1,"SELECT ");
            strclass.AppendSpaceLine(1, Fieldstrlist);			
			strclass.AppendSpaceLine(1," FROM ["+_tableName+"]");			
			//strclass.AppendSpaceLine(1," WHERE ");
			strclass.AppendLine("");	
			strclass.AppendLine("GO");		
			return strclass.Value;
			
		}		
		
		#endregion

        #region ����SQL��ѯ���

        /// <summary>
        /// ����Select��ѯ���
        /// </summary>
        /// <param name="dbName">����</param>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        public string GetSQLSelect(string dbName, string tableName)
        {
            dbobj.DbConnectStr = _dbconnectStr;
            List<ColumnInfo> collist = dbobj.GetColumnList(dbName, tableName);

            this.DbName = dbName;
            this.TableName = tableName;
            StringPlus strsql = new StringPlus();
            strsql.AppendLine("select ");

            if ((collist != null) && (collist.Count > 0))
            {
                foreach (ColumnInfo col in collist)
                {
                    strsql.AppendSpaceLine(1, " [" + col.ColumnName + "],");
                }
                strsql.DelLastComma();
            }
            else
            {
                strsql.AppendSpaceLine(1, " *");
            }
            strsql.AppendLine("");
            strsql.AppendLine(" from [" + tableName + "]");
            return strsql.Value;
        }

        /// <summary>
        /// ����update��ѯ���
        /// </summary>
        /// <param name="dbName">����</param>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        public string GetSQLUpdate(string dbName, string tableName)
        {
            dbobj.DbConnectStr = _dbconnectStr;
            List<ColumnInfo> collist = dbobj.GetColumnList(dbName, tableName);

            this.DbName = dbName;
            this.TableName = tableName;
            StringPlus strsql = new StringPlus();
            strsql.AppendLine("update [" + tableName + "] ");
            strsql.AppendSpaceLine(1,"set ");
            if ((collist!=null)&&(collist.Count>0))
            {
                foreach (ColumnInfo col in collist)
                {
                    strsql.AppendSpaceLine(1, "[" + col.ColumnName + "] = <" + col.ColumnName + ">,");
                }
                strsql.DelLastComma();
            }
            strsql.AppendLine();
            strsql.AppendSpaceLine(1, " where <��������>");
            return strsql.Value;
        }

        /// <summary>
        /// ����update��ѯ���
        /// </summary>
        /// <param name="dbName">����</param>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        public string GetSQLDelete(string dbName, string tableName)
        {
            dbobj.DbConnectStr = _dbconnectStr;
            //DataTable dt = dbobj.GetColumnList(dbName, tableName);
            //List<ColumnInfo> collist = dbobj.GetColumnList(dbName, tableName);
            this.DbName = dbName;
            this.TableName = tableName;
            StringPlus strsql = new StringPlus();
            strsql.AppendLine("delete from [" + tableName+"]");
            strsql.Append(" where  <��������>");
            return strsql.Value;
        }

        /// <summary>
        /// ����INSERT��ѯ���
        /// </summary>
        /// <param name="dbName">����</param>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        public string GetSQLInsert(string dbName, string tableName)
        {
            dbobj.DbConnectStr = _dbconnectStr;
            //DataTable dt = dbobj.GetColumnList(dbName, tableName);
            List<ColumnInfo> collist = dbobj.GetColumnList(dbName, tableName);
            this.DbName = dbName;
            this.TableName = tableName;
            StringPlus strsql = new StringPlus();
            StringPlus strsql2 = new StringPlus();
            strsql.AppendLine("INSERT INTO [" + tableName + "] ( ");

            if ((collist!=null)&&(collist.Count>0))
            {
                foreach (ColumnInfo col in collist)
                {                   
                    string columnName = col.ColumnName;
                    string columnType = col.TypeName;
                                        
                    strsql.AppendLine("[" + columnName + "] ,");
                    if (CodeCommon.IsAddMark(columnType))
                    {
                        strsql2.Append("'" + columnName + "',");
                    }
                    else
                    {
                        strsql2.Append(columnName + ",");
                    }
                    
                }
                strsql.DelLastComma();
                strsql2.DelLastComma();
            }
            strsql.Append(") VALUES (" + strsql2.Value + ")");
            return strsql.Value;
        }

        /// <summary>
        /// �������ݿ����Drop���
        /// </summary>
        /// <param name="dbName">���ݿ�����</param>
        /// <param name="dbObjectName">���ݿ��������</param>
        /// <param name="dbobjType">���ݿ�������ͣ�����ͼ���洢���̡������ȣ�</param>
        /// <returns></returns>
        public string GetSqlDrop(string dbName, string dbObjectName, DBObjectType dbobjType)
        {
            string objType = string.Empty;
            switch (dbobjType)
            { 
                case DBObjectType.TABLE:
                    objType = "TABLE";
                    break;
                case DBObjectType.VIEW:
                    objType = "VIEW";
                    break;
                case DBObjectType.PROCEDURE:
                    objType = "PROCEDURE";
                    break;
                case DBObjectType.FUNCTION:
                    objType = "FUNCTION";
                    break;
                case DBObjectType.USER:
                    objType = "USER";
                    break;
                default:
                    objType = string.Empty;
                    break;
            }

            this.DbName = dbName;
            this.TableName = dbObjectName;
            StringPlus strsql = new StringPlus();
            strsql.AppendLine("USE " + dbName);
            strsql.AppendLine("GO");
            strsql.AppendLine();
            strsql.AppendLine();
            strsql.AppendLine("/****** Object:  " + objType + "  " + dbObjectName + " Script Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "******/");
            strsql.AppendLine("DROP " + objType + "  " + dbObjectName);
            strsql.AppendLine("GO");  
            return strsql.Value;
        }
        #endregion
	}
}

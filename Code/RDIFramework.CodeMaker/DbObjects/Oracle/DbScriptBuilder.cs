using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.IO;
using System.Text;

namespace RDIFramework.CodeMaker.DbObjects.Oracle
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
        private string _dbname;
        private string _tablename;
        private string _procprefix;
        private string _projectname;
        private List<ColumnInfo> _fieldlist;
        private List<ColumnInfo> _keys; //�����������ֶ��б� 


        public string DbConnectStr
        {
            set { _dbconnectStr = value; }
            get { return _dbconnectStr; }
        }
        public string DbName
        {
            set { _dbname = value; }
            get { return _dbname; }
        }
        public string TableName
        {
            set { _tablename = value; }
            get { return _tablename; }
        }
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
            set { _fieldlist = value; }
            get { return _fieldlist; }
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

        #region ��������

        /// <summary>
        /// �õ���������������б� (���磺����Exists  Delete  GetModel �Ĳ�������)
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public string GetInParameter(List<ColumnInfo> fieldlist, bool output)
        {
            StringPlus strclass = new StringPlus();

            foreach (ColumnInfo field in fieldlist)
            {
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                bool IsIdentity = field.IsIdentity;
                bool IsPK = field.IsPK;
                string Length = field.Length;
                string Preci = field.Preci;
                string Scale = field.Scale;
                string isout = " ";
                if ((IsIdentity) && (output))
                {
                    isout = " out ";
                }
                switch (columnType.ToLower())
                {
                    case "decimal":
                    case "numeric":
                        strclass.Append("" + columnName + "_in" + isout + columnType + "(" + Preci + "," + Scale + ")");
                        break;
                    case "varchar":
                    case "nvarchar":
                    case "char":
                    case "nchar":
                        strclass.Append("" + columnName + "_in" + isout + columnType + "(" + Length + ")");
                        break; 
                    default:
                        strclass.Append("" + columnName + "_in" + isout + columnType);
                        break;
                }
                if ((IsIdentity) && (output))
                {                    
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
                strclass.Append(key.ColumnName + "= " + key.ColumnName + "_in and ");
            }
            strclass.DelLastChar("and");
            return strclass.Value;
        }
        /// <summary>
        /// �Ƿ��������������ֶ�
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public bool IsKeys(string columnName)
        {
            bool iskey = false;
            foreach (ColumnInfo key in Keys)
            {
                if (key.ColumnName.Trim() == columnName.Trim())
                {
                    iskey = true;
                }
            }
            return iskey;            
        }


        #endregion

		DbObject dbobj=new DbObject();

		public DbScriptBuilder()
		{			
		}

		#region �������ݿ�����ű�

        /// <summary>
        /// �������ݿ����б�Ĵ����ű�
        /// </summary>
        /// <returns></returns>
        public string CreateDBTabScript(string dbname)
        {
            dbobj.DbConnectStr = this.DbConnectStr;
            StringPlus strclass = new StringPlus();
            List<string> tabNames = dbobj.GetTables(dbname);
            if (tabNames.Count > 0)
            {
                foreach (string tabname in tabNames)
                {
                    strclass.AppendLine(CreateTabScript(dbname, tabname));
                }
            }
            return strclass.Value;
        }

		/// <summary>
		/// �������ݿ�����ű�
		/// </summary>
		/// <returns></returns>
		public string CreateTabScript(string dbname,string tablename)
		{
			dbobj.DbConnectStr=_dbconnectStr;
            List<ColumnInfo> collist = dbobj.GetColumnInfoList(dbname, tablename);
            DataTable dt = CodeCommon.GetColumnInfoDt(collist);
			StringPlus strclass=new StringPlus();
			
			string PKfild="";//�����ֶ�
			StringPlus ColdefaVal=new StringPlus();//�ֶε�Ĭ��ֵ�б�			
			
			Hashtable FildtabList=new Hashtable();//�ֶ��б�
			StringPlus FildList=new StringPlus();//�ֶ��б�
                                  

			//��ʼ������
			strclass.AppendLine("");
			strclass.AppendLine("CREATE TABLE \""+tablename+"\" (");
			if(dt!=null)
			{
                DataRow[] dtrows;
                dtrows = Fieldlist.Count > 0 ? dt.Select("ColumnName in (" + Fields + ")", "colorder asc") : dt.Select();
                foreach (DataRow row in dt.Rows)
				{					
					string columnName=row["ColumnName"].ToString();	
					string columnType=row["TypeName"].ToString();				
					string Length=row["Length"].ToString();
					string Preci=row["Preci"].ToString();
					string Scale=row["Scale"].ToString();
					string ispk=row["isPK"].ToString();	
					string isnull=row["isNull"].ToString();
					string defaultVal=row["defaultVal"].ToString();

					strclass.Append("\""+columnName+"\" "+columnType+" ");
					switch(columnType.Trim())
					{	
						case "CHAR":					
						case "VARCHAR2":
						case "NCHAR":
						case "NVARCHAR2":						
							strclass.Append(" ("+Length+")");
							break;
						case "NUMBER":		
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
					FildList.Append("\""+columnName+"\",");
					

					if(PKfild=="")
					{						
						PKfild=columnName;//�õ�����
					}
				}
			}
			strclass.DelLastComma();
			FildList.DelLastComma();
			strclass.AppendLine(")");
			strclass.AppendLine("");

			//��ȡ����
			DataTable dtdata=dbobj.GetTabData(dbname,tablename);
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
						foreach (DictionaryEntry myDe in FildtabList)
						{
							if(myDe.Key.ToString()==colname)
							{
								coltype=myDe.Value.ToString();
							}
						}	
						string strval="";
						switch(coltype)
						{
							case "BLOB":
							{
								byte[] bys=(byte[])row[colname];
                                strval = CodeCommon.ToHexString(bys);
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
							strfild.Append(""+colname+",");
						}

					}					
					strfild.DelLastComma();
					strdata.DelLastComma();
					//��������INSERT���
					strclass.Append("INSERT \""+tablename+"\" (");
					strclass.Append(strfild.Value);
					strclass.Append(") VALUES ( ");
					strclass.Append(strdata.Value);//����ֵ
					strclass.AppendLine(")");
				}
			}


			return strclass.Value;

		}

        /// <summary>
        /// ����SQL��ѯ��� �������ݴ����ű�
        /// </summary>
        /// <returns></returns>
        public string CreateTabScriptBySQL(string dbname, string strSql)
        {
            dbobj.DbConnectStr = _dbconnectStr;
            string PKfild = "";//�����ֶ�
            bool IsIden = false;//�Ƿ��Ǳ�ʶ�ֶ�
            string tablename = "TableName";
            StringPlus strclass = new StringPlus();

            #region ��ѯ����
            int ns = strSql.IndexOf(" from ");
            if (ns > 0)
            {
                string sqltemp = strSql.Substring(ns + 5).Trim();
                int ns2 = sqltemp.IndexOf(" ");
                if (sqltemp.Length > 0)
                {
                    if (ns2 > 0)
                    {
                        tablename = sqltemp.Substring(0, ns2).Trim();
                    }
                    else
                    {
                        tablename = sqltemp.Substring(0).Trim();
                    }
                }
            }
            tablename = tablename.Replace("[", "").Replace("]", "");

            #endregion

            #region ���ݽű�
            
            //��ȡ����
            DataTable dtdata = dbobj.GetTabDataBySQL(dbname, strSql);
            if (dtdata != null)
            {
                DataColumnCollection dtcols = dtdata.Columns;
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
                            case "blob":
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
                            strfild.Append("" + colname + ",");
                        }

                    }
                    strfild.DelLastComma();
                    strdata.DelLastComma();
                    //��������INSERT���
                    strclass.Append("INSERT " + tablename + " (");
                    strclass.Append(strfild.Value);
                    strclass.Append(") VALUES ( ");
                    strclass.Append(strdata.Value);//����ֵ
                    strclass.AppendLine(")");
                }
            }
            //StringPlus strclass0 = new StringPlus();
            //if (IsIden)
            //{
            //    strclass0.AppendLine("SET IDENTITY_INSERT [" + tablename + "] ON");
            //    strclass0.AppendLine("");
            //}
            //strclass0.AppendLine(strclass.Value);
            //if (IsIden)
            //{
            //    strclass0.AppendLine("");
            //    strclass0.AppendLine("SET IDENTITY_INSERT [" + tablename + "] OFF");
            //}
            #endregion
            return strclass.Value;

        }
		/// <summary>
		/// �������ݿ�����ű����ļ�
		/// </summary>
		/// <returns></returns>
		public void CreateTabScript(string dbname,string tablename,string filename,System.Windows.Forms.ProgressBar progressBar)
		{
			StreamWriter sw=new StreamWriter(filename,true,Encoding.Default);//,false);

			dbobj.DbConnectStr=_dbconnectStr;
            List<ColumnInfo> collist = dbobj.GetColumnInfoList(dbname, tablename);
            
			StringPlus strclass=new StringPlus();

			
			string PKfild="";//�����ֶ�
			StringPlus ColdefaVal=new StringPlus();//�ֶε�Ĭ��ֵ�б�
			
			
			Hashtable FildtabList=new Hashtable();//�ֶ��б�
			StringPlus FildList=new StringPlus();//�ֶ��б�
			
			#region �����Ľű�

			//��ʼ������
			strclass.AppendLine("");
			strclass.AppendLine("CREATE TABLE \""+tablename+"\" (");
            if ((collist!=null)&&(collist.Count > 0))
			{
                foreach (ColumnInfo col in collist)
				{				
					
                    string columnName = col.ColumnName;
                    string columnType = col.TypeName;
                    bool IsIdentity = col.IsIdentity;
                    string Length = col.Length;
                    string Preci = col.Preci;
                    string Scale = col.Scale;
                    bool ispk = col.IsPK;
                    bool isnull = col.IsNull;
                    string defaultVal = col.DefaultVal;

					strclass.Append("\""+columnName+"\" "+columnType+" ");					
					switch(columnType.Trim())
					{	
						case "CHAR":					
						case "VARCHAR2":
						case "NCHAR":
						case "NVARCHAR2":						
							strclass.Append(" ("+Length+")");
							break;
						case "NUMBER":		
							strclass.Append(" ("+Preci+","+Scale+")");
							break;							
					}				
					if(isnull)
					{
						strclass.Append(" NULL");
					}
					else
					{
						strclass.Append(" NOT NULL");
					}
					if(defaultVal!="")
					{
						strclass.Append(" DEFAULT "+defaultVal);
					}
					strclass.AppendLine(",");

					FildtabList.Add(columnName,columnType);
					FildList.Append("\""+columnName+"\",");
					
//					if(defaultVal!="")
//					{
//						ColdefaVal.Append("CONSTRAINT [DF_"+tablename+"_"+columnName+"] DEFAULT "+defaultVal+" FOR ["+columnName+"],");
//					}

					if(PKfild=="")
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
				strclass.Append("ALTER TABLE \""+tablename+"\" WITH NOCHECK ADD  CONSTRAINT [PK_"+tablename+"] PRIMARY KEY  NONCLUSTERED ( ["+PKfild+"] )");
			}

			#endregion			

			#region
			//��������
			//			if((PKfild!="")||(ColdefaVal.Value!=""))
			//			{				
			//				strclass.AppendLine("ALTER TABLE ["+tablename+"] WITH NOCHECK ADD ");
			//				if(ColdefaVal.Value!="")
			//				{
			//					strclass.Append(ColdefaVal.Value);
			//				}
			//				if(PKfild!="")
			//				{
			//					strclass.Append(" CONSTRAINT [PK_"+tablename+"] PRIMARY KEY  NONCLUSTERED ( ["+PKfild+"] )");
			//				}
			//				else
			//				{
			//					strclass.DelLastComma();
			//				}
			//			}
			#endregion

			sw.Write(strclass.Value);

			#region �������ݽű�

			//��ȡ����
			DataTable dtdata=dbobj.GetTabData(dbname,tablename);
			if(dtdata!=null)
			{		
				int i=0;				
				progressBar.Maximum=dtdata.Rows.Count;				
				foreach(DataRow row in dtdata.Rows)//ѭ��������
				{						
					progressBar.Value=i;
					i++;
					StringPlus rowdata=new StringPlus();

					StringPlus strfild=new StringPlus();
					StringPlus strdata=new StringPlus();
					string [] split= FildList.Value.Split(new Char [] { ','});

					foreach(string fild in split)//ѭ��һ�����ݵĸ����ֶ�
					{
						string colname=fild.Substring(1,fild.Length-2);
						string coltype="";
						foreach (DictionaryEntry myDE in FildtabList)
						{
							if(myDE.Key.ToString()==colname)
							{
								coltype=myDE.Value.ToString();
							}
						}	
						string strval="";
						switch(coltype)
						{
							case "BLOB":
							{
								byte[] bys=(byte[])row[colname];
                                strval = CodeCommon.ToHexString(bys);
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
							strfild.Append(""+colname+",");
						}

					}					
					strfild.DelLastComma();
					strdata.DelLastComma();

					//��������INSERT���
					rowdata.Append("INSERT \""+tablename+"\" (");
					rowdata.Append(strfild.Value);
					rowdata.Append(") VALUES ( ");
					rowdata.Append(strdata.Value);//����ֵ
					rowdata.AppendLine(")");

					sw.Write(rowdata.Value);
				}
			}

			#endregion

			sw.Flush();
			sw.Close();

		}
		#endregion

		#region �����洢����
        /// <summary>
        /// �õ�һ���������б�Ĵ洢����
        /// </summary>
        /// <param name="DbName"></param>
        /// <returns></returns>
        public string GetPROCCode(string dbname)
        {
            dbobj.DbConnectStr = _dbconnectStr;
            DataTable dt = dbobj.GetTabViews(dbname);
            StringPlus strclass = new StringPlus();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string tabname = row["name"].ToString();
                    strclass.AppendLine(GetPROCCode(dbname, tabname));
                }
            }
            return strclass.Value;
        }
        /// <summary>
        /// �õ�ĳ����Ĵ洢����
        /// </summary>
        /// <param name="dbname">����</param>
        /// <param name="tablename">����</param>
        /// <returns></returns>
        public string GetPROCCode(string dbname, string tablename)
        {            
            dbobj.DbConnectStr = _dbconnectStr;
            Fieldlist = dbobj.GetColumnInfoList(dbname, tablename);
            DataTable dtkey = dbobj.GetKeyName(dbname, tablename);
            DbName = dbname;
            TableName = tablename;
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
            strclass.AppendLine("* ������" + _tablename);
            strclass.AppendLine("* ʱ�䣺" + DateTime.Now.ToString());
            strclass.AppendLine("* Made by Codematic");
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
                            strclass.AppendLine("------------------------------------");
                            strclass.AppendLine("--��;���õ������ֶ����ֵ ");
                            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
                            strclass.AppendLine("--˵����");
                            strclass.AppendLine("--ʱ�䣺" + DateTime.Now.ToString());
                            strclass.AppendLine("------------------------------------");
                            strclass.AppendLine("CREATE OR REPLACE  PROCEDURE " + ProcPrefix + "" + _tablename + "_GetMaxId (");
                            strclass.AppendLine(")");
                            strclass.AppendLine("IS");
                            strclass.AppendLine("TempID Number;");
                            strclass.AppendLine("BEGIN");
                            strclass.AppendSpaceLine(1, "SELECT max(" + keyname + ") into TempID FROM " + _tablename);
                            strclass.AppendSpaceLine(1, "IF NVL(TempID) then");
                            strclass.AppendSpaceLine(2, "RETURN 1;");
                            strclass.AppendSpaceLine(1, "ELSE");
                            strclass.AppendSpaceLine(2, "RETURN TempID;");
                            strclass.AppendSpaceLine(1, "end IF;");
                            strclass.AppendLine("END;");
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
			strclass.AppendLine("------------------------------------");	
			strclass.AppendLine("--��;���Ƿ��Ѿ����� ");
            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
			strclass.AppendLine("--˵����");
			strclass.AppendLine("--ʱ�䣺"+DateTime.Now.ToString());
			strclass.AppendLine("------------------------------------");	
			strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + ""+_tablename+"_Exists (");
            strclass.AppendLine(GetInParameter(Keys, false));
            strclass.AppendLine(")");
			strclass.AppendLine("AS");
            strclass.AppendLine("TempID Number;");
            strclass.AppendLine("BEGIN");
            strclass.AppendSpaceLine(1, "SELECT count(1) into TempID  FROM " + _tablename + " WHERE " + GetWhereExpression(Keys));
            strclass.AppendSpaceLine(1, "IF TempID = 0 then");
			strclass.AppendSpaceLine(2,"RETURN 0;");		
			strclass.AppendSpaceLine(1,"ELSE");		
			strclass.AppendSpaceLine(2,"RETURN 1;");
            strclass.AppendSpaceLine(1, "end IF;");
            strclass.AppendLine("END;");		
			strclass.AppendLine();				
			return strclass.Value;
		}
		public string CreatPROCADD()
		{						
			StringPlus strclass=new StringPlus();
			StringPlus strclass1=new StringPlus();
			StringPlus strclass2=new StringPlus();			
			strclass.AppendLine("------------------------------------");	
			strclass.AppendLine("--��;������һ����¼ ");
            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
			strclass.AppendLine("--˵����");
			strclass.AppendLine("--ʱ�䣺"+DateTime.Now.ToString());
			strclass.AppendLine("------------------------------------");		
			strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + ""+_tablename+"_ADD (");
            strclass.AppendLine(GetInParameter(Keys, true));
            strclass.AppendLine(")");
            foreach (ColumnInfo field in Fieldlist)
            {
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                bool IsIdentity = field.IsIdentity;
                bool IsPK = field.IsPK;
                string Length = field.Length;
                string Preci = field.Preci;
                string Scale = field.Scale;					
				strclass1.Append(columnName+",");
				strclass2.Append(""+columnName+"_in ,");
			}
			strclass1.DelLastComma();
			strclass2.DelLastComma();			
			strclass.AppendLine(" AS ");
            strclass.AppendLine("BEGIN");
			strclass.AppendSpaceLine(1,"INSERT INTO "+_tablename+"(");
			strclass.AppendSpaceLine(1,strclass1.Value);
			strclass.AppendSpaceLine(1,")VALUES(");
			strclass.AppendSpaceLine(1,strclass2.Value);		
			strclass.AppendSpaceLine(1,");");
            strclass.AppendLine("COMMIT;");
            strclass.AppendLine("END;");			
			return strclass.Value;
		}
		public string CreatPROCUpdate()
		{						
			StringPlus strclass=new StringPlus();
			StringPlus strclass1=new StringPlus();						
			strclass.AppendLine("------------------------------------");	
			strclass.AppendLine("--��;���޸�һ����¼ ");
            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
			strclass.AppendLine("--˵����");
			strclass.AppendLine("--ʱ�䣺"+DateTime.Now.ToString());
			strclass.AppendLine("------------------------------------");
			strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + ""+_tablename+"_Update");
            foreach (ColumnInfo field in Fieldlist)
            {
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                bool IsIdentity = field.IsIdentity;
                bool IsPK = field.IsPK;
                string Length = field.Length;
                string Preci = field.Preci;
                string Scale = field.Scale;      
	
				switch(columnType.ToLower())
				{
					case "decimal":
					case "numeric":
						strclass.AppendLine(""+columnName+"_in "+columnType+"("+Preci+","+Scale+"),");
						break;
					case "varchar":
					case "nvarchar":
					case "char":
					case "nchar":	
						strclass.AppendLine(""+columnName+"_in "+columnType+"("+Length+"),");						
						break;
					default:
						strclass.AppendLine(""+columnName+"_in "+columnType+",");
						break;
				}
                if (IsKeys(columnName))
                {
                    continue;
                }						
				strclass1.Append(""+columnName+" = "+columnName+"_in ,");
			}			
			strclass.DelLastComma();
			strclass1.DelLastComma();
			strclass.AppendLine("");
			strclass.AppendLine(" AS ");
            strclass.AppendLine("BEGIN");
			strclass.AppendSpaceLine(1,"UPDATE "+_tablename+" SET ");
			strclass.AppendSpaceLine(1,strclass1.Value);
            strclass.AppendSpaceLine(1, "WHERE " + GetWhereExpression(Keys));	
			strclass.AppendLine("");
            strclass.AppendLine("COMMIT;");
            strclass.AppendLine("END;");
			return strclass.Value;
		}
        public string CreatPROCDelete()
		{					
			StringPlus strclass=new StringPlus();
			StringPlus strclass1=new StringPlus();						
			strclass.AppendLine("------------------------------------");	
			strclass.AppendLine("--��;��ɾ��һ����¼ ");
            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
			strclass.AppendLine("--˵����");
			strclass.AppendLine("--ʱ�䣺"+DateTime.Now.ToString());
			strclass.AppendLine("------------------------------------");
			strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + ""+_tablename+"_Delete");
            strclass.AppendLine(GetInParameter(Keys, false));
            strclass.AppendLine("BEGIN");           
			strclass.AppendLine(" AS ");
			strclass.AppendSpaceLine(1,"DELETE "+_tablename);
            strclass.AppendSpaceLine(1, " WHERE " + GetWhereExpression(Keys));				
            strclass.AppendLine("COMMIT;");
            strclass.AppendLine("END;");
			return strclass.Value;
			
		}

        public string CreatPROCGetEntity()
		{		
			StringPlus strclass=new StringPlus();
			StringPlus strclass1=new StringPlus();						
			strclass.AppendLine("------------------------------------");	
			strclass.AppendLine("--��;���õ�ʵ��������ϸ��Ϣ ");
            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
			strclass.AppendLine("--˵����");
			strclass.AppendLine("--ʱ�䣺"+DateTime.Now.ToString());
			strclass.AppendLine("------------------------------------");            
			strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + ""+_tablename+"_GetModel");
            strclass.AppendLine(GetInParameter(Keys, false));            
			strclass.AppendLine(" AS ");
            strclass.AppendLine("BEGIN");    
            strclass.AppendSpaceLine(1, "SELECT ");
            strclass.AppendSpaceLine(1, Fieldstrlist);
            strclass.AppendSpaceLine(1, " FROM " + _tablename);
            strclass.AppendSpaceLine(1, " WHERE " + GetWhereExpression(Keys));
            strclass.AppendLine("COMMIT;");
            strclass.AppendLine("END;");	
			return strclass.Value;
			
		}

		public string CreatPROCGetList()
		{						
			StringPlus strclass=new StringPlus();
			StringPlus strclass1=new StringPlus();			
			strclass.AppendLine("------------------------------------");	
			strclass.AppendLine("--��;����ѯ��¼��Ϣ ");
            strclass.AppendLine("--��Ŀ���ƣ�" + ProjectName);
			strclass.AppendLine("--˵����");
			strclass.AppendLine("--ʱ�䣺"+DateTime.Now.ToString());
			strclass.AppendLine("------------------------------------");			
			strclass.AppendLine("CREATE PROCEDURE " + ProcPrefix + ""+_tablename+"_GetList");						
			strclass.AppendLine(" AS ");
            strclass.AppendLine("BEGIN");    
			strclass.AppendSpaceLine(1,"SELECT ");
            strclass.AppendSpaceLine(1, Fieldstrlist);			
			strclass.AppendSpaceLine(1," FROM "+_tablename);			
			//strclass.AppendSpaceLine(1," WHERE ");
            strclass.AppendLine("COMMIT;");
            strclass.AppendLine("END;");		
			return strclass.Value;
			
		}
        				
		#endregion

        #region ����SQL��ѯ���

        /// <summary>
        /// ����Select��ѯ���
        /// </summary>
        /// <param name="dbname">����</param>
        /// <param name="tablename">����</param>
        /// <returns></returns>
        public string GetSQLSelect(string dbname, string tablename)
        {
            dbobj.DbConnectStr = _dbconnectStr;            
            List<ColumnInfo> collist = dbobj.GetColumnList(dbname, tablename);

            this.DbName = dbname;
            this.TableName = tablename;
            StringPlus strsql = new StringPlus();
            strsql.Append("select ");
            if ((collist!=null)&&(collist.Count > 0))
            {
                foreach (ColumnInfo col in collist)
                {
                    string columnName = col.ColumnName;
                    strsql.Append("" + columnName + ",");
                }
                strsql.DelLastComma();
            }
            strsql.Append(" from " + tablename);
            return strsql.Value;
        }

        /// <summary>
        /// ����update��ѯ���
        /// </summary>
        /// <param name="dbname">����</param>
        /// <param name="tablename">����</param>
        /// <returns></returns>
        public string GetSQLUpdate(string dbname, string tablename)
        {
            dbobj.DbConnectStr = _dbconnectStr;
            List<ColumnInfo> collist = dbobj.GetColumnList(dbname, tablename);
            this.DbName = dbname;
            this.TableName = tablename;
            StringPlus strsql = new StringPlus();
            strsql.AppendLine("update " + tablename + " set ");
            if ((collist!=null)&&(collist.Count > 0))
            {
                foreach (ColumnInfo col in collist)
                {
                    string columnName = col.ColumnName;
                    strsql.AppendLine("" + columnName + " = <" + columnName + ">,");
                }
                strsql.DelLastComma();
            }
            strsql.Append(" where <��������>");
            return strsql.Value;
        }
        /// <summary>
        /// ����update��ѯ���
        /// </summary>
        /// <param name="dbname">����</param>
        /// <param name="tablename">����</param>
        /// <returns></returns>
        public string GetSQLDelete(string dbname, string tablename)
        {
            dbobj.DbConnectStr = _dbconnectStr;
            //DataTable dt = dbobj.GetColumnList(dbname, tablename);
            this.DbName = dbname;
            this.TableName = tablename;
            StringPlus strsql = new StringPlus();
            strsql.AppendLine("delete from " + tablename);
            strsql.Append(" where  <��������>");
            return strsql.Value;
        }
        /// <summary>
        /// ����INSERT��ѯ���
        /// </summary>
        /// <param name="dbname">����</param>
        /// <param name="tablename">����</param>
        /// <returns></returns>
        public string GetSQLInsert(string dbname, string tablename)
        {
            dbobj.DbConnectStr = _dbconnectStr;
            List<ColumnInfo> collist = dbobj.GetColumnList(dbname, tablename);
            this.DbName = dbname;
            this.TableName = tablename;
            StringPlus strsql = new StringPlus();
            StringPlus strsql2 = new StringPlus();
            strsql.AppendLine("INSERT INTO " + tablename + " ( ");

            if ((collist!=null)&&(collist.Count > 0))
            {
                foreach (ColumnInfo col in collist)
                {
                    string columnName = col.ColumnName;
                    string columnType = col.TypeName;
                    strsql.AppendLine("" + columnName + " ,");
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
            strsql.AppendLine("/****** Object:  " + objType + "  " + dbObjectName + " Script Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "******/");
            strsql.AppendLine("DROP " + objType + "  " + dbObjectName);
            return strsql.Value;
        }
        #endregion
	}
}

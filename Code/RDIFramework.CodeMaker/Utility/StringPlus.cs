using System.Text;

namespace RDIFramework.CodeMaker
{
	/// <summary>
	///string�����ࡣ
	/// </summary>
    public class StringPlus
	{
		StringBuilder str;
		public string Value
		{			
			get
            {
                return str.ToString();
            }
		}

		public StringPlus()
		{
			str=new StringBuilder();
		}

		#region ���ӿո���������
		/// <summary>
		/// ���ӿո���������
		/// </summary>
		/// <param name="num">�����</param>
		/// <returns></returns>
		public string Space(int SpaceNum)
		{			
			StringBuilder strspace=new StringBuilder();
			for(int n=0;n<SpaceNum;n++)
			{
				strspace.Append("\t");
			}
			return strspace.ToString();
		}
		#endregion

		#region �����ı�
		/// <summary>
		/// �����ı�
		/// </summary>
		/// <param name="num"></param>
		/// <returns></returns>
		public string Append(string Text)
		{			
			str.Append(Text);
			return str.ToString();
		}
		#endregion
	
		#region ׷��һ���ı������س����С�
		/// <summary>
		/// ׷�ӻس����С�
		/// </summary>		
		public string AppendLine()
		{			
			str.Append("\r\n");
			return str.ToString();
		}
        /// <summary>
        /// ׷��һ���ı������س����С�
        /// </summary>
        /// <param name="Text">�ı�</param>
        /// <returns></returns>
        public string AppendLine(string Text)
        {
            str.Append(Text + "\r\n");
            return str.ToString();
        }
		#endregion

		#region ׷��һ���ı���ǰ��ӿո�������������س����С�

        /// <summary>
        /// ׷��һ���ı���ǰ��ӿո�����
        /// </summary>
        /// <param name="SpaceNum">�ո�������Ŀ</param>
        /// <param name="Text">�ı�</param>
        /// <returns></returns>
        public string AppendSpace(int SpaceNum, string Text)
        {
            str.Append(Space(SpaceNum));
            str.Append(Text);           
            return str.ToString();
        }
		/// <summary>
		/// ׷��һ���ı���ǰ��ӿո�������������س����С�
		/// </summary>
		/// <param name="SpaceNum">�ո�������Ŀ</param>
		/// <param name="Text">�ı�</param>
		/// <returns></returns>
		public string AppendSpaceLine(int SpaceNum,string Text)
		{			
			str.Append(Space(SpaceNum));
			str.Append(Text);
			str.Append("\r\n");
			return str.ToString();
		}
		public override string ToString()
		{
			return str.ToString();
		}
		
		#endregion

        #region ɾ���ַ�
        /// <summary>
        /// ɾ������β��һ������
        /// </summary>
        public void DelLastComma()
        {
            string strtemp = str.ToString();            
            int n=strtemp.LastIndexOf(",");
            if (n <= 0) return;
            str = new StringBuilder();
            str.Append(strtemp.Substring(0, n));
        }

        /// <summary>
        /// ɾ������β��ָ���ַ�����ַ�
        /// </summary>
        public void DelLastChar(string strchar)
        {
            string strtemp = str.ToString();
            int n = strtemp.LastIndexOf(strchar);
            if (n <= 0) return;
            str = new StringBuilder();
            str.Append(strtemp.Substring(0, n));
        }

    
        /// <summary>
        /// ɾ��ָ��λ�õ��ַ�
        /// </summary>
        /// <param name="Start">��ʼ����</param>
        /// <param name="Num">ɾ������</param>
        public void Remove(int Start, int Num)
        {
            //string strtemp = str.ToString();
            //str = new StringBuilder();
            //str.Append(strtemp.Substring(0, strtemp.LastIndexOf(strchar)));
            str.Remove(Start, Num);
        }

        #endregion

    }
}

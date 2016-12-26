
namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// �ֶ���Ϣ
    /// </summary>
    public class ColumnInfo
    {
        public ColumnInfo()
        {
            ColDescription = "";
            DefaultVal = "";
            Scale = "";
            Preci = "";
            Length = "";
            TypeName = "";
        }

        /// <summary>
        /// ���
        /// </summary>
        public string ColOrder { get; set; }

        /// <summary>
        /// �ֶ���
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// �ֶ�����
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Preci { get; set; }

        /// <summary>
        /// С��λ��
        /// </summary>
        public string Scale { get; set; }

        /// <summary>
        /// �Ƿ��Ǳ�ʶ��
        /// </summary>
        public bool IsIdentity { get; set; }

        /// <summary>
        /// �Ƿ�������
        /// </summary>
        public bool IsPK { get; set; }

        /// <summary>
        /// �Ƿ������
        /// </summary>
        public bool IsNull { get; set; }

        /// <summary>
        /// Ĭ��ֵ
        /// </summary>
        public string DefaultVal { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        public string ColDescription { get; set; }
    }
}

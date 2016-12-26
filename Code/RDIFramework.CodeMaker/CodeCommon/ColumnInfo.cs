
namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// 字段信息
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
        /// 序号
        /// </summary>
        public string ColOrder { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// 精度
        /// </summary>
        public string Preci { get; set; }

        /// <summary>
        /// 小数位数
        /// </summary>
        public string Scale { get; set; }

        /// <summary>
        /// 是否是标识列
        /// </summary>
        public bool IsIdentity { get; set; }

        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsPK { get; set; }

        /// <summary>
        /// 是否允许空
        /// </summary>
        public bool IsNull { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultVal { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string ColDescription { get; set; }
    }
}

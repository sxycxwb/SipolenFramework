namespace RDIFramework.Utilities
{
	/// <summary>
	/// 单元格值的类型
	/// </summary>
	public enum CellValueType : int
	{
		/// <summary>可用 String 表示的，即可调用 ToString() 得到</summary>
		StringDenotable = 0,

		/// <summary>String</summary>
		String = 1,

		/// <summary>DateTime</summary>
		DateTime = 2,

		/// <summary>Boolean</summary>
		Boolean = 3,

		/// <summary>Double，数字的都用 double 表示</summary>
		Double = 4,

		/// <summary>IRichTextString</summary>
		RichText = 5,

		/// <summary>其他，需要自己发现</summary>
		Other = 6,
	}
}

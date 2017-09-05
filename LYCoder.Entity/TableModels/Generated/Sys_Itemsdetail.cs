using System;
namespace LYCoder.Entity
{
	/// <summary>
	/// Sys_Itemsdetail
	/// </summary>
		[TableName("lycoder.sys_itemsdetail")]	
		[PrimaryKey("Id")]
	 
	 
	[ExplicitColumns]
		public partial class Sys_Itemsdetail : DbContext.Record<Sys_Itemsdetail>
	{
			private int _Id = 0;
			/// <summary>
		/// Id
		/// </summary>
		[Column] public int Id
		{ 
			get {	return _Id;	}
			set {	_Id = value; }
		}
			private int _SIDItemId = 0;
			/// <summary>
		/// SIDItemId
		/// </summary>
		[Column] public int SIDItemId
		{ 
			get {	return _SIDItemId;	}
			set {	_SIDItemId = value; }
		}
	 
		private string _SIDEnCode = string.Empty ;
			/// <summary>
		/// SIDEnCode
		/// </summary>
		[Column] public string SIDEnCode
		{ 
			get {	return _SIDEnCode;	}
			set {	_SIDEnCode = value; }
		}
	 
		private string _SIDName = string.Empty ;
			/// <summary>
		/// SIDName
		/// </summary>
		[Column] public string SIDName
		{ 
			get {	return _SIDName;	}
			set {	_SIDName = value; }
		}
			private int _SIDIsDefault = 0;
			/// <summary>
		/// SIDIsDefault
		/// </summary>
		[Column] public int SIDIsDefault
		{ 
			get {	return _SIDIsDefault;	}
			set {	_SIDIsDefault = value; }
		}
			private int _SIDSortCode = 0;
			/// <summary>
		/// SIDSortCode
		/// </summary>
		[Column] public int SIDSortCode
		{ 
			get {	return _SIDSortCode;	}
			set {	_SIDSortCode = value; }
		}
			private int _SIDDeleteMark = 0;
			/// <summary>
		/// SIDDeleteMark
		/// </summary>
		[Column] public int SIDDeleteMark
		{ 
			get {	return _SIDDeleteMark;	}
			set {	_SIDDeleteMark = value; }
		}
			private int _SIDIsEnabled = 0;
			/// <summary>
		/// SIDIsEnabled
		/// </summary>
		[Column] public int SIDIsEnabled
		{ 
			get {	return _SIDIsEnabled;	}
			set {	_SIDIsEnabled = value; }
		}
			private int _SIDCreateUser = 0;
			/// <summary>
		/// SIDCreateUser
		/// </summary>
		[Column] public int SIDCreateUser
		{ 
			get {	return _SIDCreateUser;	}
			set {	_SIDCreateUser = value; }
		}
			private DateTime _SIDCreateTime ;
			/// <summary>
		/// SIDCreateTime
		/// </summary>
		[Column] public DateTime SIDCreateTime
		{ 
			get {	return _SIDCreateTime;	}
			set {	_SIDCreateTime = value; }
		}
			private int _SIDModifyUser = 0;
			/// <summary>
		/// SIDModifyUser
		/// </summary>
		[Column] public int SIDModifyUser
		{ 
			get {	return _SIDModifyUser;	}
			set {	_SIDModifyUser = value; }
		}
			private DateTime _SIDModifyTime ;
			/// <summary>
		/// SIDModifyTime
		/// </summary>
		[Column] public DateTime SIDModifyTime
		{ 
			get {	return _SIDModifyTime;	}
			set {	_SIDModifyTime = value; }
		}
	}

	/// <summary>
	/// Sys_Itemsdetail字段枚举
	/// </summary>
	public enum Sys_ItemsdetailFields
	{
			/// <summary>
		/// Id
		/// </summary>
		Id,
			/// <summary>
		/// SIDItemId
		/// </summary>
		SIDItemId,
			/// <summary>
		/// SIDEnCode
		/// </summary>
		SIDEnCode,
			/// <summary>
		/// SIDName
		/// </summary>
		SIDName,
			/// <summary>
		/// SIDIsDefault
		/// </summary>
		SIDIsDefault,
			/// <summary>
		/// SIDSortCode
		/// </summary>
		SIDSortCode,
			/// <summary>
		/// SIDDeleteMark
		/// </summary>
		SIDDeleteMark,
			/// <summary>
		/// SIDIsEnabled
		/// </summary>
		SIDIsEnabled,
			/// <summary>
		/// SIDCreateUser
		/// </summary>
		SIDCreateUser,
			/// <summary>
		/// SIDCreateTime
		/// </summary>
		SIDCreateTime,
			/// <summary>
		/// SIDModifyUser
		/// </summary>
		SIDModifyUser,
			/// <summary>
		/// SIDModifyTime
		/// </summary>
		SIDModifyTime,
		}
}
	
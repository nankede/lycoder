using System;
namespace LYCoder.Entity
{
	/// <summary>
	/// Sys_Role
	/// </summary>
		[TableName("lycoder.sys_role")]	
		[PrimaryKey("Id")]
	 
	 
	[ExplicitColumns]
		public partial class Sys_Role : DbContext.Record<Sys_Role>
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
			private int _SROrganizeId = 0;
			/// <summary>
		/// SROrganizeId
		/// </summary>
		[Column] public int SROrganizeId
		{ 
			get {	return _SROrganizeId;	}
			set {	_SROrganizeId = value; }
		}
			private int _SRType = 0;
			/// <summary>
		/// SRType
		/// </summary>
		[Column] public int SRType
		{ 
			get {	return _SRType;	}
			set {	_SRType = value; }
		}
	 
		private string _SREnCode = string.Empty ;
			/// <summary>
		/// SREnCode
		/// </summary>
		[Column] public string SREnCode
		{ 
			get {	return _SREnCode;	}
			set {	_SREnCode = value; }
		}
	 
		private string _SRName = string.Empty ;
			/// <summary>
		/// SRName
		/// </summary>
		[Column] public string SRName
		{ 
			get {	return _SRName;	}
			set {	_SRName = value; }
		}
			private int _SRAllowEdit = 0;
			/// <summary>
		/// SRAllowEdit
		/// </summary>
		[Column] public int SRAllowEdit
		{ 
			get {	return _SRAllowEdit;	}
			set {	_SRAllowEdit = value; }
		}
			private int _SRDeleteMark = 0;
			/// <summary>
		/// SRDeleteMark
		/// </summary>
		[Column] public int SRDeleteMark
		{ 
			get {	return _SRDeleteMark;	}
			set {	_SRDeleteMark = value; }
		}
			private int _SRIsEnabled = 0;
			/// <summary>
		/// SRIsEnabled
		/// </summary>
		[Column] public int SRIsEnabled
		{ 
			get {	return _SRIsEnabled;	}
			set {	_SRIsEnabled = value; }
		}
	 
		private string _SRRemark = string.Empty ;
			/// <summary>
		/// SRRemark
		/// </summary>
		[Column] public string SRRemark
		{ 
			get {	return _SRRemark;	}
			set {	_SRRemark = value; }
		}
			private int _SRSortCode = 0;
			/// <summary>
		/// SRSortCode
		/// </summary>
		[Column] public int SRSortCode
		{ 
			get {	return _SRSortCode;	}
			set {	_SRSortCode = value; }
		}
			private int _SRCreateUser = 0;
			/// <summary>
		/// SRCreateUser
		/// </summary>
		[Column] public int SRCreateUser
		{ 
			get {	return _SRCreateUser;	}
			set {	_SRCreateUser = value; }
		}
			private int _SRModifyUser = 0;
			/// <summary>
		/// SRModifyUser
		/// </summary>
		[Column] public int SRModifyUser
		{ 
			get {	return _SRModifyUser;	}
			set {	_SRModifyUser = value; }
		}
			private DateTime _SRCreateTime ;
			/// <summary>
		/// SRCreateTime
		/// </summary>
		[Column] public DateTime SRCreateTime
		{ 
			get {	return _SRCreateTime;	}
			set {	_SRCreateTime = value; }
		}
			private DateTime _SRModifyTime ;
			/// <summary>
		/// SRModifyTime
		/// </summary>
		[Column] public DateTime SRModifyTime
		{ 
			get {	return _SRModifyTime;	}
			set {	_SRModifyTime = value; }
		}
	}

	/// <summary>
	/// Sys_Role字段枚举
	/// </summary>
	public enum Sys_RoleFields
	{
			/// <summary>
		/// Id
		/// </summary>
		Id,
			/// <summary>
		/// SROrganizeId
		/// </summary>
		SROrganizeId,
			/// <summary>
		/// SRType
		/// </summary>
		SRType,
			/// <summary>
		/// SREnCode
		/// </summary>
		SREnCode,
			/// <summary>
		/// SRName
		/// </summary>
		SRName,
			/// <summary>
		/// SRAllowEdit
		/// </summary>
		SRAllowEdit,
			/// <summary>
		/// SRDeleteMark
		/// </summary>
		SRDeleteMark,
			/// <summary>
		/// SRIsEnabled
		/// </summary>
		SRIsEnabled,
			/// <summary>
		/// SRRemark
		/// </summary>
		SRRemark,
			/// <summary>
		/// SRSortCode
		/// </summary>
		SRSortCode,
			/// <summary>
		/// SRCreateUser
		/// </summary>
		SRCreateUser,
			/// <summary>
		/// SRModifyUser
		/// </summary>
		SRModifyUser,
			/// <summary>
		/// SRCreateTime
		/// </summary>
		SRCreateTime,
			/// <summary>
		/// SRModifyTime
		/// </summary>
		SRModifyTime,
		}
}
	
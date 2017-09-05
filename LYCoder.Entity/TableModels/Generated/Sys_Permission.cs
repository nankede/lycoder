using System;
namespace LYCoder.Entity
{
	/// <summary>
	/// Sys_Permission
	/// </summary>
		[TableName("lycoder.sys_permission")]	
		[PrimaryKey("Id")]
	 
	 
	[ExplicitColumns]
		public partial class Sys_Permission : DbContext.Record<Sys_Permission>
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
			private int _SPParentId = 0;
			/// <summary>
		/// SPParentId
		/// </summary>
		[Column] public int SPParentId
		{ 
			get {	return _SPParentId;	}
			set {	_SPParentId = value; }
		}
			private int _SPLayer = 0;
			/// <summary>
		/// SPLayer
		/// </summary>
		[Column] public int SPLayer
		{ 
			get {	return _SPLayer;	}
			set {	_SPLayer = value; }
		}
			private int _SPType = 0;
			/// <summary>
		/// SPType
		/// </summary>
		[Column] public int SPType
		{ 
			get {	return _SPType;	}
			set {	_SPType = value; }
		}
	 
		private string _SPEnCode = string.Empty ;
			/// <summary>
		/// SPEnCode
		/// </summary>
		[Column] public string SPEnCode
		{ 
			get {	return _SPEnCode;	}
			set {	_SPEnCode = value; }
		}
	 
		private string _SPName = string.Empty ;
			/// <summary>
		/// SPName
		/// </summary>
		[Column] public string SPName
		{ 
			get {	return _SPName;	}
			set {	_SPName = value; }
		}
	 
		private string _SPJsEvent = string.Empty ;
			/// <summary>
		/// SPJsEvent
		/// </summary>
		[Column] public string SPJsEvent
		{ 
			get {	return _SPJsEvent;	}
			set {	_SPJsEvent = value; }
		}
	 
		private string _SPIcon = string.Empty ;
			/// <summary>
		/// SPIcon
		/// </summary>
		[Column] public string SPIcon
		{ 
			get {	return _SPIcon;	}
			set {	_SPIcon = value; }
		}
	 
		private string _SPUrl = string.Empty ;
			/// <summary>
		/// SPUrl
		/// </summary>
		[Column] public string SPUrl
		{ 
			get {	return _SPUrl;	}
			set {	_SPUrl = value; }
		}
	 
		private string _SPRemark = string.Empty ;
			/// <summary>
		/// SPRemark
		/// </summary>
		[Column] public string SPRemark
		{ 
			get {	return _SPRemark;	}
			set {	_SPRemark = value; }
		}
			private int _SPSortCode = 0;
			/// <summary>
		/// SPSortCode
		/// </summary>
		[Column] public int SPSortCode
		{ 
			get {	return _SPSortCode;	}
			set {	_SPSortCode = value; }
		}
			private int _SPIsPublic = 0;
			/// <summary>
		/// SPIsPublic
		/// </summary>
		[Column] public int SPIsPublic
		{ 
			get {	return _SPIsPublic;	}
			set {	_SPIsPublic = value; }
		}
			private int _SPIsEnabled = 0;
			/// <summary>
		/// SPIsEnabled
		/// </summary>
		[Column] public int SPIsEnabled
		{ 
			get {	return _SPIsEnabled;	}
			set {	_SPIsEnabled = value; }
		}
			private int _SPIsEdit = 0;
			/// <summary>
		/// SPIsEdit
		/// </summary>
		[Column] public int SPIsEdit
		{ 
			get {	return _SPIsEdit;	}
			set {	_SPIsEdit = value; }
		}
			private int _SPDeleteMark = 0;
			/// <summary>
		/// SPDeleteMark
		/// </summary>
		[Column] public int SPDeleteMark
		{ 
			get {	return _SPDeleteMark;	}
			set {	_SPDeleteMark = value; }
		}
			private int _SPCreateUser = 0;
			/// <summary>
		/// SPCreateUser
		/// </summary>
		[Column] public int SPCreateUser
		{ 
			get {	return _SPCreateUser;	}
			set {	_SPCreateUser = value; }
		}
			private int _SPModifyUser = 0;
			/// <summary>
		/// SPModifyUser
		/// </summary>
		[Column] public int SPModifyUser
		{ 
			get {	return _SPModifyUser;	}
			set {	_SPModifyUser = value; }
		}
			private DateTime _SPCreateTime ;
			/// <summary>
		/// SPCreateTime
		/// </summary>
		[Column] public DateTime SPCreateTime
		{ 
			get {	return _SPCreateTime;	}
			set {	_SPCreateTime = value; }
		}
			private DateTime _SPModifyTime ;
			/// <summary>
		/// SPModifyTime
		/// </summary>
		[Column] public DateTime SPModifyTime
		{ 
			get {	return _SPModifyTime;	}
			set {	_SPModifyTime = value; }
		}
	}

	/// <summary>
	/// Sys_Permission字段枚举
	/// </summary>
	public enum Sys_PermissionFields
	{
			/// <summary>
		/// Id
		/// </summary>
		Id,
			/// <summary>
		/// SPParentId
		/// </summary>
		SPParentId,
			/// <summary>
		/// SPLayer
		/// </summary>
		SPLayer,
			/// <summary>
		/// SPType
		/// </summary>
		SPType,
			/// <summary>
		/// SPEnCode
		/// </summary>
		SPEnCode,
			/// <summary>
		/// SPName
		/// </summary>
		SPName,
			/// <summary>
		/// SPJsEvent
		/// </summary>
		SPJsEvent,
			/// <summary>
		/// SPIcon
		/// </summary>
		SPIcon,
			/// <summary>
		/// SPUrl
		/// </summary>
		SPUrl,
			/// <summary>
		/// SPRemark
		/// </summary>
		SPRemark,
			/// <summary>
		/// SPSortCode
		/// </summary>
		SPSortCode,
			/// <summary>
		/// SPIsPublic
		/// </summary>
		SPIsPublic,
			/// <summary>
		/// SPIsEnabled
		/// </summary>
		SPIsEnabled,
			/// <summary>
		/// SPIsEdit
		/// </summary>
		SPIsEdit,
			/// <summary>
		/// SPDeleteMark
		/// </summary>
		SPDeleteMark,
			/// <summary>
		/// SPCreateUser
		/// </summary>
		SPCreateUser,
			/// <summary>
		/// SPModifyUser
		/// </summary>
		SPModifyUser,
			/// <summary>
		/// SPCreateTime
		/// </summary>
		SPCreateTime,
			/// <summary>
		/// SPModifyTime
		/// </summary>
		SPModifyTime,
		}
}
	
using System;
namespace LYCoder.Entity
{
	/// <summary>
	/// Sys_Organize
	/// </summary>
		[TableName("lycoder.sys_organize")]	
		[PrimaryKey("Id")]
	 
	 
	[ExplicitColumns]
		public partial class Sys_Organize : DbContext.Record<Sys_Organize>
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
			private int _SOParentId = 0;
			/// <summary>
		/// SOParentId
		/// </summary>
		[Column] public int SOParentId
		{ 
			get {	return _SOParentId;	}
			set {	_SOParentId = value; }
		}
			private int _SOLayer = 0;
			/// <summary>
		/// SOLayer
		/// </summary>
		[Column] public int SOLayer
		{ 
			get {	return _SOLayer;	}
			set {	_SOLayer = value; }
		}
			private int _SORootId = 0;
			/// <summary>
		/// SORootId
		/// </summary>
		[Column] public int SORootId
		{ 
			get {	return _SORootId;	}
			set {	_SORootId = value; }
		}
	 
		private string _SOEnCode = string.Empty ;
			/// <summary>
		/// SOEnCode
		/// </summary>
		[Column] public string SOEnCode
		{ 
			get {	return _SOEnCode;	}
			set {	_SOEnCode = value; }
		}
	 
		private string _SOFullName = string.Empty ;
			/// <summary>
		/// SOFullName
		/// </summary>
		[Column] public string SOFullName
		{ 
			get {	return _SOFullName;	}
			set {	_SOFullName = value; }
		}
			private int _SOManagerId = 0;
			/// <summary>
		/// SOManagerId
		/// </summary>
		[Column] public int SOManagerId
		{ 
			get {	return _SOManagerId;	}
			set {	_SOManagerId = value; }
		}
	 
		private string _SOTelePhone = string.Empty ;
			/// <summary>
		/// SOTelePhone
		/// </summary>
		[Column] public string SOTelePhone
		{ 
			get {	return _SOTelePhone;	}
			set {	_SOTelePhone = value; }
		}
	 
		private string _SOWeChat = string.Empty ;
			/// <summary>
		/// SOWeChat
		/// </summary>
		[Column] public string SOWeChat
		{ 
			get {	return _SOWeChat;	}
			set {	_SOWeChat = value; }
		}
	 
		private string _SOFax = string.Empty ;
			/// <summary>
		/// SOFax
		/// </summary>
		[Column] public string SOFax
		{ 
			get {	return _SOFax;	}
			set {	_SOFax = value; }
		}
	 
		private string _SOEmail = string.Empty ;
			/// <summary>
		/// SOEmail
		/// </summary>
		[Column] public string SOEmail
		{ 
			get {	return _SOEmail;	}
			set {	_SOEmail = value; }
		}
	 
		private string _SOAddress = string.Empty ;
			/// <summary>
		/// SOAddress
		/// </summary>
		[Column] public string SOAddress
		{ 
			get {	return _SOAddress;	}
			set {	_SOAddress = value; }
		}
			private int _SOType = 0;
			/// <summary>
		/// SOType
		/// </summary>
		[Column] public int SOType
		{ 
			get {	return _SOType;	}
			set {	_SOType = value; }
		}
			private int _SOSortCode = 0;
			/// <summary>
		/// SOSortCode
		/// </summary>
		[Column] public int SOSortCode
		{ 
			get {	return _SOSortCode;	}
			set {	_SOSortCode = value; }
		}
			private int _SOIsEnabled = 0;
			/// <summary>
		/// SOIsEnabled
		/// </summary>
		[Column] public int SOIsEnabled
		{ 
			get {	return _SOIsEnabled;	}
			set {	_SOIsEnabled = value; }
		}
			private int _SODeleteMark = 0;
			/// <summary>
		/// SODeleteMark
		/// </summary>
		[Column] public int SODeleteMark
		{ 
			get {	return _SODeleteMark;	}
			set {	_SODeleteMark = value; }
		}
	 
		private string _SORemark = string.Empty ;
			/// <summary>
		/// SORemark
		/// </summary>
		[Column] public string SORemark
		{ 
			get {	return _SORemark;	}
			set {	_SORemark = value; }
		}
			private int _SOCreateUser = 0;
			/// <summary>
		/// SOCreateUser
		/// </summary>
		[Column] public int SOCreateUser
		{ 
			get {	return _SOCreateUser;	}
			set {	_SOCreateUser = value; }
		}
			private int _SOModifyUser = 0;
			/// <summary>
		/// SOModifyUser
		/// </summary>
		[Column] public int SOModifyUser
		{ 
			get {	return _SOModifyUser;	}
			set {	_SOModifyUser = value; }
		}
			private DateTime _SOCreateTime ;
			/// <summary>
		/// SOCreateTime
		/// </summary>
		[Column] public DateTime SOCreateTime
		{ 
			get {	return _SOCreateTime;	}
			set {	_SOCreateTime = value; }
		}
			private DateTime _SOModifyTime ;
			/// <summary>
		/// SOModifyTime
		/// </summary>
		[Column] public DateTime SOModifyTime
		{ 
			get {	return _SOModifyTime;	}
			set {	_SOModifyTime = value; }
		}
	}

	/// <summary>
	/// Sys_Organize字段枚举
	/// </summary>
	public enum Sys_OrganizeFields
	{
			/// <summary>
		/// Id
		/// </summary>
		Id,
			/// <summary>
		/// SOParentId
		/// </summary>
		SOParentId,
			/// <summary>
		/// SOLayer
		/// </summary>
		SOLayer,
			/// <summary>
		/// SORootId
		/// </summary>
		SORootId,
			/// <summary>
		/// SOEnCode
		/// </summary>
		SOEnCode,
			/// <summary>
		/// SOFullName
		/// </summary>
		SOFullName,
			/// <summary>
		/// SOManagerId
		/// </summary>
		SOManagerId,
			/// <summary>
		/// SOTelePhone
		/// </summary>
		SOTelePhone,
			/// <summary>
		/// SOWeChat
		/// </summary>
		SOWeChat,
			/// <summary>
		/// SOFax
		/// </summary>
		SOFax,
			/// <summary>
		/// SOEmail
		/// </summary>
		SOEmail,
			/// <summary>
		/// SOAddress
		/// </summary>
		SOAddress,
			/// <summary>
		/// SOType
		/// </summary>
		SOType,
			/// <summary>
		/// SOSortCode
		/// </summary>
		SOSortCode,
			/// <summary>
		/// SOIsEnabled
		/// </summary>
		SOIsEnabled,
			/// <summary>
		/// SODeleteMark
		/// </summary>
		SODeleteMark,
			/// <summary>
		/// SORemark
		/// </summary>
		SORemark,
			/// <summary>
		/// SOCreateUser
		/// </summary>
		SOCreateUser,
			/// <summary>
		/// SOModifyUser
		/// </summary>
		SOModifyUser,
			/// <summary>
		/// SOCreateTime
		/// </summary>
		SOCreateTime,
			/// <summary>
		/// SOModifyTime
		/// </summary>
		SOModifyTime,
		}
}
	
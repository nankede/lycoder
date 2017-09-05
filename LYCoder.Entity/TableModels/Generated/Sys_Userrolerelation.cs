using System;
namespace LYCoder.Entity
{
	/// <summary>
	/// Sys_Userrolerelation
	/// </summary>
		[TableName("lycoder.sys_userrolerelation")]	
		[PrimaryKey("Id")]
	 
	 
	[ExplicitColumns]
		public partial class Sys_Userrolerelation : DbContext.Record<Sys_Userrolerelation>
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
			private int _SURRUserId = 0;
			/// <summary>
		/// SURRUserId
		/// </summary>
		[Column] public int SURRUserId
		{ 
			get {	return _SURRUserId;	}
			set {	_SURRUserId = value; }
		}
			private int _SURRRoleId = 0;
			/// <summary>
		/// SURRRoleId
		/// </summary>
		[Column] public int SURRRoleId
		{ 
			get {	return _SURRRoleId;	}
			set {	_SURRRoleId = value; }
		}
			private int _SURRDeleteMark = 0;
			/// <summary>
		/// SURRDeleteMark
		/// </summary>
		[Column] public int SURRDeleteMark
		{ 
			get {	return _SURRDeleteMark;	}
			set {	_SURRDeleteMark = value; }
		}
			private int _SURRCreateUser = 0;
			/// <summary>
		/// SURRCreateUser
		/// </summary>
		[Column] public int SURRCreateUser
		{ 
			get {	return _SURRCreateUser;	}
			set {	_SURRCreateUser = value; }
		}
			private int _SURRModifyUser = 0;
			/// <summary>
		/// SURRModifyUser
		/// </summary>
		[Column] public int SURRModifyUser
		{ 
			get {	return _SURRModifyUser;	}
			set {	_SURRModifyUser = value; }
		}
			private DateTime _SURRCreateTime ;
			/// <summary>
		/// SURRCreateTime
		/// </summary>
		[Column] public DateTime SURRCreateTime
		{ 
			get {	return _SURRCreateTime;	}
			set {	_SURRCreateTime = value; }
		}
			private DateTime _SURRModifyTime ;
			/// <summary>
		/// SURRModifyTime
		/// </summary>
		[Column] public DateTime SURRModifyTime
		{ 
			get {	return _SURRModifyTime;	}
			set {	_SURRModifyTime = value; }
		}
	}

	/// <summary>
	/// Sys_Userrolerelation字段枚举
	/// </summary>
	public enum Sys_UserrolerelationFields
	{
			/// <summary>
		/// Id
		/// </summary>
		Id,
			/// <summary>
		/// SURRUserId
		/// </summary>
		SURRUserId,
			/// <summary>
		/// SURRRoleId
		/// </summary>
		SURRRoleId,
			/// <summary>
		/// SURRDeleteMark
		/// </summary>
		SURRDeleteMark,
			/// <summary>
		/// SURRCreateUser
		/// </summary>
		SURRCreateUser,
			/// <summary>
		/// SURRModifyUser
		/// </summary>
		SURRModifyUser,
			/// <summary>
		/// SURRCreateTime
		/// </summary>
		SURRCreateTime,
			/// <summary>
		/// SURRModifyTime
		/// </summary>
		SURRModifyTime,
		}
}
	
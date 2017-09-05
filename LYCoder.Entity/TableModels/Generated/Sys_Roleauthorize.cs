using System;
namespace LYCoder.Entity
{
	/// <summary>
	/// Sys_Roleauthorize
	/// </summary>
		[TableName("lycoder.sys_roleauthorize")]	
		[PrimaryKey("Id")]
	 
	 
	[ExplicitColumns]
		public partial class Sys_Roleauthorize : DbContext.Record<Sys_Roleauthorize>
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
			private int _SRARoleId = 0;
			/// <summary>
		/// SRARoleId
		/// </summary>
		[Column] public int SRARoleId
		{ 
			get {	return _SRARoleId;	}
			set {	_SRARoleId = value; }
		}
			private int _SRAModuleId = 0;
			/// <summary>
		/// SRAModuleId
		/// </summary>
		[Column] public int SRAModuleId
		{ 
			get {	return _SRAModuleId;	}
			set {	_SRAModuleId = value; }
		}
			private int _SRACreateUser = 0;
			/// <summary>
		/// SRACreateUser
		/// </summary>
		[Column] public int SRACreateUser
		{ 
			get {	return _SRACreateUser;	}
			set {	_SRACreateUser = value; }
		}
			private DateTime _SRACreateTime ;
			/// <summary>
		/// SRACreateTime
		/// </summary>
		[Column] public DateTime SRACreateTime
		{ 
			get {	return _SRACreateTime;	}
			set {	_SRACreateTime = value; }
		}
	}

	/// <summary>
	/// Sys_Roleauthorize字段枚举
	/// </summary>
	public enum Sys_RoleauthorizeFields
	{
			/// <summary>
		/// Id
		/// </summary>
		Id,
			/// <summary>
		/// SRARoleId
		/// </summary>
		SRARoleId,
			/// <summary>
		/// SRAModuleId
		/// </summary>
		SRAModuleId,
			/// <summary>
		/// SRACreateUser
		/// </summary>
		SRACreateUser,
			/// <summary>
		/// SRACreateTime
		/// </summary>
		SRACreateTime,
		}
}
	
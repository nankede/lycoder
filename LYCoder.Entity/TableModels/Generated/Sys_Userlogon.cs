using System;
namespace LYCoder.Entity
{
	/// <summary>
	/// Sys_Userlogon
	/// </summary>
		[TableName("lycoder.sys_userlogon")]	
		[PrimaryKey("Id")]
	 
	 
	[ExplicitColumns]
		public partial class Sys_Userlogon : DbContext.Record<Sys_Userlogon>
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
			private int _SULUserId = 0;
			/// <summary>
		/// SULUserId
		/// </summary>
		[Column] public int SULUserId
		{ 
			get {	return _SULUserId;	}
			set {	_SULUserId = value; }
		}
	 
		private string _SULLoginName = string.Empty ;
			/// <summary>
		/// SULLoginName
		/// </summary>
		[Column] public string SULLoginName
		{ 
			get {	return _SULLoginName;	}
			set {	_SULLoginName = value; }
		}
	 
		private string _SULPassword = string.Empty ;
			/// <summary>
		/// SULPassword
		/// </summary>
		[Column] public string SULPassword
		{ 
			get {	return _SULPassword;	}
			set {	_SULPassword = value; }
		}
	 
		private string _SULSecretKey = string.Empty ;
			/// <summary>
		/// SULSecretKey
		/// </summary>
		[Column] public string SULSecretKey
		{ 
			get {	return _SULSecretKey;	}
			set {	_SULSecretKey = value; }
		}
			private DateTime _SULPrevVisitTime ;
			/// <summary>
		/// SULPrevVisitTime
		/// </summary>
		[Column] public DateTime SULPrevVisitTime
		{ 
			get {	return _SULPrevVisitTime;	}
			set {	_SULPrevVisitTime = value; }
		}
			private DateTime _SULLastVisitTime ;
			/// <summary>
		/// SULLastVisitTime
		/// </summary>
		[Column] public DateTime SULLastVisitTime
		{ 
			get {	return _SULLastVisitTime;	}
			set {	_SULLastVisitTime = value; }
		}
			private DateTime _SULChangePwdTime ;
			/// <summary>
		/// SULChangePwdTime
		/// </summary>
		[Column] public DateTime SULChangePwdTime
		{ 
			get {	return _SULChangePwdTime;	}
			set {	_SULChangePwdTime = value; }
		}
			private int _SULLoginCount = 0;
			/// <summary>
		/// SULLoginCount
		/// </summary>
		[Column] public int SULLoginCount
		{ 
			get {	return _SULLoginCount;	}
			set {	_SULLoginCount = value; }
		}
			private int _SULAllowMultiUserOnline = 0;
			/// <summary>
		/// SULAllowMultiUserOnline
		/// </summary>
		[Column] public int SULAllowMultiUserOnline
		{ 
			get {	return _SULAllowMultiUserOnline;	}
			set {	_SULAllowMultiUserOnline = value; }
		}
			private int _SULIsOnLine = 0;
			/// <summary>
		/// SULIsOnLine
		/// </summary>
		[Column] public int SULIsOnLine
		{ 
			get {	return _SULIsOnLine;	}
			set {	_SULIsOnLine = value; }
		}
	 
		private string _SULQuestion = string.Empty ;
			/// <summary>
		/// SULQuestion
		/// </summary>
		[Column] public string SULQuestion
		{ 
			get {	return _SULQuestion;	}
			set {	_SULQuestion = value; }
		}
	 
		private string _SULAnswerQuestion = string.Empty ;
			/// <summary>
		/// SULAnswerQuestion
		/// </summary>
		[Column] public string SULAnswerQuestion
		{ 
			get {	return _SULAnswerQuestion;	}
			set {	_SULAnswerQuestion = value; }
		}
			private int _SULCheckIPAddress = 0;
			/// <summary>
		/// SULCheckIPAddress
		/// </summary>
		[Column] public int SULCheckIPAddress
		{ 
			get {	return _SULCheckIPAddress;	}
			set {	_SULCheckIPAddress = value; }
		}
			private int _SULLanguage = 0;
			/// <summary>
		/// SULLanguage
		/// </summary>
		[Column] public int SULLanguage
		{ 
			get {	return _SULLanguage;	}
			set {	_SULLanguage = value; }
		}
			private int _SULTheme = 0;
			/// <summary>
		/// SULTheme
		/// </summary>
		[Column] public int SULTheme
		{ 
			get {	return _SULTheme;	}
			set {	_SULTheme = value; }
		}
	}

	/// <summary>
	/// Sys_Userlogon字段枚举
	/// </summary>
	public enum Sys_UserlogonFields
	{
			/// <summary>
		/// Id
		/// </summary>
		Id,
			/// <summary>
		/// SULUserId
		/// </summary>
		SULUserId,
			/// <summary>
		/// SULLoginName
		/// </summary>
		SULLoginName,
			/// <summary>
		/// SULPassword
		/// </summary>
		SULPassword,
			/// <summary>
		/// SULSecretKey
		/// </summary>
		SULSecretKey,
			/// <summary>
		/// SULPrevVisitTime
		/// </summary>
		SULPrevVisitTime,
			/// <summary>
		/// SULLastVisitTime
		/// </summary>
		SULLastVisitTime,
			/// <summary>
		/// SULChangePwdTime
		/// </summary>
		SULChangePwdTime,
			/// <summary>
		/// SULLoginCount
		/// </summary>
		SULLoginCount,
			/// <summary>
		/// SULAllowMultiUserOnline
		/// </summary>
		SULAllowMultiUserOnline,
			/// <summary>
		/// SULIsOnLine
		/// </summary>
		SULIsOnLine,
			/// <summary>
		/// SULQuestion
		/// </summary>
		SULQuestion,
			/// <summary>
		/// SULAnswerQuestion
		/// </summary>
		SULAnswerQuestion,
			/// <summary>
		/// SULCheckIPAddress
		/// </summary>
		SULCheckIPAddress,
			/// <summary>
		/// SULLanguage
		/// </summary>
		SULLanguage,
			/// <summary>
		/// SULTheme
		/// </summary>
		SULTheme,
		}
}
	
using System;
namespace LYCoder.Entity
{
	/// <summary>
	/// Sys_Log
	/// </summary>
		[TableName("lycoder.sys_log")]	
		[PrimaryKey("Id")]
	 
	 
	[ExplicitColumns]
		public partial class Sys_Log : DbContext.Record<Sys_Log>
	{
			private long _Id = 0;
			/// <summary>
		/// Id
		/// </summary>
		[Column] public long Id
		{ 
			get {	return _Id;	}
			set {	_Id = value; }
		}
	 
		private string _SLLogLevel = string.Empty ;
			/// <summary>
		/// SLLogLevel
		/// </summary>
		[Column] public string SLLogLevel
		{ 
			get {	return _SLLogLevel;	}
			set {	_SLLogLevel = value; }
		}
	 
		private string _SLOperation = string.Empty ;
			/// <summary>
		/// SLOperation
		/// </summary>
		[Column] public string SLOperation
		{ 
			get {	return _SLOperation;	}
			set {	_SLOperation = value; }
		}
	 
		private string _SLMessage = string.Empty ;
			/// <summary>
		/// SLMessage
		/// </summary>
		[Column] public string SLMessage
		{ 
			get {	return _SLMessage;	}
			set {	_SLMessage = value; }
		}
	 
		private string _SLIP = string.Empty ;
			/// <summary>
		/// SLIP
		/// </summary>
		[Column] public string SLIP
		{ 
			get {	return _SLIP;	}
			set {	_SLIP = value; }
		}
	 
		private string _SLIPAddress = string.Empty ;
			/// <summary>
		/// SLIPAddress
		/// </summary>
		[Column] public string SLIPAddress
		{ 
			get {	return _SLIPAddress;	}
			set {	_SLIPAddress = value; }
		}
	 
		private string _SLBrowser = string.Empty ;
			/// <summary>
		/// SLBrowser
		/// </summary>
		[Column] public string SLBrowser
		{ 
			get {	return _SLBrowser;	}
			set {	_SLBrowser = value; }
		}
	 
		private string _SLStackTrace = string.Empty ;
			/// <summary>
		/// SLStackTrace
		/// </summary>
		[Column] public string SLStackTrace
		{ 
			get {	return _SLStackTrace;	}
			set {	_SLStackTrace = value; }
		}
			private int _SLCreateUser = 0;
			/// <summary>
		/// SLCreateUser
		/// </summary>
		[Column] public int SLCreateUser
		{ 
			get {	return _SLCreateUser;	}
			set {	_SLCreateUser = value; }
		}
	 
		private string _SLUserName = string.Empty ;
			/// <summary>
		/// SLUserName
		/// </summary>
		[Column] public string SLUserName
		{ 
			get {	return _SLUserName;	}
			set {	_SLUserName = value; }
		}
			private DateTime _SLCreateTime ;
			/// <summary>
		/// SLCreateTime
		/// </summary>
		[Column] public DateTime SLCreateTime
		{ 
			get {	return _SLCreateTime;	}
			set {	_SLCreateTime = value; }
		}
	}

	/// <summary>
	/// Sys_Log字段枚举
	/// </summary>
	public enum Sys_LogFields
	{
			/// <summary>
		/// Id
		/// </summary>
		Id,
			/// <summary>
		/// SLLogLevel
		/// </summary>
		SLLogLevel,
			/// <summary>
		/// SLOperation
		/// </summary>
		SLOperation,
			/// <summary>
		/// SLMessage
		/// </summary>
		SLMessage,
			/// <summary>
		/// SLIP
		/// </summary>
		SLIP,
			/// <summary>
		/// SLIPAddress
		/// </summary>
		SLIPAddress,
			/// <summary>
		/// SLBrowser
		/// </summary>
		SLBrowser,
			/// <summary>
		/// SLStackTrace
		/// </summary>
		SLStackTrace,
			/// <summary>
		/// SLCreateUser
		/// </summary>
		SLCreateUser,
			/// <summary>
		/// SLUserName
		/// </summary>
		SLUserName,
			/// <summary>
		/// SLCreateTime
		/// </summary>
		SLCreateTime,
		}
}
	
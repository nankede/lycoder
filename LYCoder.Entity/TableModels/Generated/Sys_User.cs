using System;
namespace LYCoder.Entity
{
    /// <summary>
    /// Sys_User
    /// </summary>
    [TableName("lycoder.sys_user")]
    [PrimaryKey("Id")]


    [ExplicitColumns]
    public partial class Sys_User : DbContext.Record<Sys_User>
    {
        private int _Id = 0;
        /// <summary>
        /// Id
        /// </summary>
        [Column]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _SUAccount = string.Empty;
        /// <summary>
        /// SUAccount
        /// </summary>
        [Column]
        public string SUAccount
        {
            get { return _SUAccount; }
            set { _SUAccount = value; }
        }

        private string _SURealName = string.Empty;
        /// <summary>
        /// SURealName
        /// </summary>
        [Column]
        public string SURealName
        {
            get { return _SURealName; }
            set { _SURealName = value; }
        }

        private string _SUNickName = string.Empty;
        /// <summary>
        /// SUNickName
        /// </summary>
        [Column]
        public string SUNickName
        {
            get { return _SUNickName; }
            set { _SUNickName = value; }
        }
        private DateTime _SUBirthday;
        /// <summary>
        /// SUBirthday
        /// </summary>
        [Column]
        public DateTime SUBirthday
        {
            get { return _SUBirthday; }
            set { _SUBirthday = value; }
        }

        private string _SUMobilePhone = string.Empty;
        /// <summary>
        /// SUMobilePhone
        /// </summary>
        [Column]
        public string SUMobilePhone
        {
            get { return _SUMobilePhone; }
            set { _SUMobilePhone = value; }
        }
        private int _SUGender = 0;
        /// <summary>
        /// SUGender
        /// </summary>
        [Column]
        public int SUGender
        {
            get { return _SUGender; }
            set { _SUGender = value; }
        }

        private string _SUAvatar = string.Empty;
        /// <summary>
        /// SUAvatar
        /// </summary>
        [Column]
        public string SUAvatar
        {
            get { return _SUAvatar; }
            set { _SUAvatar = value; }
        }

        private string _SUEmail = string.Empty;
        /// <summary>
        /// SUEmail
        /// </summary>
        [Column]
        public string SUEmail
        {
            get { return _SUEmail; }
            set { _SUEmail = value; }
        }

        private string _SUSignature = string.Empty;
        /// <summary>
        /// SUSignature
        /// </summary>
        [Column]
        public string SUSignature
        {
            get { return _SUSignature; }
            set { _SUSignature = value; }
        }

        private string _SUAddress = string.Empty;
        /// <summary>
        /// SUAddress
        /// </summary>
        [Column]
        public string SUAddress
        {
            get { return _SUAddress; }
            set { _SUAddress = value; }
        }
        private int _SUCompanyId = 0;
        /// <summary>
        /// SUCompanyId
        /// </summary>
        [Column]
        public int SUCompanyId
        {
            get { return _SUCompanyId; }
            set { _SUCompanyId = value; }
        }
        private int _SUDepartmentId = 0;
        /// <summary>
        /// SUDepartmentId
        /// </summary>
        [Column]
        public int SUDepartmentId
        {
            get { return _SUDepartmentId; }
            set { _SUDepartmentId = value; }
        }
        private int _SUIsEnabled = 0;
        /// <summary>
        /// SUIsEnabled
        /// </summary>
        [Column]
        public int SUIsEnabled
        {
            get { return _SUIsEnabled; }
            set { _SUIsEnabled = value; }
        }
        private int _SUDeleteMark = 0;
        /// <summary>
        /// SUDeleteMark
        /// </summary>
        [Column]
        public int SUDeleteMark
        {
            get { return _SUDeleteMark; }
            set { _SUDeleteMark = value; }
        }
        private int _SUCreateUser = 0;
        /// <summary>
        /// SUCreateUser
        /// </summary>
        [Column]
        public int SUCreateUser
        {
            get { return _SUCreateUser; }
            set { _SUCreateUser = value; }
        }
        private int _SUModifyUser = 0;
        /// <summary>
        /// SUModifyUser
        /// </summary>
        [Column]
        public int SUModifyUser
        {
            get { return _SUModifyUser; }
            set { _SUModifyUser = value; }
        }
        private DateTime _SUCreateTime;
        /// <summary>
        /// SUCreateTime
        /// </summary>
        [Column]
        public DateTime SUCreateTime
        {
            get { return _SUCreateTime; }
            set { _SUCreateTime = value; }
        }
        private DateTime _SUModifyTime;
        /// <summary>
        /// SUModifyTime
        /// </summary>
        [Column]
        public DateTime SUModifyTime
        {
            get { return _SUModifyTime; }
            set { _SUModifyTime = value; }
        }
    }

    /// <summary>
    /// Sys_User字段枚举
    /// </summary>
    public enum Sys_UserFields
    {
        /// <summary>
        /// Id
        /// </summary>
        Id,
        /// <summary>
        /// SUAccount
        /// </summary>
        SUAccount,
        /// <summary>
        /// SURealName
        /// </summary>
        SURealName,
        /// <summary>
        /// SUNickName
        /// </summary>
        SUNickName,
        /// <summary>
        /// SUBirthday
        /// </summary>
        SUBirthday,
        /// <summary>
        /// SUMobilePhone
        /// </summary>
        SUMobilePhone,
        /// <summary>
        /// SUGender
        /// </summary>
        SUGender,
        /// <summary>
        /// SUAvatar
        /// </summary>
        SUAvatar,
        /// <summary>
        /// SUEmail
        /// </summary>
        SUEmail,
        /// <summary>
        /// SUSignature
        /// </summary>
        SUSignature,
        /// <summary>
        /// SUAddress
        /// </summary>
        SUAddress,
        /// <summary>
        /// SUCompanyId
        /// </summary>
        SUCompanyId,
        /// <summary>
        /// SUDepartmentId
        /// </summary>
        SUDepartmentId,
        /// <summary>
        /// SUIsEnabled
        /// </summary>
        SUIsEnabled,
        /// <summary>
        /// SUDeleteMark
        /// </summary>
        SUDeleteMark,
        /// <summary>
        /// SUCreateUser
        /// </summary>
        SUCreateUser,
        /// <summary>
        /// SUModifyUser
        /// </summary>
        SUModifyUser,
        /// <summary>
        /// SUCreateTime
        /// </summary>
        SUCreateTime,
        /// <summary>
        /// SUModifyTime
        /// </summary>
        SUModifyTime,
    }
}

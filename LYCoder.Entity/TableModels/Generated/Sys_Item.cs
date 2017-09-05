using System;
namespace LYCoder.Entity
{
    /// <summary>
    /// Sys_Item
    /// </summary>
    [TableName("lycoder.sys_item")]
    [PrimaryKey("Id")]


    [ExplicitColumns]
    public partial class Sys_Item : DbContext.Record<Sys_Item>
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
        private int _SIParentId = 0;
        /// <summary>
        /// SIParentId
        /// </summary>
        [Column]
        public int SIParentId
        {
            get { return _SIParentId; }
            set { _SIParentId = value; }
        }

        private string _SIEnCode = string.Empty;
        /// <summary>
        /// SIEnCode
        /// </summary>
        [Column]
        public string SIEnCode
        {
            get { return _SIEnCode; }
            set { _SIEnCode = value; }
        }

        private string _SIName = string.Empty;
        /// <summary>
        /// SIName
        /// </summary>
        [Column]
        public string SIName
        {
            get { return _SIName; }
            set { _SIName = value; }
        }
        private int _SILayer = 0;
        /// <summary>
        /// SILayer
        /// </summary>
        [Column]
        public int SILayer
        {
            get { return _SILayer; }
            set { _SILayer = value; }
        }
        private int _SISortCode = 0;
        /// <summary>
        /// SISortCode
        /// </summary>
        [Column]
        public int SISortCode
        {
            get { return _SISortCode; }
            set { _SISortCode = value; }
        }
        private int _SIIsTree = 0;
        /// <summary>
        /// SIIsTree
        /// </summary>
        [Column]
        public int SIIsTree
        {
            get { return _SIIsTree; }
            set { _SIIsTree = value; }
        }
        private int _SIDeleteMark = 0;
        /// <summary>
        /// SIDeleteMark
        /// </summary>
        [Column]
        public int SIDeleteMark
        {
            get { return _SIDeleteMark; }
            set { _SIDeleteMark = value; }
        }
        private int _SIIsEnabled = 0;
        /// <summary>
        /// SIIsEnabled
        /// </summary>
        [Column]
        public int SIIsEnabled
        {
            get { return _SIIsEnabled; }
            set { _SIIsEnabled = value; }
        }

        private string _SIRemark = string.Empty;
        /// <summary>
        /// SIRemark
        /// </summary>
        [Column]
        public string SIRemark
        {
            get { return _SIRemark; }
            set { _SIRemark = value; }
        }
        private int _SICreateUser = 0;
        /// <summary>
        /// SICreateUser
        /// </summary>
        [Column]
        public int SICreateUser
        {
            get { return _SICreateUser; }
            set { _SICreateUser = value; }
        }
        private DateTime _SICreateTime;
        /// <summary>
        /// SICreateTime
        /// </summary>
        [Column]
        public DateTime SICreateTime
        {
            get { return _SICreateTime; }
            set { _SICreateTime = value; }
        }
        private int _SIModifyUser = 0;
        /// <summary>
        /// SIModifyUser
        /// </summary>
        [Column]
        public int SIModifyUser
        {
            get { return _SIModifyUser; }
            set { _SIModifyUser = value; }
        }
        private DateTime _SIModifyTime;
        /// <summary>
        /// SIModifyTime
        /// </summary>
        [Column]
        public DateTime SIModifyTime
        {
            get { return _SIModifyTime; }
            set { _SIModifyTime = value; }
        }
    }

    /// <summary>
    /// Sys_Item字段枚举
    /// </summary>
    public enum Sys_ItemFields
    {
        /// <summary>
        /// Id
        /// </summary>
        Id,
        /// <summary>
        /// SIParentId
        /// </summary>
        SIParentId,
        /// <summary>
        /// SIEnCode
        /// </summary>
        SIEnCode,
        /// <summary>
        /// SIName
        /// </summary>
        SIName,
        /// <summary>
        /// SILayer
        /// </summary>
        SILayer,
        /// <summary>
        /// SISortCode
        /// </summary>
        SISortCode,
        /// <summary>
        /// SIIsTree
        /// </summary>
        SIIsTree,
        /// <summary>
        /// SIDeleteMark
        /// </summary>
        SIDeleteMark,
        /// <summary>
        /// SIIsEnabled
        /// </summary>
        SIIsEnabled,
        /// <summary>
        /// SIRemark
        /// </summary>
        SIRemark,
        /// <summary>
        /// SICreateUser
        /// </summary>
        SICreateUser,
        /// <summary>
        /// SICreateTime
        /// </summary>
        SICreateTime,
        /// <summary>
        /// SIModifyUser
        /// </summary>
        SIModifyUser,
        /// <summary>
        /// SIModifyTime
        /// </summary>
        SIModifyTime,
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>文件上传关联对象信息</summary>
    [Serializable]
    [DataObject]
    [Description("文件上传关联对象信息")]
    [BindTable("UploadFiles", Description = "文件上传关联对象信息", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class UploadFiles : IUploadFiles
    {
        #region 属性
        private Guid _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, false, false, 0)]
        [BindColumn("Id", "", "uniqueidentifier")]
        public Guid Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private String _CreatBy;
        /// <summary>添加人</summary>
        [DisplayName("添加人")]
        [Description("添加人")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("CreatBy", "添加人", "nvarchar(255)")]
        public String CreatBy { get { return _CreatBy; } set { if (OnPropertyChanging(__.CreatBy, value)) { _CreatBy = value; OnPropertyChanged(__.CreatBy); } } }

        private DateTime _CreateDate;
        /// <summary>添加时间</summary>
        [DisplayName("添加时间")]
        [Description("添加时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateDate", "添加时间", "datetime")]
        public DateTime CreateDate { get { return _CreateDate; } set { if (OnPropertyChanging(__.CreateDate, value)) { _CreateDate = value; OnPropertyChanged(__.CreateDate); } } }

        private Int32 _FilesInfoID;
        /// <summary>关联的FilesInfo对象ID</summary>
        [DisplayName("关联的FilesInfo对象ID")]
        [Description("关联的FilesInfo对象ID")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("FilesInfoID", "关联的FilesInfo对象ID", "int")]
        public Int32 FilesInfoID { get { return _FilesInfoID; } set { if (OnPropertyChanging(__.FilesInfoID, value)) { _FilesInfoID = value; OnPropertyChanged(__.FilesInfoID); } } }

        private Int32 _Hits;
        /// <summary>点击次数</summary>
        [DisplayName("点击次数")]
        [Description("点击次数")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Hits", "点击次数", "int")]
        public Int32 Hits { get { return _Hits; } set { if (OnPropertyChanging(__.Hits, value)) { _Hits = value; OnPropertyChanged(__.Hits); } } }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.Id : return _Id;
                    case __.CreatBy : return _CreatBy;
                    case __.CreateDate : return _CreateDate;
                    case __.FilesInfoID : return _FilesInfoID;
                    case __.Hits : return _Hits;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = (Guid)value; break;
                    case __.CreatBy : _CreatBy = Convert.ToString(value); break;
                    case __.CreateDate : _CreateDate = Convert.ToDateTime(value); break;
                    case __.FilesInfoID : _FilesInfoID = Convert.ToInt32(value); break;
                    case __.Hits : _Hits = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得文件上传关联对象信息字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>添加人</summary>
            public static readonly Field CreatBy = FindByName(__.CreatBy);

            /// <summary>添加时间</summary>
            public static readonly Field CreateDate = FindByName(__.CreateDate);

            /// <summary>关联的FilesInfo对象ID</summary>
            public static readonly Field FilesInfoID = FindByName(__.FilesInfoID);

            /// <summary>点击次数</summary>
            public static readonly Field Hits = FindByName(__.Hits);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得文件上传关联对象信息字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary>添加人</summary>
            public const String CreatBy = "CreatBy";

            /// <summary>添加时间</summary>
            public const String CreateDate = "CreateDate";

            /// <summary>关联的FilesInfo对象ID</summary>
            public const String FilesInfoID = "FilesInfoID";

            /// <summary>点击次数</summary>
            public const String Hits = "Hits";
        }
        #endregion
    }

    /// <summary>文件上传关联对象信息接口</summary>
    public partial interface IUploadFiles
    {
        #region 属性
        /// <summary></summary>
        Guid Id { get; set; }

        /// <summary>添加人</summary>
        String CreatBy { get; set; }

        /// <summary>添加时间</summary>
        DateTime CreateDate { get; set; }

        /// <summary>关联的FilesInfo对象ID</summary>
        Int32 FilesInfoID { get; set; }

        /// <summary>点击次数</summary>
        Int32 Hits { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}
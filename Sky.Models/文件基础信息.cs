using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>文件基础信息</summary>
    [Serializable]
    [DataObject]
    [Description("文件基础信息")]
    [BindTable("FilesInfo", Description = "文件基础信息", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class FilesInfo : IFilesInfo
    {
        #region 属性
        private Int32 _ID;
        /// <summary></summary>
        [DisplayName("ID")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "", "int")]
        public Int32 ID { get { return _ID; } set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } } }

        private String _FileName;
        /// <summary>文件名称</summary>
        [DisplayName("文件名称")]
        [Description("文件名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("FileName", "文件名称", "nvarchar(255)")]
        public String FileName { get { return _FileName; } set { if (OnPropertyChanging(__.FileName, value)) { _FileName = value; OnPropertyChanged(__.FileName); } } }

        private String _FileSize;
        /// <summary>文件大小</summary>
        [DisplayName("文件大小")]
        [Description("文件大小")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("FileSize", "文件大小", "nvarchar(255)")]
        public String FileSize { get { return _FileSize; } set { if (OnPropertyChanging(__.FileSize, value)) { _FileSize = value; OnPropertyChanged(__.FileSize); } } }

        private String _FileType;
        /// <summary>文件类型</summary>
        [DisplayName("文件类型")]
        [Description("文件类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("FileType", "文件类型", "nvarchar(255)")]
        public String FileType { get { return _FileType; } set { if (OnPropertyChanging(__.FileType, value)) { _FileType = value; OnPropertyChanged(__.FileType); } } }

        private String _FileExt;
        /// <summary>文件后缀名</summary>
        [DisplayName("文件后缀名")]
        [Description("文件后缀名")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("FileExt", "文件后缀名", "nvarchar(255)")]
        public String FileExt { get { return _FileExt; } set { if (OnPropertyChanging(__.FileExt, value)) { _FileExt = value; OnPropertyChanged(__.FileExt); } } }

        private String _FilePath;
        /// <summary>存储路径</summary>
        [DisplayName("存储路径")]
        [Description("存储路径")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("FilePath", "存储路径", "nvarchar(255)")]
        public String FilePath { get { return _FilePath; } set { if (OnPropertyChanging(__.FilePath, value)) { _FilePath = value; OnPropertyChanged(__.FilePath); } } }

        private Boolean _IsImg;
        /// <summary>是否图片</summary>
        [DisplayName("是否图片")]
        [Description("是否图片")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("IsImg", "是否图片", "bit")]
        public Boolean IsImg { get { return _IsImg; } set { if (OnPropertyChanging(__.IsImg, value)) { _IsImg = value; OnPropertyChanged(__.IsImg); } } }

        private Byte[] _FileContent;
        /// <summary>文件内容</summary>
        [DisplayName("文件内容")]
        [Description("文件内容")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("FileContent", "文件内容", "image")]
        public Byte[] FileContent { get { return _FileContent; } set { if (OnPropertyChanging(__.FileContent, value)) { _FileContent = value; OnPropertyChanged(__.FileContent); } } }

        private String _bytHash;
        /// <summary>文件MD5值</summary>
        [DisplayName("文件MD5值")]
        [Description("文件MD5值")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("bytHash", "文件MD5值", "nvarchar(255)")]
        public String bytHash { get { return _bytHash; } set { if (OnPropertyChanging(__.bytHash, value)) { _bytHash = value; OnPropertyChanged(__.bytHash); } } }

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
                    case __.ID : return _ID;
                    case __.FileName : return _FileName;
                    case __.FileSize : return _FileSize;
                    case __.FileType : return _FileType;
                    case __.FileExt : return _FileExt;
                    case __.FilePath : return _FilePath;
                    case __.IsImg : return _IsImg;
                    case __.FileContent : return _FileContent;
                    case __.bytHash : return _bytHash;
                    case __.CreatBy : return _CreatBy;
                    case __.CreateDate : return _CreateDate;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.FileName : _FileName = Convert.ToString(value); break;
                    case __.FileSize : _FileSize = Convert.ToString(value); break;
                    case __.FileType : _FileType = Convert.ToString(value); break;
                    case __.FileExt : _FileExt = Convert.ToString(value); break;
                    case __.FilePath : _FilePath = Convert.ToString(value); break;
                    case __.IsImg : _IsImg = Convert.ToBoolean(value); break;
                    case __.bytHash : _bytHash = Convert.ToString(value); break;
                    case __.CreatBy : _CreatBy = Convert.ToString(value); break;
                    case __.CreateDate : _CreateDate = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得文件基础信息字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field ID = FindByName(__.ID);

            /// <summary>文件名称</summary>
            public static readonly Field FileName = FindByName(__.FileName);

            /// <summary>文件大小</summary>
            public static readonly Field FileSize = FindByName(__.FileSize);

            /// <summary>文件类型</summary>
            public static readonly Field FileType = FindByName(__.FileType);

            /// <summary>文件后缀名</summary>
            public static readonly Field FileExt = FindByName(__.FileExt);

            /// <summary>存储路径</summary>
            public static readonly Field FilePath = FindByName(__.FilePath);

            /// <summary>是否图片</summary>
            public static readonly Field IsImg = FindByName(__.IsImg);

            /// <summary>文件内容</summary>
            public static readonly Field FileContent = FindByName(__.FileContent);

            /// <summary>文件MD5值</summary>
            public static readonly Field bytHash = FindByName(__.bytHash);

            /// <summary>添加人</summary>
            public static readonly Field CreatBy = FindByName(__.CreatBy);

            /// <summary>添加时间</summary>
            public static readonly Field CreateDate = FindByName(__.CreateDate);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得文件基础信息字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String ID = "ID";

            /// <summary>文件名称</summary>
            public const String FileName = "FileName";

            /// <summary>文件大小</summary>
            public const String FileSize = "FileSize";

            /// <summary>文件类型</summary>
            public const String FileType = "FileType";

            /// <summary>文件后缀名</summary>
            public const String FileExt = "FileExt";

            /// <summary>存储路径</summary>
            public const String FilePath = "FilePath";

            /// <summary>是否图片</summary>
            public const String IsImg = "IsImg";

            /// <summary>文件内容</summary>
            public const String FileContent = "FileContent";

            /// <summary>文件MD5值</summary>
            public const String bytHash = "bytHash";

            /// <summary>添加人</summary>
            public const String CreatBy = "CreatBy";

            /// <summary>添加时间</summary>
            public const String CreateDate = "CreateDate";
        }
        #endregion
    }

    /// <summary>文件基础信息接口</summary>
    public partial interface IFilesInfo
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary>文件名称</summary>
        String FileName { get; set; }

        /// <summary>文件大小</summary>
        String FileSize { get; set; }

        /// <summary>文件类型</summary>
        String FileType { get; set; }

        /// <summary>文件后缀名</summary>
        String FileExt { get; set; }

        /// <summary>存储路径</summary>
        String FilePath { get; set; }

        /// <summary>是否图片</summary>
        Boolean IsImg { get; set; }

        /// <summary>文件内容</summary>
        Byte[] FileContent { get; set; }

        /// <summary>文件MD5值</summary>
        String bytHash { get; set; }

        /// <summary>添加人</summary>
        String CreatBy { get; set; }

        /// <summary>添加时间</summary>
        DateTime CreateDate { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}
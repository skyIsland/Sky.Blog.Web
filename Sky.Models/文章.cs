using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>文章</summary>
    [Serializable]
    [DataObject]
    [Description("文章")]
    [BindTable("Article", Description = "文章", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class Article : IArticle
    {
        #region 属性
        private Int32 _Id;
        /// <summary>Id</summary>
        [DisplayName("Id")]
        [Description("Id")]
        [DataObjectField(false, true, false, 0)]
        [BindColumn("Id", "Id", "int")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private Int32 _ArticlassId;
        /// <summary>文章分类ID</summary>
        [DisplayName("文章分类ID")]
        [Description("文章分类ID")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ArticlassId", "文章分类ID", "int", Master = true)]
        public Int32 ArticlassId { get { return _ArticlassId; } set { if (OnPropertyChanging(__.ArticlassId, value)) { _ArticlassId = value; OnPropertyChanged(__.ArticlassId); } } }

        private String _Title;
        /// <summary>标题</summary>
        [DisplayName("标题")]
        [Description("标题")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Title", "标题", "nvarchar(50)", Master = true)]
        public String Title { get { return _Title; } set { if (OnPropertyChanging(__.Title, value)) { _Title = value; OnPropertyChanged(__.Title); } } }

        private String _Author;
        /// <summary>作者</summary>
        [DisplayName("作者")]
        [Description("作者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Author", "作者", "nvarchar(50)", Master = true)]
        public String Author { get { return _Author; } set { if (OnPropertyChanging(__.Author, value)) { _Author = value; OnPropertyChanged(__.Author); } } }

        private String _Content;
        /// <summary>文章内容</summary>
        [DisplayName("文章内容")]
        [Description("文章内容")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Content", "文章内容", "nvarchar(500)", Master = true)]
        public String Content { get { return _Content; } set { if (OnPropertyChanging(__.Content, value)) { _Content = value; OnPropertyChanged(__.Content); } } }

        private Boolean _IsTop;
        /// <summary>是否置顶</summary>
        [DisplayName("是否置顶")]
        [Description("是否置顶")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("IsTop", "是否置顶", "bit")]
        public Boolean IsTop { get { return _IsTop; } set { if (OnPropertyChanging(__.IsTop, value)) { _IsTop = value; OnPropertyChanged(__.IsTop); } } }

        private Boolean _IsRecommend;
        /// <summary>是否推荐</summary>
        [DisplayName("是否推荐")]
        [Description("是否推荐")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("IsRecommend", "是否推荐", "bit")]
        public Boolean IsRecommend { get { return _IsRecommend; } set { if (OnPropertyChanging(__.IsRecommend, value)) { _IsRecommend = value; OnPropertyChanged(__.IsRecommend); } } }

        private Boolean _IsDelete;
        /// <summary>是否删除</summary>
        [DisplayName("是否删除")]
        [Description("是否删除")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("IsDelete", "是否删除", "bit")]
        public Boolean IsDelete { get { return _IsDelete; } set { if (OnPropertyChanging(__.IsDelete, value)) { _IsDelete = value; OnPropertyChanged(__.IsDelete); } } }

        private DateTime _AddTime;
        /// <summary>添加时间</summary>
        [DisplayName("添加时间")]
        [Description("添加时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AddTime", "添加时间", "datetime")]
        public DateTime AddTime { get { return _AddTime; } set { if (OnPropertyChanging(__.AddTime, value)) { _AddTime = value; OnPropertyChanged(__.AddTime); } } }

        private DateTime _EditTime;
        /// <summary>编辑时间</summary>
        [DisplayName("编辑时间")]
        [Description("编辑时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("EditTime", "编辑时间", "datetime")]
        public DateTime EditTime { get { return _EditTime; } set { if (OnPropertyChanging(__.EditTime, value)) { _EditTime = value; OnPropertyChanged(__.EditTime); } } }

        private String _AddUser;
        /// <summary>添加人</summary>
        [DisplayName("添加人")]
        [Description("添加人")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("AddUser", "添加人", "nvarchar(50)")]
        public String AddUser { get { return _AddUser; } set { if (OnPropertyChanging(__.AddUser, value)) { _AddUser = value; OnPropertyChanged(__.AddUser); } } }
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
                    case __.ArticlassId : return _ArticlassId;
                    case __.Title : return _Title;
                    case __.Author : return _Author;
                    case __.Content : return _Content;
                    case __.IsTop : return _IsTop;
                    case __.IsRecommend : return _IsRecommend;
                    case __.IsDelete : return _IsDelete;
                    case __.AddTime : return _AddTime;
                    case __.EditTime : return _EditTime;
                    case __.AddUser : return _AddUser;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.ArticlassId : _ArticlassId = Convert.ToInt32(value); break;
                    case __.Title : _Title = Convert.ToString(value); break;
                    case __.Author : _Author = Convert.ToString(value); break;
                    case __.Content : _Content = Convert.ToString(value); break;
                    case __.IsTop : _IsTop = Convert.ToBoolean(value); break;
                    case __.IsRecommend : _IsRecommend = Convert.ToBoolean(value); break;
                    case __.IsDelete : _IsDelete = Convert.ToBoolean(value); break;
                    case __.AddTime : _AddTime = Convert.ToDateTime(value); break;
                    case __.EditTime : _EditTime = Convert.ToDateTime(value); break;
                    case __.AddUser : _AddUser = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得文章字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>Id</summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>文章分类ID</summary>
            public static readonly Field ArticlassId = FindByName(__.ArticlassId);

            /// <summary>标题</summary>
            public static readonly Field Title = FindByName(__.Title);

            /// <summary>作者</summary>
            public static readonly Field Author = FindByName(__.Author);

            /// <summary>文章内容</summary>
            public static readonly Field Content = FindByName(__.Content);

            /// <summary>是否置顶</summary>
            public static readonly Field IsTop = FindByName(__.IsTop);

            /// <summary>是否推荐</summary>
            public static readonly Field IsRecommend = FindByName(__.IsRecommend);

            /// <summary>是否删除</summary>
            public static readonly Field IsDelete = FindByName(__.IsDelete);

            /// <summary>添加时间</summary>
            public static readonly Field AddTime = FindByName(__.AddTime);

            /// <summary>编辑时间</summary>
            public static readonly Field EditTime = FindByName(__.EditTime);

            /// <summary>添加人</summary>
            public static readonly Field AddUser = FindByName(__.AddUser);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得文章字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>Id</summary>
            public const String Id = "Id";

            /// <summary>文章分类ID</summary>
            public const String ArticlassId = "ArticlassId";

            /// <summary>标题</summary>
            public const String Title = "Title";

            /// <summary>作者</summary>
            public const String Author = "Author";

            /// <summary>文章内容</summary>
            public const String Content = "Content";

            /// <summary>是否置顶</summary>
            public const String IsTop = "IsTop";

            /// <summary>是否推荐</summary>
            public const String IsRecommend = "IsRecommend";

            /// <summary>是否删除</summary>
            public const String IsDelete = "IsDelete";

            /// <summary>添加时间</summary>
            public const String AddTime = "AddTime";

            /// <summary>编辑时间</summary>
            public const String EditTime = "EditTime";

            /// <summary>添加人</summary>
            public const String AddUser = "AddUser";
        }
        #endregion
    }

    /// <summary>文章接口</summary>
    public partial interface IArticle
    {
        #region 属性
        /// <summary>Id</summary>
        Int32 Id { get; set; }

        /// <summary>文章分类ID</summary>
        Int32 ArticlassId { get; set; }

        /// <summary>标题</summary>
        String Title { get; set; }

        /// <summary>作者</summary>
        String Author { get; set; }

        /// <summary>文章内容</summary>
        String Content { get; set; }

        /// <summary>是否置顶</summary>
        Boolean IsTop { get; set; }

        /// <summary>是否推荐</summary>
        Boolean IsRecommend { get; set; }

        /// <summary>是否删除</summary>
        Boolean IsDelete { get; set; }

        /// <summary>添加时间</summary>
        DateTime AddTime { get; set; }

        /// <summary>编辑时间</summary>
        DateTime EditTime { get; set; }

        /// <summary>添加人</summary>
        String AddUser { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}
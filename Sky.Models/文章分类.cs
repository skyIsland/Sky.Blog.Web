using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>文章分类</summary>
    [Serializable]
    [DataObject]
    [Description("文章分类")]
    [BindTable("ArticleClass", Description = "文章分类", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class ArticleClass : IArticleClass
    {
        #region 属性
        private Int32 _Id;
        /// <summary>Id</summary>
        [DisplayName("Id")]
        [Description("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "Id", "int")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private String _ClassName;
        /// <summary>分类名称</summary>
        [DisplayName("分类名称")]
        [Description("分类名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("ClassName", "分类名称", "nvarchar(50)", Master = true)]
        public String ClassName { get { return _ClassName; } set { if (OnPropertyChanging(__.ClassName, value)) { _ClassName = value; OnPropertyChanged(__.ClassName); } } }

        private String _ClassEname;
        /// <summary>分类英文名</summary>
        [DisplayName("分类英文名")]
        [Description("分类英文名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("ClassEname", "分类英文名", "nvarchar(50)", Master = true)]
        public String ClassEname { get { return _ClassEname; } set { if (OnPropertyChanging(__.ClassEname, value)) { _ClassEname = value; OnPropertyChanged(__.ClassEname); } } }

        private Int32 _ParentId;
        /// <summary>父级Id</summary>
        [DisplayName("父级Id")]
        [Description("父级Id")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ParentId", "父级Id", "int", Master = true)]
        public Int32 ParentId { get { return _ParentId; } set { if (OnPropertyChanging(__.ParentId, value)) { _ParentId = value; OnPropertyChanged(__.ParentId); } } }

        private String _ParentIds;
        /// <summary>父级Ids</summary>
        [DisplayName("父级Ids")]
        [Description("父级Ids")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("ParentIds", "父级Ids", "nvarchar(50)")]
        public String ParentIds { get { return _ParentIds; } set { if (OnPropertyChanging(__.ParentIds, value)) { _ParentIds = value; OnPropertyChanged(__.ParentIds); } } }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Sort", "排序", "int")]
        public Int32 Sort { get { return _Sort; } set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } } }

        private DateTime _AddTime;
        /// <summary>添加时间</summary>
        [DisplayName("添加时间")]
        [Description("添加时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AddTime", "添加时间", "datetime")]
        public DateTime AddTime { get { return _AddTime; } set { if (OnPropertyChanging(__.AddTime, value)) { _AddTime = value; OnPropertyChanged(__.AddTime); } } }
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
                    case __.ClassName : return _ClassName;
                    case __.ClassEname : return _ClassEname;
                    case __.ParentId : return _ParentId;
                    case __.ParentIds : return _ParentIds;
                    case __.Sort : return _Sort;
                    case __.AddTime : return _AddTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.ClassName : _ClassName = Convert.ToString(value); break;
                    case __.ClassEname : _ClassEname = Convert.ToString(value); break;
                    case __.ParentId : _ParentId = Convert.ToInt32(value); break;
                    case __.ParentIds : _ParentIds = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.AddTime : _AddTime = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得文章分类字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>Id</summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>分类名称</summary>
            public static readonly Field ClassName = FindByName(__.ClassName);

            /// <summary>分类英文名</summary>
            public static readonly Field ClassEname = FindByName(__.ClassEname);

            /// <summary>父级Id</summary>
            public static readonly Field ParentId = FindByName(__.ParentId);

            /// <summary>父级Ids</summary>
            public static readonly Field ParentIds = FindByName(__.ParentIds);

            /// <summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            /// <summary>添加时间</summary>
            public static readonly Field AddTime = FindByName(__.AddTime);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得文章分类字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>Id</summary>
            public const String Id = "Id";

            /// <summary>分类名称</summary>
            public const String ClassName = "ClassName";

            /// <summary>分类英文名</summary>
            public const String ClassEname = "ClassEname";

            /// <summary>父级Id</summary>
            public const String ParentId = "ParentId";

            /// <summary>父级Ids</summary>
            public const String ParentIds = "ParentIds";

            /// <summary>排序</summary>
            public const String Sort = "Sort";

            /// <summary>添加时间</summary>
            public const String AddTime = "AddTime";
        }
        #endregion
    }

    /// <summary>文章分类接口</summary>
    public partial interface IArticleClass
    {
        #region 属性
        /// <summary>Id</summary>
        Int32 Id { get; set; }

        /// <summary>分类名称</summary>
        String ClassName { get; set; }

        /// <summary>分类英文名</summary>
        String ClassEname { get; set; }

        /// <summary>父级Id</summary>
        Int32 ParentId { get; set; }

        /// <summary>父级Ids</summary>
        String ParentIds { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>添加时间</summary>
        DateTime AddTime { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}
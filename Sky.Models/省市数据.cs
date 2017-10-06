using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>省市数据</summary>
    [Serializable]
    [DataObject]
    [Description("省市数据")]
    [BindTable("PositionData", Description = "省市数据", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class PositionData : IPositionData
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "", "int")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private String _Province;
        /// <summary>省份</summary>
        [DisplayName("省份")]
        [Description("省份")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Province", "省份", "nvarchar(50)")]
        public String Province { get { return _Province; } set { if (OnPropertyChanging(__.Province, value)) { _Province = value; OnPropertyChanged(__.Province); } } }

        private String _City;
        /// <summary>城市</summary>
        [DisplayName("城市")]
        [Description("城市")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("City", "城市", "nvarchar(50)")]
        public String City { get { return _City; } set { if (OnPropertyChanging(__.City, value)) { _City = value; OnPropertyChanged(__.City); } } }

        private Int32 _ParentId;
        /// <summary>父级Id</summary>
        [DisplayName("父级Id")]
        [Description("父级Id")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ParentId", "父级Id", "int")]
        public Int32 ParentId { get { return _ParentId; } set { if (OnPropertyChanging(__.ParentId, value)) { _ParentId = value; OnPropertyChanged(__.ParentId); } } }
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
                    case __.Province : return _Province;
                    case __.City : return _City;
                    case __.ParentId : return _ParentId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.Province : _Province = Convert.ToString(value); break;
                    case __.City : _City = Convert.ToString(value); break;
                    case __.ParentId : _ParentId = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得省市数据字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>省份</summary>
            public static readonly Field Province = FindByName(__.Province);

            /// <summary>城市</summary>
            public static readonly Field City = FindByName(__.City);

            /// <summary>父级Id</summary>
            public static readonly Field ParentId = FindByName(__.ParentId);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得省市数据字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary>省份</summary>
            public const String Province = "Province";

            /// <summary>城市</summary>
            public const String City = "City";

            /// <summary>父级Id</summary>
            public const String ParentId = "ParentId";
        }
        #endregion
    }

    /// <summary>省市数据接口</summary>
    public partial interface IPositionData
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary>省份</summary>
        String Province { get; set; }

        /// <summary>城市</summary>
        String City { get; set; }

        /// <summary>父级Id</summary>
        Int32 ParentId { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>访问记录</summary>
    [Serializable]
    [DataObject]
    [Description("访问记录")]
    [BindTable("IpInfo", Description = "访问记录", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class IpInfo : IIpInfo
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "", "int")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private String _Ip;
        /// <summary>Ip</summary>
        [DisplayName("Ip")]
        [Description("Ip")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Ip", "Ip", "nvarchar(50)")]
        public String Ip { get { return _Ip; } set { if (OnPropertyChanging(__.Ip, value)) { _Ip = value; OnPropertyChanged(__.Ip); } } }

        private Int32 _ProvinceId;
        /// <summary>省份Id</summary>
        [DisplayName("省份Id")]
        [Description("省份Id")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ProvinceId", "省份Id", "int")]
        public Int32 ProvinceId { get { return _ProvinceId; } set { if (OnPropertyChanging(__.ProvinceId, value)) { _ProvinceId = value; OnPropertyChanged(__.ProvinceId); } } }

        private Int32 _CityId;
        /// <summary>城市Id</summary>
        [DisplayName("城市Id")]
        [Description("城市Id")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("CityId", "城市Id", "int")]
        public Int32 CityId { get { return _CityId; } set { if (OnPropertyChanging(__.CityId, value)) { _CityId = value; OnPropertyChanged(__.CityId); } } }

        private DateTime _AddTime;
        /// <summary>访问时间</summary>
        [DisplayName("访问时间")]
        [Description("访问时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AddTime", "访问时间", "datetime")]
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
                    case __.Ip : return _Ip;
                    case __.ProvinceId : return _ProvinceId;
                    case __.CityId : return _CityId;
                    case __.AddTime : return _AddTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.Ip : _Ip = Convert.ToString(value); break;
                    case __.ProvinceId : _ProvinceId = Convert.ToInt32(value); break;
                    case __.CityId : _CityId = Convert.ToInt32(value); break;
                    case __.AddTime : _AddTime = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得访问记录字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>Ip</summary>
            public static readonly Field Ip = FindByName(__.Ip);

            /// <summary>省份Id</summary>
            public static readonly Field ProvinceId = FindByName(__.ProvinceId);

            /// <summary>城市Id</summary>
            public static readonly Field CityId = FindByName(__.CityId);

            /// <summary>访问时间</summary>
            public static readonly Field AddTime = FindByName(__.AddTime);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得访问记录字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary>Ip</summary>
            public const String Ip = "Ip";

            /// <summary>省份Id</summary>
            public const String ProvinceId = "ProvinceId";

            /// <summary>城市Id</summary>
            public const String CityId = "CityId";

            /// <summary>访问时间</summary>
            public const String AddTime = "AddTime";
        }
        #endregion
    }

    /// <summary>访问记录接口</summary>
    public partial interface IIpInfo
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary>Ip</summary>
        String Ip { get; set; }

        /// <summary>省份Id</summary>
        Int32 ProvinceId { get; set; }

        /// <summary>城市Id</summary>
        Int32 CityId { get; set; }

        /// <summary>访问时间</summary>
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
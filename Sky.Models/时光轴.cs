using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>时光轴</summary>
    [Serializable]
    [DataObject]
    [Description("时光轴")]
    [BindTable("TimeLine", Description = "时光轴", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class TimeLine : ITimeLine
    {
        #region 属性
        private Int32 _Id;
        /// <summary>Id</summary>
        [DisplayName("Id")]
        [Description("Id")]
        [DataObjectField(false, true, false, 0)]
        [BindColumn("Id", "Id", "int")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private String _Desc;
        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Desc", "描述", "nvarchar(500)", Master = true)]
        public String Desc { get { return _Desc; } set { if (OnPropertyChanging(__.Desc, value)) { _Desc = value; OnPropertyChanged(__.Desc); } } }

        private DateTime _Time;
        /// <summary>时间</summary>
        [DisplayName("时间")]
        [Description("时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Time", "时间", "datetime", Master = true)]
        public DateTime Time { get { return _Time; } set { if (OnPropertyChanging(__.Time, value)) { _Time = value; OnPropertyChanged(__.Time); } } }

        private DateTime _AddTime;
        /// <summary>添加时间</summary>
        [DisplayName("添加时间")]
        [Description("添加时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AddTime", "添加时间", "datetime", Master = true)]
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
                    case __.Desc : return _Desc;
                    case __.Time : return _Time;
                    case __.AddTime : return _AddTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.Desc : _Desc = Convert.ToString(value); break;
                    case __.Time : _Time = Convert.ToDateTime(value); break;
                    case __.AddTime : _AddTime = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得时光轴字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>Id</summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>描述</summary>
            public static readonly Field Desc = FindByName(__.Desc);

            /// <summary>时间</summary>
            public static readonly Field Time = FindByName(__.Time);

            /// <summary>添加时间</summary>
            public static readonly Field AddTime = FindByName(__.AddTime);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得时光轴字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>Id</summary>
            public const String Id = "Id";

            /// <summary>描述</summary>
            public const String Desc = "Desc";

            /// <summary>时间</summary>
            public const String Time = "Time";

            /// <summary>添加时间</summary>
            public const String AddTime = "AddTime";
        }
        #endregion
    }

    /// <summary>时光轴接口</summary>
    public partial interface ITimeLine
    {
        #region 属性
        /// <summary>Id</summary>
        Int32 Id { get; set; }

        /// <summary>描述</summary>
        String Desc { get; set; }

        /// <summary>时间</summary>
        DateTime Time { get; set; }

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
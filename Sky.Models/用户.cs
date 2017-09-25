using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>用户</summary>
    [Serializable]
    [DataObject]
    [Description("用户")]
    [BindTable("SysUser", Description = "用户", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class SysUser : ISysUser
    {
        #region 属性
        private Int32 _Id;
        /// <summary>Id</summary>
        [DisplayName("Id")]
        [Description("Id")]
        [DataObjectField(false, true, false, 0)]
        [BindColumn("Id", "Id", "int")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private String _LoginName;
        /// <summary>登录用户名</summary>
        [DisplayName("登录用户名")]
        [Description("登录用户名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("LoginName", "登录用户名", "nvarchar(50)", Master = true)]
        public String LoginName { get { return _LoginName; } set { if (OnPropertyChanging(__.LoginName, value)) { _LoginName = value; OnPropertyChanged(__.LoginName); } } }

        private String _NickName;
        /// <summary>昵称</summary>
        [DisplayName("昵称")]
        [Description("昵称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("NickName", "昵称", "nvarchar(50)", Master = true)]
        public String NickName { get { return _NickName; } set { if (OnPropertyChanging(__.NickName, value)) { _NickName = value; OnPropertyChanged(__.NickName); } } }

        private String _LoginPwd;
        /// <summary>登录密码</summary>
        [DisplayName("登录密码")]
        [Description("登录密码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("LoginPwd", "登录密码", "nvarchar(50)", Master = true)]
        public String LoginPwd { get { return _LoginPwd; } set { if (OnPropertyChanging(__.LoginPwd, value)) { _LoginPwd = value; OnPropertyChanged(__.LoginPwd); } } }

        private DateTime _AddTime;
        /// <summary>添加时间</summary>
        [DisplayName("添加时间")]
        [Description("添加时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AddTime", "添加时间", "datetime")]
        public DateTime AddTime { get { return _AddTime; } set { if (OnPropertyChanging(__.AddTime, value)) { _AddTime = value; OnPropertyChanged(__.AddTime); } } }

        private DateTime _LastLoginTime;
        /// <summary>上次登录时间</summary>
        [DisplayName("上次登录时间")]
        [Description("上次登录时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("LastLoginTime", "上次登录时间", "datetime")]
        public DateTime LastLoginTime { get { return _LastLoginTime; } set { if (OnPropertyChanging(__.LastLoginTime, value)) { _LastLoginTime = value; OnPropertyChanged(__.LastLoginTime); } } }

        private String _LastLoginIp;
        /// <summary>上次登录Ip</summary>
        [DisplayName("上次登录Ip")]
        [Description("上次登录Ip")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("LastLoginIp", "上次登录Ip", "nvarchar(50)")]
        public String LastLoginIp { get { return _LastLoginIp; } set { if (OnPropertyChanging(__.LastLoginIp, value)) { _LastLoginIp = value; OnPropertyChanged(__.LastLoginIp); } } }

        private String _Skip;
        /// <summary>默认皮肤</summary>
        [DisplayName("默认皮肤")]
        [Description("默认皮肤")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Skip", "默认皮肤", "nvarchar(50)")]
        public String Skip { get { return _Skip; } set { if (OnPropertyChanging(__.Skip, value)) { _Skip = value; OnPropertyChanged(__.Skip); } } }

        private Int32 _LoginCount;
        /// <summary>登录次数</summary>
        [DisplayName("登录次数")]
        [Description("登录次数")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("LoginCount", "登录次数", "int")]
        public Int32 LoginCount { get { return _LoginCount; } set { if (OnPropertyChanging(__.LoginCount, value)) { _LoginCount = value; OnPropertyChanged(__.LoginCount); } } }
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
                    case __.LoginName : return _LoginName;
                    case __.NickName : return _NickName;
                    case __.LoginPwd : return _LoginPwd;
                    case __.AddTime : return _AddTime;
                    case __.LastLoginTime : return _LastLoginTime;
                    case __.LastLoginIp : return _LastLoginIp;
                    case __.Skip : return _Skip;
                    case __.LoginCount : return _LoginCount;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.LoginName : _LoginName = Convert.ToString(value); break;
                    case __.NickName : _NickName = Convert.ToString(value); break;
                    case __.LoginPwd : _LoginPwd = Convert.ToString(value); break;
                    case __.AddTime : _AddTime = Convert.ToDateTime(value); break;
                    case __.LastLoginTime : _LastLoginTime = Convert.ToDateTime(value); break;
                    case __.LastLoginIp : _LastLoginIp = Convert.ToString(value); break;
                    case __.Skip : _Skip = Convert.ToString(value); break;
                    case __.LoginCount : _LoginCount = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得用户字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>Id</summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>登录用户名</summary>
            public static readonly Field LoginName = FindByName(__.LoginName);

            /// <summary>昵称</summary>
            public static readonly Field NickName = FindByName(__.NickName);

            /// <summary>登录密码</summary>
            public static readonly Field LoginPwd = FindByName(__.LoginPwd);

            /// <summary>添加时间</summary>
            public static readonly Field AddTime = FindByName(__.AddTime);

            /// <summary>上次登录时间</summary>
            public static readonly Field LastLoginTime = FindByName(__.LastLoginTime);

            /// <summary>上次登录Ip</summary>
            public static readonly Field LastLoginIp = FindByName(__.LastLoginIp);

            /// <summary>默认皮肤</summary>
            public static readonly Field Skip = FindByName(__.Skip);

            /// <summary>登录次数</summary>
            public static readonly Field LoginCount = FindByName(__.LoginCount);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得用户字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>Id</summary>
            public const String Id = "Id";

            /// <summary>登录用户名</summary>
            public const String LoginName = "LoginName";

            /// <summary>昵称</summary>
            public const String NickName = "NickName";

            /// <summary>登录密码</summary>
            public const String LoginPwd = "LoginPwd";

            /// <summary>添加时间</summary>
            public const String AddTime = "AddTime";

            /// <summary>上次登录时间</summary>
            public const String LastLoginTime = "LastLoginTime";

            /// <summary>上次登录Ip</summary>
            public const String LastLoginIp = "LastLoginIp";

            /// <summary>默认皮肤</summary>
            public const String Skip = "Skip";

            /// <summary>登录次数</summary>
            public const String LoginCount = "LoginCount";
        }
        #endregion
    }

    /// <summary>用户接口</summary>
    public partial interface ISysUser
    {
        #region 属性
        /// <summary>Id</summary>
        Int32 Id { get; set; }

        /// <summary>登录用户名</summary>
        String LoginName { get; set; }

        /// <summary>昵称</summary>
        String NickName { get; set; }

        /// <summary>登录密码</summary>
        String LoginPwd { get; set; }

        /// <summary>添加时间</summary>
        DateTime AddTime { get; set; }

        /// <summary>上次登录时间</summary>
        DateTime LastLoginTime { get; set; }

        /// <summary>上次登录Ip</summary>
        String LastLoginIp { get; set; }

        /// <summary>默认皮肤</summary>
        String Skip { get; set; }

        /// <summary>登录次数</summary>
        Int32 LoginCount { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}
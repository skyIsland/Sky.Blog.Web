using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using NewLife;
using NewLife.Data;
using NewLife.Log;
using NewLife.Model;
using NewLife.Reflection;
using NewLife.Threading;
using NewLife.Web;
using XCode;
using XCode.Cache;
using XCode.Configuration;
using XCode.DataAccessLayer;
using XCode.Membership;

namespace Sky.Models
{
    /// <summary>用户</summary>
    public partial class SysUser : Entity<SysUser>
    {
        #region 对象操作
        static SysUser()
        {
            // 累加字段
            //Meta.Factory.AdditionalFields.Add(__.Logins);

            // 过滤器 UserModule、TimeModule、IPModule
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 在新插入数据或者修改了指定字段时进行修正
        }

        /// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void InitData()
        {
            // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
            if (Meta.Count > 0) return;

            if (XTrace.Debug) XTrace.WriteLine("开始初始化SysUser[用户]数据……");

            var entity = new SysUser();
            entity.Id = 0;
            entity.LoginName = "sdm";
            entity.NickName = "丹麦的面包不单卖";
            entity.LoginPwd = "sdmadmin".MD5();
            entity.AddTime = DateTime.Now;
            entity.LastLoginTime = DateTime.Now;
            entity.LastLoginIp = "127.0.0.1";
            entity.LoginCount = 1;
            entity.Insert();

            if (XTrace.Debug) XTrace.WriteLine("完成初始化SysUser[用户]数据！");
        }

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        /// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        /// <returns></returns>
        protected override Int32 OnDelete()
        {
            if(Meta.Count<=1) throw new Exception("必须保留至少一个可用账号！");
            return base.OnDelete();
        }
        #endregion

        #region 扩展属性
        #endregion

        #region 扩展查询
        /// <summary>
        /// 根据Id查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SysUser FindById(int id)
        {
            if (id <= 0) return null;
            if (Meta.Count >= 1000)
                return Find(_.Id, id);
            return Meta.Cache.Entities.FirstOrDefault(p => p.Id == id);
        }
        #endregion

        #region 高级查询
        #endregion

        #region 业务操作
        /// <summary>
        /// 更新登录信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int SaveLoginInfo(SysUser model)
        {
            model.LastLoginTime = DateTime.Now;
            model.LastLoginIp = WebHelper.UserHost;
            model.LoginCount++;
            return model.Update();
        }
        #endregion
    }
}
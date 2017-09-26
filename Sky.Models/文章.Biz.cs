using System;
using System.Collections.Generic;
using System.Linq;
using XCode;

namespace Sky.Models
{
    /// <summary>文章</summary>
    public partial class Article : Entity<Article>
    {
        #region 对象操作
        static Article()
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

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化Article[文章]数据……");

        //    var entity = new Article();
        //    entity.Id = 0;
        //    entity.ArticlassId = 0;
        //    entity.Title = "abc";
        //    entity.Author = "abc";
        //    entity.Content = "abc";
        //    entity.IsTop = true;
        //    entity.IsRecommend = true;
        //    entity.IsDelete = true;
        //    entity.AddTime = DateTime.Now;
        //    entity.EditTime = DateTime.Now;
        //    entity.AddUser = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化Article[文章]数据！"
        //}

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        ///// <returns></returns>
        //protected override Int32 OnDelete()
        //{
        //    return base.OnDelete();
        //}
        #endregion

        #region 扩展属性
        /// <summary>
        /// 所属分类
        /// </summary>
        public ArticleClass MyArticleClass => ArticleClass.FindById(ArticlassId);

        #endregion

        #region 扩展查询
        /// <summary>
        /// 作者推荐
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static List<Article> FindRecommend(int size) =>FindAll(_.IsRecommend == true & _.State == 1, "Id desc", null, 0, size).ToList();
        /// <summary>
        /// 随便看看
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static List<Article> FindRandom(int size)
        {
            var s = FindAll(_.State == 1, "Id desc", null, 0, 0);
            var list=new List<Article>();
            var count = s.Count;
            for (int i = 0; i < size; i++)
            {
                if (i <= count - 1)
                {
                    var rnd = new Random().Next(count);
                    var item = s[rnd];                   
                    if(list.Contains(item))
                        list.Add(s[i]);
                }
            }
            return list;
        }

        #endregion

        #region 高级查询

        #endregion

        #region 业务操作

        #endregion
    }
}
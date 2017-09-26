using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sky.Models;
using Sky.Web.Filter;

namespace Sky.Web.Controllers
{
    [TestActionExecuting]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 文章专栏
        /// </summary>
        /// <returns></returns>
        public ActionResult Article(string keyword, int articleClassId = 0,int pageNo=1,int pageSize=5)
        {
            var exp = Models.Article._.State == 1;
            exp &= Models.Article.SearchWhereByKey(keyword);
            exp &= Models.Article._.ArticlassId == articleClassId;           
            var count = Models.Article.FindCount(exp);
            ViewBag.IsKeyWord = count == 0&&!keyword.IsNullOrWhiteSpace()?keyword:"";
            ViewBag.ArticleClass = articleClassId == 0 ? new ArticleClass() : ArticleClass.FindById(articleClassId);
            var list = count == 0 ? Models.Article.FindAll("", Models.Article._.Hits + " desc", null, 0, 5).ToList() : Models.Article.FindAll(exp, Models.Article._.Sort, null, (pageNo - 1) * pageSize, pageSize).ToList();        
            return View(list);
        }
        /// <summary>
        /// 文章详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(Article model)
        {
            model.Hits++;
            model.Update();
            return View(model);
        }
        /// <summary>
        /// 资源分享
        /// </summary>
        /// <returns></returns>
        public ActionResult Resource()
        {
            return View();
        }
        /// <summary>
        /// 点点滴滴
        /// </summary>
        /// <returns></returns>
        public ActionResult TimeLine()
        {
            return View();
        }

        /// <summary>
        /// 关于本站
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sky.Common.Web;
using Sky.Models;
using Sky.Web.Filter;

namespace Sky.Web.Controllers
{
    [RecordPosition]
    [MvcHandleError]
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
        /// 网站来源分析
        /// </summary>
        /// <returns></returns>
        public ActionResult FromWhere()
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
        [HttpGet]
        public  ActionResult GetDataList(int pageNo, int pageSize)
        {
            var exp = Models.Article._.State == 1;
            var count = Models.Article.FindCount(exp);
            var datas = Models.Article.FindAll(exp, Models.Article._.IsTop + " Desc," + Models.Article._.IsRecommend + " Desc," + "EditTime desc", null, (pageNo - 1) * pageSize, pageSize).ToList();
            var totalPages = (int)Math.Ceiling((double) count / pageSize);
            var data = new List<string>{};
            datas.ForEach(p =>
            {               
                data.Add("<div class=\"article shadow animated zoomIn\">" +
                    "<div class=\"article-left\">" +
                    "<img src = '" + (p.PhotoUrl.IsNullOrWhiteSpace() ? "/Content/images/ShaDaMeng.jpg" : p.PhotoUrl) + "' alt=" + p.Title + " />" +
                    "</div>" +
                    "<div class=\"article-right\">" +
                    "<div class=\"article-title\">" +
                    "<a href = '" + Url.Action("Detail", new { id = p.Id }) + "'>" + p.Title + "</a>" +
                     "</div>" +
                     "<div class=\"article-abstract\">" + p.Introduce +
                        " </div>" +
                        " </div>" +
                        " <div class=\"clear\"></div>" +
                        " <div class=\"article-footer\">" +
                        " <span><i class=\"fa fa-clock-o\"></i>&nbsp;&nbsp;" + p.AddTime.ToString("yyyy-MM-dd HH:mm:ss") + "</span>" +
                        " <span class=\"article-author\"><i class=\"fa fa-user\"></i>&nbsp;&nbsp;" + p.Author + "</span>" +
                        " <span><i class=\"fa fa-tag\"></i>&nbsp;&nbsp;<a href = " + Url.Action("Article", new { articleClassId = p.ArticlassId }) + ">" + p.MyArticleClass + "</a></span>" +
                        " <span class=\"article-viewinfo\"><i class=\"fa fa-eye\"></i>&nbsp;"+p.Hits+"</span>" +
                        " </div>" +
                        "</div>");
            });
            var result = new DataResult
            {
                Result = true,
                Count = (int)count,
                Data = data.Join(""),
                PageNo = pageNo,
                TotalPages = totalPages
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取访问网站省份数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetHitsFromProvice()
        {
            //按省份分组
            var data = IpInfo.Meta.Cache.Entities.GroupBy(p => p.ProvinceId).OrderByDescending(p=>p.Count()).ToList();
            var provice=new List<object>();
            data.ForEach(p =>
            {
                var strName = (PositionData.Meta.Cache.Entities.FirstOrDefault(f=>f.Id==p.Key)??new PositionData()).Province;
                provice.Add(new {key=strName,value=p.Count()});
            });
            var result = new AjaxResult {Data = provice, Result = true};
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
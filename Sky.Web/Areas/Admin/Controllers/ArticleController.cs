using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sky.Common.Web;
using Sky.Models;
namespace Sky.Web.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {
        // GET: Admin/Article
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetDataList(string keyword, int pageNo, int pageSize)
        {
            var exp = Article._.State == 1;
            var count = Article.FindCount(exp);
            var data = Article.FindAll(exp, Article._.Id, null, (pageNo - 1) * pageSize, pageSize);
            var result = new DataResult
            {
                Result = true,
                Count =(int)count,
                Data = data,
                PageNo = pageNo
            };            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            var m=new Article();
            return View("Edit",m);
        }
        public ActionResult Edit(Article model)
        {
            return View(model);
        }
        [HttpPost]
        public ActionResult Save(Article model)
        {
            return Json(new AjaxResult());
        }
    }
}
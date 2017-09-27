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
    public class ArticleController : BaseController<ArticleClass>
    {
        // GET: Admin/Article
        public override ActionResult Index()
        {
            var allClass = ArticleClass.FindAll();
            ViewBag.AllClass = allClass;
            return View();
        }
        [HttpGet]
        public override ActionResult GetDataList(string keyword, int pageNo, int pageSize)
        {
            var exp = Article._.State>=0;
            var count = Article.FindCount(exp);
            var data = Article.FindAll(exp, Article._.EditTime+" desc ,"+Article._.Id+" desc", null, (pageNo - 1) * pageSize, pageSize);
            var result = new DataResult
            {
                Result = true,
                Count =(int)count,
                Data = data,
                PageNo = pageNo
            };            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(Article model)
        {
            var result = new AjaxResult();
            if (model.Id == 0)
            {
                model.AddTime=DateTime.Now;
                model.AddUser = CurrSysUser.LoginName;
            }
            model.EditTime=DateTime.Now;
            model.Save();
            result.Result = true;
            result.Message = "保存成功";
            return Json(result);
        }
        [HttpGet]
        public ActionResult Delete(Article model)
        {
            var result = new AjaxResult();
            if (model != null)
            {
                model.State = -1;
                model.Update();
                result.Result = true;
                result.Message = "删除成功!";
            }
            else
            {
                result.Message = "查找不到文章,请检查!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
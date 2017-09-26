using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sky.Common.Web;
using Sky.Models;
using XCode;

namespace Sky.Web.Areas.Admin.Controllers
{
    public class ArticleClassController : BaseController
    {
        // GET: Admin/ArticleClass
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetDataList(string keyword, int pageNo, int pageSize)
        {
            var exp = "1=1";
            var count = ArticleClass.FindCount(exp);
            var data = ArticleClass.FindAll(exp, ArticleClass._.Id, null, (pageNo - 1) * pageSize, pageSize);
            var result = new DataResult
            {
                Result = true,
                Count = (int)count,
                Data = data,
                PageNo = pageNo
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            var m = new ArticleClass();
            return View("Edit", m);
        }
        public ActionResult Edit(ArticleClass model)
        {
            return View(model);
        }      
        [HttpPost]
        public ActionResult Save(ArticleClass model)
        {
            model.ClassName = model.ClassName.Trim();         
            var records = ArticleClass.FindAll(ArticleClass._.ClassName, model.ClassName).FirstOrDefault();
            if (records != null&&records.Id!=model.Id)
                return Json(new AjaxResult { Message = "分类名字已存在!" });
            if (model.Id == 0) model.AddTime = DateTime.Now;
            model.Save();
            return Json(new AjaxResult{Result = true,Message="保存成功"});
        }
        [HttpGet]
        public ActionResult Delete(ArticleClass model)
        {
            var result=new AjaxResult();
            if (model != null)
            {
                ArticleClass.Meta.BeginTrans();
                try
                {
                    var allArticle = Article.FindAll(Article._.ArticlassId == model.Id);
                    allArticle.Delete();
                    model.Delete();
                    result.Result = true;
                    result.Message = "删除成功!";
                    ArticleClass.Meta.Commit();
                }
                catch (Exception ex)
                {
                    ArticleClass.Meta.Rollback();
                    NewLife.Log.XTrace.Log.Error("删除分类和分类下的文章出错,原因:"+ex.Message);
                }
              
            }
            else
            {
                result.Message = "查找分类失败,请检查!";
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sky.Common.Web;
using Sky.Models;

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
        [HttpGet]
        public ActionResult CheckName(string name)
        {
            var result=new AjaxResult();
            var records = ArticleClass.FindAll(ArticleClass._.ClassName, name).FirstOrDefault();
            if (records == null)
            {
                result.Result = true;
            }
            else
            {
                result.Message = "分类已存在!";
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Save(ArticleClass model)
        {
            if (model.Id == 0) model.AddTime = DateTime.Now;
            model.Save();
            return Json(new AjaxResult{Result = true,Message="保存成功"});
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewLife.Reflection;
using Sky.Common.Web;
using Sky.Models;
using Sky.Web.Filter;
using XCode;

namespace Sky.Web.Areas.Admin.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// 基类控制器
    /// </summary>
    [MvcHandleError]
    [EntityAuthorize]
    public class BaseController<TEntity> : Controller where TEntity : Entity<TEntity>, new()
    {
        // GET: Admin/Base
        public SysUser CurrSysUser => Sky.Core.Login.UserLogin.CurrUserData;
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public virtual ActionResult GetDataList(string keyword, int pageNo, int pageSize)
        {
            var op = EntityFactory.CreateOperate(new TEntity().GetType());
            var count = op.FindCount();
            var data = op.FindAll("", "Id", null, (pageNo - 1) * pageSize, pageSize);
            var result = new DataResult
            {
                Result = true,
                Count = (int)count,
                Data = data,
                PageNo = pageNo
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Add()
        {
            var model=new TEntity();
            return View("Edit", model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ActionResult Edit(TEntity model)
        {
            return View(model);
        }

        public virtual ActionResult Save(TEntity model)
        {
            model.Save();
            return Json(new AjaxResult { Result = true, Message = "保存成功!" });
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Delete(TEntity model)
        {          
            model.Delete();
            return Json(new AjaxResult {Result = true,Message = "删除成功!"},JsonRequestBehavior.AllowGet);
        }
    }
}
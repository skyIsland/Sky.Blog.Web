using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Article()
        {
            return View();
        }
        /// <summary>
        /// 文章详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            return View();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sky.Web.Areas.Admin.Controllers
{
    public class ArticleClassController : BaseController
    {
        // GET: Admin/ArticleClass
        public ActionResult Index()
        {
            return View();
        }
    }
}
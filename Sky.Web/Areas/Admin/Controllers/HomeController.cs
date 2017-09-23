using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Sky.Common.Common;
using Sky.Common.Web;
using Sky.Models;
using XCode.Membership;

namespace Sky.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }       
        public ActionResult DataList()
        {
            return View();
        }

        
    }
}
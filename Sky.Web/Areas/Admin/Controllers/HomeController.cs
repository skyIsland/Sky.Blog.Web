using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Sky.Common.Common;
using Sky.Common.Web;
using Sky.Models;
using Sky.Web.Filter;
using XCode.Membership;

namespace Sky.Web.Areas.Admin.Controllers
{
    [MvcHandleError]
    [EntityAuthorize]
    public class HomeController :Controller
    {
        // GET: Admin/Home       

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
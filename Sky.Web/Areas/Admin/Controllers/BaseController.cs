using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sky.Models;
using Sky.Web.Filter;

namespace Sky.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 基类控制器
    /// </summary>
    [MvcHandleError]
    [EntityAuthorize]
    public class BaseController : Controller
    {
        // GET: Admin/Base
        public SysUser CurrSysUser => Sky.Core.Login.UserLogin.CurrUserData;
    }
}
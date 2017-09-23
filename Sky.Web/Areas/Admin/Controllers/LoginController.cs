using Sky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sky.Common.Web;

namespace Sky.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        #region 登录
        public ActionResult Index()
        {
            //已登陆
            if (Sky.Core.Login.UserLogin.CurrUserData != null)
            {
                return Redirect("/Admin/Home/Main");
            }
            else
            {
                return View();
            }
        }
        /// <summary>登陆</summary>
        /// <param name="loginName">用户名</param>
        /// <param name="loginPwd">密码</param>
        /// <returns></returns>
        public ActionResult Login(String loginName, String loginPwd)
        {
            loginName = loginName.Trim();
            loginPwd = loginPwd.Trim().MD5();
            var user = SysUser.Find(SysUser._.LoginName, loginName);
            if (user == null) return Json(new AjaxResult { Message = "你没输对账号啵!" });
            if (user.LoginPwd != loginPwd) return Json(new AjaxResult { Message = "你的密码没输对啊!" });
            Sky.Core.Login.UserLogin.Signin(user);
            return Json(new AjaxResult { Result = true, Message = "欢迎回来！" });
        }
        /// <summary>登出</summary>
        public ActionResult Logout()
        {

            return Redirect("/Admin/Login/Index");
        }


        #endregion
    }
}
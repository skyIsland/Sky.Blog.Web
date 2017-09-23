using Sky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Sky.Core.Login
{
    public class UserLogin
    {
        /// <summary>
        /// 当前登录用户信息(如果未登录，返回null)
        /// </summary>
        public static SysUser CurrUserData
        {
            get
            {
                int g = 0;
                if (HttpContext.Current.User.Identity.IsAuthenticated && int.TryParse(HttpContext.Current.User.Identity.Name, out g))
                {
                    return SysUser.FindById(g);
                }
                return null;
            }
        }
        /// <summary>
        /// 管理员用户登陆
        /// </summary>
        /// <param name="sUT">用户实体类</param>
        public static void Signin(SysUser sUT)
        {
            System.Web.Security.FormsAuthenticationTicket tk = new FormsAuthenticationTicket(1,
                sUT.Id.ToString(),
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                true,
                sUT.LoginName,
                System.Web.Security.FormsAuthentication.FormsCookiePath
            );
            string key = System.Web.Security.FormsAuthentication.Encrypt(tk); //得到加密后的身份验证票字串 
            HttpCookie ck = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, key);
            ck.HttpOnly = true;
            //ck.Domain = System.Web.Security.FormsAuthentication.CookieDomain;  // 这句话在部署网站后有用，此为关系到同一个域名下面的多个站点是否能共享Cookie
            HttpContext.Current.Response.Cookies.Add(ck);
        }
        /// <summary>
        /// 管理员用户退出()
        /// </summary>
        public static void UserOut()
        {

            if (CurrUserData != null)
            {
                System.Web.Security.FormsAuthentication.SignOut();
            }
        }
    }
}

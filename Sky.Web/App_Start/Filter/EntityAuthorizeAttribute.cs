using System.Net;
using System.Web.Mvc;
using NewLife.Web;

namespace Sky.Web.Filter
{
    /// <inheritdoc />
    /// <summary>实体授权特性</summary>
    public class EntityAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = Sky.Core.Login.UserLogin.CurrUserData;
            var context = filterContext.HttpContext;
            var request = context.Request;
            var response = context.Response;
            //判断是否登陆
            if (user == null)
            {
                //往Cookie中写入登陆超时
                WebHelper.WriteCookie("CookieLoginError", "Timeout");
                //非ajax请求，增加js跳转
                if (!request.IsAjaxRequest()) response.Write("<script>top.location.href = '/Admin/Login/Index';</script>");
                //这个方法会将StatusCode设置为401,并设置响应结果为HttpUnauthorizedResult
                //HandleUnauthorizedRequest(filterContext);
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized, Sky.Common.Common.Utils.StringToISO_8859_1("401 登陆超时"));
                return;
            }
            base.OnAuthorization(filterContext);
        }
    }
   
}
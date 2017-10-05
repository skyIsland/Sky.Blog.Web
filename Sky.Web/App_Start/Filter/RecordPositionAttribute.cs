using System.Configuration;
using System.Web.Mvc;
using Sky.Common.Common;

namespace Sky.Web.Filter
{
    public class RecordPositionAttribute: ActionFilterAttribute
    {
        private static string _IpKey;
        private static string IpKey => _IpKey ?? ConfigurationManager.AppSettings["IpKey"];
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.RequestContext.HttpContext.Request;
            var ip = NewLife.Web.WebHelper.UserHost;           
            var str = GetIpFromWhere.GetPosition(ip, IpKey);
            NewLife.Log.XTrace.Log.Info($"Ip:{ip}访问了:{request.Url}!浏览器:{request.Browser.Browser}");
            NewLife.Log.XTrace.Log.Info($"Ip地址来源:{str}");
            base.OnActionExecuting(filterContext);
        }
    }
}
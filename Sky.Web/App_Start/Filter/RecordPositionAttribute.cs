using System;
using System.Configuration;
using System.Web.Mvc;
using Sky.Common.Common;
using Sky.Models;
namespace Sky.Web.Filter
{
    public class RecordPositionAttribute: ActionFilterAttribute
    {
        private static string _IpKey;
        private static string IpKey => _IpKey ?? ConfigurationManager.AppSettings["IpKey"];
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.RequestContext.HttpContext.Request;
            //var ip = NewLife.Web.WebHelper.UserHost;
            var ip = "116.208.225.252";
            var str = GetIpFromWhere.GetPosition(ip, IpKey);
            if (!str.IsNullOrEmpty()||!str.Contains("错误"))//返回正确的信息
            {
                var array = str.Split(",");
                var provice = array[0];
                var city = array[1];
                var cityData = PositionData.FindCity(provice, city);
                var record = new IpInfo
                {
                    AddTime = DateTime.Now,
                    CityId = cityData.Id,
                    ProvinceId = cityData.ParentId,
                    Ip = ip
                };
                record.Insert();
            }
            NewLife.Log.XTrace.Log.Info($"Ip:{ip}访问了:{request.Url}!浏览器:{request.Browser.Browser}");
            //NewLife.Log.XTrace.Log.Info($"Ip地址来源:{str}");
            base.OnActionExecuting(filterContext);
        }
    }
}
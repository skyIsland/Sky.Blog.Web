using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sky.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("manager", "manager", new { controller = "Login", action = "Index" },new[]{ "Sky.Web.Areas.Admin.Controllers" }).DataTokens.Add("area","admin");
            routes.MapRoute(
                 "Default",
                 "{controller}/{action}/{id}",
                 new { controller = "Home", action = "Index", id = UrlParameter.Optional },new string[]
                 {
                     "Sky.Web.Controllers"
                 }
            );
         
        }
    }
}

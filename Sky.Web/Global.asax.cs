﻿using Sky.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sky.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //注册实体数据绑定器
            EntityModelBinderProvider.Register();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

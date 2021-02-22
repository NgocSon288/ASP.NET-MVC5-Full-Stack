using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FShop.Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ok
            routes.MapRoute(
                name: "TestLoginAdmin",
                url: "Admin/{controller}/{action}/{id}",
                namespaces: new[] { "FShop.Web.Areas.Admin.Controllers" },
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                namespaces: new[] { "FShop.Web.Controllers" },
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional}
            ); 
        }
    }
}

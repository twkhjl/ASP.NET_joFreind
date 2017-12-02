using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestWebAPI2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //enable attribute routing
            routes.MapMvcAttributeRoutes();

       
            routes.MapRoute(
               name: "Default",
               url: "",
               defaults: new { controller = "Page", action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}


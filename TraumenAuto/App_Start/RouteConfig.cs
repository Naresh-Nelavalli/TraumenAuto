using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TraumenAuto
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional,
                    name = UrlParameter.Optional,
                    distance = UrlParameter.Optional,
                    year = UrlParameter.Optional,
                    maker = UrlParameter.Optional,
                    zipcode = UrlParameter.Optional,
                    price = UrlParameter.Optional
                }
            );
        }
    }
}

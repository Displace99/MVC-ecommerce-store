using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Specific to the Admin controller. Overrides the {category} route below
            routes.MapRoute(null, "Admin",
                new { controller = "Admin", action = "Index" });

            //If no URL is specified, go to Product/List
            routes.MapRoute(null, "",
                new { controller = "Product", action = "List", category = (string)null, page = 1 });

            //URL: /Page2
            routes.MapRoute(null, "Page{page}",
                new { controller = "Product", action = "List", category = (string)null }, new { page = @"\d+" });

            //URL: /Watersports (NOTE: "Admin" is overridden in the route above)
            routes.MapRoute(null, "{category}",
                new { controller = "Product", action = "List", page = 1 });

            //URL: /Watersports/Page2
            routes.MapRoute(null, "{category}/Page{page}",
                new { controller = "Product", action = "List" }, new { page = @"\d+" });

            //Sets up standard routing for edit page (ex. "Admin/Edit/5") 
            routes.MapRoute(null, "{controller}/{action}/{productID}",
                new { controller = "Admin", action = "Edit" }, new { productID = @"\d+" });

            routes.MapRoute(null, "{controller}/{action}");

            //routes.MapRoute(
            //    name: null,
            //    url: "Page{page}",
            //    defaults: new { Controller = "Product", action = "List"}
            //    );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            //);
        }
    }
}

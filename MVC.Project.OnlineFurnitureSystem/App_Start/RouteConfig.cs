using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Project.OnlineFurnitureSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Account", "Account/{action}/{id}", new { controller = "Account", action = "Index", id = UrlParameter.Optional }, new[] { "CmsShoppingCart.Controllers" });

            routes.MapRoute("Cart", "Cart/{action}/{id}", new { controller = "Cart", action = "Index", id = UrlParameter.Optional }, new[] { "CmsShoppingCart.Controllers" });

            routes.MapRoute("Shop", "Shop/{action}/{name}", new { Controller = "Shop", action = "Index",name= UrlParameter.Optional }, new[] { "MVC.Project.OnlineFurnitureSystem.Controllers" });

            routes.MapRoute("HomePagePartial", "Pages/HomePagePartial", new { Controller = "Pages", action = "HomePagePartial" }, new[] { "MVC.Project.OnlineFurnitureSystem.Controllers" });
            routes.MapRoute("SideBarPartial", "Pages/SideBarPartial", new { Controller = "Pages", action = "SideBarPartial" }, new[] { "MVC.Project.OnlineFurnitureSystem.Controllers" });
            routes.MapRoute("PagesMenuPartial", "Pages/PagesMenuPartial", new { Controller = "Pages", action = "PagesMenuPartial" }, new[] { "MVC.Project.OnlineFurnitureSystem.Controllers" });
            routes.MapRoute("Pages", "{Page}", new { Controller = "Pages", action = "Index" }, new[] { "MVC.Project.OnlineFurnitureSystem.Controllers" });
            routes.MapRoute("Home", "Pages/Index", new { Controller = "Pages", action = "Index" }, new[] { "MVC.Project.OnlineFurnitureSystem.Controllers" });
            routes.MapRoute("Default", "", new { Controller = "Pages", action = "Index" }, new[] { "MVC.Project.OnlineFurnitureSystem.Controllers" });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}

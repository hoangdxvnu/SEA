using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TLU.Blog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AjaxRemoveComment",
                url: "AjaxRemoveComment",
                defaults: new { controller = "Home", action = "RemoveComment", pId = UrlParameter.Optional, pPostId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "NewPost",
                url: "NewPost",
                defaults: new { controller = "Home", action = "NewPost", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Post",
                url: "Post/{id}",
                defaults: new { controller = "Home", action = "Post", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contact",
                url: "Contact",
                defaults: new { controller = "Home", action = "Contact", pPostId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Answer",
                url: "Answer/{id}",
                defaults: new { controller = "Home", action = "Answer", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "New",
                url: "New",
                defaults: new { controller = "Home", action = "New", pPostId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "Home", action = "About", pPostId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Index",
                url: "Index",
                defaults: new { controller = "Home", action = "Index", pPostId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AutoListComment",
                url: "AutoListComment/{pPostId}",
                defaults: new { controller = "Home", action = "AutoListComment", pPostId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "IpAddress",
                url: "IpAddress/{Url}",
                defaults: new { controller = "AdminImage", action = "IpAddress", Url = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CountComment",
                url: "CountComment/{pPostId}",
                defaults: new { controller = "Home", action = "CountComment", pPostId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {

            routes.RouteExistingFiles = true;

            routes.MapMvcAttributeRoutes();
/*
            routes.MapRoute(
               name: "NewRoute",
               url: "App/Do{action}",
               defaults: new {
                   controller = "Home"                                      
               }
           );
            */
            /*routes.MapRoute(
         
                name: "MyRoute",
               url: "{controller}/{action}/{id}",
               defaults: new {
                   controller = "Home", 
                   action = "Index", 
                   id = UrlParameter.Optional
               }               
           );
             */

            routes.Add(new Route("SayHello", new CustomRouteHandler()));

            routes.Add(
                new LegacyRoute(
                    "~/articles/Windows_3.1_Overview.html", 
                    "~/old/.NET_1.0_Class_Library"));

            routes.MapRoute(
                name: "MyRoute",
                url: "{controller}/{action}",
                namespaces: new []{"UrlsAndRoutes.Controllers"});

            routes.MapRoute(
                name: "MyOthewrRoute",
                url: "App/{action}",
                defaults: new {controller = "Home"},
                namespaces: new[] { "UrlsAndRoutes.Controllers" });
        }
    }
}
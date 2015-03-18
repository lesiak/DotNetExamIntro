using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           /* routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );*/

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },             
               namespaces: new[] { "URLsAndRoutes.Controllers" }
           );


           /* routes.MapRoute(
                name: "ChromeRoute",
                url: "{*catchall}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional},
                constraints: new {customConstrint = new UserAgentConstraint("Chrome")},
                namespaces: new[] { "URLsAndRoutes.AdditionalControllers" }
                );
            
            routes.MapRoute(
                name: "MyRoute",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new {
                    controller = "^H.*", 
                    action = "^Index$|^About$", 
                    httpMethod = new HttpMethodConstraint("GET"),
                    id = new CompoundRouteConstraint(new IRouteConstraint[] {
                      //new RangeRouteConstraint(10, 20),  
                      new AlphaRouteConstraint(), 
                      new MinLengthRouteConstraint(6), 
                    }) 
                },
                namespaces: new[] { "URLsAndRoutes.Controllers" }
            );
            */
            //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add("MyRoute", myRoute);

           /* routes.MapRoute("Shop", "Shop/OldAction",
                defaults: new { controller = "Home", action = "Index" });

            routes.MapRoute("Shop", "Shop/{action}",
                defaults: new { controller = "Home" });

            routes.MapRoute("", "X{controller}/{action}");

            routes.MapRoute("MyRoute", "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" });

            

            routes.MapRoute("", "Public/{controller}/{action}",
               defaults: new { controller = "Home", action = "Index" });
            */
        }
    }
}

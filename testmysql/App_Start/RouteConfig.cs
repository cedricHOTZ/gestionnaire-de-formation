using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace testmysql
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
           name: "contact",
           url: "Contact",
           defaults: new { controller = "Contact", action = "Index" }
       );

            routes.MapRoute(
              name: "detailsFormation",
              url: "formation/{nomSeo}",
              defaults: new { controller = "Formation", action = "DetailsFormation" }
          );

            routes.MapRoute(
               name: "ToutesLesFormations",
               url: "Toutes-Les-Formations",
               defaults: new { controller = "Formation", action = "ToutesLesFormations" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GruppG
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //HomeController
            routes.MapRoute(
                name: "Home",
                url: "Hem",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "About",
                url: "Hem/Om/{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contact",
                url: "Kontakt",
                defaults: new { controller = "Home", action = "Contact" }
            );


            routes.MapRoute(
                name: "Programinfo",
                url: "Programdetaljer/{title}",
                defaults: new { controller = "Home", action = "ProgramDetails", title = "" }
            );

            //PersonController
            //routes.MapRoute(
            //    name: "MyPage",
            //    url: "Minasidor/{id}",
            //    defaults: new { controller = "Person", action = "MyPage", id = UrlParameter.Optional }
            //);

            //LoginController
            routes.MapRoute(
                name: "LogIn",
                url: "MinaSidor",
                defaults: new { controller = "Login", action = "LogIn" }
            );

            routes.MapRoute(
                name: "Register",
                url: "Registrering",
                defaults: new { controller = "Login", action = "Register" }
            );

           





            //DON'T TOUCH! 
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

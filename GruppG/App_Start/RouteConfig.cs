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
                defaults: new { controller = "Home", action = "Index",
                date = UrlParameter.Optional,
                id = UrlParameter.Optional}
            );


            routes.MapRoute(
                name: "Contact",
                url: "Kontakt",
                defaults: new { controller = "Home", action = "Contact" }
            );


            routes.MapRoute(
                name: "Programinfo",
                url: "Programdetaljer",
                defaults: new { controller = "Home", action = "ProgramDetails",
                
                }
            );

         

            //LoginController
            routes.MapRoute(
                name: "LogIn",
                url: "LogIn",
                defaults: new { controller = "Login", action = "LogIn", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "Registrering",
                defaults: new { controller = "Login", action = "Register" }
            );

            //MyPage
            //routes.MapRoute(
            //    name: "Index",
            //    url: "MinaSidor, {firstName}, {lastName}",
            //    defaults: new { controller = "MyPage", action = "Index",
            //        firstName = "",
            //        lastName = "",
            //        date = UrlParameter.Optional,
            //        category = UrlParameter.Optional,
            //        id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Index",
                url: "MinaSidor",
                defaults: new
                {
                    controller = "MyPage",
                    action = "Index",
                    date = UrlParameter.Optional,
                    category = UrlParameter.Optional,
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "MyFavoriteChannels",
                url: "Redigera",
                defaults: new
                { controller = "MyPage", action = "MyFavoriteChannels", username = UrlParameter.Optional }
                //Lägg till datum som id här?
            );



            //AdminController
            routes.MapRoute(
               name: "Admin",
               url: "Admin",
               defaults: new
               {
                   controller = "Admin",
                   action = "Index",
                   date = UrlParameter.Optional,
                   id = UrlParameter.Optional
               }
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

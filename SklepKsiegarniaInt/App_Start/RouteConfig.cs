using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SklepKsiegarniaInt
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "KsiazkiSzczegoly",
                url: "ksiazka-(id).html",
                defaults: new { controller = "Ksiazki", action = "Szczegoly" });

            routes.MapRoute(
                name: "KsiazkiList",
                url: "Kategoria/{nazwaKategori}",
                defaults: new { controller = "Ksiazki", action = "Lista" });

            routes.MapRoute(
                name: "StronyStatyczne",   //trasa dla stron statycznych , metoda jest w Homekontrolerze
                url: "strony/{nazwa}.html", //adres url do stron statycznych
                defaults: new { controller = "Home", action = "StronyStatyczne" }); // wartosci domyslne

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

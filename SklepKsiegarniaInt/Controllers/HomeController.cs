using SklepKsiegarniaInt.DAL;
using SklepKsiegarniaInt.Infrastructure;
using SklepKsiegarniaInt.Models;
using SklepKsiegarniaInt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepKsiegarniaInt.Controllers
{
    public class HomeController : Controller
    {
        private KsiazkiContext db = new KsiazkiContext();
        public ActionResult Index()
        {
            

            ICacheProvider cache = new DefaultCacheProvider();

            List<Kategoria> kategorie;
            if (cache.IsSet(Consts.KategorieCacheKey))
            {
                kategorie = cache.Get(Consts.KategorieCacheKey) as List<Kategoria>;
            }
            else
            {
                kategorie = db.Kategorie.ToList();
                cache.Set(Consts.KategorieCacheKey, kategorie, 5);
            }


             var nowosci = db.Ksiazki.Where(a => !a.Ukryty).OrderByDescending(a => a.DataDodania).Take(3).ToList();           
             var bestseller = db.Ksiazki.Where(a => !a.Ukryty && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList();//Guid sortuje po unikalnej wartosci losowo
    
             
            var vm = new HomeViewModel()
            {
                Kategorie = kategorie,
                Nowosci = nowosci,
                Bestsellery = bestseller
            };
            return View(vm);
        }

            public ActionResult StronyStatyczne(string nazwa)
            {
                return View ( nazwa );
        
            }
        
    }
}

using SklepKsiegarniaInt.DAL;
using SklepKsiegarniaInt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepKsiegarniaInt.Controllers
{
    public class KsiazkiController : Controller
    {
        private KsiazkiContext db = new KsiazkiContext();
        // GET: Ksiazki
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Lista(string nazwaKategori, string searchQuery = null)
        {
            var kategoria = db.Kategorie.Include("Ksiazki").Where(k => k.NazwaKategorii.ToUpper() == nazwaKategori.ToUpper()).Single();

            var ksiazki = kategoria.Ksiazki.Where(a => (searchQuery == null ||
                                              a.TytulKsiazki.ToLower().Contains(searchQuery.ToLower()) ||
                                              a.AutorKsiazki.ToLower().Contains(searchQuery.ToLower())) &&
                                              !a.Ukryty);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_KsiazkiList", ksiazki);
            }

            return View(ksiazki);
        }
        public ActionResult Szczegoly(int id)
        {
            var ksiazka = db.Ksiazki.Find(id);
            return View(ksiazka);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult KategorieMenu()
        {
            var kategorie = db.Kategorie.ToList();
            return PartialView("_KategorieMenu", kategorie);
        }
        public ActionResult KsiazkiPodpowiedzi(string term)
        {
            var ksiazki = db.Ksiazki.Where(a => !a.Ukryty && a.TytulKsiazki.ToLower().Contains(term.ToLower()))
                        .Take(5).Select(a => new { label = a.TytulKsiazki });

            return Json(ksiazki, JsonRequestBehavior.AllowGet);
        }
    }
}
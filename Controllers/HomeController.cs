using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmSitesi.Models;
using FilmSitesi.DAL;
using System.Globalization;

namespace FilmSitesi.Controllers
{
    public class HomeController : Controller
    {
        uygulamalarContext db = new uygulamalarContext();
        public ActionResult Index()
        {
            try
            {
                ViewBag.Kategori = db.Kategoriler.OrderBy(x => x.KategoriAdi).ToList();
                return View(db.Filmler.ToList());
            }
            catch (Exception)
            {
                ViewBag.Hata = "Hiç film yok";
                return View();
            }
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }

        public ActionResult GoogleSearch()
        {
            return View();
        }


        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
           public ActionResult Iletisim()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Iletisim(tbl_BizeUlas k)
        { 
            try
            {
                db.BizeUlas.Add(k);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            catch (Exception)
            {
                ViewBag.Hata = "Mesajınız Gönderilemedi";
            }

            return View();
        }
        public ActionResult Portfoy()
        {
          


            return View();
        }
   
    }
}
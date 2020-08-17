using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmSitesi.Models;
using FilmSitesi.DAL;
namespace FilmSitesi.Areas.Admin.Controllers
{
    public class KategoriController : Controller
    {
        uygulamalarContext db = new uygulamalarContext();
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Giris", "Panel");
            }

            try
            {
                return View(db.Kategoriler.ToList());
            }
            catch (Exception)
            {
                ViewBag.Hata = "Kategori eklenirken Hatalar Oluştu.";
                return View();
            }
        }
        public ActionResult Ekle()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Giris", "Panel");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tbl_Kategori k)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int say = db.Kategoriler.Where(x => x.KategoriAdi.ToLower() == k.KategoriAdi.ToLower()).Count();
                    if (say == 0)
                    {
                        k.KategoriAdi = k.KategoriAdi.ToUpper();
                        db.Kategoriler.Add(k);
                        db.SaveChanges();
                        ViewBag.Mesaj = "Kategori Eklendi.";
                    }
                    else
                    {
                        ModelState.AddModelError("", "böyle bir kategori zaten var.");
                    }
                }
                catch (Exception)
                {
                    ViewBag.Hata = "Kategori eklenirken Hatalar Oluştu.";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Sil(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Giris", "Panel");
            }

            if (id == null)
                return RedirectToAction("Index");
            try
            {
                var k = db.Kategoriler.Find(id);
                return View(k);
            }
            catch (Exception)
            {
                ViewBag.Hata = "Kategori eklenirken Hatalar Oluştu.";
                return View();
            }

        }
        [HttpPost]
        public ActionResult Sil(int id)
        {
            try
            {
                var k = db.Kategoriler.Find(id);
                db.Kategoriler.Remove(k);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Hata = "Kategori silinirken Hatalar Oluştu.";
                return View();
            }
        }
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
                return RedirectToAction("index");
            try
            {
                var k = db.Kategoriler.Find(id);
                return View(k);
            }
            catch (Exception)
            {

                ViewBag.Hata = "Kategori eklenirken Hatalar Oluştu.";
                return View();
            }
        }
        [HttpPost]
        public ActionResult Guncelle(tbl_Kategori k,int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var m = db.Kategoriler.Find(id);
                    m.KategoriAdi = k.KategoriAdi.ToUpper();
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {
                ViewBag.Hata = "Kategori Guncellerken Hatalar Oluştu.";
            }
            return View();
        }
    }
}
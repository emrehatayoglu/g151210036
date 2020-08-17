using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmSitesi.Models;
using FilmSitesi.DAL;
namespace FilmSitesi.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        uygulamalarContext db = new uygulamalarContext();
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Giris", "Panel");
            }

            try
            {
                return View(db.Adminler.ToList());
            }
            catch (Exception)
            {
                ViewBag.Hata = "Admin eklenirken Hatalar Oluştu.";
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
        public ActionResult Ekle(tbl_Admin k)
        {
            if (ModelState.IsValid)
            {
                try
                {

                                      
                    int say = db.Adminler.Where(x => x.AdminAdi.ToLower() == k.AdminAdi.ToLower()).Count();
                    if (say == 0)
                    {
                        k.AdminAdi = k.AdminAdi.ToUpper();
                        db.Adminler.Add(k);
                        db.SaveChanges();

                    }
                    else
                    {
                        ModelState.AddModelError("", "böyle bir Admin zaten var.");
                    }
                }
                catch (Exception)
                {
                    ViewBag.Hata = "Admin eklenirken Hatalar Oluştu.";
                }
            }
            else
            {

                if (string.IsNullOrEmpty(k.AdminAdi) || string.IsNullOrEmpty(k.AdminSifre))
                {
                    ModelState.AddModelError("", "Lütfe tüm alanları doldurunuz.");
                }
                
            }
            return View();
        }
        public ActionResult Sil(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Giris", "Panel");
            }

            try
            {
                var k = db.Adminler.Find(id);
                return View(k);
            }
            catch (Exception)
            {
                ViewBag.Hata = "Admin Silinirken Hatalar Oluştu.";
                return View();
            }

        }
        [HttpPost]
        public ActionResult Sil( int id )
        {
            try
            {
                var k = db.Adminler.Find(id);
                db.Adminler.Remove(k);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception) { 
         
                ViewBag.Hata = "Admin silinirken Hatalar Oluştu.";
                return View();
            }

        }
        public ActionResult Guncelle(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Giris", "Panel");
            }

            if (id == null)
                return RedirectToAction("index");
            try
            {
                var k = db.Adminler.Find(id);
                return View(k);
            }
            catch (Exception)
            {

                ViewBag.Hata = "Admin Güncellenirken Hatalar Oluştu.";
                return View();
            }
        }
        [HttpPost]
        public ActionResult Guncelle(tbl_Admin k, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var m = db.Adminler.Find(id);
                    m.AdminAdi = k.AdminAdi.ToUpper();
                    m.AdminSifre = k.AdminSifre;
                    db.SaveChanges();
                    ViewBag.Mesaj = "Başarıyla Güncellendi";
                    return RedirectToAction("index");

                }
            }
            catch (Exception)
            {
                ViewBag.Hata = "Admin Guncellerken Hatalar Oluştu.";
            }
            return View();
        }
    }
}
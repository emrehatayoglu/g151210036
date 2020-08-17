using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmSitesi.Models;
using FilmSitesi.DAL;
using System.IO;
namespace FilmSitesi.Areas.Admin.Controllers
{
    public class FilmController : Controller
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
                ViewBag.Film = db.Filmler.OrderBy(x => x.FilmAdi).ToList();
                return View(db.Filmler.ToList());
            }
            catch (Exception)
            {
                ViewBag.Hata = "Hiç film yok";
                return View();
            }
        }
        public ActionResult Ekle()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Giris", "Panel");
            }

            ViewBag.Kategori = db.Kategoriler.OrderBy(x => x.KategoriAdi).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tbl_Film m)
        {
            m.resimUrl = "/assets/img/film/";
            if (ModelState.IsValid)
            {
                try
                {
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];

                        if (file != null && file.ContentLength > 0)
                        {
                            string[] uzantilar = { ".JPG", ".JPEG", ".PNG", ".BMP", ".GIF" };
                            Random sayi = new Random();
                            int nameID = sayi.Next(1, 10000); ;

                            for (int i = 0; i < uzantilar.Count(); i++)
                            {
                                if (file.FileName.ToString().ToUpper().EndsWith(uzantilar[i]))
                                {
                                    m.resimUrl += m.FilmAdi + nameID.ToString() + uzantilar[i];
                                    db.Filmler.Add(m);
                                    db.SaveChanges();
                                    var path = Path.Combine(Server.MapPath("~/assets/img/film/"), m.FilmAdi + nameID.ToString() + uzantilar[i]);
                                    file.SaveAs(path);
                                    ViewBag.Mesaj = "Film Başarıyla eklendi.";
                                    return RedirectToAction("index");
                                }
                            }
                        }
                    }
                    return RedirectToAction("index");
                }
                catch (Exception)
                {
                    ViewBag.Hata = "Film eklenirken Hatalar Oluştu.";
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
                var k = db.Filmler.Find(id);
                return View(k);
            }
            catch (Exception)
            {
                ViewBag.Hata = "Film eklenirken Hatalar Oluştu.";
                return View();
            }
        }
        [HttpPost]
        public ActionResult Sil(int id)
        {
            try
            {
                var k = db.Filmler.Find(id);
                db.Filmler.Remove(k);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Hata = "Film silinirken Hatalar Oluştu.";
                return View();
            }
        }

        public ActionResult Guncelle(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Giris", "Panel");
            }
            try
            {
                ViewBag.Kategori = db.Kategoriler.OrderBy(x => x.KategoriAdi).ToList();
                var k = db.Filmler.Find(id);

                return View(k);
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }



        }
        [HttpPost]
        public ActionResult Guncelle(tbl_Film k, int id)
        {
            try
            {
               
                var m = db.Filmler.Find(id);
                m.resimUrl = "/assets/img/film/";
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        string[] uzantilar = { ".JPG", ".JPEG", ".PNG", ".BMP", ".GIF" };
                        Random sayi = new Random();
                        int nameID = sayi.Next(1, 10000); ;

                        for (int i = 0; i < uzantilar.Count(); i++)
                        {
                            if (file.FileName.ToString().ToUpper().EndsWith(uzantilar[i]))
                            {
                                m.FilmAdi = k.FilmAdi.ToUpper();
                                m.FilmBilgi = k.FilmBilgi;

                                m.YonetmenAdi = k.YonetmenAdi;
                                m.tbl_KategoriID = k.tbl_KategoriID;
                                m.resimUrl += m.FilmAdi + nameID.ToString() + uzantilar[i];

                                db.SaveChanges();
                                var path = Path.Combine(Server.MapPath("~/assets/img/film/"), m.FilmAdi + nameID.ToString() + uzantilar[i]);
                                file.SaveAs(path);
                                ViewBag.Mesaj = "Film Başarıyla güncellendi.";
                                return RedirectToAction("index");
                            }
                        }
                    }
                }
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                ViewBag.Hata = "Film eklenirken Hatalar Oluştu.";
            }
            return RedirectToAction("index");
        }
    }
}

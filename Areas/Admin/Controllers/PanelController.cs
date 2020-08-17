using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmSitesi.Models;
using FilmSitesi.DAL;
namespace FilmSitesi.Areas.Admin.Controllers
{
    public class PanelController : Controller
    {
        uygulamalarContext db = new uygulamalarContext();

        // GET: Admin/Panel
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Giris", "Panel");
            }
            return View();
        }

        public ActionResult AdminName()
        {
           
            int a = int.Parse(Session["user"].ToString());
            var k = db.Adminler.Find(a);
            ViewBag.ad=k.AdminAdi;

            return View();
        }
       
        public ActionResult Giris(string AdminAdi,string AdminSifre)
        {
            var varmi = db.Adminler.Where(x => x.AdminAdi == AdminAdi && x.AdminSifre == AdminSifre).FirstOrDefault();
            if (varmi != null)
            {
                Session["user"]=varmi.tbl_AdminID;
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                ViewBag.GirisHata = "Giriş Yapılmadı";
                RedirectToAction("Giris", "Panel");
            }

           
            return View();
        }
        public ActionResult Cikis()
        {
            Session["user"] = null;
            return RedirectToAction("Giris", "Panel");
           
        }
       public ActionResult Bizeulasin()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Giris", "Panel");
            }

            return View(db.BizeUlas.ToList());

        }
        [HttpGet]
        public ActionResult BizeUlasSil(int? id)
       {
            try
            {
                var k = db.BizeUlas.Find(id);
                return View(k);
            }
            catch (Exception)
            {
                ViewBag.Hata = "Kategori eklenirken Hatalar Oluştu.";
                return View();
            }
            

        }

        [HttpPost]
        public ActionResult BizeUlasSil(int id)
        {
            try
            {
                var k = db.BizeUlas.Find(id);
                db.BizeUlas.Remove(k);
                db.SaveChanges();
                return RedirectToAction("index","panel");
            }
            catch (Exception)
            {
                ViewBag.Hata = "Mesaj silinirken Hatalar Oluştu.";
                return View();
            }
        }
    }
}
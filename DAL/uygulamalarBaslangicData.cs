using FilmSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmSitesi.DAL
{//Oluşturulan tablolara test işlemleri için veri girişi yapılıyor.
    public class uygulamalarBaslangicData : System.Data.Entity.DropCreateDatabaseIfModelChanges<uygulamalarContext>
    {
        protected override void Seed(uygulamalarContext context)
        {
            var Kategori = new List<tbl_Kategori>
                        {
            new tbl_Kategori {KategoriAdi="Aksiyon"},
             new tbl_Kategori {KategoriAdi="Dram"},
              new tbl_Kategori {KategoriAdi="Gerilim"},
               new tbl_Kategori {KategoriAdi="Komedi"},
                new tbl_Kategori {KategoriAdi="Korku"},
                   new tbl_Kategori {KategoriAdi="Macera"}
            };
            context.Kategoriler.AddRange(Kategori);
            context.SaveChanges();

            var Admin = new List<tbl_Admin>
                        {
            new tbl_Admin {AdminAdi="emre",AdminSifre="hatayoglu"},
              new tbl_Admin {AdminAdi="admin",AdminSifre="admin"}

            };
            context.Adminler.AddRange(Admin);
            context.SaveChanges();

            var Film = new List<tbl_Film>
            {
            new tbl_Film {FilmAdi ="3 Ideots",tbl_KategoriID=1,YonetmenAdi="ahmet@gmail.com",FilmBilgi="Deneme" },
            new tbl_Film {FilmAdi ="Labirent",tbl_KategoriID=2,YonetmenAdi="cetin@gmail.com",FilmBilgi="Deneme" },
            new tbl_Film {FilmAdi ="Sema",tbl_KategoriID=3,YonetmenAdi="Sema@gmail.com" ,FilmBilgi="Deneme"},
            new tbl_Film {FilmAdi ="sefa",tbl_KategoriID=3,YonetmenAdi="sefa@gmail.com" ,FilmBilgi="Deneme"},
            new tbl_Film {FilmAdi ="mehmet",tbl_KategoriID=3,YonetmenAdi="mehmet@gmail.com",FilmBilgi="Deneme" },
            new tbl_Film {FilmAdi ="eda",tbl_KategoriID=2,YonetmenAdi="eda@gmail.com" ,FilmBilgi="Deneme"},
            new tbl_Film {FilmAdi ="esra",tbl_KategoriID=1,YonetmenAdi="esra@gmail.com" ,FilmBilgi="Deneme"}

            };

            context.Filmler.AddRange(Film);
            context.SaveChanges();
        }
    }
}
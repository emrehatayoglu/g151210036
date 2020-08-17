using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmSitesi.Models
{
    public class tbl_Film
    {
        public int tbl_FilmID { get; set; }
        [Required(ErrorMessage = "Lütfen Film adı giriniz...")]
        public string FilmAdi { get; set; }


        public string resimUrl { get; set; }
        [Required(ErrorMessage = "Lütfen Kategori seçiniz...")]
        public int tbl_KategoriID { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı adı giriniz...")]
        public string YonetmenAdi { get; set; }

        [Required(ErrorMessage = "Lütfen Film içeriği alanını doldurunuz...")]
        public string FilmBilgi { get; set; }

        public virtual tbl_Kategori kategori { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmSitesi.Models
{
    public class tbl_Kategori
    {
        public int tbl_KategoriID { get; set; }

        [Required(ErrorMessage = "Lütfen Kategori adı giriniz.")]
        public string KategoriAdi { get; set; }
        public virtual ICollection<tbl_Film> film { get; set; }
    }
}
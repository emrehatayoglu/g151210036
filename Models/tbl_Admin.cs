using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmSitesi.Models
{
    public class tbl_Admin
    {
        
        public int tbl_AdminID { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı adı giriniz...")]
        public string AdminAdi { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı şifresi giriniz...")]
        public string AdminSifre { get; set; }    }
}
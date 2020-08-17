using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmSitesi.Models
{
    public class tbl_BizeUlas
    {
        public int tbl_BizeUlasID { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı giriniz...")]
        public string BizeUlasAd { get; set; }


        [Required(ErrorMessage = "Lütfen soyadınızı giriniz...")]
        public string BizeUlasSoyAd { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Lütfen doğru bir eposta  giriniz..")]
        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz...")]
        public string BizeUlasMail { get; set; }


        [Required(ErrorMessage = "Lütfen mesajınızı giriniz...")]
        public string BizeUlasMesaj { get; set; }
    }
}
using FilmSitesi.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FilmSitesi.DAL
{                //Benim verdiğim isim : Kalıtım alınan sınıf
    public class uygulamalarContext : DbContext
    {
        public uygulamalarContext()
            : base("uygulamalarContext")
        {
        }
        //uygulama 5 den itibaren code first örnekleri için oluşturuldu.
        public DbSet<tbl_Kategori> Kategoriler { get; set; }
        public DbSet<tbl_Admin> Adminler { get; set; }
        public DbSet<tbl_Film> Filmler { get; set; }
        public DbSet<tbl_BizeUlas> BizeUlas { get; set; }
        //uygulama 5 den itibaren code first örnekleri için oluşturuldu.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}
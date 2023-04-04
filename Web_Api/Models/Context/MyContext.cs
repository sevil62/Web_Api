using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web_Api.Models.Entities;

namespace Web_Api.Models.Context
{
    public class MyContext : DbContext
    {
        //DbContext sınıfınız veritabanı işlemlerinizin hepsini yapabilen bir sınıfınızdır...Siz veritabanı işlemlerinizi yapabilmek icin DbContext'ten miras alırsınız...

        //Bir sınıf DbContext'ten miras alıyor ise o bir Veritabanı sınıfıdır...

        //Buradaki base'in string argümanı calısacak olan projenin config dosyasındaki connectionStrings isimlerini arar...Oradan buldugunun adresini algılar..

        public MyContext() : base("myConnection")
        {

        }
        //Tam veritabanı olusurken yapmak istediginiz özel ayarlamalar(tablo isimleri,sütun isimleri,ilgili sütun veri tipleri vs...) OnModelCreating isimli metotta yapılır..
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("City");
        }
        public DbSet<City> Cities { get; set; }
    }
}
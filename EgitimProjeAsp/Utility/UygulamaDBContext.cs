using EgitimProjeAsp.Models;
using Microsoft.EntityFrameworkCore;

//Veri tabanında EF tablo oluşturması için ilgili model sınıflarınızı buraya eklemelisiniz.
namespace EgitimProjeAsp.Utility
{
    public class UygulamaDBContext:DbContext
    {
        public UygulamaDBContext(DbContextOptions<UygulamaDBContext> options):base(options) { } 
        
        public DbSet<KitapTuru> KitapTuruleri { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kiralama> Kiralamalar { get; set; }
    }
}

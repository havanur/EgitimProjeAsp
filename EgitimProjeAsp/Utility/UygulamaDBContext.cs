using EgitimProjeAsp.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimProjeAsp.Utility
{
    public class UygulamaDBContext:DbContext
    {
        public UygulamaDBContext(DbContextOptions<UygulamaDBContext> options):base(options) { } 
        
        public DbSet<KitapTuru> KitapTuruleri { get; set; }  
    }
}

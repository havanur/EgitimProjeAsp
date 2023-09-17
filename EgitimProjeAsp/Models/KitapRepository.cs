using EgitimProjeAsp.Utility;

namespace EgitimProjeAsp.Models
{
    public class KitapRepository : Repository<Kitap>, IKitapRepository
    {
        private UygulamaDBContext _uygulamaDBContext;
        public KitapRepository(UygulamaDBContext uygulamaDBContext) : base(uygulamaDBContext)
        {
            _uygulamaDBContext=uygulamaDBContext;
        }

        public void Guncelle(Kitap kitap)
        {
            _uygulamaDBContext.Update(kitap);
        }

        public void Kaydet()
        {
            _uygulamaDBContext.SaveChanges();
        }
    }
}

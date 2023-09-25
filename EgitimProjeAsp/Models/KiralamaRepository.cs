using EgitimProjeAsp.Utility;

namespace EgitimProjeAsp.Models
{
    public class KiralamaRepository : Repository<Kiralama>, IKiralamaRepository
    {
        private UygulamaDBContext _uygulamaDBContext;
        public KiralamaRepository(UygulamaDBContext uygulamaDBContext) : base(uygulamaDBContext)
        {
            _uygulamaDBContext=uygulamaDBContext;
        }

        public void Guncelle(Kiralama kiralama)
        {
            _uygulamaDBContext.Update(kiralama);
        }

        public void Kaydet()
        {
            _uygulamaDBContext.SaveChanges();
        }
    }
}

﻿using EgitimProjeAsp.Utility;

namespace EgitimProjeAsp.Models
{
    public class KitapTuruRepository : Repository<KitapTuru>, IKitapTuruRepository
    {
        private UygulamaDBContext _uygulamaDBContext;
        public KitapTuruRepository(UygulamaDBContext uygulamaDBContext) : base(uygulamaDBContext)
        {
            _uygulamaDBContext=uygulamaDBContext;
        }

        public void Guncelle(KitapTuru kitapTuru)
        {
            _uygulamaDBContext.Update(kitapTuru);
        }

        public void Kaydet()
        {
            _uygulamaDBContext.SaveChanges();
        }
    }
}

﻿namespace EgitimProjeAsp.Models
{
    public interface IKitapTuruRepository : IRepository<KitapTuru>
    {
        void Guncelle(KitapTuru kitapTuru);

        void Kaydet();
    }

}

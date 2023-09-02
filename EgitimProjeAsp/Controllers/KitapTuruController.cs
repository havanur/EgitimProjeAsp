using EgitimProjeAsp.Models;
using EgitimProjeAsp.Utility;
using Microsoft.AspNetCore.Mvc;

namespace EgitimProjeAsp.Controllers
{
    public class KitapTuruController : Controller
    {

        private readonly UygulamaDBContext _uygulamaDBContext;

        public KitapTuruController(UygulamaDBContext context)
        {
            _uygulamaDBContext = context;
        }
        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruList = _uygulamaDBContext.KitapTuruleri.ToList();
            return View(objKitapTuruList);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(KitapTuru kitapTuru)
        {

            //_uygulamaDBContext.KitapTuruleri.Add(kitapTuru);
            //_uygulamaDBContext.SaveChanges(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.

            //return RedirectToAction("Index", "KitapTuru");

            if (ModelState.IsValid)
            {

                _uygulamaDBContext.KitapTuruleri.Add(kitapTuru);
                _uygulamaDBContext.SaveChanges(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.
                TempData["basarili"] = "Yeni Kitap Türü başarılıyla oluşturuldu.";
                return RedirectToAction("Index", "KitapTuru");
            }
            return View();
        }

        public IActionResult Guncelle(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuruVt = _uygulamaDBContext.KitapTuruleri.Find(id);

            if (kitapTuruVt == null)
            {
                return NotFound();
            }
            return View(kitapTuruVt);
        }

        [HttpPost]
        public IActionResult Guncelle(KitapTuru kitapTuru)
        {

            //_uygulamaDBContext.KitapTuruleri.Add(kitapTuru);
            //_uygulamaDBContext.SaveChanges(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.

            //return RedirectToAction("Index", "KitapTuru");

            if (ModelState.IsValid)
            {

                _uygulamaDBContext.KitapTuruleri.Update(kitapTuru);
                _uygulamaDBContext.SaveChanges(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.
                TempData["basarili"] = "Yeni Kitap Türü başarılıyla güncellendi.";
                return RedirectToAction("Index", "KitapTuru");
            }
            return View();
        }

        //GET ACTION
        public IActionResult Sil(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuruVt = _uygulamaDBContext.KitapTuruleri.Find(id);

            if (kitapTuruVt == null)
            {
                return NotFound();
            }
            return View(kitapTuruVt);
        }

        [HttpPost,ActionName("Sil")]
        public IActionResult SilPost(int? id)
        {
            KitapTuru? kitapTuru = _uygulamaDBContext.KitapTuruleri.Find(id);
            if(kitapTuru==null)
            {
                return NotFound(); 
            }
            _uygulamaDBContext.KitapTuruleri.Remove(kitapTuru);
            _uygulamaDBContext.SaveChanges();
            TempData["basarili"] = "Kayıt silme işlemi başarılı.";
            return RedirectToAction("Index", "KitapTuru");


        }

    }
}

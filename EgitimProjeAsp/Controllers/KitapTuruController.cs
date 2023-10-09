using EgitimProjeAsp.Models;
using EgitimProjeAsp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EgitimProjeAsp.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class KitapTuruController : Controller
    {

        //private readonly UygulamaDBContext _uygulamaDBContext;

        private readonly IKitapTuruRepository _kitapTuruRepository;

        public KitapTuruController(IKitapTuruRepository context)
        {
            _kitapTuruRepository = context;
        }
        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruList = _kitapTuruRepository.GetAll().ToList();
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

                _kitapTuruRepository.Ekle(kitapTuru);
                _kitapTuruRepository.Kaydet(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.
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
            KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u=>u.id==id);

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

                _kitapTuruRepository.Guncelle(kitapTuru);
                _kitapTuruRepository.Kaydet(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.
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
             KitapTuru ? kitapTuruVt = _kitapTuruRepository.Get(u => u.id == id); 

            if (kitapTuruVt == null)
            {
                return NotFound();
            }
            return View(kitapTuruVt);
        }

        [HttpPost,ActionName("Sil")]
        public IActionResult SilPost(int? id)
        {
            KitapTuru? kitapTuru = _kitapTuruRepository.Get(u => u.id == id);
            if (kitapTuru==null)
            {
                return NotFound(); 
            }
            _kitapTuruRepository.Sil(kitapTuru);
            _kitapTuruRepository.Kaydet();
            TempData["basarili"] = "Kayıt silme işlemi başarılı.";
            return RedirectToAction("Index", "KitapTuru");


        }

    }
}

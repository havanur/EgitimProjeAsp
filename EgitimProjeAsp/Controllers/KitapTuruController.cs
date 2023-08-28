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

            _uygulamaDBContext.KitapTuruleri.Add(kitapTuru);
            _uygulamaDBContext.SaveChanges(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.

            return RedirectToAction("Index", "KitapTuru");

            //if(ModelState.IsValid)
            //{ 

            //_uygulamaDBContext.KitapTuruleri.Add(kitapTuru);
            //_uygulamaDBContext.SaveChanges(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.

            //return RedirectToAction("Index","KitapTuru");
            //}
            //return View();
        }

    }
}

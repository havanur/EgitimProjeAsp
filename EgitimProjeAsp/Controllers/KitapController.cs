using EgitimProjeAsp.Models;
using EgitimProjeAsp.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace EgitimProjeAsp.Controllers
{
    public class KitapController : Controller
    {

        //private readonly UygulamaDBContext _uygulamaDBContext;

        private readonly IKitapRepository _kitapRepository;
        private readonly IKitapTuruRepository _kitapTuruRepository;

        public KitapController(IKitapRepository kitapRepository, IKitapTuruRepository kitapTuruRepository)
        {
            _kitapRepository = kitapRepository;
            _kitapTuruRepository = kitapTuruRepository;
        }
        public IActionResult Index()
        {
            List<Kitap> objKitapList = _kitapRepository.GetAll().ToList();


            return View(objKitapList);
        }

        public IActionResult EkleGuncelle(int? id)
        {

            IEnumerable<SelectListItem> KitapTuruList = _kitapTuruRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.Ad,
                    Value = k.id.ToString()
                });

            ViewBag.KitapTuruList = KitapTuruList;


            if (id == null || id==0)
            {
                //ekle
                return View();
            }
            else
            {

                //Güncelle

                Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);

                if (kitapVt == null)
                {
                    return NotFound();
                }
                return View(kitapVt);

            }

           

            
        }

        [HttpPost]
        public IActionResult EkleGuncelle(Kitap kitap,IFormFile file)
        {

            //_uygulamaDBContext.Kitaplar.Add(kitap);
            //_uygulamaDBContext.SaveChanges(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.

            //return RedirectToAction("Index", "Kitap");

            if (ModelState.IsValid)
            {

                _kitapRepository.Ekle(kitap);
                _kitapRepository.Kaydet(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.
                TempData["basarili"] = "Yeni Kitap başarılıyla oluşturuldu.";
                return RedirectToAction("Index", "Kitap");
            }
            return View();
        }

        //public IActionResult Guncelle(int? id)
        //{

        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Kitap? kitapVt = _kitapRepository.Get(u=>u.Id==id);

        //    if (kitapVt == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(kitapVt);
        //}

        //[HttpPost]
        //public IActionResult Guncelle(Kitap kitap)
        //{

        //    //_uygulamaDBContext.Kitaplar.Add(kitap);
        //    //_uygulamaDBContext.SaveChanges(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.

        //    //return RedirectToAction("Index", "Kitap");

        //    if (ModelState.IsValid)
        //    {

        //        _kitapRepository.Guncelle(kitap);
        //        _kitapRepository.Kaydet(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.
        //        TempData["basarili"] = "Yeni Kitap başarılıyla güncellendi.";
        //        return RedirectToAction("Index", "Kitap");
        //    }
        //    return View();
        //}

        //GET ACTION
        public IActionResult Sil(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
             Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id); 

            if (kitapVt == null)
            {
                return NotFound();
            }
            return View(kitapVt);
        }

        [HttpPost,ActionName("Sil")]
        public IActionResult SilPost(int? id)
        {
            Kitap? kitap = _kitapRepository.Get(u => u.Id == id);
            if (kitap == null)
            {
                return NotFound(); 
            }
            _kitapRepository.Sil(kitap);
            _kitapRepository.Kaydet();
            TempData["basarili"] = "Kayıt silme işlemi başarılı.";
            return RedirectToAction("Index", "Kitap");


        }

    }
}

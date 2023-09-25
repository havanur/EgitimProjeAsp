using EgitimProjeAsp.Models;
using EgitimProjeAsp.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace EgitimProjeAsp.Controllers
{
    public class KiralamaController : Controller
    {

        //private readonly UygulamaDBContext _uygulamaDBContext;

        private readonly IKiralamaRepository _kiralamaRepository;
        private readonly IKitapRepository _kitapRepository;
        public readonly IWebHostEnvironment _webHostEnviroment;

        public KiralamaController(IKiralamaRepository kiralamaRepository, IKitapRepository kitapRepository, IWebHostEnvironment webHostEnviroment)
        {
            _kiralamaRepository = kiralamaRepository;
            _kitapRepository = kitapRepository;
            _webHostEnviroment = webHostEnviroment;
        }
        public IActionResult Index()
        {
            List<Kiralama> objKiralamaList = _kiralamaRepository.GetAll(includeProps:"Kitap").ToList();


            return View(objKiralamaList);
        }

        public IActionResult EkleGuncelle(int? id)
        {

            IEnumerable<SelectListItem> KitapList = _kitapRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.KitapAdi,
                    Value = k.Id.ToString()
                });

            ViewBag.KitapList = KitapList;


            if (id == null || id==0)
            {
                //ekle
                return View();
            }
            else
            {

                //Güncelle

                Kiralama? kiralamaVt = _kiralamaRepository.Get(u => u.Id == id);

                if (kiralamaVt == null)
                {
                    return NotFound();
                }
                return View(kiralamaVt);

            }

           

            
        }

        [HttpPost]
        public IActionResult EkleGuncelle(Kiralama kiralama)
        {



            if (ModelState.IsValid)
            {



                if (kiralama.Id==0)
                {
                    _kiralamaRepository.Ekle(kiralama);
                    TempData["basarili"] = "Yeni kiralama kaydı başarılıyla oluşturuldu.";
                }
                else
                {
                    _kiralamaRepository.Guncelle(kiralama);
                    TempData["basarili"] = "Kiralama kayıt güncelleme başarılı";
                }



                _kiralamaRepository.Kaydet(); //SaveChange yapılmazsa bilgiler veritabanına eklemez.
              
                return RedirectToAction("Index", "Kiralama");
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
            IEnumerable<SelectListItem> KitapList = _kitapRepository.GetAll()
              .Select(k => new SelectListItem
              {
                  Text = k.KitapAdi,
                  Value = k.Id.ToString()
              });

            ViewBag.KitapList = KitapList;

            if (id == null || id == 0)
            {
                return NotFound();
            }
             Kiralama? kiralamaVt = _kiralamaRepository.Get(u => u.Id == id); 

            if (kiralamaVt == null)
            {
                return NotFound();
            }
            return View(kiralamaVt);
        }

        [HttpPost,ActionName("Sil")]
        public IActionResult SilPost(int? id)
        {
            Kiralama? kiralama = _kiralamaRepository.Get(u => u.Id == id);
            if (kiralama == null)
            {
                return NotFound(); 
            }
            _kiralamaRepository.Sil(kiralama);
            _kiralamaRepository.Kaydet();
            TempData["basarili"] = "Kayıt silme işlemi başarılı.";
            return RedirectToAction("Index", "Kiralama");


        }

    }
}

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
    }
}

using OnlineTicariOtomasyon.WebUI.Models;
using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class GrafikController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public List<UrunListesi> UrunListesi()
        {
            List<UrunListesi> urunListesi = new List<UrunListesi>();
            using (Context context = new Context())
            {
                urunListesi = context.Uruns.Select(u => new UrunListesi
                {
                    urunAd = u.UrunAd,
                    stok = u.Stok
                }).ToList();
            }
            return urunListesi;
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
    }
}
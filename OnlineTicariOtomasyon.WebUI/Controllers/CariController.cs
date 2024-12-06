using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class CariController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            List<Cari> cariler = context.Caris.ToList();
            return View(cariler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            cari.Durum = true;
            context.Caris.Add(cari);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult CariSil(int id)
        {
            Cari cari = context.Caris.Find(id);
            cari.Durum = false;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult CariGetir(int id)
        {
            Cari cari = context.Caris.Find(id);
            return View(cari);
        }
        [HttpPost]
        public ActionResult CariDuzenle(Cari cari)
        {
            
            if (!ModelState.IsValid)
            {
                return View("CariGetir", cari);
            }
            else
            {
                Cari guncelCari = context.Caris.Find(cari.CariID);
                if(guncelCari != null)
                {
                    guncelCari.CariID = cari.CariID;
                    guncelCari.CariAd = cari.CariAd;
                    guncelCari.CariSoyad = cari.CariSoyad;
                    guncelCari.CariSehir = cari.CariSehir;
                    guncelCari.CariEmail = cari.CariEmail;
                    guncelCari.Durum = true;
                    context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public ActionResult CariDetay(int id)
        {
            List<SatisHareket> satislar = context.SatisHarekets.Where(s => s.Cari.CariID == id).ToList();
            string cari = context.Caris.Where(c => c.CariID == id).Select(ca => ca.CariAd + " " + ca.CariSoyad).FirstOrDefault();
            ViewBag.Cari = cari;
            return View(satislar);
        }
    }
}
using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class SatisHareketController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            List<SatisHareket> satislar = context.SatisHarekets.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            AcilirMenuListesi();
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satis)
        {
            satis.ToplamTutar = satis.Adet * satis.Fiyat;
            satis.Tarih = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy"));
            context.SatisHarekets.Add(satis);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult SatisGetir(int id)
        {
            AcilirMenuListesi();
            SatisHareket satis = context.SatisHarekets.Find(id);
            return View(satis);
        }
        [HttpPost]
        public ActionResult SatisDuzenle(SatisHareket satis)
        {
            SatisHareket guncelSatis = context.SatisHarekets.FirstOrDefault(s => s.SatisHareketID == satis.SatisHareketID);
            guncelSatis.UrunID = satis.UrunID;
            guncelSatis.CariID = satis.CariID;
            guncelSatis.PersonelID = satis.PersonelID;
            guncelSatis.Adet = satis.Adet;
            guncelSatis.Fiyat = satis.Fiyat;
            guncelSatis.ToplamTutar = satis.Adet * satis.Fiyat;
            guncelSatis.Tarih = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy"));
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult SatisDetay(int id)
        {
            List<SatisHareket> satislar = context.SatisHarekets.Where(s => s.Cari.CariID == id).ToList();
            string cari = context.Caris.Where(c => c.CariID == id).Select(c => c.CariAd + " " + c.CariSoyad).FirstOrDefault();
            ViewBag.Cari = cari;
            return View(satislar);
        }
        private void AcilirMenuListesi()
        {
            #region ÜrünAçılırMenü
            List<SelectListItem> urun = (from u in context.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = u.UrunAd,
                                             Value = u.UrunID.ToString()
                                         }).ToList();
            ViewBag.Urun = urun;
            #endregion
            #region CariAçılırMenü
            List<SelectListItem> cari = (from c in context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = c.CariAd + " " + c.CariSoyad,
                                             Value = c.CariID.ToString()
                                         }).ToList();
            ViewBag.Cari = cari;
            #endregion
            #region PersonelAçılırMenü
            List<SelectListItem> personel = (from p in context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = p.PersonelAd + " " + p.PersonelSoyad,
                                                 Value = p.PersonelID.ToString()
                                             }).ToList();
            ViewBag.Personel = personel;
            #endregion
        }
    }
}
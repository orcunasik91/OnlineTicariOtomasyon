using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();
        public ActionResult Index(string urun)
        {
            var urunler = from u in context.Uruns select u;
            if (!string.IsNullOrEmpty(urun))
            {
                urunler = urunler.Where(u => u.UrunAd.Contains(urun) || u.Marka.Contains(urun));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> urunKategori = (from k in context.Kategoris.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = k.KategoriAd,
                                                     Value = k.KategoriID.ToString()
                                                 }).ToList();
            ViewBag.UrunKategori = urunKategori;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            Kategori kategori = context.Kategoris.Where(k => k.KategoriID == urun.KategoriID).FirstOrDefault();
            urun.Kategori = kategori;
            urun.Durum = true;
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult UrunSil(int id)
        {
            Urun urun = context.Uruns.Find(id);
            urun.Durum = false;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> urunKategori = (from k in context.Kategoris.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = k.KategoriAd,
                                                     Value = k.KategoriID.ToString()
                                                 }).ToList();
            ViewBag.UrunKategori = urunKategori;
            Urun urun = context.Uruns.Find(id);
            return View(urun);
        }
        [HttpPost]
        public ActionResult UrunDuzenle(Urun urun)
        {
            Kategori kategori = context.Kategoris.Where(k => k.KategoriID == urun.KategoriID).FirstOrDefault();
            Urun urunDeger = context.Uruns.Find(urun.UrunID);
            urunDeger.Kategori = kategori;
            urunDeger.UrunID = urun.UrunID;
            urunDeger.UrunAd = urun.UrunAd;
            urunDeger.Marka = urun.Marka;
            urunDeger.Stok = urun.Stok;
            urunDeger.AlisFiyati = urun.AlisFiyati;
            urunDeger.SatisFiyati = urun.SatisFiyati;
            urunDeger.UrunGorsel = urun.UrunGorsel;
            urunDeger.Durum = true;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> personel = (from p in context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = p.PersonelAd + " " + p.PersonelSoyad,
                                                 Value = p.PersonelID.ToString()
                                             }).ToList();
            ViewBag.Personel = personel;

            Urun urun = context.Uruns.Find(id);
            ViewBag.UrunID = urun.UrunID;
            ViewBag.Fiyat = urun.SatisFiyati;
            List<Cari> cariler = context.Caris.ToList();
            ViewBag.CariListe = cariler;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket satis)
        {
            satis.Tarih = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy"));
            context.SatisHarekets.Add(satis);
            context.SaveChanges();
            return RedirectToAction("Index","SatisHareket");
        }
    }
}
using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            List<Urun> uruns = context.Uruns.Where(u => u.Durum == true).ToList();
            return View(uruns);
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

    }
}
using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();
        [HttpGet]
        public ActionResult Index()
        {
            #region ToplamCari
            int toplamCari = context.Caris.Count();
            ViewBag.ToplamCari = toplamCari;
            #endregion
            #region ToplamUrun
            int toplamUrun = context.Uruns.Count();
            ViewBag.ToplamUrun = toplamUrun;
            #endregion
            #region MevcutPersonel
            int mevcutPersonel = context.Personels.Count();
            ViewBag.MevcutPersonel = mevcutPersonel;
            #endregion
            #region ToplamKategori
            int toplamKategori = context.Kategoris.Count();
            ViewBag.ToplamKategori = toplamKategori;
            #endregion
            //-------------------------------------------
            #region ToplamStok
            int toplamStok = context.Uruns.Sum(u => u.Stok);
            ViewBag.ToplamStok = toplamStok;
            #endregion
            #region ToplamMarka
            int toplamMarka = (from u in context.Uruns select u.Marka).Distinct().Count();
            ViewBag.ToplamMarka = toplamMarka;
            #endregion
            #region KritikSeviyeUrun
            string kritikSeviyeUrun = context.Uruns.Where(u => u.Stok <= 50).Select(u => u.UrunAd).FirstOrDefault();
            ViewBag.KritikSeviyeUrun = kritikSeviyeUrun;
            #endregion
            #region EnYuksekFiyatliUrun
            string enYuksekFiyatliUrun = context.Uruns.OrderByDescending(u => u.SatisFiyati).Select(u => u.UrunAd).FirstOrDefault();
            ViewBag.EnYuksekFiyatliUrun = enYuksekFiyatliUrun;
            #endregion
            //-------------------------------------------
            #region EnDusukFiyatliUrun
            string enDusukFiyatliUrun = context.Uruns.OrderBy(u => u.SatisFiyati).Select(u => u.UrunAd).FirstOrDefault();
            ViewBag.EnDusukFiyatliUrun = enDusukFiyatliUrun;
            #endregion
            #region EnCokMarka
            string enCokMarka = context.Uruns.GroupBy(u => u.Marka).OrderByDescending(u => u.Count()).Select(u => u.Key).FirstOrDefault();
            ViewBag.EnCokMarka = enCokMarka;
            #endregion
            #region ToplamBuzdolabi
            int toplamBuzdolabi = context.Uruns.Count(u => u.UrunAd == "Buzdolabı");
            ViewBag.ToplamBuzdolabi = toplamBuzdolabi;
            #endregion
            #region ToplamLaptop
            int toplamLaptop = context.Uruns.Count(u => u.UrunAd == "Notebook");
            ViewBag.ToplamLaptop = toplamLaptop;
            #endregion
            //-------------------------------------------
            #region EnCokSatanUrun
            string enCokSatanUrun = context.SatisHarekets.GroupBy(sh => sh.Urun.UrunAd).OrderByDescending(sh => sh.Count()).Select(sh => sh.Key).FirstOrDefault();
            ViewBag.EnCokSatanUrun = enCokSatanUrun;
            #endregion
            #region KasaToplam
            decimal kasaToplam = context.SatisHarekets.Sum(sh => sh.ToplamTutar);
            ViewBag.KasaToplam = kasaToplam;
            #endregion
            #region GunlukSatis
            int gunlukSatis = context.SatisHarekets.Count(sh => sh.Tarih == DateTime.Now);
            ViewBag.GunlukSatis = gunlukSatis;
            #endregion
            #region GunlukKasa
            decimal gunlukKasa = context.SatisHarekets.Where(sh => sh.Tarih == DateTime.Now).Sum(sh => (decimal?)sh.ToplamTutar) ?? 0;
            ViewBag.GunlukKasa = gunlukKasa;
            #endregion
            return View();
        }
        [HttpGet]
        public ActionResult OzetTablolar()
        {
            return View();
        }
        public PartialViewResult KategoriUrun()
        {
            var urunAdet = from u in context.Uruns
                           group u by u.Kategori.KategoriAd into g
                           select new KategoriUrun
                           {
                               Kategori = g.Key,
                               Adet = g.Count()
                           };
            return PartialView(urunAdet.ToList());
        }
        public PartialViewResult SehirCari()
        {
            var cariAdet = from c in context.Caris
                            group c by c.CariSehir into g
                            select new MusteriWithSehir
                            {
                                Sehir = g.Key,
                                Adet = g.Count()
                            };
            return PartialView(cariAdet.ToList());
        }
        public PartialViewResult DepartmanPersonel()
        {
            var personelAdet = from p in context.Personels
                                    group p by p.Departmanlars.DepartmanAd into g
                                    select new DepartmanPersonel
                                    {
                                        Departman = g.Key,
                                        Adet = g.Count()
                                    };
            return PartialView(personelAdet.ToList());
        }
        public PartialViewResult MarkaUrunSatis()
        {
            var markaAdet = from sh in context.SatisHarekets
                               group sh by sh.Urun.Marka into g
                               select new MarkaUrunSatis
                               {
                                   Marka = g.Key,
                                   Adet = g.Count()
                               };
            return PartialView(markaAdet.ToList());
        }
        public PartialViewResult SatisHareketleri()
        {
            var satisHareketleri = context.SatisHarekets.ToList();
            return PartialView(satisHareketleri);
        }
    }
}
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
            int gunlukSatis = context.SatisHarekets.Count(sh => sh.Tarih == DateTime.Today);
            ViewBag.GunlukSatis = gunlukSatis;
            #endregion
            #region GunlukKasa
            decimal gunlukKasa = context.SatisHarekets.Where(sh => sh.Tarih == DateTime.Today).Sum(sh => sh.ToplamTutar);
            ViewBag.GunlukKasa = gunlukKasa;
            #endregion
            return View();
        }
    }
}
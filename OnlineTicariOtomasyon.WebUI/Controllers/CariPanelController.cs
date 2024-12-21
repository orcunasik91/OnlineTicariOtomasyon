using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    [Authorize]
    public class CariPanelController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            string cariEposta = (string)Session["CariEmail"];
            Cari cari = context.Caris.FirstOrDefault(c => c.CariEmail == cariEposta);
            return View(cari);
        }
        public ActionResult Siparislerim()
        {
            string cariEposta = (string)Session["CariEmail"];
            int cariId = context.Caris.Where(c => c.CariEmail == cariEposta.ToString()).Select(c => c.CariID).FirstOrDefault();
            var siparisler = context.SatisHarekets.Where(sh => sh.CariID == cariId).ToList();
            return View(siparisler);
        }
        [HttpGet]
        public ActionResult Mesajlar()
        {
            string cariEposta = (string)Session["CariEmail"];
            List<Mesajlar> mesajlar = context.Mesajlars.Where(m => m.Alici == cariEposta).ToList();
            GelenGidenMesajSayisi();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult GonderilenMesajlar()
        {
            string cariEposta = (string)Session["CariEmail"];
            List<Mesajlar> mesajlar = context.Mesajlars.Where(m => m.Gonderici == cariEposta).ToList();
            GelenGidenMesajSayisi();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            string cariEposta = (string)Session["CariEmail"];
            GelenGidenMesajSayisi();
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar mesaj)
        {
            string cariEposta = (string)Session["CariEmail"];
            mesaj.Tarih = DateTime.Parse(DateTime.Now.ToString("g"));
            mesaj.Gonderici = cariEposta;
            context.Mesajlars.Add(mesaj);
            context.SaveChanges();
            return RedirectToAction(nameof(Mesajlar));
        }
        [HttpGet]
        public ActionResult MesajDetay(int id)
        {
            GelenGidenMesajSayisi();
            Mesajlar mesaj = context.Mesajlars.Find(id);
            return View(mesaj);
        }
        [HttpGet]
        public ActionResult KargoTakip(string kargo)
        {
            string cariEposta = (string)Session["CariEmail"];
            var kargolar = from k in context.KargoDetays select k;
            if (!string.IsNullOrEmpty(kargo))
            {
                kargolar = kargolar.Where(k => k.TakipKodu.Contains(kargo));
            }
            return View(kargolar.ToList());
        }
        [HttpGet]
        public ActionResult KargoDetay(string id)
        {
            string cariEposta = (string)Session["CariEmail"];
            List<KargoTakip> kargoDetay = context.KargoTakips.Where(k => k.TakipKodu == id).ToList();
            return View(kargoDetay);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        private void GelenGidenMesajSayisi()
        {
            string cariEposta = (string)Session["CariEmail"];
            int gelenMesaySayisi = context.Mesajlars.Count(m => m.Alici == cariEposta);
            ViewBag.GelenMesajSayisi = gelenMesaySayisi;
            int gidenMesaySayisi = context.Mesajlars.Count(m => m.Gonderici == cariEposta);
            ViewBag.GidenMesajSayisi = gidenMesaySayisi;
        }
    }
}
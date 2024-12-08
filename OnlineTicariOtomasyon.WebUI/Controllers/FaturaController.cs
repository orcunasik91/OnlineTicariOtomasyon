using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class FaturaController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            List<Fatura> faturalar = context.Faturas.ToList();
            return View(faturalar);
        }
        [HttpGet]
        public ActionResult YeniFatura()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniFatura(Fatura fatura)
        {
            fatura.FaturaTarih = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy"));
            fatura.FaturaSaat = DateTime.Parse(DateTime.Now.ToString("t"));
            context.Faturas.Add(fatura);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult FaturaGetir(int id)
        {
            Fatura fatura = context.Faturas.Find(id);
            return View(fatura);
        }
        [HttpPost]
        public ActionResult FaturaDuzenle(Fatura fatura)
        {
            Fatura guncelFatura = context.Faturas.Find(fatura.FaturaID);
            guncelFatura.FaturaSeriNo = fatura.FaturaSeriNo;
            guncelFatura.FaturaSiraNo = fatura.FaturaSiraNo;
            guncelFatura.VergiDairesi = fatura.VergiDairesi;
            guncelFatura.TeslimEden = fatura.TeslimEden;
            guncelFatura.TeslimAlan = fatura.TeslimAlan;
            guncelFatura.FaturaTarih = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy"));
            guncelFatura.FaturaSaat = DateTime.Parse(DateTime.Now.ToString("t"));
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult FaturaDetay(int id)
        {
            List<FaturaKalem> faturaKalemleri = context.FaturaKalems.Where(fk => fk.FaturaID == id).ToList();
            string faturaBilgi = context.Faturas.Where(fk => fk.FaturaID == id).Select(fk => fk.FaturaSeriNo+"-"+fk.FaturaSiraNo + " ------ Müşteri: " + fk.TeslimAlan).FirstOrDefault();
            ViewBag.FaturaKalem = faturaBilgi;
            return View(faturaKalemleri);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem faturaKalem)
        {
            faturaKalem.Tutar = faturaKalem.Miktar * faturaKalem.BirimFiyat;
            context.FaturaKalems.Add(faturaKalem);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
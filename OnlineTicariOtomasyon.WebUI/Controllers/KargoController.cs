using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class KargoController : Controller
    {
        Context context = new Context();
        public ActionResult Index(string kargo)
        {
            var kargolar = from k in context.KargoDetays select k;
            if (!string.IsNullOrEmpty(kargo))
            {
                kargolar = kargolar.Where(k => k.TakipKodu.Contains(kargo));
            }
            return View(kargolar.ToList());
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] takipMetin = { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "O", "Q", "P", "R", "S", "T", "U", "V", "W", "Y", "Z" };
            int k1, k2, k3;
            k1 = rnd.Next(0, takipMetin.Length);
            k2 = rnd.Next(0, takipMetin.Length);
            k3 = rnd.Next(0, takipMetin.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string takipKodu = s1 + takipMetin[k1] + s2 + takipMetin[k2] + s3 + takipMetin[k3];
            ViewBag.TakipKodu = takipKodu;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay kargoDetay)
        {
            kargoDetay.Tarih = DateTime.Parse(DateTime.Now.ToString("G"));
            

            context.KargoDetays.Add(kargoDetay);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult KargoTakip(string id)
        {
            List<KargoTakip> kargoTakip = context.KargoTakips.Where(k => k.TakipKodu == id).ToList();
            return View(kargoTakip);
        }
    }
}
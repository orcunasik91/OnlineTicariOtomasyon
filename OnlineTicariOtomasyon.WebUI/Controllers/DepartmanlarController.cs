using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class DepartmanlarController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            List<Departmanlar> departmanlar = context.Departmanlars.ToList();
            return View(departmanlar);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departmanlar departman)
        {
            departman.Durum = true;
            context.Departmanlars.Add(departman);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult DepartmanSil(int id)
        {
            Departmanlar departman = context.Departmanlars.Find(id);
            departman.Durum = false;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult DepartmanGetir(int id)
        {
            Departmanlar departman = context.Departmanlars.Find(id);
            return View(departman);
        }
        [HttpPost]
        public ActionResult DepartmanDuzenle(Departmanlar departman)
        {
            Departmanlar departmanDeger = context.Departmanlars.Find(departman.DepartmanID);
            departmanDeger.DepartmanID = departman.DepartmanID;
            departmanDeger.DepartmanAd = departman.DepartmanAd;
            departmanDeger.Durum = true;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult DepartmanDetay(int id)
        {
            List<Personel> personelDetay = context.Personels.Include(p => p.Departmanlars).Where(p => p.Departmanlars.DepartmanID == id).ToList();
            string departman = context.Departmanlars.Where(d => d.DepartmanID == id).Select(dep => dep.DepartmanAd).FirstOrDefault();
            ViewBag.Departman = departman;
            return View(personelDetay);
        }
        [HttpGet]
        public ActionResult DepartmanPersonelSatis(int id)
        {
            List<SatisHareket> satislar = context.SatisHarekets.Where(s => s.Personel.PersonelID == id).ToList();
            string personel = context.Personels.Where(p => p.PersonelID == id).Select(sh => sh.PersonelAd +" "+ sh.PersonelSoyad).FirstOrDefault();
            ViewBag.Personel = personel;
            return View(satislar);
        }
    }
}
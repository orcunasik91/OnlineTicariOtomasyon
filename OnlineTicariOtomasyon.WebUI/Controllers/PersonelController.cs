using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            List<Personel> personeller = context.Personels.ToList();
            return View(personeller);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> personelDepartman = (from d in context.Departmanlars.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = d.DepartmanAd,
                                                     Value = d.DepartmanID.ToString()
                                                 }).ToList();
            ViewBag.PersonelDepartman = personelDepartman;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> personelDepartman = (from d in context.Departmanlars.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = d.DepartmanAd,
                                                          Value = d.DepartmanID.ToString()
                                                      }).ToList();
            ViewBag.PersonelDepartman = personelDepartman;
            Personel personel = context.Personels.Find(id);
            return View(personel);
        }
        [HttpPost]
        public ActionResult PersonelDuzenle(Personel personel)
        {
            Personel guncelPersonel = context.Personels.Find(personel.PersonelID);
            guncelPersonel.PersonelAd = personel.PersonelAd;
            guncelPersonel.PersonelSoyad = personel.PersonelSoyad;
            guncelPersonel.PersonelResim = personel.PersonelResim;
            guncelPersonel.DepartmanID = personel.DepartmanID;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
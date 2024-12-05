using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class KategoriController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            List<Kategori> kategoriler = context.Kategoris.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            context.Kategoris.Add(kategori);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult KategoriSil(int id)
        {
            Kategori kategori = context.Kategoris.Find(id);
            context.Kategoris.Remove(kategori);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult KategoriDuzenle(int id)
        {
            Kategori kategori = context.Kategoris.Find(id);
            return View(kategori);
        }
        [HttpPost]
        public ActionResult KategoriDuzenle(Kategori kategori)
        {
            Kategori kategoriDeger = context.Kategoris.Find(kategori.KategoriID);
            kategoriDeger.KategoriID = kategori.KategoriID;
            kategoriDeger.KategoriAd = kategori.KategoriAd;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
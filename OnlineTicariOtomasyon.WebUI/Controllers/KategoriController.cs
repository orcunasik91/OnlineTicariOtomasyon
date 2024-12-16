using OnlineTicariOtomasyon.WebUI.Models.Entities;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        Context context = new Context();
        public ActionResult Index(int? sayfa)
        {
            int sayfaNu = sayfa ?? 1;
            IPagedList<Kategori> kategoriler = context.Kategoris.OrderByDescending(k => k.KategoriID).ToPagedList(sayfaNu,4);
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Kategori/_KategoriListesi.cshtml", kategoriler);
            }
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
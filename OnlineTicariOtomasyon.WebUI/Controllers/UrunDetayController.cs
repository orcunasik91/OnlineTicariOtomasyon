using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class UrunDetayController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            UrunWithUrunDetay urunWithUrunDetay = new UrunWithUrunDetay();
            urunWithUrunDetay.Uruns = context.Uruns.Where(u => u.UrunID == 1).ToList();
            urunWithUrunDetay.UrunDetays = context.UrunDetays.Where(ud => ud.UrunDetayID == 1).ToList();
            return View(urunWithUrunDetay);
        }
    }
}
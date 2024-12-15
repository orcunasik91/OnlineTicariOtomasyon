using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult KayitFormu()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult KayitFormu(Cari cari)
        {
            cari.Durum = true;
            context.Caris.Add(cari);
            context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult CariGiris()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CariGiris(Cari cari)
        {
            Cari cariBilgi = context.Caris.FirstOrDefault(c => c.CariEmail == cari.CariEmail && c.CariSifre == cari.CariSifre);
            if(cariBilgi != null)
            {
                FormsAuthentication.SetAuthCookie(cariBilgi.CariEmail, false);
                Session["CariEmail"] = cariBilgi.CariEmail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
                return RedirectToAction(nameof(Index));
        }
    }
}
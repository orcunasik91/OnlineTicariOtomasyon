using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System.Linq;
using System.Web.Mvc;

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
    }
}
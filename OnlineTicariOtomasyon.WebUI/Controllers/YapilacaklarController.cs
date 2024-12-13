using OnlineTicariOtomasyon.WebUI.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class YapilacaklarController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            List<Yapilacaklar> yapilacaklar = context.Yapilacaklars.ToList();
            return View(yapilacaklar);
        }
    }
}
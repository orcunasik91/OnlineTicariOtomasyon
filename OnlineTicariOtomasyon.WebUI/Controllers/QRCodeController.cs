using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string kod)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator kodUret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = kodUret.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                using(Bitmap resim = karekod.GetGraphic(10))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.KarekodImage = "data:Content/images/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}
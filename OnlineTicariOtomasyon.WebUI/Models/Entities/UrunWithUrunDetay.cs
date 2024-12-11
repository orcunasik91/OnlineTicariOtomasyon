using System.Collections.Generic;

namespace OnlineTicariOtomasyon.WebUI.Models.Entities
{
    public class UrunWithUrunDetay
    {
        public IEnumerable<Urun> Uruns { get; set; }
        public IEnumerable<UrunDetay> UrunDetays { get; set; }
    }
}
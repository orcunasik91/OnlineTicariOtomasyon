using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.WebUI.Models.Entities
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(14)]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string CariEmail { get; set; }
        public int SatisHareketID { get; set; }
        public SatisHareket SatisHareket { get; set; }
    }
}
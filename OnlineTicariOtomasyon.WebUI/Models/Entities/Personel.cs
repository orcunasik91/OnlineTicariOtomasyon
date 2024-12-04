using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.WebUI.Models.Entities
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelResim { get; set; }
        public int DepartmanID { get; set; }
        public Departmanlar Departmanlars { get; set; }
        public int SatisHareketID { get; set; }
        public SatisHareket SatisHareket { get; set; }
    }
}
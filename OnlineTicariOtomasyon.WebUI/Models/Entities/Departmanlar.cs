using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.WebUI.Models.Entities
{
    public class Departmanlar
    {
        [Key]
        public int DepartmanID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}
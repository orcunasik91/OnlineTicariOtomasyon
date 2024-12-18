using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.WebUI.Models.Entities
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Aciklama { get; set; }
        public DateTime TarihZaman { get; set; }
    }
}
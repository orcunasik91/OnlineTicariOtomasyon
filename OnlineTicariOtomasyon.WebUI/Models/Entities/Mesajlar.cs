using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.WebUI.Models.Entities
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Gonderici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Alici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Konu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        [AllowHtml]
        public string Icerik { get; set; }

        public DateTime Tarih { get; set; }
    }
}
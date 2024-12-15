using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.WebUI.Models.Entities
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "En Fazla 30 Karakter Yazabilirsiniz")]
        public string CariAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu Alan Boş Geçilmemelidir")]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(14)]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string CariEmail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSifre { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}
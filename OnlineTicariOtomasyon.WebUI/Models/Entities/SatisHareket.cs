using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTicariOtomasyon.WebUI.Models.Entities
{
    public class SatisHareket
    {
        [Key]
        public int SatişHareketID { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public ICollection<Urun> Uruns { get; set; }
        public ICollection<Cari> Caris { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineTicariOtomasyon.WebUI.Models.Entities
{
    public class SatisHareket
    {
        [Key]
        public int SatisHareketID { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int UrunID { get; set; }
        public virtual Urun Urun { get; set; }
        public int CariID { get; set; }
        public virtual Cari Cari { get; set; }
        public int PersonelID { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
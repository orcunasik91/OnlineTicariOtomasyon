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
        public Urun Urun { get; set; }
        public int CariID { get; set; }
        public Cari Cari { get; set; }
        public int PersonelID { get; set; }
        public Personel Personel { get; set; }
    }
}
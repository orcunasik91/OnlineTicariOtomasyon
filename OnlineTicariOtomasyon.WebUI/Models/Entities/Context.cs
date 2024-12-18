using System.Data.Entity;

namespace OnlineTicariOtomasyon.WebUI.Models.Entities
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<UrunDetay> UrunDetays { get; set; }
        public DbSet<Departmanlar> Departmanlars { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<SatisHareket> SatisHarekets { get; set; }
        public DbSet<Yapilacaklar> Yapilacaklars { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }
        public DbSet<KargoDetay> KargoDetays { get; set; }
    }
}
using HastaneApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace HastaneApi.Context
{
    public class HastaneDbContext : DbContext
    {

        public HastaneDbContext(DbContextOptions<HastaneDbContext> options) : base(options)
        {
        }
        public DbSet<Hastane> Hastaneler { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hastane>().HasData(
                new Hastane {Id = 1, HastaneAd = "Academic" , HastaneAdres = "Uskudar" },
                new Hastane {Id = 2, HastaneAd = "Acıbadem" , HastaneAdres = "kadıkoy" }
                );
            
            modelBuilder.Entity<Hasta>().HasData(
                new Hasta {Id = 1, Ad = "aaa", Soyad = "bbb" , Klinik = "kbb", MuayeneTarihi = DateTime.Now, HastaneId = 1 },
                new Hasta {Id = 2, Ad = "ccc", Soyad = "ddd" , Klinik = "ortopedi", MuayeneTarihi = DateTime.Now, HastaneId = 2 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}

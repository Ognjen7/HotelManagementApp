using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelsManagementApp.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Hotel> Hoteli { get; set; }
        public DbSet<LanacHotela> LanciHotela { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanacHotela>().HasData(
                new LanacHotela() { Id = 1, Naziv = "Hilton Worldwide", GodinaOsnivanja = 1919 },
                new LanacHotela() { Id = 2, Naziv = "Marriott International", GodinaOsnivanja = 1927 },
                new LanacHotela() { Id = 3, Naziv = "Kempinski", GodinaOsnivanja = 1897 }

            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel() { Id = 1, Naziv = "Sheraton Novi Sad", GodinaOtvaranja = 2018, BrojZaposlenih = 70, BrojSoba = 150, LanacHotelaId = 2 },
                new Hotel() { Id = 2, Naziv = "Hilton Belgrade", GodinaOtvaranja = 2017, BrojZaposlenih = 100, BrojSoba = 242, LanacHotelaId = 1 },
                new Hotel() { Id = 3, Naziv = "Palais Hansen", GodinaOtvaranja = 2013, BrojZaposlenih = 80, BrojSoba = 152, LanacHotelaId = 3 },
                new Hotel() { Id = 4, Naziv = "Budapest Marriott", GodinaOtvaranja = 1994, BrojZaposlenih = 130, BrojSoba = 364, LanacHotelaId = 2 },
                new Hotel() { Id = 5, Naziv = "Hilton Berlin", GodinaOtvaranja = 1991, BrojZaposlenih = 200, BrojSoba = 601, LanacHotelaId = 2 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

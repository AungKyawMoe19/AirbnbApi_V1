using Microsoft.EntityFrameworkCore;
using AirbnbApi.Models;
using System.Reflection;
namespace AirbnbApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Listing>()
                .Property(l => l.PricePerNight)
                .HasColumnType("decimal(18,2)"); // specify precision and scale

            modelBuilder.Entity<Reservation>()
                .Property(r => r.TotalPrice)
                .HasColumnType("decimal(18,2)"); // specify precision and scale
        }
    }
}

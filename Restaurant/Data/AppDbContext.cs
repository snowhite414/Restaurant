using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MenuItem> MenuItems { set; get; }

        public DbSet<Reservation> Reservations { set; get; }

        public DbSet<ReservationMenuItems> ReservationMenuItems { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "Spaghetti", Price = 14.99}
                );
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { Id = 1, Name = "Bob Loblaw", Date = DateTime.Now}
                );
            modelBuilder.Entity<ReservationMenuItems>().HasData(
                new ReservationMenuItems { Id = 1, MenuItemId = 1, ReservationId = 1 }
                );
        }

    }
}

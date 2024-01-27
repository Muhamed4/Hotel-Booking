using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserBookRoom> UserBookRooms { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<FoodDrink> FoodDrinks { get; set; }
        public DbSet<FunProgram> FunPrograms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<UserReactHotel> UserReactHotels { get; set; }
        public DbSet<UserWatchHotel> UserWatchHotels { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<IdentityRole>().ToTable(name: "IdentityRole", schema:"Security");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable(name: "IdentityUserRole", schema:"Security");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable(name: "IdentityUserClaim", schema:"Security");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable(name: "IdentityUserLogin", schema:"Security");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable(name: "IdentityRoleClaim", schema:"Security");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable(name: "IdentityUserToken", schema:"Security");
        }
    }
}
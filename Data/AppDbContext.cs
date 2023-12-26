using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Hotel>? Hotels { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<RoomImage>? RoomImages { get; set; }
        public DbSet<Feature>? Features { get; set; }
        public DbSet<FeatureFacility>? FeatureFacilities { get; set; }
        public DbSet<FeatureFoodDrink>? FeatureFoodDrinks { get; set; }
        public DbSet<FeatureFunProgram>? FeatureFunPrograms { get; set; }
        public DbSet<FeatureService>? FeatureServices { get; set; }
        public DbSet<UserReactHotel>? UserReactHotels { get; set; }
        public DbSet<UserWatchHotel>? UserWatchHotels { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
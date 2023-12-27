using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        // Foreign Key for User table
        public int UserID { get; set; }
        public ICollection<UserReactHotel>? UserReactHotels { get; set; }
        public ICollection<User>? HotelReactions { get; set; }
        public ICollection<UserWatchHotel>? UserWatchHotels { get; set; }
        public ICollection<User>? HotelWatches { get; set; }
        public ICollection<Review>? HasReviews { get; set; }
        public ICollection<Room>? ConsistOfRooms { get; set; }
        public ICollection<Feature>? ContainFeatures { get; set; }
        public User? User { get; set; }
    }
}
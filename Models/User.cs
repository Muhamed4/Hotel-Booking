using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class User
    {
        public int ID { get; set; }
        public string? Email { get; set; }
        public string? Passwords { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Image { get; set; }
        public ICollection<Hotel>? Hotels { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Room>? Rooms { get; set; }
        public ICollection<UserReactHotel>? UserReactHotels { get; set; }
        public ICollection<UserWatchHotel>? UserWatchHotels { get; set; }
    }
}
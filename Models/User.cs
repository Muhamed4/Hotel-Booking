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
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Image { get; set; }
        public ICollection<Hotel>? OwnHotels { get; set; }
        public ICollection<Review>? MakeReviews { get; set; }
        public ICollection<Room>? BookRooms { get; set; }
        public ICollection<UserReactHotel>? UserReactHotels { get; set; }
        public ICollection<Hotel>? UserReactions { get; set; }
        public ICollection<UserWatchHotel>? UserWatchHotels { get; set; }
        public ICollection<Hotel>? UserWatchs { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Hotel_Booking.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Image { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<UserReactHotel> UserReactHotels { get; set; }
        public virtual ICollection<UserWatchHotel> UserWatchHotels { get; set; }
    }
}
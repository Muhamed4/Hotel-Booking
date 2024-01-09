using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
        public virtual ICollection<Feature> Features { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<UserReactHotel> UserReactHotels { get; set; }
        public virtual ICollection<UserWatchHotel> UserWatchHotels { get; set; }
    }
}
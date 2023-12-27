using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class UserWatchHotel
    {
        public int UserID { get; set; }
        public int HotelID { get; set; }
        public uint WatchCount { get; set; }
        public User? User { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewModels
{
    public class RoomDetails
    {
        public int RoomID { get; set; }
        public decimal Price { get; set; }
        public int BedCount { get; set; }
        public int RoomNumber { get; set; }
        public int HotelID { get; set; }
        public List<string> Images { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewModels
{
    public class RoomDetailswithID
    {
        public int HotelID { get; set; }
        public List<RoomDetails> RoomDetails { get; set; }
    }
}
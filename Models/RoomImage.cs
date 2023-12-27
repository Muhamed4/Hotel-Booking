using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class RoomImage
    {
        public int ID { get; set; }
        public string? Image { get; set; }
        // Foreign for Room Table
        public int RoomID { get; set; }
        public Room? Room { get; set; }
    }
}
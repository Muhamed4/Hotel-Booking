using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class Room
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public int RoomNumber { get; set; }
        public int BedCount { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int UserID { get; set; }
        public int HotelID { get; set; }
        public ICollection<RoomImage>? RoomImages { get; set; }
        public User? User { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
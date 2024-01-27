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
        // Foreign Key for User Table
        // public string UserID { get; set; }
        // Foreign Key for Hotel Table
        public int HotelID { get; set; }
        public virtual Hotel Hotel { get; set; } = null!;
        public virtual ICollection<UserBookRoom> UserBookRooms { get; set; }
        public virtual ICollection<RoomImage>? RoomImages { get; set; }
    }
}
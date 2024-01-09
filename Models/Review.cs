using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class Review
    {
        public int ID { get; set; }
        public decimal Rating { get; set; }
        public string Comment { get; set; } = null!;
        public DateTime Date { get; set; }
        // Foreign Key for User Table
        public string UserID { get; set; }
        // Foreign Key for Hotel Table
        public int HotelID { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual Hotel Hotel { get; set; } = null!;
    }
}
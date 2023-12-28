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
        public string? Comment { get; set; }
        public DateTime? Date { get; set; }
        // Foreign Key for User Table
        public int? UserID { get; set; }
        // Foreign Key for Hotel Table
        public int HotelID { get; set; }
        public User? User { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
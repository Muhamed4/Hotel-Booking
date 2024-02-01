using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewModels
{
    public class HotelInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Rating { get; set; }
        public int RatingCount { get; set; }
        public int Views { get; set; }
        public int Loves { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewModels
{
    public class RoomWithPics
    {
        public int RoomID { get; set; }
        public decimal Price { get; set; }
        public int BedCount { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string UserID { get; set; }
        public List<string> Images { get; set; }
    }
}
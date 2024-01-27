using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class UserBookRoom
    {
        public int ID { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string UserID { get; set; }
        public int RoomID { get; set; }
        public virtual User User { get; set; }
        public virtual Room Room { get; set; }
    }
}
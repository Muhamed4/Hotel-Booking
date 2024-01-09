using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class UserWatchHotel
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int HotelID { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual Hotel Hotel { get; set; } = null!;
    }
}
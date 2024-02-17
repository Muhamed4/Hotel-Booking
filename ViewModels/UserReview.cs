using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewModels
{
    public class UserReview
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public decimal Rating { get; set; }
        public string Comment { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
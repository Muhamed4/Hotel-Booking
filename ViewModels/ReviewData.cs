using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewModels
{
    public class ReviewData
    {
        [Required]
        [Range(0.00, 10, ErrorMessage = "Rating Number is not valid (0.00, 10)")]
        public decimal Rating { get; set; }
        [Required(ErrorMessage ="Your Opinion is so important to us")]
        public string Comment { get; set; }
        public int HotelID { get; set; }
        public string UserID { get; set; }
    }
}
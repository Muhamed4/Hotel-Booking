using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewModels
{
    public class EditHotel
    {
        public int HotelID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MinLength(200, ErrorMessage ="Please enter a description for the hotel and at least 200 characters!")]
        public string Description { get; set; }
        [DisplayName("Image")]
        public IFormFile? File { get; set; }
        public string ImageUrl { get; set; }
    }
}
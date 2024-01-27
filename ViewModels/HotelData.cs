using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewModels
{
    public class HotelData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Required]
        [DisplayName("Image")]
        public IFormFile File { get; set; }
        // [Required]
        // [Range(1, int.MaxValue, ErrorMessage = "Number of rooms must be greater than 0")]
        // [DisplayName("Rooms")]
        // public int NumRoom { get; set; }
        // [Required]
        // [Range(0, int.MaxValue, ErrorMessage = "Number of rooms must be >= 0")]
        // [DisplayName("Facilities")]
        // public int NumFacility { get; set; }
        // [Required]
        // [Range(0, int.MaxValue, ErrorMessage = "Number of rooms must be >= 0")]
        // [DisplayName("Food&Drink Features")]
        // public int NumFoodDrink { get; set; }
        // [Required]
        // [Range(0, int.MaxValue, ErrorMessage = "Number of rooms must be >= 0")]
        // [DisplayName("Fun programs")]
        // public int NumFunProgram { get; set; }
        // [Required]
        // [Range(0, int.MaxValue, ErrorMessage = "Number of rooms must be >= 0")]
        // [DisplayName("Services")]
        // public int NumService { get; set; }
    }
}
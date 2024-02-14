using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewModels
{
    public class AddFeature
    {
        public int ID { get; set; }
        public int FeatureID { get; set; }
        public int HotelID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
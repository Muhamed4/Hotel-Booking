using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class FeatureService
    {
        public int FeatureID { get; set; }
        public string? Description { get; set; }
        public Feature? Feature { get; set; }
    }
}
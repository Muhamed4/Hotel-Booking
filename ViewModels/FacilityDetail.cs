using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewModels
{
    public class FeatureDetail
    {
        public List<AddFeature> features { get; set; }
        public int featureId { get; set; }
        public int HotelID { get; set; }
    }
}
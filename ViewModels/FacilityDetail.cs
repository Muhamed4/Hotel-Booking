using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewModels
{
    public class FacilityDetail
    {
        public List<AddFacility> facilities { get; set; }
        public int featureId { get; set; }
        public int HotelID { get; set; }
    }
}
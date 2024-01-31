using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.FacilitiesRepo
{
    public interface IFacilityRepo
    {
        void Insert(Facility facility);
        void Insert(string facility, int featureId);
    }
}
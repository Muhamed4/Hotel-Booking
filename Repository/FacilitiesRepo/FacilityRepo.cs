using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.FacilitiesRepo
{
    public class FacilityRepo : IFacilityRepo
    {
        private readonly AppDbContext _context;
        public FacilityRepo(AppDbContext context)
        {
            this._context = context;
        }
        public void Insert(Facility facility)
        {
            _context.Facilities.Add(facility);
            _context.SaveChanges();
        }

        public void Insert(string facility, int featureId)
        {
            if (facility is not null)
            {
                var _facility = new Facility()
                {
                    Description = facility,
                    FeatureID = featureId
                };
                _context.Facilities.Add(_facility);
                _context.SaveChanges();
            }
        }
    }
}
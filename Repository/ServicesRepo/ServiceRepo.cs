using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.ServicesRepo
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly AppDbContext _context;
        public ServiceRepo(AppDbContext context)
        {
            this._context = context;
        }

        public void Insert(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void Insert(string service, int featureId)
        {
            if (service is not null)
            {
                var _service = new Service()
                {
                    Description = service,
                    FeatureID = featureId
                };
                _context.Services.Add(_service);
                _context.SaveChanges();
            }
        }
    }
}
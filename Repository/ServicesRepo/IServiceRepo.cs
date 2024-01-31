using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.ServicesRepo
{
    public interface IServiceRepo
    {
        void Insert(Service service);
        void Insert(string service, int featureId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.AdminRepo
{
    public interface IAdminRepo
    {
        List<Hotel> GetHotels();
    }
}
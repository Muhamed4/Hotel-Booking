using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.ViewModels;

namespace Hotel_Booking.Repository.HomesRepo
{
    public interface IHomeRepo
    {
        List<HotelInfo> GetAllHotelsInfo();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.ViewModels;

namespace Hotel_Booking.Repository.HomesRepo
{
    public interface IHomeRepo
    {
        List<HotelInfo> GetAllHotelsInfo(string country, string city, string userId);
        List<HotelInfo> Filter(List<HotelInfo> info, string country, string city);
    }
}
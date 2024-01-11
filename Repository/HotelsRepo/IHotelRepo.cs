using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.HotelRepo
{
    public interface IHotelRepo
    {
        List<Hotel> GetAllHotels();
        Hotel GetById(int id);
        void Insert(Hotel hotel);
        void Update(int id, Hotel newHotel);
        void Delete(int id);
    }
}
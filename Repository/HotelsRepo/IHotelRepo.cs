using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Hotel_Booking.ViewModels;

namespace Hotel_Booking.Repository.HotelRepo
{
    public interface IHotelRepo
    {
        List<Hotel> GetAllHotels();
        Hotel GetById(int id);
        void Insert(Hotel hotel);
        void Update(int id, Hotel newHotel);
        void Delete(int id);
        List<Review> GetReviews(int hotelId);
        List<Room> GetRooms(int hotelId);
        Feature GetFeature(int hotelId);
        List<Facility> GetFacilities(int hotelId);
        List<FunProgram> GetFunPrograms(int hotelId);
        List<FoodDrink> GetFoodDrinks(int hotelId);
        List<Service> GetServices(int hotelId);
        AllHotelDetails GetAllHotelDetails(int hotelId);
    }
}
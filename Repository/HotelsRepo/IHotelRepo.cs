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
        void UserWatchHotel(int hotelId, string UserId);
        bool CheckVisited(int hotelId, string userId);
        decimal GetRate(int hotelId);
        int GetReviewsCount(int hotelId);
        int UserReact(int hotelId, string UserId);
        List<Review> GetReviews(int hotelId);
        List<UserReview> GetUserReviews(int hotelId);
        List<Room> GetRooms(int hotelId);
        Feature GetFeature(int hotelId);
        List<Facility> GetFacilities(int hotelId);
        List<FunProgram> GetFunPrograms(int hotelId);
        List<FoodDrink> GetFoodDrinks(int hotelId);
        List<Service> GetServices(int hotelId);
        AllHotelDetails GetAllHotelDetails(int hotelId, string UserID);
        List<Servicewithicon> Getservicewithicons(int hotelId);
        List<RoomWithPics> GetRoomWithPics(int hotelID, string UserID);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;
using Hotel_Booking.ViewModels;

namespace Hotel_Booking.Repository.AdminRepo
{
    public interface IAdminRepo
    {
        List<Hotel> GetHotels();
        void DeleteHotel(int hotelId);
        void DeleteFacility(int facilityId);
        void DeleteFoodDrink(int foodDrinkId);
        void DeleteFunProgram(int funProgramId);
        void DeleteService(int serviceId);
        void Edit(int hotelId, Hotel hotel);
        void EditFacility(int facilityId, Facility facility);
        void EditFoodDrink(int foodDrinkId, FoodDrink foodDrink);
        void EditFunProgram(int funProgramId, FunProgram funProgram);
        void EditService(int serviceId, Service service);
        bool CheckExistence(int hotelId);
        bool CheckExistenceFeature(int featureId);
        bool CheckExistenceFunProgram(int funProgramId);
        bool CheckExistenceService(int serviceId);
        Hotel GetHotel(int hotelId);
        Facility GetFacility(int facilityId);
        FoodDrink GetFoodDrink(int foodDrinkId);
        FunProgram GetFunProgram(int funProgramId);
        Service GetService(int serviceId);
        void InsertFacility(Facility facility);
        void InsertFoodDrink(FoodDrink foodDrink);
        void InsertFunProgram(FunProgram funProgram);
        void InsertService(Service service);
        int GetHotelId(int featureId);
        int GetFeatureId(int hotelId);
        bool CheckExistenceFacility(int facilityId);
        bool CheckExistenceFoodDrink(int foodDrinkId);
        string UploadFile(IFormFile fromFile, string ImageUrl);
        List<AddFeature> Facilities(int hotelId);
        List<AddFeature> FoodDrinks(int hotelId);
        List<AddFeature> FunPrograms(int hotelId);
        List<AddFeature> Services(int hotelId);
        List<RoomDetails> GetRooms(int hotelId);
    }
}
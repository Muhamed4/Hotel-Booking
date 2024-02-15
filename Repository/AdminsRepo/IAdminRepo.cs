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
        void DeleteRoomImage(int RoomId);
        void DeleteService(int serviceId);
        void DeleteRoom(int roomId);
        void Edit(int hotelId, Hotel hotel);
        void EditFacility(int facilityId, Facility facility);
        void EditFoodDrink(int foodDrinkId, FoodDrink foodDrink);
        void EditFunProgram(int funProgramId, FunProgram funProgram);
        void EditService(int serviceId, Service service);
        void EditRoom(int roomId, Room room);
        void EditRoomImages(IFormFileCollection GalleryImages, int RoomId);
        bool CheckExistence(int hotelId);
        bool CheckExistenceFeature(int featureId);
        bool CheckExistenceFunProgram(int funProgramId);
        bool CheckExistenceService(int serviceId);
        bool CheckExistenceRoom(int RoomId);
        Hotel GetHotel(int hotelId);
        Room GetRoom(int RoomId);
        Facility GetFacility(int facilityId);
        FoodDrink GetFoodDrink(int foodDrinkId);
        FunProgram GetFunProgram(int funProgramId);
        Service GetService(int serviceId);
        void InsertFacility(Facility facility);
        void InsertFoodDrink(FoodDrink foodDrink);
        void InsertFunProgram(FunProgram funProgram);
        void InsertService(Service service);
        void InsertRoom(Room room);
        void InsertImages(IFormFileCollection GalleryImages, int RoomId);
        int GetHotelId(int featureId);
        int GetFeatureId(int hotelId);
        bool CheckExistenceFacility(int facilityId);
        bool CheckExistenceFoodDrink(int foodDrinkId);
        string UploadFile(IFormFile fromFile, string ImageUrl);
        string UploadImage(IFormFile File);
        List<AddFeature> Facilities(int hotelId);
        List<AddFeature> FoodDrinks(int hotelId);
        List<AddFeature> FunPrograms(int hotelId);
        List<AddFeature> Services(int hotelId);
        List<RoomDetails> GetRooms(int hotelId);
        List<string> GetImagesRoom(int RoomId);
        bool CheckRoomByHotelId(int roomNumber, int RoomId, int hotelId);
    }
}
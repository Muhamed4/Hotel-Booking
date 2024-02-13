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
        void Edit(int hotelId, Hotel hotel);
        void EditFacility(int facilityId, Facility facility);
        bool CheckExistence(int hotelId);
        bool CheckExistenceFeature(int featureId);
        Hotel GetHotel(int hotelId);
        Facility GetFacility(int facilityId);
        void InsertFacility(Facility facility);
        int GetHotelId(int featureId);
        int GetFeatureId(int hotelId);
        bool CheckExistenceFacility(int facilityId);
        string UploadFile(IFormFile fromFile, string ImageUrl);
        List<AddFacility> Facilities(int hotelId);
    }
}
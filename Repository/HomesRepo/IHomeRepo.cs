using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Hotel_Booking.ViewModels;

namespace Hotel_Booking.Repository.HomesRepo
{
    public interface IHomeRepo
    {
        bool CheckExistenceUser(string UserId);
        List<HotelInfo> GetAllHotelsInfo(string country, string city, string userId);
        List<HotelInfo> Filter(List<HotelInfo> info, string country, string city);
        Profile GetUserInfo(string UserId);
        UserEdit GetUserData(string UserId);
        void UpdatePhoto(IFormFile File, string Image);
        string UploadFile(IFormFile formFile, string ImageUrl);
        void UpdateUser(string UserId, User user);
    }
}
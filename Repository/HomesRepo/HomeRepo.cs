using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;
using Hotel_Booking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking.Repository.HomesRepo
{
    public class HomeRepo : IHomeRepo
    {
        private readonly AppDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        public HomeRepo(AppDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            this._context = context;
            this._hosting = hosting;
        }

        public bool CheckExistenceUser(string UserId)
        {
            var user = _context.Users.FirstOrDefault(U => U.Id == UserId);
            if (user is null)
                return false;

            return true;
        }

        public List<HotelInfo> Filter(List<HotelInfo> info, string country, string city)
        {
            List<HotelInfo> result = new List<HotelInfo>();
            if (info is not null)
            {
                if ((country is null || country == "") && (city is null || city == ""))
                {
                    return info;
                }
                foreach (var item in info)
                {
                    string _country = item.Country.ToLower();
                    string _city = item.City.ToLower();
                    bool add = false;
                    if (country is not null && country != "")
                    {
                        if (_country.Contains(country)) add = true;
                    }
                    if (city is not null && city != "")
                    {
                        if (_city.Contains(city)) add = true;
                    }
                    if (add == true) result.Add(item);
                }
            }

            return result;
        }
        public List<HotelInfo> GetAllHotelsInfo(string country, string city, string userId)
        {
            List<HotelInfo> list = new List<HotelInfo>();
            var allHotelInfos = _context.Hotels.ToList();
            foreach (var hotelinfo in allHotelInfos)
            {
                var reviewsQuery = _context.Reviews.Where(R => R.HotelID == hotelinfo.ID).ToList();
                var watchCount = _context.UserWatchHotels.Where(W => W.HotelID == hotelinfo.ID).Count();
                var reactCount = _context.UserReactHotels.Where(R => R.HotelID == hotelinfo.ID).Count();
                bool checkReaction = false;
                if (userId is not null && userId != "")
                {
                    var res = _context.UserReactHotels.FirstOrDefault(R => R.HotelID == hotelinfo.ID && R.UserID == userId);
                    if (res is not null)
                        checkReaction = true;
                }

                HotelInfo info = new HotelInfo()
                {
                    ID = hotelinfo.ID,
                    Name = hotelinfo.Name,
                    Country = hotelinfo.Country,
                    City = hotelinfo.City,
                    Description = hotelinfo.Description,
                    Image = hotelinfo.Image,
                    Rating = reviewsQuery.Select(R => R.Rating).DefaultIfEmpty(0).Average(),
                    // Rating = reviewsQuery.DefaultIfEmpty<decimal>(0.00).Average(),
                    RatingCount = reviewsQuery.Count(),
                    Views = watchCount,
                    Loves = reactCount,
                    Reacted = checkReaction
                };

                list.Add(info);
            }

            var FilterResult = Filter(list, country, city);
            return FilterResult;
        }

        public UserEdit GetUserData(string UserId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == UserId);
            var userData = new UserEdit()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Image = user.Image
            };
            return userData;
        }

        public Profile GetUserInfo(string UserId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == UserId);
            var profile = new Profile()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Image = user.Image
            };
            return profile;
        }

        public string UploadFile(IFormFile formFile, string ImageUrl)
        {
            if (formFile != null)
            {
                string Uploads = Path.Combine(_hosting.WebRootPath, "Images");
                string newPath = Path.Combine(Uploads, formFile.FileName);
                if (ImageUrl is not null)
                {
                    string oldPath = Path.Combine(Uploads, ImageUrl);
                    System.IO.File.Delete(oldPath);
                }

                string imagesPath = Path.Combine(_hosting.WebRootPath, "Images");
                string fileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                string fullPath = Path.Combine(imagesPath, fileName);
                formFile.CopyTo(new FileStream(fullPath, FileMode.Create));

                return fileName;
            }
            return ImageUrl;
        }

        public void UpdatePhoto(IFormFile File, string Image)
        {
            UploadFile(File, Image);
        }

        public void UpdateUser(string UserId, User user)
        {
            var oldUser = _context.Users.FirstOrDefault(U => U.Id == UserId);
            if(oldUser is not null)
            {
                oldUser.FirstName = user.FirstName;
                oldUser.LastName = user.LastName;
                oldUser.UserName = user.FirstName + user.LastName;
                oldUser.Email = user.Email;
                oldUser.Image = user.Image;
            }
            _context.SaveChanges();
        }
    }
}
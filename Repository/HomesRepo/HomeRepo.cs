using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking.Repository.HomesRepo
{
    public class HomeRepo : IHomeRepo
    {
        private readonly AppDbContext _context;
        public HomeRepo(AppDbContext context)
        {
            this._context = context;
        }
        public List<HotelInfo> GetAllHotelsInfo()
        {
            List<HotelInfo> list = new List<HotelInfo>();
            var allHotelInfos = _context.Hotels.ToList();
            foreach (var hotelinfo in allHotelInfos)
            {
                var reviewsQuery = _context.Reviews.Where(R => R.HotelID == hotelinfo.ID).ToList();
                var watchCount = _context.UserWatchHotels.Where(W => W.HotelID == hotelinfo.ID).Count();
                var reactCount = _context.UserReactHotels.Where(R => R.HotelID == hotelinfo.ID).Count();

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
                    Loves = reactCount
                };

                list.Add(info);
            }

            return list;
        }
    }
}
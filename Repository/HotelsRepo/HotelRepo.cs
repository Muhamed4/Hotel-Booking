using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;
using Hotel_Booking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking.Repository.HotelRepo
{
    public class HotelRepo : IHotelRepo
    {
        private readonly AppDbContext _context;
        public HotelRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var _hotel = GetById(id);

            if (_hotel is not null)
            {
                _context.Hotels.Remove(_hotel);
                _context.SaveChanges();
            }
        }

        public List<Hotel> GetAllHotels()
        {
            return _context.Hotels.ToList();
        }

        public Hotel GetById(int id)
        {
            var _hotel = _context.Hotels.FirstOrDefault(X => X.ID == id);

            return _hotel;
        }

        public List<Review> GetReviews(int hotelId)
        {
            var res = _context.Hotels.Include(H => H.Reviews).FirstOrDefault(H => H.ID == hotelId);
            List<Review> reviews = new List<Review>();
            if (res is not null)
            {
                reviews = res.Reviews.ToList();
            }
            return reviews;
        }

        public List<Room> GetRooms(int hotelId)
        {
            var res = _context.Hotels.Include(H => H.Rooms).FirstOrDefault(H => H.ID == hotelId);
            List<Room> rooms = new List<Room>();
            if (res is not null)
            {
                rooms = res.Rooms.ToList();
            }
            return rooms;
        }

        public Feature GetFeature(int hotelId)
        {
            var res = _context.Hotels.Include(H => H.Features).FirstOrDefault(H => H.ID == hotelId);
            Feature feature = null;
            if (res is not null)
            {
                feature = res.Features.FirstOrDefault();
            }
            return feature;
        }

        public void Insert(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

        public void Update(int id, Hotel newHotel)
        {
            var _oldHotel = GetById(id);
            _oldHotel.Name = newHotel.Name;
            _oldHotel.Country = newHotel.Country;
            _oldHotel.City = newHotel.City;
            _oldHotel.Description = newHotel.Description;
            _oldHotel.Image = newHotel.Image;

            _context.SaveChanges();
        }

        public List<Facility> GetFacilities(int hotelId)
        {
            var feature = GetFeature(hotelId);
            if (feature is not null)
            {
                var res = _context.Features.Include(F => F.Facilities).FirstOrDefault(F => F.ID == feature.ID);
                if (res is not null)
                    return res.Facilities.ToList();
            }
            return new List<Facility>();
        }

        public List<FunProgram> GetFunPrograms(int hotelId)
        {
            var feature = GetFeature(hotelId);
            if (feature is not null)
            {
                var res = _context.Features.Include(F => F.FunPrograms).FirstOrDefault(F => F.ID == feature.ID);
                if (res is not null)
                    return res.FunPrograms.ToList();
            }
            return new List<FunProgram>();
        }

        public List<FoodDrink> GetFoodDrinks(int hotelId)
        {
            var feature = GetFeature(hotelId);
            if (feature is not null)
            {
                var res = _context.Features.Include(F => F.FoodDrinks).FirstOrDefault(F => F.ID == feature.ID);
                if (res is not null)
                    return res.FoodDrinks.ToList();
            }
            return new List<FoodDrink>();
        }

        public List<Service> GetServices(int hotelId)
        {
            var feature = GetFeature(hotelId);
            if (feature is not null)
            {
                var res = _context.Features.Include(F => F.Services).FirstOrDefault(F => F.ID == feature.ID);
                if (res is not null)
                    return res.Services.ToList();
            }
            return new List<Service>();
        }

        public AllHotelDetails GetAllHotelDetails(int hotelId, string UserID)
        {
            AllHotelDetails allHotelDetails = new AllHotelDetails()
            {
                UserID = UserID,
                Rate = GetRate(hotelId),
                ReviewsCount = GetReviewsCount(hotelId),
                Hotel = GetById(hotelId),
                Reviews = GetUserReviews(hotelId),
                Rooms = GetRoomWithPics(hotelId, UserID),
                Serviceswithicons = Getservicewithicons(hotelId),
                Facilities = GetFacilities(hotelId),
                FunPrograms = GetFunPrograms(hotelId),
                FoodDrinks = GetFoodDrinks(hotelId),
                Services = GetServices(hotelId),
                isVisited = CheckVisited(hotelId, UserID)
            };

            return allHotelDetails;
        }

        public List<Servicewithicon> Getservicewithicons(int hotelId)
        {
            var feature = GetFeature(hotelId);
            if (feature is not null)
            {
                List<Servicewithicon> lst = new List<Servicewithicon>();

                if (feature.FreeParking == true)
                    lst.Add(new Servicewithicon() { service = "Free Parking", icon = HotelIcons.FreeParking });

                if (feature.LaundryFacility == true)
                    lst.Add(new Servicewithicon() { service = "Laundry Facility", icon = HotelIcons.LaundryFacility });

                if (feature.NoSmoking == true)
                    lst.Add(new Servicewithicon() { service = "No Smoking", icon = HotelIcons.NoSmoking });

                if (feature.FreeWifi == true)
                    lst.Add(new Servicewithicon() { service = "Free Wifi", icon = HotelIcons.FreeWifi });

                if (feature.FreeBreakfast == true)
                    lst.Add(new Servicewithicon() { service = "Free Breakfast", icon = HotelIcons.FreeBreakfast });

                if (feature.AirportTransfer == true)
                    lst.Add(new Servicewithicon() { service = "Airport Transfer", icon = HotelIcons.AirportTransfer });

                if (feature.FontDesk247 == true)
                    lst.Add(new Servicewithicon() { service = "24/7 Front Desk", icon = HotelIcons.FontDesk247 });

                if (feature.Restaurant == true)
                    lst.Add(new Servicewithicon() { service = "Restaurant", icon = HotelIcons.Restaurant });

                if (feature.AirCondition == true)
                    lst.Add(new Servicewithicon() { service = "Air Condition", icon = HotelIcons.AirCondition });

                return lst;
            }
            return new List<Servicewithicon>();
        }

        public List<RoomWithPics> GetRoomWithPics(int hotelID, string UserID)
        {
            List<RoomWithPics> lst = new List<RoomWithPics>();
            var rooms = _context.Rooms.Where(R => R.HotelID == hotelID).ToList();

            if (rooms is not null)
            {
                foreach (var room in rooms)
                {
                    var dateTimeNow = DateTime.Now.Date;
                    var Pics = _context.RoomImages.Where(R => R.RoomID == room.ID).ToList();
                    var BookedRoom = _context.UserBookRooms.FirstOrDefault(R => R.RoomID == room.ID
                                                && (R.CheckIn.Date >= dateTimeNow || R.CheckOut.Date >= dateTimeNow));

                    List<string> images = new List<string>();
                    foreach (var pic in Pics)
                    {
                        images.Add(pic.Image);
                    }
                    DateTime _checkIn = DateTime.Now.AddDays(-10);
                    DateTime _checkOut = DateTime.Now.AddDays(-9);
                    bool isBooked = false;
                    if (BookedRoom is not null)
                    {
                        if (BookedRoom.UserID == UserID)
                        {
                            _checkIn = BookedRoom.CheckIn;
                            _checkOut = BookedRoom.CheckOut;
                        }
                        else isBooked = true;
                    }
                    RoomWithPics roomWithPics = new RoomWithPics()
                    {
                        RoomID = room.ID,
                        UserID = UserID,
                        Price = room.Price,
                        BedCount = room.BedCount,
                        RoomNumber = room.RoomNumber,
                        Booked = isBooked,
                        CheckIn = _checkIn,
                        CheckOut = _checkOut,
                        Images = images
                    };
                    lst.Add(roomWithPics);
                }
            }
            return lst;
        }

        public List<UserReview> GetUserReviews(int hotelId)
        {
            var reviews = _context.Hotels.Include(H => H.Reviews).FirstOrDefault(H => H.ID == hotelId);
            List<UserReview> userReviews = new List<UserReview>();
            if (reviews is not null)
            {
                var res = reviews.Reviews.ToList();
                foreach (var item in res)
                {
                    var user = _context.Users.FirstOrDefault(U => U.Id == item.UserID);
                    if (user is not null)
                    {
                        UserReview userReview = new UserReview()
                        {
                            UserName = user.UserName,
                            Rating = item.Rating,
                            Comment = item.Comment,
                            Date = item.Date
                        };
                        userReviews.Add(userReview);
                    }
                }
            }

            return userReviews;
        }

        public bool CheckVisited(int hotelId, string userId)
        {
            var res = _context.UserBookRooms.Where(B => B.UserID == userId && B.CheckOut.Date < DateTime.Now.Date).ToList();
            if (res is not null)
            {
                foreach (var item in res)
                {
                    var check = _context.Rooms.FirstOrDefault(R => R.ID == item.RoomID && R.HotelID == hotelId);
                    if (check is not null)
                        return true;
                }
            }

            return false;
        }

        public decimal GetRate(int hotelId)
        {
            decimal rate = 0.00m;
            var reviews = _context.Reviews.Where(R => R.HotelID == hotelId).ToList();
            if (reviews is not null)
            {
                rate = reviews.Select(R => R.Rating).DefaultIfEmpty(0).Average();
            }

            return rate;
        }

        public int GetReviewsCount(int hotelId)
        {
            int reviewsCount = 0;
            var reviews = _context.Reviews.Where(R => R.HotelID == hotelId).ToList();
            if (reviews is not null)
            {
                reviewsCount = reviews.Count();
            }

            return reviewsCount;
        }

        public void UserWatchHotel(int hotelId, string UserId)
        {
            var watch = _context.UserWatchHotels.FirstOrDefault(W => W.HotelID == hotelId && W.UserID == UserId);
            if (watch is null)
            {
                var userWatchhotel = new UserWatchHotel()
                {
                    UserID = UserId,
                    HotelID = hotelId
                };
                _context.UserWatchHotels.Add(userWatchhotel);
                _context.SaveChanges();
            }
        }

        public int UserReact(int hotelId, string UserId)
        {

            var react = _context.UserReactHotels.FirstOrDefault(R => R.HotelID == hotelId && R.UserID == UserId);
            if (react is not null)
            {
                _context.UserReactHotels.Remove(react);
            }
            else
            {
                var reaction = new UserReactHotel() { UserID = UserId, HotelID = hotelId };
                _context.UserReactHotels.Add(reaction);
            }

            _context.SaveChanges();

            int reactCount = _context.UserReactHotels.Where(R => R.HotelID == hotelId).Count();

            return reactCount;
        }

        public void AddReview(ReviewData _review)
        {
            if (_review is not null)
            {
                var review = new Review()
                {
                    Rating = _review.Rating,
                    Comment = _review.Comment,
                    Date = DateTime.Now,
                    HotelID = _review.HotelID,
                    UserID = _review.UserID
                };
                _context.Reviews.Add(review);
                _context.SaveChanges();
            }
        }

        public List<TripData> GetTrips(string UserId)
        {
            var trips = _context.UserBookRooms.Where(R => R.UserID == UserId && R.CheckIn.Date > DateTime.Now.Date).ToList();
            List<TripData> result = new List<TripData>();
            foreach (var item in trips)
            {
                var room = _context.Rooms.FirstOrDefault(H => H.ID == item.RoomID);
                if (room is not null)
                {
                    var hotel = _context.Hotels.FirstOrDefault(H => H.ID == room.HotelID);
                    if(hotel is not null)
                    {
                        var trip = new TripData() 
                        {
                            HotelID = hotel.ID,
                            UserID = UserId,
                            Name = hotel.Name,
                            Country = hotel.Country,
                            City = hotel.City,
                            CheckIn = item.CheckIn,
                            CheckOut = item.CheckOut,
                            ImageUrl = hotel.Image
                        };
                        result.Add(trip);
                    }
                }
            }
            return result;
        }
    }
}
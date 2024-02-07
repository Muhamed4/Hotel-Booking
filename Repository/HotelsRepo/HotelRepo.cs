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
            Feature feature = new Feature();
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
                Hotel = GetById(hotelId),
                Reviews = GetReviews(hotelId),
                Rooms = GetRoomWithPics(hotelId, UserID),
                Serviceswithicons = Getservicewithicons(hotelId),
                Facilities = GetFacilities(hotelId),
                FunPrograms = GetFunPrograms(hotelId),
                FoodDrinks = GetFoodDrinks(hotelId),
                Services = GetServices(hotelId)
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
                    var dateTimeNow = DateTime.Now;
                    var Pics = _context.RoomImages.Where(R => R.RoomID == room.ID).ToList();
                    var BookedRoom = _context.UserBookRooms.FirstOrDefault(R => R.RoomID == room.ID && R.UserID == UserID
                                                && R.CheckIn <= dateTimeNow && R.CheckOut >= dateTimeNow);
                    List<string> images = new List<string>();
                    foreach (var pic in Pics)
                    {
                        images.Add(pic.Image);
                    }
                    DateTime _checkIn = DateTime.Now.AddDays(-10);
                    DateTime _checkOut = DateTime.Now.AddDays(-9);
                    if(BookedRoom is not null)
                    {
                        _checkIn = BookedRoom.CheckIn;
                        _checkOut = BookedRoom.CheckOut;
                    }
                    RoomWithPics roomWithPics = new RoomWithPics()
                    {
                        RoomID = room.ID,
                        UserID = UserID,
                        Price = room.Price,
                        BedCount = room.BedCount,
                        CheckIn = _checkIn,
                        CheckOut = _checkOut,
                        Images = images
                    };
                    lst.Add(roomWithPics);
                }
            }
            return lst;
        }
    }
}
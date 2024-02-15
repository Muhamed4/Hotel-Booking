using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;
using Hotel_Booking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking.Repository.AdminRepo
{
    public class AdminRepo : IAdminRepo
    {
        private readonly AppDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        public AdminRepo(AppDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            this._context = context;
            this._hosting = hosting;
        }

        public bool CheckExistence(int hotelId)
        {
            var check = _context.Hotels.FirstOrDefault(H => H.ID == hotelId);
            if (check is null)
                return false;

            return true;
        }

        public bool CheckExistenceFacility(int facilityId)
        {
            var check = _context.Facilities.FirstOrDefault(F => F.ID == facilityId);
            if (check is null)
                return false;

            return true;
        }

        public bool CheckExistenceFeature(int featureId)
        {
            var check = _context.Features.FirstOrDefault(F => F.ID == featureId);
            if (check is null)
                return false;

            return true;
        }

        public bool CheckExistenceFoodDrink(int foodDrinkId)
        {
            var check = _context.FoodDrinks.FirstOrDefault(F => F.ID == foodDrinkId);
            if (check is null)
                return false;

            return true;
        }

        public bool CheckExistenceFunProgram(int funProgramId)
        {
            var check = _context.FunPrograms.FirstOrDefault(F => F.ID == funProgramId);
            if (check is null)
                return false;

            return true;
        }

        public bool CheckExistenceService(int serviceId)
        {
            var check = _context.Services.FirstOrDefault(S => S.ID == serviceId);
            if (check is null)
                return false;

            return true;
        }

        public void DeleteFacility(int facilityId)
        {
            var facility = _context.Facilities.Find(facilityId);

            if (facility is not null)
            {
                _context.Facilities.Remove(facility);
                _context.SaveChanges();
            }
        }

        public void DeleteFoodDrink(int foodDrinkId)
        {
            var foodDrink = _context.FoodDrinks.Find(foodDrinkId);
            if (foodDrink is not null)
            {
                _context.FoodDrinks.Remove(foodDrink);
                _context.SaveChanges();
            }
        }

        public void DeleteFunProgram(int funProgramId)
        {
            var funProgram = _context.FunPrograms.Find(funProgramId);
            if (funProgram is not null)
            {
                _context.FunPrograms.Remove(funProgram);
                _context.SaveChanges();
            }
        }

        public void DeleteHotel(int hotelId)
        {
            var hotel = _context.Hotels.Find(hotelId);

            if (hotel is not null)
            {
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();
            }
        }

        public void DeleteService(int serviceId)
        {
            var service = _context.Services.Find(serviceId);
            if (service is not null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }

        public void Edit(int hotelId, Hotel hotel)
        {
            var oldHotel = _context.Hotels.Find(hotelId);
            if (oldHotel is null)
                return;

            oldHotel.Name = hotel.Name;
            oldHotel.Country = hotel.Country;
            oldHotel.City = hotel.City;
            oldHotel.Description = hotel.Description;
            oldHotel.Image = hotel.Image;

            _context.SaveChanges();
        }

        public void EditFacility(int facilityId, Facility facility)
        {
            var oldFacility = _context.Facilities.Find(facilityId);
            if (oldFacility is null)
                return;

            oldFacility.Description = facility.Description;

            _context.SaveChanges();
        }

        public void EditFoodDrink(int foodDrinkId, FoodDrink foodDrink)
        {
            var oldFoodDrink = _context.FoodDrinks.Find(foodDrinkId);
            if (oldFoodDrink is null)
                return;

            oldFoodDrink.Description = foodDrink.Description;

            _context.SaveChanges();
        }

        public void EditFunProgram(int funProgramId, FunProgram funProgram)
        {
            var oldFunProgram = _context.FunPrograms.Find(funProgramId);
            if (oldFunProgram is null)
                return;

            oldFunProgram.Description = funProgram.Description;

            _context.SaveChanges();
        }

        public void EditService(int serviceId, Service service)
        {
            var oldService = _context.Services.Find(serviceId);
            if (oldService is null)
                return;

            oldService.Description = service.Description;

            _context.SaveChanges();
        }

        public List<AddFeature> Facilities(int hotelId)
        {
            List<AddFeature> facilities = new List<AddFeature>();
            var feature = _context.Features.FirstOrDefault(F => F.HotelID == hotelId);
            if (feature is not null)
            {
                var res = _context.Facilities.Where(F => F.FeatureID == feature.ID).ToList();
                foreach (var item in res)
                {
                    var facility = new AddFeature() { ID = item.ID, Description = item.Description, FeatureID = item.FeatureID, HotelID = hotelId };
                    facilities.Add(facility);
                }
            }

            return facilities;
        }

        public List<AddFeature> FoodDrinks(int hotelId)
        {
            List<AddFeature> foodDrinks = new List<AddFeature>();
            var feature = _context.Features.FirstOrDefault(F => F.HotelID == hotelId);
            if (feature is not null)
            {
                var res = _context.FoodDrinks.Where(F => F.FeatureID == feature.ID).ToList();
                foreach (var item in res)
                {
                    var foodDrink = new AddFeature() { ID = item.ID, Description = item.Description, FeatureID = item.FeatureID, HotelID = hotelId };
                    foodDrinks.Add(foodDrink);
                }
            }

            return foodDrinks;
        }

        public List<AddFeature> FunPrograms(int hotelId)
        {
            List<AddFeature> funPrograms = new List<AddFeature>();
            var feature = _context.Features.FirstOrDefault(F => F.HotelID == hotelId);
            if (feature is not null)
            {
                var res = _context.FunPrograms.Where(F => F.FeatureID == feature.ID).ToList();
                foreach (var item in res)
                {
                    var funProgram = new AddFeature() { ID = item.ID, Description = item.Description, FeatureID = item.FeatureID, HotelID = hotelId };
                    funPrograms.Add(funProgram);
                }
            }

            return funPrograms;
        }

        public Facility GetFacility(int facilityId)
        {
            var facility = _context.Facilities.FirstOrDefault(F => F.ID == facilityId);
            return facility;
        }

        public int GetFeatureId(int hotelId)
        {
            var feature = _context.Features.FirstOrDefault(F => F.HotelID == hotelId);
            if (feature is not null)
                return feature.ID;

            return -1;
        }

        public FoodDrink GetFoodDrink(int foodDrinkId)
        {
            var foodDrink = _context.FoodDrinks.FirstOrDefault(F => F.ID == foodDrinkId);
            return foodDrink;
        }

        public FunProgram GetFunProgram(int funProgramId)
        {
            var funProgram = _context.FunPrograms.FirstOrDefault(F => F.ID == funProgramId);
            return funProgram;
        }

        public Hotel GetHotel(int hotelId)
        {
            var hotel = _context.Hotels.FirstOrDefault(H => H.ID == hotelId);
            return hotel;
        }

        public int GetHotelId(int featureId)
        {
            var feature = _context.Features.FirstOrDefault(F => F.ID == featureId);
            if (feature is not null)
            {
                return feature.HotelID;
            }

            return -1;
        }

        public List<Hotel> GetHotels()
        {
            return _context.Hotels.ToList();
        }

        public List<RoomDetails> GetRooms(int hotelId)
        {
            List<RoomDetails> roomDetails = new List<RoomDetails>();
            var rooms = _context.Rooms.Where(R => R.HotelID == hotelId).ToList();
            if (rooms is not null)
            {
                foreach (var item in rooms)
                {
                    var pics = _context.RoomImages.Where(R => R.RoomID == item.ID).Select(R => R.Image).ToList() ?? new List<string>();
                    var room = new RoomDetails()
                    {
                        RoomID = item.ID,
                        Price = item.Price,
                        RoomNumber = item.RoomNumber,
                        BedCount = item.BedCount,
                        HotelID = hotelId,
                        Images = pics
                    };

                    roomDetails.Add(room);
                }
            }

            return roomDetails;
        }

        public Service GetService(int serviceId)
        {
            var service = _context.Services.FirstOrDefault(F => F.ID == serviceId);
            return service;
        }

        public void InsertFacility(Facility facility)
        {
            if (facility is not null)
            {
                _context.Facilities.Add(facility);
                _context.SaveChanges();
            }
        }

        public void InsertFoodDrink(FoodDrink foodDrink)
        {
            if (foodDrink is not null)
            {
                _context.FoodDrinks.Add(foodDrink);
                _context.SaveChanges();
            }
        }

        public void InsertFunProgram(FunProgram funProgram)
        {
            if (funProgram is not null)
            {
                _context.FunPrograms.Add(funProgram);
                _context.SaveChanges();
            }
        }

        public void InsertImages(IFormFileCollection GalleryImages, int RoomId)
        {
            if (GalleryImages is not null)
            {
                foreach (var file in GalleryImages)
                {
                    var _roomImage = new RoomImage()
                    {
                        Image = UploadImage(file),
                        RoomID = RoomId
                    };
                    _context.RoomImages.Add(_roomImage);
                    _context.SaveChanges();
                }
            }
        }

        public void InsertRoom(Room room)
        {
            if (room is not null)
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();
            }
        }

        public void InsertService(Service service)
        {
            if (service is not null)
            {
                _context.Services.Add(service);
                _context.SaveChanges();
            }
        }

        public List<AddFeature> Services(int hotelId)
        {
            List<AddFeature> services = new List<AddFeature>();
            var feature = _context.Features.FirstOrDefault(F => F.HotelID == hotelId);
            if (feature is not null)
            {
                var res = _context.Services.Where(F => F.FeatureID == feature.ID).ToList();
                foreach (var item in res)
                {
                    var service = new AddFeature() { ID = item.ID, Description = item.Description, FeatureID = item.FeatureID, HotelID = hotelId };
                    services.Add(service);
                }
            }

            return services;
        }

        public string UploadImage(IFormFile File)
        {
            string fileName = string.Empty;
            if (File is not null)
            {
                string imagesPath = Path.Combine(_hosting.WebRootPath, "RoomImages");
                fileName = Guid.NewGuid().ToString() + "_" + File.FileName;
                string fullPath = Path.Combine(imagesPath, fileName);
                File.CopyTo(new FileStream(fullPath, FileMode.Create));
            }

            return fileName;
        }

        public string UploadFile(IFormFile formFile, string ImageUrl)
        {
            if (formFile != null)
            {
                string Uploads = Path.Combine(_hosting.WebRootPath, "Images");
                string newPath = Path.Combine(Uploads, formFile.FileName);
                string oldPath = Path.Combine(Uploads, ImageUrl);
                if (oldPath != newPath)
                {
                    System.IO.File.Delete(oldPath);
                    formFile.CopyTo(new FileStream(newPath, FileMode.Create));
                }

                return formFile.FileName;
            }
            return ImageUrl;
        }

        public bool CheckExistenceRoom(int RoomId)
        {
            var room = _context.Rooms.FirstOrDefault(R => R.ID == RoomId);
            if (room is null)
                return false;

            return true;
        }

        public Room GetRoom(int RoomId)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.ID == RoomId);
            return room;
        }

        public List<string> GetImagesRoom(int RoomId)
        {
            var roomImages = _context.RoomImages.Where(R => R.RoomID == RoomId).Select(R => R.Image).ToList();
            return roomImages;
        }

        public void EditRoom(int roomId, Room room)
        {
            var oldRoom = _context.Rooms.FirstOrDefault(R => R.ID == roomId);
            if (oldRoom is not null)
            {
                oldRoom.Price = room.Price;
                oldRoom.RoomNumber = room.RoomNumber;
                oldRoom.BedCount = room.BedCount;

                _context.SaveChanges();
            }
        }

        public void EditRoomImages(IFormFileCollection GalleryImages, int RoomId)
        {
            if (GalleryImages is not null)
            {
                DeleteRoomImage(RoomId);
                InsertImages(GalleryImages, RoomId);
            }
        }

        public void DeleteRoomImage(int RoomId)
        {
            var images = _context.RoomImages.Where(R => R.RoomID == RoomId).ToList();
            if (images is not null)
            {
                foreach (var image in images)
                {
                    _context.RoomImages.Remove(image);
                    _context.SaveChanges();
                }
            }
        }

        public bool CheckRoomByHotelId(int roomNumber, int RoomId, int hotelId)
        {
            var _room = _context.Rooms.FirstOrDefault(X => X.HotelID == hotelId && X.ID != RoomId && X.RoomNumber == roomNumber);

            if (_room is null)
                return true;

            return false;
        }

        public void DeleteRoom(int roomId)
        {
            var room = _context.Rooms.FirstOrDefault(R => R.ID == roomId);
            if(room is not null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }
    }
}
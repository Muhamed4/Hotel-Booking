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
            if(check is null)
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

        public void DeleteFacility(int facilityId)
        {
            var facility = _context.Facilities.Find(facilityId);

            if(facility is not null)
            {
                _context.Facilities.Remove(facility);
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
            if(oldFacility is null)
                return;

            oldFacility.Description = facility.Description;

            _context.SaveChanges();
        }

        public List<AddFacility> Facilities(int hotelId)
        {
            List<AddFacility> facilities = new List<AddFacility>();
            var feature = _context.Features.FirstOrDefault(F => F.HotelID == hotelId);
            if (feature is not null)
            {
                var res = _context.Facilities.Where(F => F.FeatureID == feature.ID).ToList();
                foreach (var item in res)
                {
                    var facility = new AddFacility() { ID = item.ID, Description = item.Description, FeatureID = item.FeatureID, HotelID = hotelId };
                    facilities.Add(facility);
                }
            }

            return facilities;
        }

        public Facility GetFacility(int facilityId)
        {
            var facility = _context.Facilities.FirstOrDefault(F => F.ID == facilityId);
            return facility;
        }

        public int GetFeatureId(int hotelId)
        {
            var feature = _context.Features.FirstOrDefault(F => F.HotelID == hotelId);
            if(feature is not null)
                return feature.ID;

            return -1;
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

        public void InsertFacility(Facility facility)
        {
            if (facility is not null)
            {
                _context.Facilities.Add(facility);
                _context.SaveChanges();
            }
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
    }
}
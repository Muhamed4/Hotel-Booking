using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.FeaturesRepo
{
    public class FeatureRepo : IFeatureRepo
    {
        private readonly AppDbContext _context;
        public FeatureRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var _feature = GetById(id);

            if(_feature is not null)
            {
                _context.Features.Remove(_feature);
                _context.SaveChanges();
            }
        }

        public List<Feature> GetAllFeature()
        {
            return _context.Features.ToList();
        }

        public Feature GetById(int id)
        {
            var _feature = _context.Features.FirstOrDefault(X => X.ID == id);
            
            return _feature;
        }

        public void Insert(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
        }

        public void Update(int id, Feature newHotel)
        {
            var _oldFeature = GetById(id);
            _oldFeature.FreeParking = newHotel.FreeParking;
            _oldFeature.LaundryFacility = newHotel.LaundryFacility;
            _oldFeature.NoSmoking = newHotel.NoSmoking;
            _oldFeature.FreeWifi = newHotel.FreeWifi;
            _oldFeature.FreeBreakfast = newHotel.FreeBreakfast;
            _oldFeature.AirportTransfer = newHotel.AirportTransfer;
            _oldFeature.FontDesk247 = newHotel.FontDesk247;
            _oldFeature.Restaurant = newHotel.Restaurant;
            _oldFeature.AirCondition = newHotel.AirCondition;

            _context.SaveChanges();
        }
    }
}
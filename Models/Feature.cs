using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class Feature
    {
        public int ID { get; set; }
        public byte FreeParking { get; set; }
        public byte LaundryFacility { get; set; }
        public byte NoSmoking { get; set; }
        public byte FreeWifi { get; set; }
        public byte FreeBreakfast { get; set; }
        public byte AirportTransfer { get; set; }
        public byte FontDesk247 { get; set; }
        public byte Restaurant { get; set; }
        public byte AirCondition { get; set; }
        public int HotelID { get; set; }
        public Hotel? Hotel { get; set; }
        public ICollection<FeatureFacility>? FeatureFacilities { get; set; }
        public ICollection<FeatureFoodDrink>? FeatureFoodDrinks { get; set; }
        public ICollection<FeatureService>? FeatureServices { get; set; }
        public ICollection<FeatureFunProgram>? FeatureFunPrograms { get; set; }
    }
}
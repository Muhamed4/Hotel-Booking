using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class Feature
    {
        public int ID { get; set; }
        public bool FreeParking { get; set; }
        public bool LaundryFacility { get; set; }
        public bool NoSmoking { get; set; }
        public bool FreeWifi { get; set; }
        public bool FreeBreakfast { get; set; }
        public bool AirportTransfer { get; set; }
        public bool FontDesk247 { get; set; }
        public bool Restaurant { get; set; }
        public bool AirCondition { get; set; }
        // Foreign Key for Hotel Table
        public int HotelID { get; set; }
        public Hotel? Hotel { get; set; }
        public ICollection<FeatureFacility>? FeatureFacilities { get; set; }
        public ICollection<FeatureFoodDrink>? FeatureFoodDrinks { get; set; }
        public ICollection<FeatureService>? FeatureServices { get; set; }
        public ICollection<FeatureFunProgram>? FeatureFunPrograms { get; set; }
    }
}
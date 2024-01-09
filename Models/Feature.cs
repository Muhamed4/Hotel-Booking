using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class Feature
    {
        public int ID { get; set; }
        public bool? FreeParking { get; set; }
        public bool? LaundryFacility { get; set; }
        public bool? NoSmoking { get; set; }
        public bool? FreeWifi { get; set; }
        public bool? FreeBreakfast { get; set; }
        public bool? AirportTransfer { get; set; }
        public bool? FontDesk247 { get; set; }
        public bool? Restaurant { get; set; }
        public bool? AirCondition { get; set; }
        // Foreign Key for Hotel Table
        public int HotelID { get; set; }
        public virtual Hotel Hotel { get; set; } = null!;
        public virtual ICollection<Facility> Facilities { get; set; }
        public virtual ICollection<FoodDrink> FoodDrinks { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<FunProgram> FunPrograms { get; set; }
    }
}
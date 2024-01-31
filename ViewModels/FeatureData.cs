using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;

namespace Hotel_Booking.ViewModels
{
    public class FeatureData
    {
        [Required(ErrorMessage = "Select one of the choices !")]
        public bool FreeParking { get; set; }
        [Required(ErrorMessage = "Select one of the choices !")]
        public bool LaundryFacility { get; set; }
        [Required(ErrorMessage = "Select one of the choices !")]
        public bool NoSmoking { get; set; }
        [Required(ErrorMessage = "Select one of the choices !")]
        public bool FreeWifi { get; set; }
        [Required(ErrorMessage = "Select one of the choices !")]
        public bool FreeBreakfast { get; set; }
        [Required(ErrorMessage = "Select one of the choices !")]
        public bool AirportTransfer { get; set; }
        [Required(ErrorMessage = "Select one of the choices !")]
        public bool FontDesk247 { get; set; }
        [Required(ErrorMessage = "Select one of the choices !")]
        public bool Restaurant { get; set; }
        [Required(ErrorMessage = "Select one of the choices !")]
        public bool AirCondition { get; set; }
        // public int NumRooms { get; set; }
        // public List<string>Facilities;
        // public List<string>FoodDrinks;
        // public List<string>FunPrograms;
        // public List<string>Services;
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;

namespace Hotel_Booking.ViewModels
{
    public class AllHotelDetails
    {
        public Hotel Hotel { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Room> Rooms { get; set; }
        public Feature Feature { get; set; }
        public List<Facility> Facilities { get; set; }
        public List<FunProgram> FunPrograms { get; set; }
        public List<FoodDrink> FoodDrinks { get; set; }
        public List<Service> Services { get; set; }
    }
}
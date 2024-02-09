using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;

namespace Hotel_Booking.ViewModels
{
    public class AllHotelDetails
    {
        public string UserID { get; set; }
        public bool isVisited { get; set; }
        public decimal Rate { get; set; }
        public int ReviewsCount { get; set; }
        public Hotel Hotel { get; set; }
        public List<UserReview> Reviews { get; set; }
        public List<RoomWithPics> Rooms { get; set; }
        public List<Servicewithicon> Serviceswithicons { get; set; }
        public List<Facility> Facilities { get; set; }
        public List<FunProgram> FunPrograms { get; set; }
        public List<FoodDrink> FoodDrinks { get; set; }
        public List<Service> Services { get; set; }
    }
}
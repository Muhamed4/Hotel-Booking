using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.FoodDrinksRepo
{
    public interface IFoodDrinkRepo
    {
        void Insert(FoodDrink foodDrink);
        void Insert(string foodDrink, int featureId);
    }
}
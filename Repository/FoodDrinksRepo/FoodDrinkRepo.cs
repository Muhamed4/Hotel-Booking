using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;
using Hotel_Booking.Repository;

namespace Hotel_Booking.Repository.FoodDrinksRepo
{
    public class FoodDrinkRepo : IFoodDrinkRepo
    {
        private readonly AppDbContext _context;
        public FoodDrinkRepo(AppDbContext context)
        {
            this._context = context;
        }
        public void Insert(FoodDrink foodDrink)
        {
            _context.FoodDrinks.Add(foodDrink);
            _context.SaveChanges();
        }

        public void Insert(string foodDrink, int featureId)
        {
            if(foodDrink is not null)
            {
                var _foodDrink = new FoodDrink()
                {
                    Description = foodDrink,
                    FeatureID = featureId
                };
                _context.FoodDrinks.Add(_foodDrink);
                _context.SaveChanges();
            }
        }
    }
}
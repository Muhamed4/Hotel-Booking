using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Hotel_Booking.Repository.FacilitiesRepo;
using Hotel_Booking.Repository.FeaturesRepo;
using Hotel_Booking.Repository.FoodDrinksRepo;
using Hotel_Booking.Repository.FunProgramsRepo;
using Hotel_Booking.Repository.ServicesRepo;
using Hotel_Booking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotel_Booking.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureRepo _featureContext;
        private readonly IFacilityRepo _facilityContext;
        private readonly IFoodDrinkRepo _foodDrinkContext;
        private readonly IFunProgramRepo _funProgramContext;
        private readonly IServiceRepo _serviceContext;
        public FeatureController(IFeatureRepo featureRepository, IFacilityRepo facilityRepository, IFoodDrinkRepo foodDrinkRepository,
                                 IFunProgramRepo funProgramRepository, IServiceRepo serviceRepository)
        {
            this._featureContext = featureRepository;
            this._facilityContext = facilityRepository;
            this._foodDrinkContext = foodDrinkRepository;
            this._funProgramContext = funProgramRepository;
            this._serviceContext = serviceRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddFeature(int hotelID)
        {
            ViewBag.HotelID = hotelID;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFeature(FeatureData featureData, int hotelID)
        {
            if (ModelState.IsValid)
            {
                Feature feature = new Feature()
                {
                    FreeParking = featureData.FreeParking,
                    LaundryFacility = featureData.LaundryFacility,
                    NoSmoking = featureData.NoSmoking,
                    FreeWifi = featureData.FreeWifi,
                    FreeBreakfast = featureData.FreeBreakfast,
                    AirportTransfer = featureData.AirportTransfer,
                    FontDesk247 = featureData.FontDesk247,
                    Restaurant = featureData.Restaurant,
                    AirCondition = featureData.AirCondition,
                    HotelID = hotelID
                };

                _featureContext.Insert(feature);

                return RedirectToAction(nameof(AddOtherFeature), new { featureID = feature.ID });
            }
            ViewBag.HotelID = hotelID;
            return View(featureData);
        }


        [HttpGet]
        public IActionResult AddOtherFeature(int featureID)
        {
            var otherFeature = new OtherFeature();
            otherFeature.FeatureID = featureID;
            return View(otherFeature);
        }

        [HttpPost]
        public IActionResult AddOtherFeature(OtherFeature otherFeature)
        {
            if(ModelState.IsValid)
            {
                _facilityContext.Insert(otherFeature.Facility, otherFeature.FeatureID);
                _foodDrinkContext.Insert(otherFeature.FoodDrink, otherFeature.FeatureID);
                _funProgramContext.Insert(otherFeature.FunProgram, otherFeature.FeatureID);
                _serviceContext.Insert(otherFeature.Service, otherFeature.FeatureID);

                bool Decide = otherFeature.addMore;
                if(Decide)
                    return RedirectToAction("AddOtherFeature", "Feature", new { featureID = otherFeature.FeatureID });
                
                return RedirectToAction("Index", "AdminHotels");
            }
            return View(otherFeature);
        }
    }
}
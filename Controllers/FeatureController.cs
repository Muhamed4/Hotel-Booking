using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Hotel_Booking.Repository.FeaturesRepo;
using Hotel_Booking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotel_Booking.Controllers
{
    public class FeatureController : Controller
    {
        private IFeatureRepo _featureContext;
        public FeatureController(IFeatureRepo featureRepository)
        {
            this._featureContext = featureRepository;
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
            ViewBag.FeatureID = featureID;
            return Content($"{featureID}");
        }
    }
}
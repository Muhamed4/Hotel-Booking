using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Hotel_Booking.Repository.AdminRepo;
using Hotel_Booking.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.Extensions.Logging;

namespace Hotel_Booking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminHotelsController : Controller
    {
        private readonly IAdminRepo _adminContext;
        public AdminHotelsController(IAdminRepo adminContext)
        {
            this._adminContext = adminContext;
        }

        public IActionResult Index()
        {
            var hotels = _adminContext.GetHotels();
            return View(hotels);
        }

        [HttpGet]
        public IActionResult Delete(int hotelId)
        {
            var check = _adminContext.CheckExistence(hotelId);
            if (check == false)
            {
                return NotFound();
            }
            _adminContext.DeleteHotel(hotelId);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int hotelId)
        {
            var check = _adminContext.CheckExistence(hotelId);
            if (check == false)
            {
                return NotFound();
            }

            var hotel = _adminContext.GetHotel(hotelId);
            var hotelData = new EditHotel()
            {
                HotelID = hotel.ID,
                Name = hotel.Name,
                Country = hotel.Country,
                City = hotel.City,
                Description = hotel.Description,
                ImageUrl = hotel.Image
            };

            return View(hotelData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditHotel editHotel)
        {
            if (ModelState.IsValid)
            {
                string fileName = _adminContext.UploadFile(editHotel.File, editHotel.ImageUrl) ?? string.Empty;

                var hotel = new Hotel()
                {
                    Name = editHotel.Name,
                    Country = editHotel.Country,
                    City = editHotel.City,
                    Description = editHotel.Description,
                    Image = fileName
                };

                _adminContext.Edit(editHotel.HotelID, hotel);

                return RedirectToAction(nameof(Index));
            }

            return View(editHotel);
        }

        [HttpGet]
        public IActionResult Details(int hotelId)
        {
            var check = _adminContext.CheckExistence(hotelId);
            if (check == false)
                return NotFound();

            var hotel = _adminContext.GetHotel(hotelId);
            return View(hotel);
        }

        [HttpGet]
        public IActionResult FacilityDetails(int hotelId)
        {
            var check = _adminContext.CheckExistence(hotelId);
            if (check == false)
                return NotFound();

            var facilities = _adminContext.Facilities(hotelId);
            var featureId = _adminContext.GetFeatureId(hotelId);
            if (featureId == -1)
                return NotFound();
            var HotelId = _adminContext.GetHotelId(featureId);
            if (HotelId == -1)
                return NotFound();
            var facility = new FeatureDetail() { features = facilities, featureId = featureId, HotelID = HotelId };

            return View(facility);
        }

        [HttpGet]
        public IActionResult AddFacility(int featureId)
        {
            var check = _adminContext.CheckExistenceFeature(featureId);
            if (check == false)
                return NotFound();

            var hotelId = _adminContext.GetHotelId(featureId);

            if (hotelId == -1)
                return NotFound();

            var facility = new AddFeature() { FeatureID = featureId, HotelID = hotelId };

            return View(facility);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFacility(AddFeature facility)
        {
            if (ModelState.IsValid)
            {
                var newFacility = new Facility()
                {
                    Description = facility.Description,
                    FeatureID = facility.FeatureID
                };

                _adminContext.InsertFacility(newFacility);

                return RedirectToAction("FacilityDetails", new { hotelId = facility.HotelID });
            }

            return View(facility);
        }

        [HttpGet]
        public IActionResult EditFacility(int facilityId)
        {
            var check = _adminContext.CheckExistenceFacility(facilityId);
            if (check == false)
                return NotFound();

            var facility = _adminContext.GetFacility(facilityId);
            var hotelId = _adminContext.GetHotelId(facility.FeatureID);
            var newFacility = new EditFeature() { ID = facility.ID, Description = facility.Description, FeatureID = facility.FeatureID, HotelID = hotelId };
            return View(newFacility);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditFacility(EditFeature editFeature)
        {
            if (ModelState.IsValid)
            {
                var facility = new Facility()
                {
                    Description = editFeature.Description
                };

                _adminContext.EditFacility(editFeature.ID, facility);

                return RedirectToAction("FacilityDetails", new { hotelId = editFeature.HotelID });
            }

            return View(editFeature);
        }


        [HttpGet]
        public IActionResult DeleteFacility(int facilityId, int hotelId)
        {
            var check = _adminContext.CheckExistenceFacility(facilityId);
            if (check == false)
            {
                return NotFound();
            }
            _adminContext.DeleteFacility(facilityId);

            return RedirectToAction("FacilityDetails", new { hotelId = hotelId });
        }

        [HttpGet]
        public IActionResult FoodDrinkDetails(int hotelId)
        {
            var check = _adminContext.CheckExistence(hotelId);
            if (check == false)
                return NotFound();

            var foodDrinks = _adminContext.FoodDrinks(hotelId);
            var featureId = _adminContext.GetFeatureId(hotelId);
            if (featureId == -1)
                return NotFound();
            var HotelId = _adminContext.GetHotelId(featureId);
            if (HotelId == -1)
                return NotFound();
            var foodDrink = new FeatureDetail() { features = foodDrinks, featureId = featureId, HotelID = HotelId };

            return View(foodDrink);
        }

        [HttpGet]
        public IActionResult AddFoodDrink(int featureId)
        {
            var check = _adminContext.CheckExistenceFeature(featureId);
            if (check == false)
                return NotFound();

            var hotelId = _adminContext.GetHotelId(featureId);

            if (hotelId == -1)
                return NotFound();

            var foodDrink = new AddFeature() { FeatureID = featureId, HotelID = hotelId };

            return View(foodDrink);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFoodDrink(AddFeature foodDrink)
        {
            if (ModelState.IsValid)
            {
                var newFoodDrink = new FoodDrink()
                {
                    Description = foodDrink.Description,
                    FeatureID = foodDrink.FeatureID
                };

                _adminContext.InsertFoodDrink(newFoodDrink);

                return RedirectToAction("FoodDrinkDetails", new { hotelId = foodDrink.HotelID });
            }

            return View(foodDrink);
        }

        [HttpGet]
        public IActionResult EditFoodDrink(int foodDrinkId)
        {
            var check = _adminContext.CheckExistenceFoodDrink(foodDrinkId);
            if (check == false)
                return NotFound();

            var foodDrink = _adminContext.GetFoodDrink(foodDrinkId);
            var hotelId = _adminContext.GetHotelId(foodDrink.FeatureID);
            var newFeature = new EditFeature() { ID = foodDrink.ID, Description = foodDrink.Description, FeatureID = foodDrink.FeatureID, HotelID = hotelId };
            return View(newFeature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditFoodDrink(EditFeature editFeature)
        {
            if (ModelState.IsValid)
            {
                var foodDrink = new FoodDrink()
                {
                    Description = editFeature.Description
                };

                _adminContext.EditFoodDrink(editFeature.ID, foodDrink);

                return RedirectToAction("FoodDrinkDetails", new { hotelId = editFeature.HotelID });
            }

            return View(editFeature);
        }

        [HttpGet]
        public IActionResult DeleteFoodDrink(int foodDrinkId, int hotelId)
        {
            var check = _adminContext.CheckExistenceFoodDrink(foodDrinkId);
            if (check == false)
            {
                return NotFound();
            }
            _adminContext.DeleteFoodDrink(foodDrinkId);

            return RedirectToAction("FoodDrinkDetails", new { hotelId = hotelId });
        }

        [HttpGet]
        public IActionResult FunProgramDetails(int hotelId)
        {
            var check = _adminContext.CheckExistence(hotelId);
            if (check == false)
                return NotFound();

            var funPrograms = _adminContext.FunPrograms(hotelId);
            var featureId = _adminContext.GetFeatureId(hotelId);
            if (featureId == -1)
                return NotFound();
            var HotelId = _adminContext.GetHotelId(featureId);
            if (HotelId == -1)
                return NotFound();
            var funProgram = new FeatureDetail() { features = funPrograms, featureId = featureId, HotelID = HotelId };

            return View(funProgram);
        }

        [HttpGet]
        public IActionResult AddFunProgram(int featureId)
        {
            var check = _adminContext.CheckExistenceFeature(featureId);
            if (check == false)
                return NotFound();

            var hotelId = _adminContext.GetHotelId(featureId);

            if (hotelId == -1)
                return NotFound();

            var funProgram = new AddFeature() { FeatureID = featureId, HotelID = hotelId };

            return View(funProgram);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFunProgram(AddFeature funProgram)
        {
            if (ModelState.IsValid)
            {
                var newFunProgram = new FunProgram()
                {
                    Description = funProgram.Description,
                    FeatureID = funProgram.FeatureID
                };

                _adminContext.InsertFunProgram(newFunProgram);

                return RedirectToAction("FunProgramDetails", new { hotelId = funProgram.HotelID });
            }

            return View(funProgram);
        }

        [HttpGet]
        public IActionResult EditFunProgram(int funProgramId)
        {
            var check = _adminContext.CheckExistenceFunProgram(funProgramId);
            if (check == false)
                return NotFound();

            var funProgram = _adminContext.GetFunProgram(funProgramId);
            var hotelId = _adminContext.GetHotelId(funProgram.FeatureID);
            var newFeature = new EditFeature() { ID = funProgram.ID, Description = funProgram.Description, FeatureID = funProgram.FeatureID, HotelID = hotelId };
            return View(newFeature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditFunProgram(EditFeature editFeature)
        {
            if (ModelState.IsValid)
            {
                var funProgram = new FunProgram()
                {
                    Description = editFeature.Description
                };

                _adminContext.EditFunProgram(editFeature.ID, funProgram);

                return RedirectToAction("FunProgramDetails", new { hotelId = editFeature.HotelID });
            }

            return View(editFeature);
        }

        [HttpGet]
        public IActionResult DeleteFunProgram(int funProgramId, int hotelId)
        {
            var check = _adminContext.CheckExistenceFunProgram(funProgramId);
            if (check == false)
            {
                return NotFound();
            }
            _adminContext.DeleteFunProgram(funProgramId);

            return RedirectToAction("FunProgramDetails", new { hotelId = hotelId });
        }

        [HttpGet]
        public IActionResult ServiceDetails(int hotelId)
        {
            var check = _adminContext.CheckExistence(hotelId);
            if (check == false)
                return NotFound();

            var services = _adminContext.Services(hotelId);
            var featureId = _adminContext.GetFeatureId(hotelId);
            if (featureId == -1)
                return NotFound();
            var HotelId = _adminContext.GetHotelId(featureId);
            if (HotelId == -1)
                return NotFound();
            var service = new FeatureDetail() { features = services, featureId = featureId, HotelID = HotelId };

            return View(service);
        }

        [HttpGet]
        public IActionResult AddService(int featureId)
        {
            var check = _adminContext.CheckExistenceFeature(featureId);
            if (check == false)
                return NotFound();

            var hotelId = _adminContext.GetHotelId(featureId);

            if (hotelId == -1)
                return NotFound();

            var service = new AddFeature() { FeatureID = featureId, HotelID = hotelId };

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddService(AddFeature service)
        {
            if (ModelState.IsValid)
            {
                var newService = new Service()
                {
                    Description = service.Description,
                    FeatureID = service.FeatureID
                };

                _adminContext.InsertService(newService);

                return RedirectToAction("ServiceDetails", new { hotelId = service.HotelID });
            }

            return View(service);
        }

        [HttpGet]
        public IActionResult EditService(int serviceId)
        {
            var check = _adminContext.CheckExistenceService(serviceId);
            if (check == false)
                return NotFound();

            var service = _adminContext.GetService(serviceId);
            var hotelId = _adminContext.GetHotelId(service.FeatureID);
            var newFeature = new EditFeature() { ID = service.ID, Description = service.Description, FeatureID = service.FeatureID, HotelID = hotelId };
            return View(newFeature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditService(EditFeature editFeature)
        {
            if (ModelState.IsValid)
            {
                var service = new Service()
                {
                    Description = editFeature.Description
                };

                _adminContext.EditService(editFeature.ID, service);

                return RedirectToAction("ServiceDetails", new { hotelId = editFeature.HotelID });
            }

            return View(editFeature);
        }

        [HttpGet]
        public IActionResult DeleteService(int serviceId, int hotelId)
        {
            var check = _adminContext.CheckExistenceService(serviceId);
            if (check == false)
            {
                return NotFound();
            }
            _adminContext.DeleteService(serviceId);

            return RedirectToAction("ServiceDetails", new { hotelId = hotelId });
        }

        [HttpGet]
        public IActionResult RoomDetails(int hotelId)
        {
            var check = _adminContext.CheckExistence(hotelId);
            if(check == false)
                return NotFound();

            var rooms = new RoomDetailswithID() { HotelID = hotelId, RoomDetails = _adminContext.GetRooms(hotelId) };
            return View(rooms);
        }
    }
}
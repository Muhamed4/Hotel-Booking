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
            if(HotelId == -1)
                return NotFound();
            var facility = new FacilityDetail() { facilities = facilities, featureId = featureId, HotelID = HotelId };

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

            var facility = new AddFacility() { FeatureID = featureId, HotelID = hotelId };

            return View(facility);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFacility(AddFacility facility)
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
            var newFacility = new EditFacility() { ID = facility.ID, Description = facility.Description, FeatureID = facility.FeatureID, HotelID = hotelId };
            return View(newFacility);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditFacility(EditFacility editFacility)
        {
            if (ModelState.IsValid)
            {
                var facility = new Facility()
                {
                    Description = editFacility.Description
                };

                _adminContext.EditFacility(editFacility.ID, facility);

                return RedirectToAction("FacilityDetails", new { hotelId = editFacility.HotelID });
            }

            return View(editFacility);
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
    }
}
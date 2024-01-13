using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Hotel_Booking.Repository.HotelRepo;
using Hotel_Booking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotel_Booking.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelRepo _hotelContext;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        public HotelController(IHotelRepo hotelRepo, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _hotelContext = hotelRepo;
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            // Just for test!
            // return Content("Hotel Controller is exist!");
            return View();
        }

        [HttpGet]
        public IActionResult AddHotel()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddHotel(HotelData hotelData)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (hotelData.File is not null)
                {
                    string imagesPath = Path.Combine(_hosting.WebRootPath, "Images");
                    fileName = Guid.NewGuid().ToString() + hotelData.File.FileName;
                    string fullPath = Path.Combine(imagesPath, fileName);
                    hotelData.File.CopyTo(new FileStream(fullPath, FileMode.Create));

                    Hotel _hotel = new Hotel()
                    {
                        Name = hotelData.Name,
                        Country = hotelData.Country,
                        City = hotelData.City,
                        Description = hotelData.Description,
                        Image = fileName
                    };

                    _hotelContext.Insert(_hotel);
                    
                    // Go to Feature Page
                    return RedirectToAction(nameof(AddFeature), new {_id = _hotel.ID});
                }
            }
            return View(hotelData);
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
            return Content($"{hotelID}");
        }
    }
}
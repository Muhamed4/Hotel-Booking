using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Hotel_Booking.Repository.HotelRepo;
using Hotel_Booking.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddHotel()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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
                    fileName = Guid.NewGuid().ToString() + "_" + hotelData.File.FileName;
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
                    // return RedirectToAction("AddFeature", "Feature", new { hotelID = _hotel.ID });
                    return RedirectToAction("AddRoom", "Room", new { hotelID = _hotel.ID });
                }
            }
            return View(hotelData);
        }

        [Authorize(Roles = "NUser")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _hotelContext.UserWatchHotel(id, userId);
            var allHotelDetails = _hotelContext.GetAllHotelDetails(id, userId);

            return View(allHotelDetails);
        }

        [Authorize(Roles = "NUser")]
        public JsonResult Reaction(int hotelId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int reactCount = _hotelContext.UserReact(hotelId, userId);
            return Json(reactCount);
        }

        [Authorize(Roles = "NUser")]
        [HttpGet]
        public IActionResult Review(int hotelId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var review = new ReviewData();
            review.HotelID = hotelId;
            review.UserID = userId;
            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Review(ReviewData review)
        {
            if (ModelState.IsValid)
            {
                _hotelContext.AddReview(review);
                return RedirectToAction("Details", "Hotel", new { id = review.HotelID });
            }

            return View(review);
        }

        [Authorize(Roles = "NUser")]
        [HttpGet]
        public IActionResult Trips()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var trips = _hotelContext.GetTrips(userId);
            return View(trips);
        }

        [Authorize(Roles = "NUser")]
        [HttpGet]
        public IActionResult FavHotels()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favHotels = _hotelContext.GetFavouritHotels(userId);
            return View(favHotels);
        }


        [HttpPost]
        public IActionResult ShowImages()
        {
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Hotel_Booking.Repository.RoomImageRepo;
using Hotel_Booking.Repository.RoomsRepo;
using Hotel_Booking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotel_Booking.Controllers
{
    public class RoomController : Controller
    {
        private IRoomRepo _roomContext;
        private IRoomImageRepo _roomImageContext;
        public RoomController(IRoomRepo roomContext, IRoomImageRepo roomImageContext)
        {
            this._roomContext = roomContext;
            this._roomImageContext = roomImageContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddRoom(int hotelID)
        {
            var roomData = new RoomData();
            roomData.hotelID = hotelID;
            return View(roomData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRoom(RoomData roomData)
        {
            if(ModelState.IsValid)
            {
                var _room = new Room()
                {
                    Price = roomData.Price,
                    RoomNumber = roomData.RoomNumber,
                    BedCount = roomData.BedCount,
                    HotelID = roomData.hotelID
                };

                _roomContext.Insert(_room);

                // Add the Images of this room using RoomImages list ....
                if(roomData.GalleryImages is not null)
                {
                    foreach(var file in roomData.GalleryImages)
                    {
                        var _roomImage = new RoomImage()
                        {
                            Image = _roomContext.UploadImage(file),
                            RoomID = _room.ID
                        };
                        _roomImageContext.Insert(_roomImage);
                    }
                }

                bool Decide = roomData.addMore;
                if(Decide)
                    return RedirectToAction("AddRoom", "Room", new { hotelID = roomData.hotelID });
                    
                return RedirectToAction("AddFeature", "Feature", new { hotelID = roomData.hotelID });
            }

            return View(roomData);
        }
    }
}
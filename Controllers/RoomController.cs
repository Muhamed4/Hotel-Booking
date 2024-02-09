using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Hotel_Booking.Repository.RoomImageRepo;
using Hotel_Booking.Repository.RoomsRepo;
using Hotel_Booking.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotel_Booking.Controllers
{
    [Authorize]
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

        [HttpGet]
        public IActionResult BookRoom(int RoomID, int hotelId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var _data = new UserBookRoomData();
            _data.UserId = userId;
            _data.RoomId = RoomID;
            ViewBag.hotelId = hotelId;
            return View(_data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookRoom(UserBookRoomData _data, int hotelId)
        {
            if(ModelState.IsValid)
            {
                var Date = _data.BookDate;
                var booking = new UserBookRoom()
                {
                    RoomID = _data.RoomId,
                    UserID = _data.UserId,
                    CheckIn = _data.BookDate,
                    CheckOut = Date.AddDays(_data.Nights)
                };
                _roomContext.BookRoom(booking);
                return RedirectToAction("Details", "Hotel", new { id = hotelId });
            }

            return View(_data);
        }

        [HttpGet]
        public IActionResult CancelBookRoom(int RoomID, int hotelId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _roomContext.CancelBookRoom(RoomID, userId);
            return RedirectToAction("Details", "Hotel", new { id = hotelId });
        }
    }
}
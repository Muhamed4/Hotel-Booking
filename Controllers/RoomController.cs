using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Repository.RoomsRepo;
using Hotel_Booking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotel_Booking.Controllers
{
    public class RoomController : Controller
    {
        private IRoomRepo _roomContext;
        public RoomController(IRoomRepo roomContext)
        {
            this._roomContext = roomContext;
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
                
            }
            return View(roomData);
        }
    }
}
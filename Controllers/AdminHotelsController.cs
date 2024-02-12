using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Repository.AdminRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotel_Booking.Controllers
{
    [Authorize(Roles ="Admin")]
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
    }
}
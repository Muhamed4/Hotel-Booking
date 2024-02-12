using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotel_Booking.Controllers
{
    public class RouteController : Controller
    {
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated == true)
            {
                if(User.IsInRole("Admin"))
                    return RedirectToAction(nameof(Index), "AdminHotels");
            }
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
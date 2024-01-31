using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotel_Booking.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminHotelsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
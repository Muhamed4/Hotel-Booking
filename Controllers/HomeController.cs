using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

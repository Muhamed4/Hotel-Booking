using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CreateCookie()
    {
        string key = "Muhamed";
        string value = "Morsi";
        CookieOptions options = new CookieOptions()
        {
            Expires = DateTime.Now.AddDays(5)
        };

        Response.Cookies.Append(key, value, options);
        return View(nameof(Index));
    }

    public IActionResult ReadCookie()
    {
        string key = "Muhamed";
        var cookieValue = Request.Cookies[key];
        return View(nameof(Index));
    }

    public IActionResult RemoveCookie()
    {
        string key = "Muhamed";
        string value = "";
        CookieOptions options = new CookieOptions()
        {
            Expires = DateTime.Now.AddDays(-1)
        };

        Response.Cookies.Append(key, value, options);
        return View(nameof(Index));
    }
}

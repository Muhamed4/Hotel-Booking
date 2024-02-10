using System.Security.Claims;
using Hotel_Booking.Repository.HomesRepo;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking.Controllers;

public class HomeController : Controller
{
    private readonly IHomeRepo _homeContext;
    public HomeController(IHomeRepo homeContext)
    {
        this._homeContext = homeContext;
    }
    public IActionResult Index()
    {
        string country = TempData["Country"] as string;
        string city = TempData["City"] as string;
        string userId = "";
        if(User.Identity.IsAuthenticated)
        {
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        var allHotelsInfo = _homeContext.GetAllHotelsInfo(country, city, userId);
        return View(allHotelsInfo);
    }

    public IActionResult Search(string country, string city)
    {
        string _country = "", _city = "";
        if(country is not null && country != "")_country = country.ToLower();
        if(city is not null && city != "") _city = city.ToLower();
        TempData["Country"] = _country;
        TempData["City"] = _city;
        
        return RedirectToAction(nameof(Index));
    }
}

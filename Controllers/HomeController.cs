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
        var allHotelsInfo = _homeContext.GetAllHotelsInfo();
        return View(allHotelsInfo);
    }
}

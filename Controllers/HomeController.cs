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
        var allHotelsInfo = _homeContext.GetAllHotelsInfo();
        return View(allHotelsInfo);
    }

    public IActionResult SomeAction()
    {
        var userId = "";
        if(User.Identity.IsAuthenticated)
        {
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        return Content($"{userId}");
    }
}

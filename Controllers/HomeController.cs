using System.Security.Claims;
using Hotel_Booking.Models;
using Hotel_Booking.Repository.HomesRepo;
using Hotel_Booking.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        if (User.Identity.IsAuthenticated)
        {
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        var allHotelsInfo = _homeContext.GetAllHotelsInfo(country, city, userId);
        return View(allHotelsInfo);
    }

    public IActionResult Search(string country, string city)
    {
        string _country = "", _city = "";
        if (country is not null && country != "") _country = country.ToLower();
        if (city is not null && city != "") _city = city.ToLower();
        TempData["Country"] = _country;
        TempData["City"] = _city;

        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "NUser")]
    [HttpGet]
    public IActionResult UserProfile(string UserId)
    {
        var check = _homeContext.CheckExistenceUser(UserId);
        if (check == false)
            return NotFound();
        var userProfile = _homeContext.GetUserInfo(UserId);
        return View(userProfile);
    }

    [Authorize(Roles = "NUser")]
    [HttpGet]
    public IActionResult EditUser(string UserId)
    {
        var check = _homeContext.CheckExistenceUser(UserId);
        if (check == false)
            return NotFound();
        var userData = _homeContext.GetUserData(UserId);
        return View(userData);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditUser(UserEdit userEdit)
    {
        if (ModelState.IsValid)
        {
            var fileName = _homeContext.UploadFile(userEdit.File, userEdit.Image);
            var user = new User()
            {
                Id = userEdit.UserId,
                FirstName = userEdit.FirstName,
                LastName = userEdit.LastName,
                Email = userEdit.Email,
                Image = fileName
            };

            _homeContext.UpdateUser(user.Id, user);

            return RedirectToAction("UserProfile", new { UserId = user.Id });
        }

        return View(userEdit);
    }
}

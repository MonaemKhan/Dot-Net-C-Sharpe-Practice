using Microsoft.AspNetCore.Mvc;

namespace Employee.Frontend.Controllers;

public class CountryFController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

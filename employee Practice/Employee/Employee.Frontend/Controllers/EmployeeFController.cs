using Microsoft.AspNetCore.Mvc;

namespace Employee.Frontend.Controllers;

public class EmployeeFController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Quiz_Application_Test_MVC.Controllers
{
    public class QuizQuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}

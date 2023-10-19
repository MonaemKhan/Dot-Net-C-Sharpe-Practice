using Employee.Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Frontend.Controllers
{
    public class FrontendEmployeeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public FrontendEmployeeController(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient.CreateClient("EmployeeAPIBase"); ;
            _configuration = configuration;
        }

        private bool UserAuth()
        {
            if (_configuration["UserName"] == "EMP")
            {
                return true;
            }
            return false;
        }

        public async Task<IActionResult> Index(){
            Environment.SetEnvironmentVariable("SomeKey", "Monaem");
            return View(await GetAllCountry());
        }

        private async Task<List<Employeess>> GetAllCountry()
        {
            var responce = await _httpClient.GetFromJsonAsync<List<Employeess>>("Employee");
            return responce is not null? responce: new List<Employeess>();
        }
    }
}

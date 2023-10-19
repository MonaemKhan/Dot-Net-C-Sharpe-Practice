using Employee.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Employee.Frontend.Controllers
{
    public class FrontendStateController : Controller
    {
        private readonly HttpClient _httpClient;

        public FrontendStateController(IHttpClientFactory httpClient) => _httpClient = httpClient.CreateClient("EmployeeAPIBase");

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var responce = await _httpClient.GetFromJsonAsync<List<States>>("State");
            return responce is not null ? View(responce):BadRequest("Request Invalid") ;
        }

        [HttpGet]
        public async Task<IActionResult> AddorEdit(int Id)
        {
            var country = await _httpClient.GetFromJsonAsync<List<Countrys>>("Country");
            ViewData["CountryId"] = new SelectList(country, "Id", "CountryName");

            if (Id == 0)
            {
                //create From
                ViewBag.SubmitName = "Create";
                return View();
            }
            else
            {
                var data = await _httpClient.GetAsync("State/Id:int?Id=" + Id);
                
                if (data.IsSuccessStatusCode)
                {
                    var result = await data.Content.ReadFromJsonAsync<States>();                    
                    ViewBag.SubmitName = "Save";
                    return View(result);
                }
            }
            return View(new States());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddorEdit(int Id,States _data)
        {
            var country = await _httpClient.GetFromJsonAsync<List<Countrys>>("Country");
            ViewData["CountryId"] = new SelectList(country, "Id", "CountryName");

                if (Id == 0)
                {
                    var response = await _httpClient.PostAsJsonAsync("State", _data);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error creating Country.");
                        ViewBag.SubmitName = "Create";
                        return View(_data);
                    }
                }
                else
                {
                    var response = await _httpClient.PutAsJsonAsync($"State?Id={Id}", _data);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Update Country UnSuccsfull.");
                        ViewBag.SubmitName = "Save";
                        return View(_data);
                    }
                }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var responce = await _httpClient.DeleteAsync($"State?Id={Id}");
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

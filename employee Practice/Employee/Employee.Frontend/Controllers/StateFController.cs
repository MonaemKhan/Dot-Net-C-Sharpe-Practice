using Employee.Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Frontend.Controllers;

public class StateFController : Controller
{
    private readonly HttpClient _httpClient;
    public StateFController(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient.CreateClient("APIBaseAddress");
    }
    public async Task<IActionResult> Index()
    {
        var responce = await _httpClient.GetAsync("State");
        return View(await responce.Content.ReadFromJsonAsync<IEnumerable<StateFM>>());
    }

    [HttpGet]
    public async Task<IActionResult> AddorEdit(int Id)
    {
        var responceToCOuntry = await _httpClient.GetAsync("Country");
        if (Id == 0)
        {
            ViewBag.ButtonText = "Create";
            ViewBag.Country = await responceToCOuntry.Content.ReadFromJsonAsync<IEnumerable<CountryFM>>();
            return View();
        }
        else
        {
            var responceToEdit = await _httpClient.GetAsync($"State/int:Id?Id={Id}");
            var data = await responceToEdit.Content.ReadFromJsonAsync<StateFM>();
            ViewBag.ButtonText = "Save";
            ViewBag.Country = await responceToCOuntry.Content.ReadFromJsonAsync<IEnumerable<CountryFM>>();
            return View(data);
        }        
    }

    [HttpPost]
    public async Task<IActionResult> AddorEdit(int Id,StateFM _data)
    {
        var responceToCOuntry = await _httpClient.GetAsync("Country");
        ViewBag.Country = await responceToCOuntry.Content.ReadFromJsonAsync<IEnumerable<CountryFM>>();
        if (ModelState.IsValid)
        {
            if (Id>0)
            {
                var responceToEdit = await _httpClient.PutAsJsonAsync($"State/int: Id?Id={Id}", _data);
                if (responceToEdit.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Data Update Unsuccesfull");
                ViewBag.ButtonText = "Save";
                return View();
            }
            else
            {
                var responceToPost = await _httpClient.PostAsJsonAsync("State", _data);
                if (responceToPost.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Data Inser Unsuccesfull");
                ViewBag.ButtonText = "Create";
                return View(_data);
            }
        }
        else
        {
            ModelState.AddModelError("","Check Your Input");
            if (Id == 0)
            {
                ViewBag.ButtonText = "Create";
                return View(_data);
            }
            else
            {
                ViewBag.ButtonText = "Save";
                return View(_data);
            }
        }
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id > 0)
        {
            var responceToDelete = await _httpClient.DeleteAsync($"State/int: Id?Id={Id}");
            if(responceToDelete.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest("Invalid Id");
        }
        return View();
    }
}

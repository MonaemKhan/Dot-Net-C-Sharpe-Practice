using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEB_API_AUTH_Parctice.Model.AuthModel;
using WEB_API_AUTH_Parctice.Repository.Auth;

namespace WEB_API_AUTH_Parctice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuth _auth;

    public AuthController(IAuth auth)
    {
        _auth = auth;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginProcess(Login log)
    { 
        return await _auth.LoginProcess(log);
    }

    [HttpPost]
    [Route("Register/Reader")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterReader(Register reg)
    {
        return await _auth.RegisterProcess(reg, "Reader");
    }

    [HttpPost]
    [Route("Register/Writer")]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> RegisterWriter(Register reg)
    {
        return await _auth.RegisterProcess(reg, "Writer");
    }

    [HttpDelete("Delete")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteProcess(Login log)
    {
        return await _auth.DeleteUSerProcess(log);
    }
}
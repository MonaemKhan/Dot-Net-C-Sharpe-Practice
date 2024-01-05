using InvenTrackPro.App.Controllers.Base;
using InvenTrackPro.Application.Features.AuthOperation.Command;
using InvenTrackPro.Application.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMaster.App.Controllers;

[AllowAnonymous]
public class AccountController : ApiControllerBase
{
    
    [HttpPost("login")]
    public async Task<IActionResult> Signin([FromBody] LoginModel model)
    {
        return await HandelCommandAsync(new UserLoginCommand(model));
    }

    [HttpPost("register")]
    public async Task<IActionResult> SignUp([FromBody] RegistrationModel model)
    {
        return await HandelCommandAsync(new UserRegistration(model));
    }
}

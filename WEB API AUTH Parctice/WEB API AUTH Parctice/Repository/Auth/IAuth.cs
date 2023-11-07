using Microsoft.AspNetCore.Mvc;
using WEB_API_AUTH_Parctice.Model.AuthModel;

namespace WEB_API_AUTH_Parctice.Repository.Auth;

public interface IAuth
{
    public Task<IActionResult> LoginProcess(Login log);
    public Task<IActionResult> RegisterProcess(Register reg, string roles);
    public Task<IActionResult> DeleteUSerProcess(Login log);
}

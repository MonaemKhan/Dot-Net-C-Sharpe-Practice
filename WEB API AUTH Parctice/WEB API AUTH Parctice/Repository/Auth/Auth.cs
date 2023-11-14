using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB_API_AUTH_Parctice.Model.AuthModel;
using WEB_API_AUTH_Parctice.Repository.Token_Generator;

namespace WEB_API_AUTH_Parctice.Repository.Auth;

public class Auth : IAuth
{
    private readonly UserManager<IdentityUser> _userManger;
    private readonly IToken _token;
    public Auth(UserManager<IdentityUser> userManager, IToken token)
    {
        _userManger = userManager;
        _token = token;
    }    

    public async Task<IActionResult> LoginProcess(Login log)
    {
        var user = await _userManger.FindByEmailAsync(log.Emial); // check if user exit by this email
        if(user != null)
        {
            var pass = await _userManger.CheckPasswordAsync(user, log.Password); // check if given user pasword match
            if (pass)
            {
                //get user role
                var roles = await _userManger.GetRolesAsync(user);
                if(roles != null)
                {
                    //create token
                    var token = _token.CreateJwtToken(user, roles.ToList());
                    return new OkObjectResult(token);
                }
                else
                {
                    return new BadRequestObjectResult("Invalid User");
                }
                
            }
            else
            {
                return new BadRequestObjectResult("Password Not Match");
            }
        }
        return new BadRequestObjectResult("User Not Found");
    }

    public async Task<IActionResult> RegisterProcess(Register reg, string roles)
    {
        // create IdentityUser of regiter user
        var idenityUser = new IdentityUser
        {
            UserName = reg.UserName,
            Email = reg.Emial
        };

        //crate user in db, usermanager class will handle the rest
        var identityUserResult = await _userManger.CreateAsync(idenityUser, reg.Password);

        if (identityUserResult.Succeeded)
        {
            // now we add Reader roles to the user
            identityUserResult = await _userManger.AddToRoleAsync(idenityUser, roles);
            if (identityUserResult.Succeeded)
            {
                return new OkObjectResult($"Registration Successful");
            }
        }
        return new BadRequestObjectResult("Something Went Wrong");
    }

    public async Task<IActionResult> DeleteUSerProcess(Login log)
    {
        var user = await _userManger.FindByEmailAsync(log.Emial); // check if user exit by this email
        if (user != null)
        {
            var pass = await _userManger.CheckPasswordAsync(user, log.Password); // check if given user pasword match
            if (pass)
            {
                //get user role
                var identityUserResult = await _userManger.DeleteAsync(user);
                if (identityUserResult.Succeeded)
                {
                    return new OkObjectResult($"Delete Successful");
                }
                else
                {
                    return new BadRequestObjectResult("Error . . . . . . ");
                }

            }
            else
            {
                return new BadRequestObjectResult("Password Not Match");
            }
        }
        return new BadRequestObjectResult("User Not Found");
    }
}

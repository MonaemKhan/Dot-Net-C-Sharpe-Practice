using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WEB_API_AUTH_Parctice.Repository.Token_Generator;

public class Token : IToken
{
    private readonly UserManager<IdentityUser> _userManger;
    private readonly IConfiguration _config;
    public Token(UserManager<IdentityUser> userManager, IConfiguration config)
    {
        _userManger = userManager;
        _config = config;
    }
    public string CreateJwtToken(IdentityUser user, List<string> roles)
    {
        // create claims
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Email,user.Email));

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
        var issuer = _config["jwt:Issuer"];
        var audiance = _config["jwt:Audiance"];

        var credentials= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer,
            audiance,
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials : credentials
            ) ;

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

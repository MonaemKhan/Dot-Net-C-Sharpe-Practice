using Microsoft.AspNetCore.Identity;

namespace WEB_API_AUTH_Parctice.Repository.Token_Generator;

public interface IToken
{
    public string CreateJwtToken(IdentityUser user, List<string> roles);
}

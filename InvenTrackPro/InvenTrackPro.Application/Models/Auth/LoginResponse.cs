namespace InvenTrackPro.Application.Models.Auth;

public class LoginResponse(string token, DateTime expires)
{
    public DateTime Expires { get; init; } = expires;
    public string Token { get; init; } = token;
}


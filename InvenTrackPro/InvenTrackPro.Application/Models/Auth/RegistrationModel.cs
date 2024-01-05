namespace InvenTrackPro.Application.Models.Auth;

public class RegistrationModel
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public bool TramsAndConditions { get; set; }
}

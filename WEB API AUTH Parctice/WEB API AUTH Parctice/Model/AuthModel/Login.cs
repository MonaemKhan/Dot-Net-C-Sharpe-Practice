using System.ComponentModel.DataAnnotations;

namespace WEB_API_AUTH_Parctice.Model.AuthModel;

public class Login
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Emial { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace WEB_API_AUTH_Parctice.Model.AuthModel;

public class Register
{
    [Required]
    [DataType(DataType.Text)]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Emial { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}

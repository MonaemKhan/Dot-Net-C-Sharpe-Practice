namespace WEB_API_AUTH_Parctice.Model;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string University { get; set; } = "Rangamati Science and Technology University";
    public DateTimeOffset CreatedBy { get; set; } = DateTime.UtcNow;
}

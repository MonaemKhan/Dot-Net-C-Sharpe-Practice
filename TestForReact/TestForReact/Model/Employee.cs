using System.Text.Json.Serialization;

namespace TestForReact.Model;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }

    public int CityId { get; set; }
    public City? City { get; set; }
}

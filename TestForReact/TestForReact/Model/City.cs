namespace TestForReact.Model;

public class City
{
    public int Id { get; set; }
    public string CityName { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
}

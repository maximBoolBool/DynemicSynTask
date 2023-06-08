using System.ComponentModel.DataAnnotations.Schema;

namespace DynemicSun.Models;

public class Month
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    [ForeignKey("Year")]
    public int YearId { get; set; }
    
    public Year Year { get; set; }
    public List<WeatherMeasurement> WeatherMeasurements { get; set; }
}
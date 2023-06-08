using System.ComponentModel.DataAnnotations.Schema;

namespace DynemicSun.Models;

public class WeatherMeasurement
{
    public int Id { get;set; }
    
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public double Temperature { get; set; }
    public int AirRelativeHumidity { get; set; }
    public double DewPoint { get; set; }
    public int AtmospericPressure { get; set; }
    public string? AirDirection { get; set; }
    public int? AirSpeed { get; set; }
    public int? CloudCover { get; set; }
    public int? LowerCloudLimit { get; set; }
    public double? VisualVisibility { get; set; }
    public string? WeatherPhenomena { get; set; }
    
    [ForeignKey("Month")]
    public int MonthId { get; set; }
    
    public Month Month { get; set; }
}
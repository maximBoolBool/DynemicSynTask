using Microsoft.EntityFrameworkCore;

namespace DynemicSun.Models;

[Index("Value")]
public class Year
{
    public int Id { get; set; }
   
    public int? Value { get; set; }
    
    public List<Month> Months { get; set; }
}
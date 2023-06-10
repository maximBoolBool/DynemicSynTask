using DynemicSun.Models;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;

namespace DynemicSun.Services.IGetServices;

public class GetService : IGetService
{
    private ApplicationContext db;

    public GetService(ApplicationContext _db)
    {
        db = _db;
    }

    public async Task<Month> GetMonth(string monthName)
    {
        var responseMonth = await db.Months
            .Include(m => m.WeatherMeasurements).FirstOrDefaultAsync(m => m.Name.Equals(monthName));
        return responseMonth;
    }
    
    
    public async Task<List<string?>> GetMonths()
    {
        List<string?> monthesName = await db.Months
            .Include(mo => mo.WeatherMeasurements)
            .Select(m => new{Name = m.Name , Date = m.WeatherMeasurements.First().Date })
            .OrderBy(m => m.Date  ).Select(m => m.Name).ToListAsync();

        return monthesName;
    }

    public async Task<List<string>> GetNeighborsMonth(DateOnly date)
    {
        string? leftNeighbors = await db.Months.Include(mo => mo.WeatherMeasurements)
            .Select(m => new { Name = m.Name, Date = m.WeatherMeasurements.First().Date })
            .Where(m => m.Date.CompareTo(date) == -1).OrderBy(m => m.Date).Select(m=>m.Name).LastOrDefaultAsync();
        
        string? rightNeighbor = await db.Months.Include(mo => mo.WeatherMeasurements)
            .Select(m => new { Name = m.Name, Date = m.WeatherMeasurements.First().Date })
            .Where( m => m.Date.CompareTo(date) == 1 ).Select(m=> m.Name).FirstOrDefaultAsync();
        
        List<string?> response = new();
        
        if(leftNeighbors is not null)
            response.Add(leftNeighbors);
        
        if(rightNeighbor is not null)
            response.Add(rightNeighbor);
        return response;
    }
    
    
    public async Task<Year?> GetYear(int value)
    {
        var responseYear = await db.Years
            .Include( y=> y.Months )
            .ThenInclude(month => month.WeatherMeasurements ).FirstOrDefaultAsync(y => y.Value.Equals(value));
        return responseYear;
    }

    public async Task<List<int?>> GetYears()
    {
        List<int?> years = await db.Years.Select(y => y.Value).OrderBy(y => y).ToListAsync();
        return years;
    }

    public async Task<List<int?>> GetNeighborsYears(int yearId)
    {
        List<int?> neighbors = await db.Years
            .Where(y => (y.Id == yearId-1) || (y.Id == yearId+1) )
            .Select(y => y.Value).ToListAsync();
        return neighbors;
    }
}
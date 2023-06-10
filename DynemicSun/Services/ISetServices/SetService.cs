using DynemicSun.Models;
using Microsoft.EntityFrameworkCore;

namespace DynemicSun.Services.ISetServices;

public class SetService : ISetService
{
    private ApplicationContext db;

    public SetService(ApplicationContext _db)
    {
        db = _db;
    }
    
    public async Task AddYearsToDb(List<Year> years)
    {
        List<int?> dbYears = await db.Years.Select(y => y.Value).ToListAsync();
        List<int?> valueYears = years.Select(y => y.Value).ToList();
        List<int?> res = valueYears.Except(dbYears).ToList();
        await db.Years.AddRangeAsync(years.Where(y => res.Contains(y.Value)));
        await db.SaveChangesAsync();
    }
}
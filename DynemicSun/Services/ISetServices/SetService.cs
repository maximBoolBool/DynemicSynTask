using DynemicSun.Models;
using Microsoft.EntityFrameworkCore;

namespace DynemicSun.Services.ISetServices;

public class SetService : iSetService
{
    private ApplicationContext db;

    public SetService(ApplicationContext _db)
    {
        db = _db;
    }
    
    public async Task AddYearsToDb(List<Year> years)
    {
        List<int> dbYears = await db.Years.Select(y => y.Value).ToListAsync();
        
        var addList = years.Select(y=> y.Value).Except(dbYears);

        await db.Years.AddRangeAsync(years.Where(y => addList.Contains(y.Value)));
        await db.SaveChangesAsync();
    }
}
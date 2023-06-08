using DynemicSun.Models;

namespace DynemicSun.Services.ISetServices;

public interface iSetService
{
    public Task AddYearsToDb(List<Year> years);
    
}
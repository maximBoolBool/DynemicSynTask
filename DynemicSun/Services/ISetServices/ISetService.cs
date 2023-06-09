using DynemicSun.Models;

namespace DynemicSun.Services.ISetServices;

public interface ISetService
{
    public Task AddYearsToDb(List<Year> years);
    
}
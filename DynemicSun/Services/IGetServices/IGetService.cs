using DynemicSun.Models;
namespace DynemicSun.Services.IGetServices;

public interface IGetService
{
    public Task<Month> GetMonth(string monthName);
    public Task<Year?> GetYear(int value);
    public Task<List<string?>> GetMonths();
    public Task<List<int?>> GetYears();
    public Task<List<int?>> GetNeighborsYears(int yearId);
    public Task<List<string?>> GetNeighborsMonth(DateOnly date);
}
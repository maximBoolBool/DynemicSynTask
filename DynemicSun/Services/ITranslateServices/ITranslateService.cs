using DynemicSun.Models;

namespace DynemicSun.Services.ITranslateServices;

public interface ITranslateService
{
    public Task<List<Year>> FromExcelsToYears(IFormFileCollection collections);
    
}
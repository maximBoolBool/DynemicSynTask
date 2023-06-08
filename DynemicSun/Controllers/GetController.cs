using Microsoft.AspNetCore.Mvc;

namespace DynemicSun.Controllers;

public class GetController : Controller
{
    private ApplicationContext db;

    public GetController(ApplicationContext _db)
    {
        db = _db;
    }
    
    public async Task<IActionResult> GetMonthArchive()
    {
        return View();
    }

    public async Task<IActionResult> GetYearArchive()
    {
        return View();
    } 
}
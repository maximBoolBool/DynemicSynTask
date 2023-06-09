using DynemicSun.Services.IGetServices;
using Microsoft.AspNetCore.Mvc;

namespace DynemicSun.Controllers;

public class GetController : Controller
{
    private IGetService getService;

    public GetController(IGetService _getService)
    {
        getService = _getService;
    }

    public async Task<IActionResult> GetAllMonths()
    {
        return View();
    }

    public async Task<IActionResult> GetAllYears()
    {
        return View();
    }

    public async Task<IActionResult> GetMonthArchive()
    {
        return View();
    }

    public async Task<IActionResult> GetYearArchive()
    {
        return View();
    }

    [Route("GetChoosePage")]
    public async Task<IActionResult> GetChoosePage()
    {
        return View();
    }
}
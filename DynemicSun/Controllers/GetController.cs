using DynemicSun.Models;
using DynemicSun.Services.IGetServices;
using Microsoft.AspNetCore.Mvc;
using NPOI.XSSF.Streaming.Values;

namespace DynemicSun.Controllers;

public class GetController : Controller
{
    private IGetService getService;

    public GetController(IGetService _getService)
    {
        getService = _getService;
    }

    [Route("GetAllMonths")]
    public async Task<IActionResult> GetAllMonths()
    {
        List<string?> months = await getService.GetMonths();
        return View(months);
    }

    [Route("GetAllYears")]
    public async Task<IActionResult> GetAllYears()
    {
        List<int> years = await getService.GetYears();
        return View(years);
    }

    [HttpPost]
    [Route("GetMonthArchive")]
    public async Task<IActionResult> GetMonthArchive()
    {
        string? month = Request.Form["month"];
        Month responseMonth = await getService.GetMonth(month); 
        return View(responseMonth);
    }

    [Route("GetYearArchive")]
    public async Task<IActionResult> GetYearArchive()
    {
        int yearValue = int.Parse(Request.Form["year"]);
        Year? year = await getService.GetYear(yearValue);
        return View(year);
    }

    [Route("GetChoosePage")]
    public async Task<IActionResult> GetChoosePage()
    {
        return View();
    }
}
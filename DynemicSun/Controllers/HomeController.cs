using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DynemicSun.Models;
using DynemicSun.Services.ISetServices;
using DynemicSun.Services.ITranslateServices;
using NPOI.SS.Formula.Functions;

namespace DynemicSun.Controllers;

public class HomeController : Controller
{
    private ITranslateService translator;

    private ISetService setService;
    
    public HomeController(ITranslateService _translator, ISetService _setService)
    {
        translator = _translator;
        setService = _setService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [Route("AddNewArchiveForm")]
    public async Task<IActionResult> AddNewArchiveForm()
    {
        return View();
    }

    [HttpPost]
    [Route("AddNewArchive")]
    public async Task<IActionResult> AddNewArchive()
    {
        IFormFileCollection files = Request.Form.Files;
        List<Year> years = await translator.FromExcelsToYears(files);
        await setService.AddYearsToDb(years);
        return Redirect("AddNewArchiveForm");
    }
}
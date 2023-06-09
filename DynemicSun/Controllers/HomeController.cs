using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DynemicSun.Models;
using DynemicSun.Services.ISetServices;
using DynemicSun.Services.ITranslateServices;

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
    public async Task<IActionResult> AddNewArchive(IFormFileCollection collection)
    {
        translator.FromExcelsToYears(collection);
        return View();
    }
    
}
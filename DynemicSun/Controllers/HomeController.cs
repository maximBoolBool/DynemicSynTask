using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DynemicSun.Models;

namespace DynemicSun.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> AddNewArchiveForm()
    {
        return View();
    }

    public async Task<IActionResult> AddNewArchive()
    {
        return View();
    }
    
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoCatalogoCep.Models;
using DemoCatalogoCep.Services;

namespace DemoCatalogoCep.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICepService _cepService;

    public HomeController(ILogger<HomeController> logger, ICepService cepService)
    {
        _logger = logger;
        _cepService = cepService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

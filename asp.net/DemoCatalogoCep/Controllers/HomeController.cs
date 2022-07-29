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
        var ceps = _cepService.ConsultaTodos();
        return View(ceps);
    }

    //GET .../Home/Create
    public IActionResult Create()
    {
        return View();
    }

    //POST .../Home/Create
    [HttpPost]
    public IActionResult Create(CepViewModel novoCep)
    {
        if (!ModelState.IsValid)
        {
            return View(novoCep);
        }
        _cepService.Cadastrar(novoCep);
        return RedirectToAction(nameof(Index));
    }

    //GET .../Home/Search/{id}
    public IActionResult Search(string id)
    {
        ViewData["Id"] = id;
        CepViewModel? resultado = null;
        if (!String.IsNullOrEmpty(id))
        {
            resultado = _cepService.ConsultaPorCep(id);
        }
        return View(resultado);
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

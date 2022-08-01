using Microsoft.AspNetCore.Mvc;
using DemoAloMundoWebService.Models;

namespace DemoAloMundoWebService.Controllers;

[ApiController]
[Route("[controller]")]
public class AloMundoController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    public AloMundoController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string Get()
    {
        _logger.LogInformation("GET /AloMundo");
        return "Alô Mundo!";
    }

    [HttpGet("{nome}")]
    public string Get(string nome)
    {
        _logger.LogInformation($"GET /AloMundo/{nome}");
        return $"Alô {nome}!";
    }

    [HttpGet("query")]
    public string GetQuery(string nome)
    {
        _logger.LogInformation($"GET /AloMundo/query?nome={nome}");
        return $"Alô {nome}!";
    }

    [HttpPost]
    public string Post([FromBody] string nome)
    {
        _logger.LogInformation($"POST /AloMundo");
        return $"Alô {nome}!";
    }

    [HttpPost("Pessoa")]
    public string Post(Pessoa umaPessoa)
    {
        _logger.LogInformation($"POST /AloMundo/Pessoa");
        return $"Alô {umaPessoa.Nome}! Você tem {umaPessoa.Idade} anos.";
    }
}
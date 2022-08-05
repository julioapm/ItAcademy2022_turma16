using Microsoft.AspNetCore.Mvc;
using DemoEFWebApi.Models;
using DemoEFWebApi.Services;

namespace DemoEFWebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CatalogoController : ControllerBase
{
    private readonly ILogger<CatalogoController> _logger;
    private readonly IProdutoRepositorio _produtosRepositorio;

    public CatalogoController(ILogger<CatalogoController> logger, IProdutoRepositorio produtosRepositorio)
    {
        _logger = logger;
        _produtosRepositorio = produtosRepositorio;
    }

    [HttpGet] //GET .../api/v1/Catalogo
    public Task<IEnumerable<Produto>> GetTodos()
    {
        return _produtosRepositorio.ConsultarTodosAsync();
    }
}

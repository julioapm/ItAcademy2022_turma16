using Microsoft.AspNetCore.Mvc;
using DemoEFWebApi.Models;
using DemoEFWebApi.Services;
using DemoEFWebApi.DTOs;

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
    public async Task<IEnumerable<ProdutoDTO>> GetTodos()
    {
        var produtos = await _produtosRepositorio.ConsultarTodosAsync();
        return produtos.Select(p => ProdutoDTO.DeEntidadeParaDTO(p));
    }

    [HttpGet("{id}")] //GET .../ap1/v1/Catalogo/{id}
    public async Task<ActionResult<ProdutoDTO>> GetPorId(int id)
    {
        var produto = await _produtosRepositorio.ConsultarPorIdAsync(id);
        if (produto == null) return NotFound();
        else return ProdutoDTO.DeEntidadeParaDTO(produto);
    }
}

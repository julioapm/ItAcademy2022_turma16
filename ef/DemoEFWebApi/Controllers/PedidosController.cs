using Microsoft.AspNetCore.Mvc;
using DemoEFWebApi.Models;
using DemoEFWebApi.Services;
using DemoEFWebApi.DTOs;

namespace DemoEFWebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly ILogger<CatalogoController> _logger;
    private readonly IPedidoRepositorio _pedidosRepositorio;

    public PedidosController(ILogger<CatalogoController> logger, IPedidoRepositorio pedidoRepositorio)
    {
        _logger = logger;
        _pedidosRepositorio = pedidoRepositorio;
    }

    [HttpGet("{id}")] //GET api/v1/Pedidos/{id}
    public async Task<ActionResult<Pedido>> GetPorId(int id)
    {
        var pedido = await _pedidosRepositorio.ConsultarPorIdAsync(id);
        if (pedido == null) return NotFound();
        else return pedido;
    }
}

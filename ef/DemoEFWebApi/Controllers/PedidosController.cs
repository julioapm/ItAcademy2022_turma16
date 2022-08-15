using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DemoEFWebApi.Models;
using DemoEFWebApi.Services;
using DemoEFWebApi.DTOs;

namespace DemoEFWebApi.Controllers;

[EnableCors("LiberaGeral")]
[ApiController]
[Route("api/v1/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly ILogger<CatalogoController> _logger;
    private readonly IPedidoRepositorio _pedidosRepositorio;
    private readonly IClienteRepositorio _clientesRepositorio;
    private readonly IProdutoRepositorio _produtosRepositorio;

    public PedidosController(ILogger<CatalogoController> logger, IPedidoRepositorio pedidoRepositorio, IClienteRepositorio clienteRepositorio, IProdutoRepositorio produtoRepositorio)
    {
        _logger = logger;
        _pedidosRepositorio = pedidoRepositorio;
        _clientesRepositorio = clienteRepositorio;
        _produtosRepositorio = produtoRepositorio;
    }

    [HttpGet("{id}")] //GET api/v1/Pedidos/{id}
    public async Task<ActionResult<PedidoDTO>> GetPorId(int id)
    {
        var pedido = await _pedidosRepositorio.ConsultarPorIdAsync(id);
        if (pedido == null) return NotFound();
        else return PedidoDTO.DeEntidadeParaDTO(pedido);
    }

    [HttpPost] //POST api/v1/Pedidos
    public async Task<ActionResult<PedidoDTO>> PostNovoPedido(CarrinhoDTO carrinho)
    {
        var pedido = new Pedido();
        pedido.DataEmissao = DateTime.Now;
        var cliente = await _clientesRepositorio.ConsultarPorIdAsync(carrinho.IdCliente.GetValueOrDefault());
        if (cliente == null) return BadRequest();
        pedido.Cliente = cliente;
        if (carrinho.Itens.Count() == 0) return BadRequest();
        pedido.Itens = new List<Item>();
        foreach (var item in carrinho.Itens)
        {
            var produto = await _produtosRepositorio.ConsultarPorIdAsync(item.IdProduto.GetValueOrDefault());
            if (produto == null) return BadRequest();
            var itemPedido = new Item()
            {
                Quantidade = item.Quantidade.GetValueOrDefault(),
                Produto = produto
            };
            pedido.Itens.Add(itemPedido);
        }
        var novoPedido =  await _pedidosRepositorio.AdicionarAsync(pedido);
        return PedidoDTO.DeEntidadeParaDTO(novoPedido);
    }
}

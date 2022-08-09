using DemoEFWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEFWebApi.Services;

public class PedidoRepositorioEF : IPedidoRepositorio
{
    private readonly LojinhaContext _contexto;

    public PedidoRepositorioEF(LojinhaContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<Pedido?> ConsultarPorIdAsync(int id)
    {
        //eager loading
        var pedido = await _contexto.Pedidos
                                .Where(p => p.Id == id)
                                .Include(p => p.Cliente)
                                .Include(p => p.Itens)
                                .ThenInclude(i => i.Produto)
                                .FirstOrDefaultAsync();
        return pedido;
    }
}

using DemoEFWebApi.Models;

namespace DemoEFWebApi.Services;

public interface IPedidoRepositorio
{
    Task<Pedido?> ConsultarPorIdAsync(int id);
    Task<Pedido> AdicionarAsync(Pedido pedido);
}
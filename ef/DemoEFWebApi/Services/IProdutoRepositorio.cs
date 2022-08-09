using DemoEFWebApi.Models;

namespace DemoEFWebApi.Services;

public interface IProdutoRepositorio
{
    Task<IEnumerable<Produto>> ConsultarTodosAsync();
    Task<Produto?> ConsultarPorIdAsync(int id);
}
using DemoEFWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEFWebApi.Services;

public class ProdutoRepositorioEF : IProdutoRepositorio
{
    private readonly LojinhaContext _contexto;

    public ProdutoRepositorioEF(LojinhaContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<IEnumerable<Produto>> ConsultarTodosAsync()
    {
        return await _contexto.Produtos.OrderBy(p => p.Id).ToListAsync();
    }
}

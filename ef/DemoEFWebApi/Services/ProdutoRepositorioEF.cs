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

    public async Task<Produto?> ConsultarPorIdAsync(int id)
    {
        var produto = await _contexto.Produtos.Where(p => p.Id == id)
                                              .FirstOrDefaultAsync();
        return produto;
    }

    public async Task<IEnumerable<Produto>> ConsultarTodosAsync()
    {
        return await _contexto.Produtos.AsNoTracking()
                                       .OrderBy(p => p.Id)
                                       .ToListAsync();
    }
}

using DemoEFWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEFWebApi.Services;

public class ClienteRepositorioEF: IClienteRepositorio
{
    private readonly LojinhaContext _contexto;

    public ClienteRepositorioEF(LojinhaContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<Cliente?> ConsultarPorIdAsync(int id)
    {
        return await _contexto.Clientes.FindAsync(id);
    }
}

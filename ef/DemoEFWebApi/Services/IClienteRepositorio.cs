using DemoEFWebApi.Models;

namespace DemoEFWebApi.Services;

public interface IClienteRepositorio
{
    Task<Cliente?> ConsultarPorIdAsync(int id);
}
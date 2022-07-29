using DemoCatalogoCep.Models;
using System.Collections.Concurrent;
namespace DemoCatalogoCep.Services;

public class CepMemoriaService : ICepService
{
    private readonly ConcurrentDictionary<string,CepViewModel> dados =
        new ConcurrentDictionary<string, CepViewModel>();
    
    public void Cadastrar(CepViewModel cep)
    {
        dados.TryAdd(cep.Cep, cep);
    }

    public CepViewModel? ConsultaPorCep(string cep)
    {
        CepViewModel? resultado;
        dados.TryGetValue(cep, out resultado);
        return resultado;
    }

    public IEnumerable<CepViewModel> ConsultaTodos()
    {
        return dados.Values;
    }

    public CepMemoriaService()
    {
        dados.TryAdd("90619900", new CepViewModel{
            Logradouro = "Avenida Ipiranga, 6681",
            Bairro = "Partenon",
            Cidade = "Porto Alegre",
            Estado = "RS",
            Cep = "90619900"
        });
        dados.TryAdd("01001000", new CepViewModel{
            Logradouro = "Praça da Sé",
            Bairro = "Sé",
            Cidade = "São Paulo",
            Estado = "SP",
            Cep = "01001000"
        });
    }
}
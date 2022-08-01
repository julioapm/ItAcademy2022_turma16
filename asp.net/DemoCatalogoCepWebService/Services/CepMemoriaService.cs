using DemoCatalogoCepWebServices.Models;
using System.Collections.Concurrent;
namespace DemoCatalogoCepWebServices.Services;

public class CepMemoriaService : ICepService
{
    private readonly ConcurrentDictionary<string,CepModel> dados =
        new ConcurrentDictionary<string, CepModel>();
    
    public void Cadastrar(CepModel cep)
    {
        dados.TryAdd(cep.Cep, cep);
    }

    public CepModel? ConsultaPorCep(string cep)
    {
        CepModel? resultado;
        dados.TryGetValue(cep, out resultado);
        return resultado;
    }

    public IEnumerable<CepModel> ConsultaTodos()
    {
        return dados.Values;
    }

    public CepMemoriaService()
    {
        dados.TryAdd("90619900", new CepModel{
            Logradouro = "Avenida Ipiranga, 6681",
            Bairro = "Partenon",
            Cidade = "Porto Alegre",
            Estado = "RS",
            Cep = "90619900"
        });
        dados.TryAdd("01001000", new CepModel{
            Logradouro = "Praça da Sé",
            Bairro = "Sé",
            Cidade = "São Paulo",
            Estado = "SP",
            Cep = "01001000"
        });
    }
}
using DemoCatalogoCepWebServices.Models;
namespace DemoCatalogoCepWebServices.Services;

public interface ICepService
{
    IEnumerable<CepModel> ConsultaTodos();
    CepModel? ConsultaPorCep(string cep);
    void Cadastrar(CepModel cep);
}
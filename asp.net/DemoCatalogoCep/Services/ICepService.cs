using DemoCatalogoCep.Models;
namespace DemoCatalogoCep.Services;

public interface ICepService
{
    IEnumerable<CepViewModel> ConsultaTodos();
    CepViewModel? ConsultaPorCep(string cep);
    void Cadastrar(CepViewModel cep);
}
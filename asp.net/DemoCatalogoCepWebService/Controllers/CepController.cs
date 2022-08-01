using Microsoft.AspNetCore.Mvc;
using DemoCatalogoCepWebServices.Services;
using DemoCatalogoCepWebServices.Models;

namespace DemoCatalogoCepWebServices.Controllers;

[ApiController]
[Route("api/v1/cep")]
public class CepController : ControllerBase
{
    private readonly ICepService _cepService;
    public CepController(ICepService cepService)
    {
        _cepService = cepService;
    }

    [HttpGet] //GET .../api/v1/cep
    public IEnumerable<CepModel> GetAll()
    {
        return _cepService.ConsultaTodos()
                          .OrderBy(c => c.Cidade)
                          .ToArray();
    }

    [HttpGet("{codigocep:regex(^\\d{{8}}$)}")] //GET .../api/v1/cep/{codigocep}
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult<CepModel> Get(string codigocep)
    {
        var cep = _cepService.ConsultaPorCep(codigocep);
        if (cep == null)
        {
            return NotFound();
        }
        return cep;
    }

    [HttpPost] //POST .../api/v1/cep
    public ActionResult<CepModel> Post(CepModel novo)
    {
        //Retornar Created
    }
}

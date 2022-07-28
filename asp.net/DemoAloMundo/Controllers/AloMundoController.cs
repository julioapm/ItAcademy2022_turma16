using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.ComponentModel.DataAnnotations;

public class AloMundoController : Controller
{
    //GET .../AloMundo
    public string Index()
    {
        return "Alô Mundo!";
    }

    //GET .../AloMundo/Saudacao/{id}
    public string Saudacao(string id)
    {
        return $"Alô {id}";
    }

    //GET .../AloMundo/SaudacaoQueryString?nome={nome}&idade={idade}
    public string SaudacaoQueryString([StringLength(10)] string nome, int idade)
    {
        if (!ModelState.IsValid)
        {
            return "Ops";
        }
        return HtmlEncoder.Default.Encode($"Alô {nome}, você tem {idade} anos!");
    }

    //GET .../AloMundo/SaudacaoHTML
    public IActionResult SaudacaoHTML()
    {
        ViewData["Title"] = "Saudação em HTML";
        return View();
    }

    //GET .../AloMundo/SaudacaoHTMLComNome?nome={nome}
    public IActionResult SaudacaoHTMLComNome(string nome)
    {
        ViewData["Title"] = "Saudação em HTML";
        ViewBag.Nome = nome;
        return View();
    }
}
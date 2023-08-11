using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Adoption_Lab.Models;

namespace Adoption_Lab.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private AnimalsDbContext _animalsDbContext = new AnimalsDbContext();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        List<AdoptList> result = _animalsDbContext.AdoptLists.ToList();

        return View(result);
    }

    public IActionResult AdoptAnimal()
    {

        return View();
    }
    public IActionResult ListOfAnimals(string breed)
    {
        List<AdoptList> D = _animalsDbContext.AdoptLists.ToList();
        List<AdoptList> result = D.Where(n => n.Breed ==breed).ToList();

        return View();
    }
    public IActionResult NewAnimal()
    {

        return View();
    }
   

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


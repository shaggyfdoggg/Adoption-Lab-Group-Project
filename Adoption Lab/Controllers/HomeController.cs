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
        return View();
    }

    public IActionResult AdoptAnimal()
    {

        return View();
    }
    public IActionResult ListOfAnimals(string breed)
    {

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


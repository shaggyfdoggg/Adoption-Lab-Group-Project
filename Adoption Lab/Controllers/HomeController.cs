using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Adoption_Lab.Models;
using Microsoft.Extensions.Hosting;

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

    public IActionResult AdoptAnimal(AdoptList a)
    {
        //AdoptList p = _animalsDbContext.AdoptLists.FirstOrDefault(x => x.Name == a.Name);
        //_animalsDbContext.AdoptLists.Remove(p);
        //_animalsDbContext.SaveChanges();

        //if (a.Name == "Waffles")
        //{
        //    return RedirectToAction("Privacy");
        //}
        //else
        //{
            
        List<AdoptList> D = _animalsDbContext.AdoptLists.ToList();
        foreach (AdoptList f in D)
        {
            if (f.Name == a.Name)
            {
                _animalsDbContext.AdoptLists.Remove(f);
                _animalsDbContext.SaveChanges();
                
            }
        }

        return RedirectToAction("Index");
        //}
        
    }
    public IActionResult ListOfAnimals(int id)
    {
        List<AdoptList> result = new List<AdoptList>();
        List<AdoptList> D = _animalsDbContext.AdoptLists.ToList();
        AdoptList p = _animalsDbContext.AdoptLists.FirstOrDefault(a => a.Id == id);
        foreach (AdoptList a in D)
        {
            if(a.Breed == p.Breed)
            {
                result.Add(a);
            }
        }
        //List<AdoptList> result = D.Where(n => n.Breed == breed).ToList();

        return View(result);
    }
    public IActionResult NewAnimal()
    {

        return View();
    }

    public IActionResult NewAnimal1(AdoptList c)
    {
        _animalsDbContext.Add(c);
        _animalsDbContext.SaveChanges();
        return RedirectToAction("Index");
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


using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portafolio.Models;
using portafolio.Services;
namespace portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyectos repositorioProyectos;
    private readonly IServicioEmail servicioEmail;

    public HomeController(ILogger<HomeController> logger,
        IRepositorioProyectos repositorioProyectos,
        IServicioEmail servicioEmail){
        _logger = logger;
        this.repositorioProyectos = repositorioProyectos;
        this.servicioEmail = servicioEmail;
    }
    

    public IActionResult Index()
    {
        
        var proyectos = repositorioProyectos.obtenerProyectos().Take(2).ToList();
        var modelo = new HomeIndexViewModel(){
           Proyectos = proyectos
        };
        return View(modelo);
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Proyectos(){
        var proyectos = repositorioProyectos.obtenerProyectos().ToList();
        return View(proyectos);
    }
    public IActionResult Contacto(){
        return View();
    }

    [HttpPost]
    public async Task <IActionResult> Contacto(ContactoDTO contacto){
        await servicioEmail.Enviar(contacto);
        return RedirectToAction("Gracias");
    }
    public IActionResult Gracias(){
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

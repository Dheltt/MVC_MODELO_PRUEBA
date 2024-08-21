using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Prueba.Models;
using MVC_Prueba.Models.Data;
using System.Diagnostics;

namespace MVC_Prueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult _Garaje()
        {
            return View("_Garaje", new Garaje());

        }
        public ActionResult _GarajeSimple()
        {
            return View("_GarajeSimple", new Garaje());
        }

        public IActionResult Usuarios()
        {
            var downData = getDataFromDB();
            return PartialView(downData);
        }
        [HttpPost]
        public IActionResult Usuarios(string nombre,string correo,int edad,string tel,string clave){
            var userData = new UserViewModel{
                UserName = nombre,
                Email = correo,
                Password =clave,
                Phonenumber = tel,
                Age = edad
            };
            return View(userData);
        }

        public UserViewModel getDataFromDB()
        {
            var userData = new UserViewModel
            {
                UserName = "John Marston",
                Email = "JohnM@gmail.com",
                Password = "ñañañaña",
                Phonenumber="7551066157",
                Age = 30
            };
            return userData;
        }

        public IActionResult Index()
        {
            //le mandamos la informacion a la vista
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
}

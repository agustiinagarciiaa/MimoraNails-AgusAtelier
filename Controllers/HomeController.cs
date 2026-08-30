using Microsoft.AspNetCore.Mvc;
using sistemaUñas_MimoraNails.Models;
using System.Diagnostics;

namespace sistemaUñas_MimoraNails.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var usuario = HttpContext.Session.GetString("Usuario");
            var rol = HttpContext.Session.GetString("Rol");

            ViewBag.Usuario = usuario;
            ViewBag.Rol = rol;

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

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using sistemaUñas_MimoraNails.Models;

namespace sistemaUñas_MimoraNails.Controllers
{
    public class LoginController : Controller
    {
        private readonly MimoraNailsAgusAtelierContext _context;

        public LoginController(MimoraNailsAgusAtelierContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Usuario usuario)
        {
            var usuarioEncontrado = await _context.Usuarios
                .FirstOrDefaultAsync(u =>
                    u.NombreUsuario == usuario.NombreUsuario &&
                    u.Contrasena == usuario.Contrasena);

            if (usuarioEncontrado != null)
            {
                HttpContext.Session.SetString("Usuario", usuarioEncontrado.NombreUsuario);
                HttpContext.Session.SetString("Rol", usuarioEncontrado.Rol);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos.";

            return View(usuario);
        }

    }
}
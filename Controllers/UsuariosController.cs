using Microsoft.AspNetCore.Mvc;
using sistemaUñas_MimoraNails.Models;

namespace sistemaUñas_MimoraNails.Controllers
{

    public class UsuariosController : Controller
    {
        private readonly MimoraNailsAgusAtelierContext _context;

        public UsuariosController(MimoraNailsAgusAtelierContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Login");
            }

            return View(usuario);
        }
    }
}
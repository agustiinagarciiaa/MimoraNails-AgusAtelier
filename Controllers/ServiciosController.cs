using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaUñas_MimoraNails.Models;
using sistemaUñas_MimoraNails.Filters;


namespace sistemaUñas_MimoraNails.Controllers
{
    [Sesion]
    public class ServiciosController : Controller
    {
        private readonly MimoraNailsAgusAtelierContext _context;

        public ServiciosController(MimoraNailsAgusAtelierContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var servicios = await _context.Servicios.ToListAsync();

            return View(servicios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicio);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(servicio);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios.FindAsync(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Servicio servicio)
        {
            if (id != servicio.IdServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(servicio);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(servicio);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .FirstOrDefaultAsync(s => s.IdServicio == id);

            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .FirstOrDefaultAsync(s => s.IdServicio == id);

            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);

            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
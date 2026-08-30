using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaUñas_MimoraNails.Models;
using sistemaUñas_MimoraNails.Filters;

namespace sistemaUñas_MimoraNails.Controllers
{
    [Sesion]
    public class TurnosController : Controller
    {
        private readonly MimoraNailsAgusAtelierContext _context;

        public TurnosController(MimoraNailsAgusAtelierContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var turnos = await _context.Turnos
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdServicioNavigation)
                .ToListAsync();

            return View(turnos);
        }

        public IActionResult Create()
        {
            ViewBag.Clientes = _context.Clientes.ToList();
            ViewBag.Servicios = _context.Servicios.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Turno turno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turno);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = _context.Clientes.ToList();
            ViewBag.Servicios = _context.Servicios.ToList();

            return View(turno);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos.FindAsync(id);

            if (turno == null)
            {
                return NotFound();
            }

            ViewBag.Clientes = _context.Clientes.ToList();
            ViewBag.Servicios = _context.Servicios.ToList();

            return View(turno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Turno turno)
        {
            if (id != turno.IdTurno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(turno);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = _context.Clientes.ToList();
            ViewBag.Servicios = _context.Servicios.ToList();

            return View(turno);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdServicioNavigation)
                .FirstOrDefaultAsync(t => t.IdTurno == id);

            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdServicioNavigation)
                .FirstOrDefaultAsync(t => t.IdTurno == id);

            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);

            if (turno != null)
            {
                _context.Turnos.Remove(turno);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
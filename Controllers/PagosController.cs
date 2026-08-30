using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaUñas_MimoraNails.Models;
using sistemaUñas_MimoraNails.Filters;

namespace sistemaUñas_MimoraNails.Controllers
{
    [Sesion]
    public class PagosController : Controller
    {
        private readonly MimoraNailsAgusAtelierContext _context;

        public PagosController(MimoraNailsAgusAtelierContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pagos = await _context.Pagos
                .Include(p => p.IdTurnoNavigation)
                    .ThenInclude(t => t.IdClienteNavigation)
                .Include(p => p.IdTurnoNavigation)
                    .ThenInclude(t => t.IdServicioNavigation)
                .ToListAsync();

            return View(pagos);
        }

        public IActionResult Create()
        {
            var turnos = _context.Turnos
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdServicioNavigation)
                .ToList();

            ViewBag.Turnos = turnos;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pago pago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var turnos = _context.Turnos
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdServicioNavigation)
                .ToList();

            ViewBag.Turnos = turnos;

            return View(pago);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos.FindAsync(id);

            if (pago == null)
            {
                return NotFound();
            }

            var turnos = _context.Turnos
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdServicioNavigation)
                .ToList();

            ViewBag.Turnos = turnos;

            return View(pago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pago pago)
        {
            if (id != pago.IdPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(pago);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var turnos = _context.Turnos
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdServicioNavigation)
                .ToList();

            ViewBag.Turnos = turnos;

            return View(pago);
        }
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.IdTurnoNavigation)
                    .ThenInclude(t => t.IdClienteNavigation)
                .Include(p => p.IdTurnoNavigation)
                    .ThenInclude(t => t.IdServicioNavigation)
                .FirstOrDefaultAsync(p => p.IdPago == id);

            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }
  
    public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.IdTurnoNavigation)
                    .ThenInclude(t => t.IdClienteNavigation)
                .Include(p => p.IdTurnoNavigation)
                    .ThenInclude(t => t.IdServicioNavigation)
                .FirstOrDefaultAsync(p => p.IdPago == id);

            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);

            if (pago != null)
            {
                _context.Pagos.Remove(pago);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
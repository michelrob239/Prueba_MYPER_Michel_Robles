using Microsoft.AspNetCore.Mvc;
using MantenimientoTrabajadores.Data;
using Microsoft.EntityFrameworkCore;
using MantenimientoTrabajadores.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace MantenimientoTrabajadores.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly AppDbContext _context;

        public TrabajadoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Index con filtro por sexo
        [HttpGet]
        public async Task<IActionResult> Index(string sexo)
        {
            // Trae todos los trabajadores desde el procedimiento almacenado
            var trabajadores = await _context.Trabajadores
                .FromSqlRaw("EXEC sp_ListarTrabajadores")
                .ToListAsync();

            // Si se selecciona un sexo, filtra los resultados
            if (!string.IsNullOrEmpty(sexo))
            {
                trabajadores = trabajadores
                    .Where(t => t.Sexo == sexo)
                    .ToList();
            }

            // Enviar el valor del filtro actual a la vista
            ViewBag.SexoSeleccionado = sexo;

            return View(trabajadores);
        }

        // POST: Crear nuevo trabajador
        [HttpPost]
        public async Task<IActionResult> Create(Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                _context.Trabajadores.Add(trabajador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trabajador);
        }

        // POST: Editar trabajador
        [HttpPost]
        public async Task<IActionResult> Edit(Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                _context.Update(trabajador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trabajador);
        }

        // POST: Eliminar trabajador
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var trabajador = await _context.Trabajadores.FindAsync(id);
            if (trabajador != null)
            {
                _context.Trabajadores.Remove(trabajador);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

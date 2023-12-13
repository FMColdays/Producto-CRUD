﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Producto_CRUD.Models;

namespace Producto_CRUD.Controllers
{
    public class TiposProductosController : Controller
    {
        private readonly CrudpContext _context;

        public TiposProductosController(CrudpContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.TiposProductos != null ? 
                          View(await _context.TiposProductos.ToListAsync()) :
                          Problem("Entity set 'CrudpContext.TiposProductos'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposProductos == null)
            {
                return NotFound();
            }

            var tiposProducto = await _context.TiposProductos
                .FirstOrDefaultAsync(m => m.IdTipo == id);
            if (tiposProducto == null)
            {
                return NotFound();
            }

            return View(tiposProducto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipo,NombreTipo")] TiposProducto tiposProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposProducto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposProductos == null)
            {
                return NotFound();
            }

            var tiposProducto = await _context.TiposProductos.FindAsync(id);
            if (tiposProducto == null)
            {
                return NotFound();
            }
            return View(tiposProducto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipo,NombreTipo")] TiposProducto tiposProducto)
        {
            if (id != tiposProducto.IdTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposProductoExists(tiposProducto.IdTipo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tiposProducto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposProductos == null)
            {
                return NotFound();
            }

            var tiposProducto = await _context.TiposProductos
                .FirstOrDefaultAsync(m => m.IdTipo == id);
            if (tiposProducto == null)
            {
                return NotFound();
            }

            return View(tiposProducto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposProductos == null)
            {
                return Problem("Entity set 'CrudpContext.TiposProductos'  is null.");
            }
            var tiposProducto = await _context.TiposProductos.FindAsync(id);
            if (tiposProducto != null)
            {
                _context.TiposProductos.Remove(tiposProducto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposProductoExists(int id)
        {
          return (_context.TiposProductos?.Any(e => e.IdTipo == id)).GetValueOrDefault();
        }
    }
}

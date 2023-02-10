using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using PucsMVC.Data;
using PucsMVC.Models.EF;

namespace PucsMVC.Controllers
{
    public class ApoliceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApoliceController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: Apolice
        // A simple View is returned
        // The Grid will asyc call the Apolice_Read action on page load
        public IActionResult Index() => View();
        public async Task<IActionResult> Apolices_Read([DataSourceRequest]DataSourceRequest request)
        {
            var applicationDbContext = _context.Apolices.Include(a => a.Cliente).Include(a => a.Modelo);
            return Json(await applicationDbContext.ToDataSourceResultAsync(request));
        }

        // GET: Apolice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apolice = await _context.Apolices
                .Include(a => a.Cliente)
                .Include(a => a.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apolice == null)
            {
                return NotFound();
            }

            return View(apolice);
        }

        // GET: Apolice/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "RazaoSocial");
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "NomeModelo");
            return View();
        }

        // POST: Apolice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasseBonus,IdentificacaoApolice,DataInicioVigencia,DataFimVigencia,ClienteId,ModeloId,Id")] Apolice apolice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apolice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", apolice.ClienteId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Id", apolice.ModeloId);
            return View(apolice);
        }

        // GET: Apolice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apolice = await _context.Apolices.FindAsync(id);
            if (apolice == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", apolice.ClienteId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Id", apolice.ModeloId);
            return View(apolice);
        }

        // POST: Apolice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasseBonus,IdentificacaoApolice,DataInicioVigencia,DataFimVigencia,ClienteId,ModeloId,Id")] Apolice apolice)
        {
            if (id != apolice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apolice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApoliceExists(apolice.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", apolice.ClienteId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Id", apolice.ModeloId);
            return View(apolice);
        }

        // GET: Apolice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apolice = await _context.Apolices
                .Include(a => a.Cliente)
                .Include(a => a.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apolice == null)
            {
                return NotFound();
            }

            return View(apolice);
        }

        // POST: Apolice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apolice = await _context.Apolices.FindAsync(id);
            _context.Apolices.Remove(apolice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApoliceExists(int id)
        {
            return _context.Apolices.Any(e => e.Id == id);
        }
    }
}

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
using PucsMVC.Interfaces.Repositories;
using PucsMVC.Interfaces.Services;

namespace PucsMVC.Controllers
{
    public class MarcasController : Controller
    {

        private readonly IServiceBase<Marca> _service;

        public MarcasController(IServiceBase<Marca> service)
        {
            _service = service;
        }

        // GET: Marcas
        // A simple View is returned
        // The Grid will asyc call the Marcas_Read action on page load
        public IActionResult Index() => View();
        public async Task<IActionResult> Marcas_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(await _service.GetAll().ToDataSourceResultAsync(request));
        }

        // GET: Marcas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _service.Get(c => c.Id == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // GET: Marcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("NomeMarca,Id")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                _service.Add(marca);

                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: Marcas/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _service.GetById(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("NomeMarca,Id")] Marca marca)
        {
            if (id != marca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(marca);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaExists(marca.Id))
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
            return View(marca);
        }

        // GET: Marcas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _service.Get(c => c.Id == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var marca = _service.Get(c => c.Id == id);
            _service.Remove(marca);
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaExists(int id)
        {
            return _service.Any(c => c.Id == id);
        }
    }
}

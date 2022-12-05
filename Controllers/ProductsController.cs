using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.Wrapper;

namespace StartupProject_Asp.NetCore_PostGRE.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public ProductsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

		// GET: Products
		public IActionResult Index()
		{
			//List<Product> allProducts = await _repository.Product.FindAll().ToListAsync();
			return View();
		}

		// GET: Products/Details/5
		public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _repository.Product.FindAll()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

		// POST: Products/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateAsync([Bind("Name,UnitPrice,Id,CreateTime,LastUpdateTime,DeletionTime")] Product product)
		{
			if (ModelState.IsValid)
			{
				_repository.Product.Create(product);
				await _repository.SaveAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(product);
		}

		// GET: Products/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var product = await _repository.Product.FindAll().FindAsync(id);
            Product product = await _repository.Product.FindByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Name,UnitPrice,Id,CreateTime,LastUpdateTime,DeletionTime")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Product.Update(product);
                    await _repository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductExistsAsync(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _repository.Product
                .FindByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var product = await _repository.Product.FindByIdAsync(id);
            _repository.Product.Delete(product);
            await _repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductExistsAsync(Guid? id)
        {
            //return _context.Product.Any(e => e.Id == id);
            return await _repository.Product.IfExistsAsync(id);
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.Wrapper;

namespace StartupProject_Asp.NetCore_PostGRE.Controllers
{
	public class OrdersController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public OrdersController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            IQueryable<Order> applicationDbContext = _repository.Order.IncludeCustomer();//.IncludeProducts()
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order order = await _repository.Order.IncludeCustomer()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            //ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderType,Id,CreateTime,LastUpdateTime,DeletionTime")] Order order)
        {
            if (ModelState.IsValid)
            {
                _repository.Order.Create(order);
                await _repository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order order = await _repository.Order.FindByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            //ViewData["CustomerId"] = new SelectList(_repository.Users, "Id", "Id", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("OrderType,Id,CreateTime,LastUpdateTime,DeletionTime")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Order.Update(order);
                    await _repository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await OrderExistsAsync(order.Id))
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
            //ViewData["CustomerId"] = new SelectList(_repository.Users, "Id", "Id", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order order = await _repository.Order.IncludeCustomer()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var order = await _repository.Order.FindByIdAsync(id);
            _repository.Order.Delete(order);
            await _repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> OrderExistsAsync(Guid? id)
        {
            return await _repository.Order.IfExistsAsync(id);
        }
    }
}

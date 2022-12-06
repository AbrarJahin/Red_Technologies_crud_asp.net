using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.Wrapper;

namespace StartupProject_Asp.NetCore_PostGRE.Controllers
{
    [Authorize]
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

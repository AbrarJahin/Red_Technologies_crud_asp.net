using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.Wrapper;

namespace StartupProject_Asp.NetCore_PostGRE.Controllers
{
	public class UserOrderController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public UserOrderController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

		// GET: UserOrder
		public IActionResult Index()
		{
			//var applicationDbContext = _repository.Orders.Include(o => o.Customer);
			//return View(await applicationDbContext.ToListAsync());
			return View();
		}

		// GET: UserOrder/Details/5
		public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _repository.Order.IncludeCustomer()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}

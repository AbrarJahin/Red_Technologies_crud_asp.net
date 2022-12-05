using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.RepositoryInterfaces;
using System;
using System.Linq;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Repository.DbRepository
{
	public class OrderRepository : RepositoryBase<Order>, IOrderRepository
	{
		private readonly ApplicationDbContext _repoContext;

		public OrderRepository(ApplicationDbContext repositoryContext)
			: base(repositoryContext)
		{
			_repoContext = repositoryContext;
		}

		public IQueryable<Order> IncludeCustomer()
		{
			return _repoContext.Orders
				.Include(o => o.Customer);
		}

		public IQueryable<Order> IncludeProduct()
		{
			return _repoContext.Orders
				.Include(o => o.OrderProducts)
					.ThenInclude(op=> op.Product);
		}

		public IQueryable<Order> IncludeCustomerAndProduct()
		{
			return _repoContext.Orders
				.Include(o => o.Customer)
				.Include(o => o.OrderProducts)
					.ThenInclude(op => op.Product);
		}
	}
}

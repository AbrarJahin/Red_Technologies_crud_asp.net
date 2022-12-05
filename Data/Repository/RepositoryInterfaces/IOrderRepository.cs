using StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData;
using System;
using System.Linq;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Repository.RepositoryInterfaces
{
	public interface IOrderRepository : IRepositoryBase<Order>
	{
		IQueryable<Order> IncludeCustomerAndProduct();
		IQueryable<Order> IncludeCustomer();
		IQueryable<Order> IncludeProduct();
	}
}

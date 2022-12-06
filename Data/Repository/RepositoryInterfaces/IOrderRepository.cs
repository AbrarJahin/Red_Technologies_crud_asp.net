using Microsoft.AspNetCore.Identity;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Repository.RepositoryInterfaces
{
	public interface IOrderRepository : IRepositoryBase<Order>
	{
		IQueryable<Order> IncludeCustomerAndProduct();
		IQueryable<Order> IncludeCustomer();
		IQueryable<Order> IncludeProduct();
		Task PlaceOrder(List<Guid?> id, List<int> count, User loggedInUser);
	}
}

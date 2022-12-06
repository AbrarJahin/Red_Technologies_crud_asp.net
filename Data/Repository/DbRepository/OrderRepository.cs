using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Repository.DbRepository
{
	public class OrderRepository : RepositoryBase<Order>, IOrderRepository
	{
		private readonly ApplicationDbContext _repoContext;

		public OrderRepository(ApplicationDbContext repositoryContext)
			: base(repositoryContext)
		{
			_repoContext = repositoryContext;
			//_repoContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
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

		public async Task PlaceOrder(List<Guid?> id, List<int> count, User loggedInUser)
		{
			float total = 0;
			Order order = new Order();
			order.OrderType = Data.Enums.EOrderType.Standard;
			order.Customer = loggedInUser;
			await _repoContext.SaveChangesAsync();
			order.OrderProducts = new List<OrderProduct>();
			for (int i = 0; i < id.Count; i++)
			{
				Product product = await _repoContext.Product.FindAsync(id[0]);
				if (product.OrderProducts == null) {
					product.OrderProducts = new List<OrderProduct>();
				}
				if(count[i]<=product.AvailableUnit)	//If unit is available, then add to order, else dont add
				{
					OrderProduct orderProduct = new OrderProduct();
					orderProduct.Product = product;
					orderProduct.Order = order;
					orderProduct.UnitBought = count[i];

					_repoContext.OrderProducts.Add(orderProduct);

					total += product.UnitPrice * count[i];
					product.AvailableUnit -= count[i];
					product.OrderProducts.Add(orderProduct);

					//order.OrderProducts.Add(orderProduct);

					_repoContext.Product.Update(product);
					//_repoContext.OrderProducts.Add(orderProduct);

					//_repoContext.Attach(order);
					//_repoContext.Entry(order).State = EntityState.Modified;

					//_repoContext.Attach(product);
					//_repoContext.Entry(product).State = EntityState.Modified;
				}
				//await _repoContext.SaveChangesAsync();
			}
			order.OrderTotal = total;
			_repoContext.Orders.Add(order);
		}
	}
}

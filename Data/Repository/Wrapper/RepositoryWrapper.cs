using StartupProject_Asp.NetCore_PostGRE.Data.Repository.DbRepository;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.RepositoryInterfaces;
using System.Threading.Tasks;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Repository.Wrapper
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private readonly ApplicationDbContext _repoContext;
		private IOrderRepository _order;
		private IProductRepository _product;
		private IOrderProductRepository _orderProduct;

		public RepositoryWrapper(ApplicationDbContext repositoryContext)
		{
			_repoContext = repositoryContext;
		}

		public IOrderRepository Order
		{
			get
			{
				if (_order == null)
				{
					_order = new OrderRepository(_repoContext);
				}
				return _order;
			}
		}

		public IProductRepository Product
		{
			get
			{
				if (_product== null)
				{
					_product = new ProductRepository(_repoContext);
				}
				return _product;
			}
		}

		public IOrderProductRepository OrderProduct
		{
			get
			{
				if (_orderProduct == null)
				{
					_orderProduct = new OrderProductRepository(_repoContext);
				}
				return _orderProduct;
			}
		}

		public async Task SaveAsync()
		{
			await _repoContext.SaveChangesAsync();
		}
	}
}

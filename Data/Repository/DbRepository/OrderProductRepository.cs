using StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.RepositoryInterfaces;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Repository.DbRepository
{
	public class OrderProductRepository : RepositoryBase<OrderProduct>, IOrderProductRepository
	{
		public OrderProductRepository(ApplicationDbContext repositoryContext)
			: base(repositoryContext)
		{
		}
	}
}

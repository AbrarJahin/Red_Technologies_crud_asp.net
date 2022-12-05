using StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.RepositoryInterfaces;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Repository.DbRepository
{
	public class OrderRepository : RepositoryBase<Order>, IOrderRepository
	{
		public OrderRepository(ApplicationDbContext repositoryContext)
			: base(repositoryContext)
		{
		}
	}
}

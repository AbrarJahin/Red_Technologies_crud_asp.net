using StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.RepositoryInterfaces;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Repository.DbRepository
{
	public class ProductRepository : RepositoryBase<Product>, IProductRepository
	{
		public ProductRepository(ApplicationDbContext repositoryContext)
			: base(repositoryContext)
		{
		}
	}
}

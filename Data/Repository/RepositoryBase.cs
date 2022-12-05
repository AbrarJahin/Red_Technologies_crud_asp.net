using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Repository
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _repositoryContext { get; set; }
        public RepositoryBase(ApplicationDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll() => _repositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _repositoryContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);

		public IQueryable<T> FindInRange(int firstPageIndex, int itemPerPage)
		{
			throw new NotImplementedException();
		}
	}
}

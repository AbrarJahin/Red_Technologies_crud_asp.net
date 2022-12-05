using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Repository
{
	public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindInRange(int firstPageIndex = 0, int itemPerPage = 10);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> FindByIdAsync(Guid? id);
        Task<bool> IfExistsAsync(Guid? id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

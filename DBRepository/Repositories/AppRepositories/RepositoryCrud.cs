using DBRepository.Interfaces;
using DBRepository.Repositories.DbRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DBRepository.Repositories.AppRepositories
{
    public class RepositoryCrud<T> : IRepositoryCrud<T> where T : class
    {
        protected RepositoryDbContext RepositoryContext { get; set; }
        public RepositoryCrud(RepositoryDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        //public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        //public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        //    RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        //public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        //public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        //public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}


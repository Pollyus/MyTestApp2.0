//Воспользуемся популярным паттерном «Репозиторий» и создадим классы-посредники, которые будут «отгораживать» наши конечные классы-потребители от работы с базой и EntityFramework в частности.
using DBRepository;
using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;

public abstract class BaseRepository//<T> : IReposiporuBase<T> where T : class
{
    protected string ConnectionString { get; }
    protected IRepositoryContextFactory ContextFactory { get; }
    public BaseRepository(string connectionString, IRepositoryContextFactory contextFactory)
    {
        ConnectionString = connectionString;
        ContextFactory = contextFactory;
    }

    //public IQueryable<T> FindAll() => ContextFactory.Set<T>().AsNoTracking();
    //public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
    //    RepositoryContext.Set<T>().Where(expression).AsNoTracking();
    //public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
    //public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
    //public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
}

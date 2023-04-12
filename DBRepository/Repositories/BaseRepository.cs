//Воспользуемся популярным паттерном «Репозиторий» и создадим классы-посредники, которые будут «отгораживать» наши конечные классы-потребители от работы с базой и EntityFramework в частности.
using DBRepository.Interfaces;

public abstract class BaseRepository
{
    protected string ConnectionString { get; }
    protected IRepositoryContextFactory ContextFactory { get; }
    public BaseRepository(string connectionString, IRepositoryContextFactory contextFactory)
    {
        ConnectionString = connectionString;
        ContextFactory = contextFactory;
    }
}
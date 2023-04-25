//using Models;


//namespace DBRepository.Interfaces
//{
//    public interface IIdentityRepository<T> where T : BaseEntity
//    {
//        List<T> GetAll();
//        T GetById(long id);
//        Task<long> Add(T entity);
//    }
//}
using Models;


namespace DBRepository.Interfaces
{
    public interface IIdentityRepository
    {
        Task<User> GetUser(string userName);
    }
}

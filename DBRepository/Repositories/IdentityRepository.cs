using DBRepository.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DBRepository.Repositories
//{
//    public class IdentityRepository<T> : IIdentityRepository<T> where T: BaseEntity 
//    {

//private readonly RepositoryDbContext _context;

//public IdentityRepository(RepositoryDbContext context)
//{
//    _context = context;
//}

//public List<T> GetAll()
//{
//    return _context.Set<T>().ToList();
//}

//public T GetById(long id)
//{
//    var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);

//    if (result == null)
//    {
//        //todo: need to add logger
//        return null;
//    }

//    return result;
//}

//public async Task<long> Add(T entity)
//{
//    var result = await _context.Set<T>().AddAsync(entity);
//    await _context.SaveChangesAsync();
//    return result.Entity.Id;
//}
//    }
//}
using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repositories
{
    public class IdentityRepository : BaseRepository, IIdentityRepository
    {
        public IdentityRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

        public async Task<User> GetUser(string userName)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Login == userName);
            }
        }
        public async Task<User> GetById(int id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            }
        }
    }
}
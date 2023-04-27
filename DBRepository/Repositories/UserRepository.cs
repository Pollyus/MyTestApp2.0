using DBRepository.Interfaces;
using DBRepository.ViewModels;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
        { }

        public async Task<User> GetUser(int UserId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Users.Include(t => t.UserName).Include(t => t.Email).FirstOrDefaultAsync(p => p.Id == UserId);
            }
        }
    }
}

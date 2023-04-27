using DBRepository.Interfaces;
using DBRepository.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;

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
                User result = null;
                await foreach (User user in context.Users)
                {

                    if (user.Id == UserId) result = user;
                    
                }
                return result;
                //return await context.Users.Where(u => u.Id == UserId).Single();
            }
        }
        public List<UserViewModel> GetAllUsers()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                List<UserViewModel> data = new List<UserViewModel>();
                foreach (User user in context.Users)
                {
                    UserViewModel viewModel = new UserViewModel();
                    viewModel.Id = user.Id;
                    data.Add(viewModel);
                }
                return data;
            }
        }

        public async Task AddUser(User user)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {

                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int userId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var user = new User() { Id = userId };
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }
    }
}

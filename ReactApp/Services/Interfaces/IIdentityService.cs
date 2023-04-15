using Models;

namespace ReactApp.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<User> GetUser(string userName);
    }
}

using Models;
using ReactApp.ViewModels;

namespace ReactApp.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<User> GetById(int userId);

        //AuthenticateResponse Authenticate(IdentityViewModel model);
        //Task<AuthenticateResponse> Register(UserViewModel userModel);
        //IEnumerable<User> GetAll();
        //User GetById(int id);
        Task<User> GetUser(string name);
    }
}

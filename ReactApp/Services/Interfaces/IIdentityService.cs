using Models;
using ReactApp.ViewModels;

namespace ReactApp.Services.Interfaces
{
    public interface IIdentityService
    {
        AuthenticateResponse Authenticate(IdentityViewModel model);
        Task<AuthenticateResponse> Register(UserViewModel userModel);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}

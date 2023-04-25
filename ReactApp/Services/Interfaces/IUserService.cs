using Models;
using ReactApp.ViewModels;

namespace ReactApp.Services.Interfaces
{
    public class IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Task<AuthenticateResponse> Register(UserModel userModel);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}

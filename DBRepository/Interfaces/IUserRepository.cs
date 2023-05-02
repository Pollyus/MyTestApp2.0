using BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace DBRepository.Interfaces
{
    public interface IUserRepository// : IRepositoryCrud<User>
    {
        Task<User> GetUser(int id);
        List<UserViewModel> GetAllUsers();
        Task AddUser(User user);
        Task DeleteUser(int userId);
    }
}

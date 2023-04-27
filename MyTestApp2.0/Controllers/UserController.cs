using DBRepository.Interfaces;
using DBRepository.Repositories;
using DBRepository.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MyTestApp2.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    public class UserController : Controller
    {
        IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        [Route("user")]
        [HttpGet("get")]
        public async Task<User> GetUser(int userId)
        {
            return await _userRepository.GetUser(userId);
        }


        [Route("user")]
        [HttpGet("get/all")]
        public List<UserViewModel> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }


        [Route("user")]
        [HttpPost("add")]
        public async Task AddUser(User user)
        {
            await _userRepository.AddUser(user);
        }


        [Route("user")]
        [HttpDelete("delete")]
        public async Task DeletePost(int userId)
        {
            await _userRepository.DeleteUser(userId);
        }

    }
}

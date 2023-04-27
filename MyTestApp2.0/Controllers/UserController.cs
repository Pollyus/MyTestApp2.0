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
        public async Task<UserViewModel> GetTest(int UserId)
        {
            return await _userRepository.GetUser(UserId);
            
        }
    }
}

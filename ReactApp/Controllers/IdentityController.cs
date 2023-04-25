//using Microsoft.AspNetCore.Mvc;
//using ReactApp.ViewModels;
//using ReactApp.Services.Interfaces;

//namespace ReactApp.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class IdentityController : ControllerBase
//    {
//        private readonly IIdentityService _userService;

//        public IdentityController(IIdentityService userService)
//        {
//            _userService = userService;
//        }

//        [HttpPost("authenticate")]
//        public IActionResult Authenticate(IdentityViewModel model)
//        {
//            var response = _userService.Authenticate(model);

//            if (response == null)
//                return BadRequest(new { message = "Username or password is incorrect" });

//            return Ok(response);
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> Register(UserViewModel userModel)
//        {
//            var response = await _userService.Register(userModel);

//            if (response == null)
//            {
//                return BadRequest(new { message = "Didn't register!" });
//            }

//            return Ok(response);
//        }

//        [Helpers.Authorize]
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var users = _userService.GetAll();
//            return Ok(users);
//        }

//    }
//}

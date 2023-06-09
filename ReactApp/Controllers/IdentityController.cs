﻿//using Microsoft.AspNetCore.Mvc;
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static ReactApp.Program;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ReactApp.ViewModels;
using ReactApp.Services.Interfaces;
using System.Security.Cryptography;
using ReactApp.Helpers;
using DBRepository.Interfaces;

namespace ReactApp.Controllers
{
    [Route("api/[controller]")]
    public class IdentityController : Controller
    {
        IIdentityService _service;
        private readonly ILogger<WeatherForecastController> _logger;
        IIdentityRepository _repository;

        public IdentityController(IIdentityService service, ILogger<WeatherForecastController> logger, IIdentityRepository repository)
        {
            _service = service;
            _logger = logger;
            _repository = repository;
        }

        [Route("token")]
        [HttpPost]
        public async Task<IActionResult> Token([FromBody] IdentityViewModel model)
        {
            var identity = await GetIdentity(model.Username, model.Password);
            if (identity == null)
            {
                return Unauthorized();
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Ok(response);
        }

        private async Task<ClaimsIdentity> GetIdentity(string userName, string password)
        {
            ClaimsIdentity identity = null;
            var user = await _service.GetUser(userName);
            if (user != null)
            {
                var sha256 = new SHA256Managed();
                var passwordHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
                if (passwordHash == user.Password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    };
                    identity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                }
            }
            return identity;
        }
    }
}
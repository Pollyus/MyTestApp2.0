using AutoMapper;
using DBRepository.Interfaces;
using Microsoft.Extensions.Configuration;
using Models;
using ReactApp.Helpers;
using ReactApp.Services.Interfaces;
using ReactApp.ViewModels;

namespace ReactApp.Services.Implementation
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        //private readonly IJwtManager _jwtManager;

        public IdentityService(IIdentityRepository<User> repository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = repository;
            _configuration = configuration;
            _mapper = mapper;

        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
        public AuthenticateResponse Authenticate(IdentityViewModel model)
        {
            var user = _userRepository
                .GetAll()
                .FirstOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            if (user == null)
            {
                // todo: need to add logger
                return null;
            }

            var token = _configuration.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }
        public async Task<AuthenticateResponse> Register(UserViewModel userModel)
        {
            var user = _mapper.Map<User>(userModel);

            var addedUser = await _userRepository.Add(user);

            var response = Authenticate(new IdentityViewModel
            {
                Username = user.UserName,
                Password = user.Password
            });

            return response;
        }
    }
}

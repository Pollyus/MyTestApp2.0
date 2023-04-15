using DBRepository.Interfaces;
using Models;
using ReactApp.Services.Interfaces;

namespace ReactApp.Services.Implementation
{
    public class IdentityService : IIdentityService
    {
        IIdentityRepository _repository;

        public IdentityService(IIdentityRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> GetUser(string userName)
        {
            return await _repository.GetUser(userName);
        }
    }
}

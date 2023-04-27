using DBRepository.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);
    }
}

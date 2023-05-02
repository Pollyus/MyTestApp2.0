using BLL.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Interfaces
{
    public interface ITestGroupRepository
    {
        Task<TestsGroup> GetGroup(int groupId);
        List<GroupViewModel> GetAllGroups();
        Task AddGroup(TestsGroup group);
        Task DeleteGroup(int groupId);
    }
}

using BLL.ViewModels;
using DBRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MyTestsGroupApp2.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    public class TestsGroupController : Controller
    {
        ITestGroupRepository _groupRepository;
        public TestsGroupController(ITestGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [Route("group")]
        [HttpGet("get")]
        public async Task<TestsGroup> GetTestsGroup(int groupId)
        {
            return await _groupRepository.GetGroup(groupId);
        }


        [Route("group")]
        [HttpGet("get/all")]
        public List<GroupViewModel> GetAllTestsGroups()
        {
            return _groupRepository.GetAllGroups();
        }


        [Route("group")]
        [HttpPost("add")]
        public async Task AddTestsGroup(TestsGroup group)
        {
            await _groupRepository.AddGroup(group);
        }


        [Route("group")]
        [HttpDelete("delete")]
        public async Task DeletePost(int groupId)
        {
            await _groupRepository.DeleteGroup(groupId);
        }


    }
}

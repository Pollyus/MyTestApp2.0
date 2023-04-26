using DBRepository.Interfaces;
using DBRepository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Models;
using MyTestApp2._0.ViewModels;

namespace MyTestApp2.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    public class TestController : Controller
    {
        ITestRepository _testRepository;
        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }
        
        [Route("test")]
        [HttpGet("get")]
        public async Task<Test> GetTest(int testId)
        {
            return await _testRepository.GetTest(testId);
        }

        
        [Route("test")]
        [HttpGet("get/all")]
        public IActionResult GetAllTests()
        {
            return (IActionResult)_testRepository.GetAllTests();
        }

        
        [Route("test")]
        [HttpPost("add")]
        public async Task AddTest(Test test)
        {
            await _testRepository.AddTest(test);
        }

        
        [Route("test")]
        [HttpDelete("delete")]
        public async Task DeletePost(int testId)
        {
            await _testRepository.DeleteTest(testId);
        }

        
    }
}

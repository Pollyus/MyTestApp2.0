﻿using DBRepository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using ReactApp.ViewModels;

namespace ReactApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        ITestRepository _testRepository;
        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [NonAction]
        [Route("test")]
        [HttpGet("get")]
        public async Task<Test> GetTest(int testId)
        {
            return await _testRepository.GetTest(testId);
        }

        [NonAction]
        [Route("test")]
        [HttpGet("get/all")]
        public IActionResult GetAllTests()
        {
            return (IActionResult)_testRepository.GetAllTests();
        }

        [NonAction]
        [Authorize]
        [Route("test")]
        [HttpPost("add")]
        public async Task AddTest(Test test)
        {
            await _testRepository.AddTest(test);
        }

        [NonAction]
        [Route("test")]
        [HttpDelete("delete")]
        public async Task DeleteTest(int testId)
        {
            await _testRepository.DeleteTest(testId);
        }

        
    }
}

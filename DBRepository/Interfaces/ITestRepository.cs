using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBRepository.Interfaces
{
    public interface ITestRepository
    {
        Task<Test> GetTest(int testId);
        Task<List<string>> GetAllTests();
        Task AddTest(Test test);
        Task DeleteTest(int testId);

    }
}
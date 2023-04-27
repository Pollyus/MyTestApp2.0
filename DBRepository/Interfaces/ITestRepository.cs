using DBRepository.ViewModels;
using Models;

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
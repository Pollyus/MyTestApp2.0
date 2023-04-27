using DBRepository.ViewModels;
using Models;
using ReactApp.ViewModels;

namespace DBRepository.Interfaces
{
    public interface ITestRepository//: IRepositoryCrud<Test>
    {
        Task<Test> GetTest(int testId);
        List<TestViewModel> GetAllTests();
        Task AddTest(Test test);
        Task DeleteTest(int testId);

    }
}
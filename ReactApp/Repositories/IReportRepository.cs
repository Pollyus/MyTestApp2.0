using ReactApp.ViewModels;

namespace ReactApp.Repositories
{
    public interface IReportRepository
    {
        //Добавление отчета
        bool AddReport(TestViewModel report);

        //Коллекция отчетов
        ICollection<TestViewModel> Reports();

    }
}

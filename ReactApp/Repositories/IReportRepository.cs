using ReactApp.ViewModels;

namespace ReactApp.Repositories
{
    public interface IReportRepository
    {
        //Добавление отчета
        bool AddReport(TestModel report);

        //Коллекция отчетов
        ICollection<TestModel> Reports();

    }
}

using System.Collections.Concurrent;
using ReactApp.ViewModels;

namespace ReactApp.Repositories
{
    //Репозиторий отчетов
    public class ReportRepository : IReportRepository
    {
        private readonly ConcurrentDictionary<string, TestModel> _reports = new();
        //private TestAppDbContext dataBase;

        //Отчеты
        public ICollection<TestModel> Reports()
        {
            return _reports.Values;
        }

        //Добавление отчетов в репозиторий
        public bool AddReport(TestModel report)
        {
            return _reports.TryAdd(report.Job, report);
        }

    }
}

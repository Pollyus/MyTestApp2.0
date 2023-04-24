using System.Collections.Concurrent;
using ReactApp.ViewModels;

namespace ReactApp.Repositories
{
    //Репозиторий отчетов
    public class ReportRepository : IReportRepository
    {
        private readonly ConcurrentDictionary<string, TestViewModel> _reports = new();
        //private TestAppDbContext dataBase;

        //Отчеты
        public ICollection<TestViewModel> Reports()
        {
            return _reports.Values;
        }

        //Добавление отчетов в репозиторий
        public bool AddReport(TestViewModel report)
        {
            return _reports.TryAdd(report.Job, report);
        }

    }
}

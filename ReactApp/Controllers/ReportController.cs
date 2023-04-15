using Microsoft.AspNetCore.Mvc;
using ReactApp.Repositories;
using ReactApp.ViewModels;

namespace ReactApp.Controllers
{
    /// <summary>
    /// Контроллер отчетов
    /// </summary>
    [Route("api/report")]
    [ApiController]
    public class ReportController : Controller
    {
        readonly IReportRepository _repository;
        //private readonly TestAppContext context;

        public ReportController(IReportRepository repository)
        {
            _repository = repository;

        }

        /// Получение всех отчетов 
        [HttpGet("get/all")]
        public IActionResult GetResult()
        {
            return Ok(_repository.Reports());
        }

        //Загрузка отчетов на сервер
        [HttpPost("load")]
        public Task<IActionResult> UploadFile([FromBody] TestModel testReport)
        {
            //return Task.FromResult<IActionResult>(_repository.AddReport(testReport) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError));
            if (_repository.AddReport(testReport))
            {
                return Task.FromResult<IActionResult>(Ok());
            }
            else
            {
                return Task.FromResult<IActionResult>(StatusCode(StatusCodes.Status500InternalServerError));
            }

        }


    }
}

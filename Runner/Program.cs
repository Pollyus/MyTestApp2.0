
using System.Diagnostics;
using System.Text;
using Serilog;
using CommandLine;
using Newtonsoft.Json;
using Models;

namespace Runner
{
    static class Program
    {
        private static readonly string FilePath = Resource.FilePath;

        static async Task Main(string[] args)
        {
            //Создание логгера
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            //Проверяем существование дирректории
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            await Parser.Default.ParseArguments<Options>(args).WithParsedAsync(StartTests);

        }

        private static async Task StartTests(Options options)
        {
            //Проверяем существование дирректории
            if (!File.Exists(options.TestFilePath))
            {
                Log.Logger.Error("Создаем новую папку");
                return;
            }

            //Если ее не существует, то создаем ее 
            var path = Path.Combine(FilePath, options.JobId);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Имена файлов
            var logFilePath = Path.Combine(path, options.JobId);
            var xmlFilePath = $"{logFilePath}.xml";
            var htmlFilePath = $"{logFilePath}.html";

            var argumentBuilder = new StringBuilder();
            argumentBuilder.Append($"/C dotnet test {options.TestFilePath} ");

            //Проверяем указан ли namespace
            if (!string.IsNullOrEmpty(options.NamespaceName))
            {
                argumentBuilder.Append((string?)$"--filter:\"FullyQualifiedName~{options.NamespaceName}\"");
            }

            //Логгеры для файлов
            argumentBuilder.Append((string?)$"--logger:\"xunit;LogFilePath={xmlFilePath}\" --logger:\"html;LogFileName={htmlFilePath}\"");

            var argumetText = argumentBuilder.ToString();

            var process = new Process
            {
                StartInfo = new ProcessStartInfo(fileName: "cmd.exe")
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = argumetText
                }
            };
            Console.WriteLine(argumetText);
            Log.Logger.Information("Начало тестирования");
            process.Start();
            process.WaitForExit();
            Log.Logger.Information("Тестирование окончено");

            //Проверяем существование файлов отчетов
            if (!File.Exists(xmlFilePath))
            {
                Log.Logger.Information("Файл xml не найден");

            }
            if (!File.Exists(htmlFilePath))
            {
                Log.Logger.Information("Файл html не найден");

            }

            await UploadFiles(options, xmlFilePath, htmlFilePath);

            //Удаление временных файлов
            // Log.Logger.Information("Удаляем временные файлы");
            // Directory.Delete(path, true);
        }

        // Загрузка Файлов на сервер 
        private static async Task UploadFiles(Options options, string xmlFilePath, string htmlFilePath)
        {
            var report = new Test
            {
                xmlReport = await File.ReadAllTextAsync(xmlFilePath),
                //htmlReport = await File.ReadAllTextAsync(htmlFilePath),
                Pipeline = options.PipelineId,
                Job = options.JobId,
                Namespace = options.NamespaceName,
                Name = options.JobId + options.PipelineId,
            };

            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(5);
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"http://localhost:5271/api/report/load"),
                    Content = new StringContent(JsonConvert.SerializeObject(report), Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    var errorMassage = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(errorMassage))
                    {
                        errorMassage = response.ReasonPhrase;
                    }
                    Log.Logger.Error(errorMassage);
                    return;
                }

                Log.Logger.Information("Файлы загружены на сервер");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
            }
        }
    }
}

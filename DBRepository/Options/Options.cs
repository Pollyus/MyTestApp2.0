
using CommandLine;

namespace DBRepository.Options
{
    /// <summary>
    /// Аргументы для записи
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Путь к файлу теста 
        /// </summary>
        [Option('p', "testFilePath", Required = true, HelpText = "Укажите дирректорию для нужного теста")]
        public string TestFilePath { get; set; }

        /// <summary>
        /// Название namespace
        /// </summary>
        [Option('n', "namespaceName", Required = false, HelpText = "Укажите namespace ")]
        public string NamespaceName { get; set; }

        /// <summary>
        /// Индификатор пайплайна
        /// </summary>
        [Option('i', "pipelineId", Required = true, HelpText = "Укажите индефикатор pipeline")]
        public string PipelineId { get; set; }

        /// <summary>
        /// Индификатор job
        /// </summary>
        [Option('j', "jobId", Required = true, HelpText = "Укажите индефикатор job")]
        public string JobId { get; set; }


    }
}
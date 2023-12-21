using Core.CrossCuttingConcerns.Logging.Extensions;
using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class FileLogger:LoggerServiceBase
    {
        private IConfiguration _configuration;
        public FileLogger(IConfiguration configuration)
        {
            _configuration = configuration;

            FileConfiguration logConfig = configuration.GetConfig<FileConfiguration>("SeriLogConfigurations:FileLogConfiguration");

            string logFilePath = string.Format("{0}{1}", Directory.GetCurrentDirectory() + logConfig.FolderPath, ".txt");
            Logger = new LoggerConfiguration()
                .WriteTo.File(
                path: logFilePath,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: null,
                fileSizeLimitBytes: 5000000,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }

    }
}

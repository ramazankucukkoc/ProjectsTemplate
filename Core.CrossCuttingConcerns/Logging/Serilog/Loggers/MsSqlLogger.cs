using Core.CrossCuttingConcerns.Logging.Extensions;
using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class MsSqlLogger : LoggerServiceBase
    {
        public MsSqlLogger(IConfiguration configuration)
        {
            MsSqlConfiguration msSqlConfiguration = configuration.GetConfig<MsSqlConfiguration>("SeriLogConfigurations:MsSqlConfiguration");

            MSSqlServerSinkOptions mSSqlServerSinkOptions = new MSSqlServerSinkOptions
            {
                TableName = msSqlConfiguration.TableName,
                AutoCreateSqlTable = msSqlConfiguration.AutoCreateSqlTable,
            };
            ColumnOptions columnOptions = new();

            Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                connectionString: msSqlConfiguration.ConncetionString,
                sinkOptions: mSSqlServerSinkOptions,
                columnOptions: columnOptions
                ).CreateLogger();
     }
    }
}

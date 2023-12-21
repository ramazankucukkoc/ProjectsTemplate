using Core.CrossCuttingConcerns.Logging.Extensions;
using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class MongoDbLogger:LoggerServiceBase
    {
        public MongoDbLogger(IConfiguration configuration)
        {
            MongoDbConfiguration mongoDbConfiguration = configuration.GetConfig<MongoDbConfiguration>("SeriLogConfiguration:MongoDbConfiguration");

            Logger = new LoggerConfiguration()
                .WriteTo.MongoDBBson(cfg =>
                {
                    var client = new MongoClient(mongoDbConfiguration.ConnectionString);
                    var mongoDbInstance = client.GetDatabase(mongoDbConfiguration.Collection);
                    cfg.SetMongoDatabase(mongoDbInstance);
                }).CreateLogger();
        }

    }
}

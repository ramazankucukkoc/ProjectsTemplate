using Core.CrossCuttingConcerns.Logging.Extensions;
using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class ElasticSearchLogger:LoggerServiceBase
    {
        public ElasticSearchLogger(IConfiguration configuration)
        {
            ElasticSearchConfiguration elasticSearchConfiguration = configuration.GetConfig<ElasticSearchConfiguration>("SeriLogConfigurations:ElasticSearchConfiguration");

            Logger = new LoggerConfiguration()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticSearchConfiguration.ConnectionString))
                {
                    AutoRegisterTemplate = elasticSearchConfiguration.AutoRegisterTemplate,
                    AutoRegisterTemplateVersion = (AutoRegisterTemplateVersion)elasticSearchConfiguration.AutoRegisterTemplateVersion,
                    CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: elasticSearchConfiguration.RenderMessage)
                }).CreateLogger();
        }
    }
}

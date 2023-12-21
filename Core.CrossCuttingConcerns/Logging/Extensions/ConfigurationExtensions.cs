using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;

namespace Core.CrossCuttingConcerns.Logging.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T GetConfig<T>(this IConfiguration configuration,string sectionName)
        {
            return configuration.GetSection(sectionName).Get<T>() ?? throw new Exception(SerilogMessages.NullOptionMessages);
        }
    }
}

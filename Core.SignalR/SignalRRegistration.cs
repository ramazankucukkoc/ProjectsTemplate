using Microsoft.Extensions.DependencyInjection;

namespace Core.SignalR
{
    public static class SignalRRegistration
    {
        public static IServiceCollection AddSignalRRegistration(this IServiceCollection services)
        {
            services.AddSignalR();
            // services.AddTransient<IHubService< >>
            return services;
        }
    }
}

using Core.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Core.SignalR.HubServices
{
    public class HubService<T> : IHubService<T> where T : class
    {
        private readonly IHubContext<EntityHub<T>> _hubContext;

        public HubService(IHubContext<EntityHub<T>> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task CreatedMessagesAsync(string receiveMessage, string message)
        {
            await _hubContext.Clients.All.SendAsync(receiveMessage, message);

        }
    }
}

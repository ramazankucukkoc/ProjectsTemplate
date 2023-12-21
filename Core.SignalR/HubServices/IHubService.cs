namespace Core.SignalR.HubServices
{
    public interface IHubService<T>
    {
        Task CreatedMessagesAsync(string receiveMessage, string message);

    }
}

namespace AnonShare.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
        Task ReceiveGroupMessage(string message);
    }
}

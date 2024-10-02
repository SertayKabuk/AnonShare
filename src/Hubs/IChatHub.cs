namespace AnonShare.Hubs
{
    public interface IChatHub
    {
        Task SendMessage(string user, string message);
        Task SendMessageToCaller(string user, string message);
        Task SendMessageToGroup(string group, string message);
        Task AddToGroup(string groupName);
        Task RemoveFromGroup(string groupName);
    }
}

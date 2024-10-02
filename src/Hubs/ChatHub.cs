using Microsoft.AspNetCore.SignalR;

namespace AnonShare.Hubs
{
    public class ChatHub : Hub<IChatClient>, IChatHub
    {
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).ReceiveGroupMessage($"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).ReceiveGroupMessage($"{Context.ConnectionId} has left the group {groupName}.");
        }

        public async Task SendMessage(string user, string message)
       => await Clients.All.ReceiveMessage(user, message);

        public async Task SendMessageToCaller(string user, string message)
            => await Clients.Caller.ReceiveMessage(user, message);

        public async Task SendMessageToGroup(string group, string message)
            => await Clients.Group(group).ReceiveGroupMessage($"{Context.ConnectionId} says: {message}.");
    }
}
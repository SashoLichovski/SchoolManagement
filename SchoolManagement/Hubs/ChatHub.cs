using Microsoft.AspNetCore.SignalR;

namespace SchoolManagement.Hubs
{
    public class ChatHub : Hub
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using WebProjectOnAzure.Models;

namespace WebProjectOnAzure.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message )
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}

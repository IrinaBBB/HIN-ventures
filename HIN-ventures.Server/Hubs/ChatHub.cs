using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using HIN_ventures.Shared.Models;

namespace HIN_ventures.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace HIN_ventures.Server.Hubs
{
    //[Authorize(Roles = SD.RoleAdmin)]
    [AllowAnonymous]
    public class BlazorChatSampleHub : Hub
    {
        public const string HubUrl = "/chat";

        public async Task Broadcast(string username, string message)
        {
            await Clients.All.SendAsync("Broadcast", username, message);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
    }
}

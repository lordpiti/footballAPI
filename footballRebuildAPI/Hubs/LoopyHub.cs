using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AspNetCoreSignalr.SignalRHubs
{
    public class LoopyHub : Hub
    {

        public Task Send(string data)
        {
            return Clients.All.SendAsync("Send", data);
        }

        public Task SendCreateMatch(string data)
        {
            return Clients.All.SendAsync("SendCreateMatch", data);
        }
    }
}
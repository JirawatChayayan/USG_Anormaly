using Microsoft.AspNetCore.SignalR;

namespace USG_Anormaly_Server.Hubs
{
    public class NotificationHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await SendMessage("", "New User Are Connected");
            await base.OnConnectedAsync();
        }
        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("send", user,message);
        }
    }
}

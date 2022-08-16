using Microsoft.AspNetCore.SignalR;

namespace USG_Anormaly_Server.Hubs
{
    public class NotificationHub : Hub
    {
        private static Dictionary<string, string> Users = new Dictionary<string, string>();
        public override async Task OnConnectedAsync()
        {
            string username = Context.GetHttpContext().Request.Query["username"];
            Users.Add(Context.ConnectionId, username);
            await SendMessage("", $"New User '{username}' Are Connected");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string username = Users.FirstOrDefault(u => u.Key == Context.ConnectionId).Value;
            await SendMessage(string.Empty, $"{username} left!");
        }
        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("notify", user,message);
        }

        public async Task send_oldData(string user,string message)
        {
            await Clients.All.SendAsync(user,message);
        }
    }
}

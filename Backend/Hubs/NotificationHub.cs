using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmployeeTaskManagementSystem.Hubs
{
    public class NotificationHub : Hub
    {
        // Called when a user connects to the hub
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        // Called when a user disconnects
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"Client disconnected: {Context.ConnectionId}");
            return base.OnDisconnectedAsync(exception);
        }

        // You can define custom events/methods
        public async Task SendNotification(string user, string message)
        {
            // Broadcast to all connected clients
            await Clients.All.SendAsync("ReceiveNotification", user, message);
        }

        // Send to specific user (optional if you have user-group logic)
        public async Task SendToUser(string userId, string message)
        {
            await Clients.User(userId).SendAsync("ReceivePrivateNotification", message);
        }
    }
}

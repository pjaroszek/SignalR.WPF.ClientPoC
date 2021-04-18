namespace Jaroszek.Poc.SignalR.Client.Services
{

    using Microsoft.Extensions.Logging;

    public sealed partial class ShellBackgroundService
    {
        private void Connect()
        {
            this.logger.LogInformation("Start connect to SignalR server");








        }

        private void SendNotification(string notification)
        {
            this.logger.LogInformation("Start sended notification {notification}", notification);


        }

        private void Disconnect()
        {
            this.logger.LogInformation("SignalR server Disconnected");


        }
    }
}

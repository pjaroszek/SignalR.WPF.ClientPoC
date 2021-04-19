namespace Jaroszek.Poc.SignalR.Client.Services
{
    using Jaroszek.Poc.SignalR.Client.Events;
    using Jaroszek.Poc.SignalR.Client.Models;

    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.Logging;

    using System;

    public sealed partial class ShellBackgroundService
    {
        private void Connect()
        {
            this.logger.LogInformation("Start connect to SignalR server");
            try
            {
                connection = new HubConnectionBuilder().WithUrl(URL).Build();
                connection.On<Notification>("ReceiveMessage", update =>
                {
                    this.eventAggregator.GetEvent<ReceivedMessageSignalRResponse>().Publish(update.Message);


                });
                connection.StartAsync();
                this.eventAggregator.GetEvent<ChangeStatusRequestEvent>().Publish("Connected");
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, exception.Message);
                throw;
            }

        }

        private void SendNotification(string notification)
        {

            connection.SendAsync("SendMessage", "SendAsync");
            connection.InvokeAsync("SendMessage", "InvokeAsync");
            connection.InvokeCoreAsync("SendMessage", new object[] { "from WPF", notification });


        }

        private void Disconnect()
        {
            if (connection != null)
            {
                connection.StopAsync();
                this.eventAggregator.GetEvent<ChangeStatusRequestEvent>().Publish("Disconnect");
            }


        }
    }
}

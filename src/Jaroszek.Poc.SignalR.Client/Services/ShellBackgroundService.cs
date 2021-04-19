namespace Jaroszek.Poc.SignalR.Client.Services
{
    using Jaroszek.Poc.SignalR.Client.Events;
    using Jaroszek.Poc.SignalR.Client.Interfaces;

    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.Logging;

    using Prism.Events;

    using System;

    public sealed partial class ShellBackgroundService : IBackgroundService
    {
        private readonly ILogger<ShellBackgroundService> logger;
        private readonly IEventAggregator eventAggregator;

        private volatile bool disposed;

        private readonly SubscriptionToken connectedToken;
        private readonly SubscriptionToken disconnectedToken;
        private readonly SubscriptionToken sendMessageToken;


        HubConnection connection;
        private const string URL = "https://localhost:5001/chatHub/";


        public ShellBackgroundService(IEventAggregator eventAggregator, ILoggerFactory loggeFactory)
        {
            this.eventAggregator = eventAggregator;
            this.logger = loggeFactory.CreateLogger<ShellBackgroundService>();


            this.logger.LogInformation("created instance ShellBackgroundService");

            this.connectedToken = this.eventAggregator.GetEvent<ConnectSignalRServerRequestEvent>()
                 .Subscribe(this.Connect, ThreadOption.BackgroundThread);

            this.disconnectedToken = this.eventAggregator.GetEvent<DisconnectSignalRServerRequestEvent>().Subscribe(this.Disconnect, ThreadOption.UIThread);

            this.sendMessageToken = this.eventAggregator.GetEvent<SendMessageSignalRServerRequestEvent>()
                .Subscribe(this.SendNotification, ThreadOption.UIThread);

        }

        ~ShellBackgroundService()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                //  this.timer.Stop();
                this.eventAggregator.GetEvent<SendMessageSignalRServerRequestEvent>().Unsubscribe(sendMessageToken);
                this.eventAggregator.GetEvent<DisconnectSignalRServerRequestEvent>().Unsubscribe(disconnectedToken);
                this.eventAggregator.GetEvent<ConnectSignalRServerRequestEvent>().Unsubscribe(connectedToken);
                this.logger.LogInformation("dispose instance ShellBackgroundService");
            }

            this.disposed = true;
        }
    }
}
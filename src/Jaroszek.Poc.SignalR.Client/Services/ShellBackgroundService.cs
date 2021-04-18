namespace Jaroszek.Poc.SignalR.Client.Services
{
    using Jaroszek.Poc.SignalR.Client.Interfaces;

    using Microsoft.Extensions.Logging;

    using Prism.Events;

    using System;

    public class ShellBackgroundService : IBackgroundService
    {
        private readonly ILogger<ShellBackgroundService> logger;
        private readonly IEventAggregator eventAggregator;

        private volatile bool disposed;

        public ShellBackgroundService(IEventAggregator eventAggregator, ILoggerFactory loggeFactory)
        {
            this.eventAggregator = eventAggregator;

            this.logger = loggeFactory.CreateLogger<ShellBackgroundService>();
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

            }

            this.disposed = true;
        }
    }
}
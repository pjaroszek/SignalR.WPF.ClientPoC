namespace Jaroszek.Poc.SignalR.Client.ViewModels
{
    using Microsoft.Extensions.Logging;

    using Prism.Events;
    using Prism.Mvvm;

    using System;

    public class ShellViewModel : BindableBase, IDisposable
    {
        private volatile bool disposed;

        private readonly IEventAggregator eventAgregator;
        private readonly ILogger<ShellViewModel> logger;
        private readonly ILoggerFactory loggerFactory;

        public ShellViewModel()
        {

        }

        public ShellViewModel(IEventAggregator eventAggregator, ILoggerFactory loggeFactory) : this()
        {
            this.eventAgregator = eventAggregator;
            this.logger = loggeFactory.CreateLogger<ShellViewModel>();
            this.loggerFactory = loggeFactory;


            this.logger.LogInformation($"Created {typeof(ShellViewModel)} object.");

        }


        ~ShellViewModel()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {

                this.logger.LogInformation("Dispose ShellViewModel Instance");
            }

            this.disposed = true;
        }
    }
}
namespace Jaroszek.Poc.SignalR.Client.ViewModels
{
    using Jaroszek.Poc.SignalR.Client.Events;

    using Prism.Commands;

    using System.Windows.Input;

    public sealed partial class ShellViewModel
    {
        public ICommand ConnectCommand => new DelegateCommand(() =>
        {
            this.eventAgregator.GetEvent<ConnectSignalRServerRequestEvent>().Publish();
        });


    }
}

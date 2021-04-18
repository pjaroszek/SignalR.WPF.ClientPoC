namespace Jaroszek.Poc.SignalR.Client.ViewModels
{
    using System.Collections.ObjectModel;

    public sealed partial class ShellViewModel
    {
        private string title = "SignalR Client";
        private string message;

        private ObservableCollection<string> messagesReceived = new ObservableCollection<string>();

        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }

        public string Message
        {
            get => this.message;
            set
            {
                this.SetProperty(ref this.message, value);
            }
        }

        public ObservableCollection<string> MessagesReceived
        {
            get => this.messagesReceived;
            set => this.SetProperty(ref this.messagesReceived, value);
        }
    }
}

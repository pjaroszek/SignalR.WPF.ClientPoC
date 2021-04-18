namespace Jaroszek.Poc.SignalR.Client.ViewModels
{
    public sealed partial class ShellViewModel
    {
        private string title = "SignalR Client";

        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }
    }
}

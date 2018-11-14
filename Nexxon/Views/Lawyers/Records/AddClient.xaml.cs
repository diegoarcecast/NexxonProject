
namespace Nexxon.Views.Lawyers.Records
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;
    
    public sealed partial class AddClient : Page
    {
        public AddClient()
        {
            this.InitializeComponent();
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Records.AddCase), null, new DrillInNavigationTransitionInfo());
        }
    }
}



namespace Nexxon.Views.Lawyers.Records
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;

    public sealed partial class AddRecord : Page
    {
        public AddRecord()
        {
            this.InitializeComponent();
        }

        private void BtnAddRecord_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Records.AddClient), null, new DrillInNavigationTransitionInfo());
        }
    }
}

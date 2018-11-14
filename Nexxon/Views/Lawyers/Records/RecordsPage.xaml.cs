
namespace Nexxon.Views.Lawyers
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;

    public sealed partial class RecordsPage : Page
    {
        public RecordsPage()
        {
            this.InitializeComponent();
        }

        private void BtnAddRecord_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Records.AddClient), null, new DrillInNavigationTransitionInfo());
        }

        private void BtnCheckCase_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Records.ListCase), null, new DrillInNavigationTransitionInfo());
        }

    }
}

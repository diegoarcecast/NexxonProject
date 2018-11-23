
namespace Nexxon.Views.Records
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;

    public sealed partial class ListCase : Page
    {
        public ListCase()
        {
            this.InitializeComponent();
        }

        private void BtnCreateCase_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Records.AddCase), null, new DrillInNavigationTransitionInfo());
        }

        private void BtnUpdateCase_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Records.ViewEditCase), null, new DrillInNavigationTransitionInfo());
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

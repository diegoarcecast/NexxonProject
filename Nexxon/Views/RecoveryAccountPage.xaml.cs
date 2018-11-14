
namespace Nexxon.Views
{

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;

    public sealed partial class RecoveryAccountPage : Page
    {
        public RecoveryAccountPage()
        {
            this.InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack(new DrillInNavigationTransitionInfo());
        }

        private void BtnRecoveryAccess_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack(new DrillInNavigationTransitionInfo());
        }
    }
}

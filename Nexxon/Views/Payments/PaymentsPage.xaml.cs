
namespace Nexxon.Views.Payments
{

    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;

    public sealed partial class PaymentsPage : Page
    {
        public PaymentsPage()
        {
            this.InitializeComponent();
        }

        private void BtnSearch_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void BtnAddPayment_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddPayment), null, new DrillInNavigationTransitionInfo());
        }

        private void BtnCancel_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }
    }
}

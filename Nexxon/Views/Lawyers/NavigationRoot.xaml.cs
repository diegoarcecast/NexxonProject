
namespace Nexxon.Views.Lawyers
{ 

    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media.Animation;

    public sealed partial class NavigationRoot : Page
    {
        public NavigationRoot()
        {
            this.InitializeComponent();
        }

        private void NVI_Schedule_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SchedulePage), null, new DrillInNavigationTransitionInfo());
        }

        private void NVI_Records_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(RecordsPage), null, new DrillInNavigationTransitionInfo());
        }

        private void NVI_Payments_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(PaymentsPage), null, new DrillInNavigationTransitionInfo());
        }
    }
}

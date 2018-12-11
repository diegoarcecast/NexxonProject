
namespace Nexxon.Views.Payments
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;
    using Windows.UI.Xaml.Navigation;
    using Nexxon.Models.Security;
    using Nexxon.ViewModels.Security;

    public sealed partial class PaymentsPage : Page
    {
        private String profile;

        public PaymentsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AutorizationModel authorizationModel = new AutorizationModel();
            AuthorizationViewModel authorizationViewModel = new AuthorizationViewModel();

            this.profile = e.Parameter.ToString();
            authorizationModel.UserProfile = this.profile;

            this.DataContext = authorizationModel;

            authorizationViewModel.PaymentsPermissions(ref authorizationModel);
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

        private void BtnEditPayment_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditPayment), null, new DrillInNavigationTransitionInfo());
        }

        private void BtnDeletePayment_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DeletePayment), null, new DrillInNavigationTransitionInfo());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

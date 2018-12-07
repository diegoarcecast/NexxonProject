
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
            AutorizationModel obj_AutorizationModel = new AutorizationModel();
            AuthorizationViewModel obj_AuthorizationViewModel = new AuthorizationViewModel();

            this.profile = e.Parameter.ToString();

            obj_AutorizationModel._sPrifle = this.profile;
            obj_AutorizationModel._buttonDeletePayment = this.BtnDeletePayment;

            obj_AuthorizationViewModel.PaymentsPermissions(ref obj_AutorizationModel);

            this.DataContext = obj_AutorizationModel;

            
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
            //AuthenticationModel obj_AuthenticationModel = new AuthenticationModel();

            

            //this.DataContext = obj_AuthenticationModel;
        }
    }
}


namespace Nexxon.Views
{
    using System;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;
    using ViewModels.Security;
    using ViewModels.Cat_Mant;
    using System.Data;
    using Nexxon.Models.Security;
    using Nexxon.Helpers;

    public sealed partial class LoginPage : Page
    {
        AuthenticationModel authenticationModel = new AuthenticationModel();
        AutorizationModel autorizationModel = new AutorizationModel();

        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string sError = "";
            AuthenticationViewModel authenticationViewModel = new AuthenticationViewModel();

            authenticationViewModel.AuthenticateUser(ref authenticationModel, ref sError);

            if (authenticationModel.UserProfile != string.Empty)
            {
                autorizationModel.UserEmail = authenticationModel.UserName;
                autorizationModel.UserProfile = authenticationModel.UserProfile;
                Frame.Navigate(typeof(MainPage), autorizationModel, new DrillInNavigationTransitionInfo());
            }
        }

        private void BtnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RecoveryAccountPage), null, new DrillInNavigationTransitionInfo());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AuthenticationViewModel authenticationViewModel = new AuthenticationViewModel();

            this.DataContext = authenticationModel;

            authenticationViewModel.OnFirstLoad(ref authenticationModel);
        }
    }
}

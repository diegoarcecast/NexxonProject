
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

    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Move this when MVVM is implemented.
            string sError = "";
            AuthenticationModel obj_AuthenticationModel = new AuthenticationModel();
            AuthenticationViewModel obj_AuthenticationViewModel = new AuthenticationViewModel();

            obj_AuthenticationModel._lpUserName = TxtEmail.Text;
            obj_AuthenticationModel._lpPassword = PBXPassword.Password.ToString();

            obj_AuthenticationViewModel.authenticateUser(ref obj_AuthenticationModel, ref sError);

            if (obj_AuthenticationModel._lpProfile == "")
            {
                TxtError.Visibility = Visibility.Visible;
            }
            else
            {
                Frame.Navigate(typeof(MainPage), obj_AuthenticationModel._lpProfile, new DrillInNavigationTransitionInfo());
            }
        }

        private void BtnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RecoveryAccountPage), null, new DrillInNavigationTransitionInfo());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TxtError.Visibility = Visibility.Collapsed;
        }
    }
}

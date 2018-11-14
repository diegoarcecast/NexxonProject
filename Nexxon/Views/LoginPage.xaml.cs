
namespace Nexxon.Views
{
    using System;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;

    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Move this when MVVM is implemented.

            var accountDialog = new AccountDialog();
            await accountDialog.ShowAsync();

            var account = accountDialog.Account;

            switch (account)
            {
                case 0:
                    Frame.Navigate(typeof(MainPage), account, new DrillInNavigationTransitionInfo());
                    break;
                case 1:
                    Frame.Navigate(typeof(MainPage), account, new DrillInNavigationTransitionInfo());
                    break;
                case 2:
                    Frame.Navigate(typeof(MainPage), account, new DrillInNavigationTransitionInfo());
                    break;
                case 3:
                    Frame.Navigate(typeof(MainPage), account, new DrillInNavigationTransitionInfo());
                    break;
            }
        }

        private void BtnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RecoveryAccountPage), null, new DrillInNavigationTransitionInfo());
        }
    }
}

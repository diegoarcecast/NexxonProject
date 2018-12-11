using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Nexxon.Models.Security;
using Nexxon.ViewModels.Security;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nexxon.Views.Administration
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdministrationPage : Page
    {
        private String profile;

        public AdministrationPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AutorizationModel authorizationModel = new AutorizationModel();
            AuthorizationViewModel authorizationViewModel = new AuthorizationViewModel();

            this.profile = e.Parameter.ToString();

            authorizationModel.UserProfile = this.profile;

            authorizationViewModel.AdministrationPermissions(ref authorizationModel);

            this.DataContext = authorizationModel;
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelEdit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }

        private void BtnCancelChangePassword_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

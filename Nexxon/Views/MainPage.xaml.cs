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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nexxon.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        AutorizationModel autorizationModel = new AutorizationModel();
        private string userProfile;
        private string userEmail;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            autorizationModel = (AutorizationModel)e.Parameter;
            userProfile = autorizationModel.UserProfile;
            userEmail = autorizationModel.UserEmail;
        }

        private void NVI_Agenda_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Agenda.AgendaPage), userProfile, new DrillInNavigationTransitionInfo());
        }

        private void NVI_Records_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Records.RecordsPage), userProfile, new DrillInNavigationTransitionInfo());
        }

        private void NVI_Payments_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Payments.PaymentsPage), userProfile, new DrillInNavigationTransitionInfo());
        }

        private void NVI_Notifications_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Notifications.NotificationsPage), null, new DrillInNavigationTransitionInfo());
        }

        private void NVI_Administration_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Administration.AdministrationPage), autorizationModel, new DrillInNavigationTransitionInfo());
        }

        private void NVI_LogOut_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.DataContext = null;
            ContentFrame.BackStack.Clear();

            this.Frame.DataContext = null;
            this.Frame.BackStack.Clear();

            Frame.Navigate(typeof(LoginPage), userProfile, new DrillInNavigationTransitionInfo());
        }
    }
}

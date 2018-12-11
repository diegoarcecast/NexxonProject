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

namespace Nexxon.Views.Agenda
{
    public sealed partial class AgendaPage : Page
    {
        private String profile;

        public AgendaPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AutorizationModel AuthorizationModel = new AutorizationModel();
            AuthorizationViewModel authorizationViewModel = new AuthorizationViewModel();

            this.profile = e.Parameter.ToString();
            AuthorizationModel.UserProfile = this.profile;

            this.DataContext = AuthorizationModel;

            authorizationViewModel.ViewAgendaPermissions(ref AuthorizationModel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

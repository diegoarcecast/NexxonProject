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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AgendaPage : Page
    {
        private String profile;

        public AgendaPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AutorizationModel obj_AutorizationModel = new AutorizationModel();
            AuthorizationViewModel obj_AuthorizationViewModel = new AuthorizationViewModel();

            this.profile = e.Parameter.ToString();

            obj_AutorizationModel._sPrifle = this.profile;
            obj_AutorizationModel._cbxAgendaUsers = this.CbxUser;

            obj_AuthorizationViewModel.ViewAgendaPermissions(ref obj_AutorizationModel);

            this.DataContext = obj_AutorizationModel;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }
    }
}


namespace Nexxon.Views.Records
{
    using System;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;
    using Windows.UI.Xaml.Navigation;
    using Nexxon.Models.Security;
    using Nexxon.ViewModels.Security;

    public sealed partial class RecordsPage : Page
    {
        private String profile;

        public RecordsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AutorizationModel obj_AutorizationModel = new AutorizationModel();
            AuthorizationViewModel obj_AuthorizationViewModel = new AuthorizationViewModel();

            this.profile = e.Parameter.ToString();

            obj_AutorizationModel._sPrifle = this.profile;

            
        }

        private void PI_CheckRecords_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void PI_CreateRecords_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void PI_UpdateRecords_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnCreateCase_Click(object sender, RoutedEventArgs e)
        {
            CheckRecordsFrame.Navigate(typeof(Records.AddCase), profile, new DrillInNavigationTransitionInfo());
        }

        private void BtnUpdateCase_Click(object sender, RoutedEventArgs e)
        {
            CheckRecordsFrame.Navigate(typeof(Records.ViewEditCase), null, new DrillInNavigationTransitionInfo());
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }

        private async void BtnAddRecord_Click(object sender, RoutedEventArgs e)
        {
            var recordsDialog = new RecordsDialog();
            await recordsDialog.ShowAsync();

            if (recordsDialog.BResult == 1)
            {
                var createCaseDialog = new CreateCaseDialog();
                await createCaseDialog.ShowAsync();
                this.Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
            }
            else
            {
                this.Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
            }
        }

        private void BtnAddRecordCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }

        private void BtnEditRecordSearchClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditRecord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditRecordCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }
    }
}

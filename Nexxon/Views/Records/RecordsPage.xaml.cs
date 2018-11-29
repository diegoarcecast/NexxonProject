
namespace Nexxon.Views.Records
{
    using System;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;

    public sealed partial class RecordsPage : Page
    {
        public RecordsPage()
        {
            this.InitializeComponent();
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
            CheckRecordsFrame.Navigate(typeof(Records.AddCase), null, new DrillInNavigationTransitionInfo());
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

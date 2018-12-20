
namespace Nexxon.Views.Records
{
    using System;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;

    public sealed partial class AddClient : Page
    {
        public AddClient()
        {
            this.InitializeComponent();
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            //var recordsDialog = new RecordsDialog();
            //await recordsDialog.ShowAsync();

            //if (recordsDialog.BResult == 1)
            //{
            //    this.Frame.Navigate(typeof(Records.AddCase), null, new DrillInNavigationTransitionInfo());
            //}
            //else
            //{
            //    this.Frame.Navigate(typeof(Records.AddClient), null, new DrillInNavigationTransitionInfo());
            //}
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }
    }
}

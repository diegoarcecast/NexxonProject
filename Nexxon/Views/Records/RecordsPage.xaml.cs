
namespace Nexxon.Views.Records
{
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
            CheckRecordsFrame.Navigate(typeof(Records.ListCase), null, new DrillInNavigationTransitionInfo());
        }

        private void PI_CreateRecords_Loaded(object sender, RoutedEventArgs e)
        {
            CreateRecordsFrame.Navigate(typeof(Records.AddClient), null, new DrillInNavigationTransitionInfo());
        }
    }
}

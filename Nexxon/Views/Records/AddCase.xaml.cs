

namespace Nexxon.Views.Records
{
    using System.Text;
    using Windows.UI.Xaml.Controls;
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Media.Animation;
    using Nexxon.Models.Security;
    using Nexxon.ViewModels.Security;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class AddCase : Page
    {
        private String profile;

        public AddCase()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AutorizationModel obj_AutorizationModel = new AutorizationModel();
            AuthorizationViewModel obj_AuthorizationViewModel = new AuthorizationViewModel();

            this.profile = e.Parameter.ToString();

            obj_AutorizationModel._sPrifle = this.profile;
            obj_AutorizationModel._radioButtonJudicialCase = this.rdbtnJudicial;

            obj_AuthorizationViewModel.CreateCasePermissions(ref obj_AutorizationModel);
        }

        private void rdbtnNotary_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CbxCaseType.Visibility = Visibility.Collapsed;
            TxtSuePartyName.Visibility = Visibility.Collapsed;
            TxtSuePartyID.Visibility = Visibility.Collapsed;
            ASBJuzgado.Visibility = Visibility.Collapsed;
            TxtLegalOfficeID.Visibility = Visibility.Collapsed;
        }

        private void rdbtnJudicial_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CbxCaseType.Visibility = Visibility.Visible;
            TxtSuePartyName.Visibility = Visibility.Visible;
            TxtSuePartyID.Visibility = Visibility.Visible;
            ASBJuzgado.Visibility = Visibility.Visible;
            TxtLegalOfficeID.Visibility = Visibility.Visible;
        }

        private async void BtnAddFiles_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".pdf");
            picker.FileTypeFilter.Add(".mp4");
            picker.FileTypeFilter.Add(".avi");
            picker.FileTypeFilter.Add(".wmv");
            picker.FileTypeFilter.Add(".mpeg");
            picker.FileTypeFilter.Add(".mp3");
            picker.FileTypeFilter.Add(".wav");

            var files = await picker.PickMultipleFilesAsync();
            if (files.Count > 0)
            {
                StringBuilder output = new StringBuilder("Archivos seleccionados:\n");

                // Application now has read/write access to the picked file(s)
                foreach (Windows.Storage.StorageFile file in files)
                {
                    output.Append(file.Name + "\n");
                }
                txtAttachedFiles.Visibility = Visibility.Visible;
                this.txtAttachedFiles.Text = output.ToString();
            }
            else
            {
                this.txtAttachedFiles.Text = "";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            rdbtnNotary.IsChecked = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Content = null;
        }
    }
}

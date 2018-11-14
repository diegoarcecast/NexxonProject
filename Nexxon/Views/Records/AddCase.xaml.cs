

namespace Nexxon.Views.Records
{
    using System.Text;
    using Windows.UI.Xaml.Controls;
    using System;
    //using Windows.UI.Popups;
    using Windows.UI.Xaml;
    //using Windows.UI.Xaml.Media.Animation;

    public sealed partial class AddCase : Page
    {
        public AddCase()
        {
            this.InitializeComponent();
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
                //this.textBlock.Text = output.ToString();
                txtAttachedFiles.Visibility = Visibility.Visible;
                this.txtAttachedFiles.Text = output.ToString();
            }
            else
            {
                //this.textBlock.Text = "Operation cancelled.";
                this.txtAttachedFiles.Text = "";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            rdbtnNotary.IsChecked = true;
        }
    }
}

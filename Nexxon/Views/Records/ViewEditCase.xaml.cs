// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nexxon.Views.Records
{
    using System.Text;
    using Windows.UI.Xaml.Controls;
    using System;
    //using Windows.UI.Popups;
    using Windows.UI.Xaml;
    //using Windows.UI.Xaml.Media.Animation;

    public sealed partial class ViewEditCase : Page
    {
        public ViewEditCase()
        {
            this.InitializeComponent();
        }

        private async void BtnAddFiles_Click(object sender, RoutedEventArgs e)
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

        private void BtnEditCase_Click(object sender, RoutedEventArgs e)
        {
            TxtTitle.IsReadOnly = false;
            ASBJuzgado.IsEnabled = true;
            TxtLegalOfficeID.IsReadOnly = false;
            DPEndDate.IsEnabled = true;
            TxtAmount.IsReadOnly = false;
            CbxStatus.IsEnabled = true;
            BtnAddFiles.IsEnabled = true;
            BtnSaveCase.Visibility = Visibility.Visible;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (TxtCaseFamily.Text == "Notarial")
            {
                TxtCaseType.Visibility = Visibility.Collapsed;
                TxtSuePartyName.Visibility = Visibility.Collapsed;
                TxtSuePartyID.Visibility = Visibility.Collapsed;
                ASBJuzgado.Visibility = Visibility.Collapsed;
                TxtLegalOfficeID.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Content = null;
        }

        private void BtnSaveCase_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

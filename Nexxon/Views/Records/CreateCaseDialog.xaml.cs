using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nexxon.Views.Records
{
    public sealed partial class CreateCaseDialog : ContentDialog
    {
        public CreateCaseDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

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
    }
}

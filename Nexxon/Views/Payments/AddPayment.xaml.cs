using System;
using System.Text;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nexxon.Views.Payments
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPayment : Page
    {
        public AddPayment()
        {
            this.InitializeComponent();
        }

        private void rdbtnPhysical_Checked(object sender, RoutedEventArgs e)
        {
            TxtDescription.Visibility = Visibility.Visible;
        }

        private void rdbtnCard_Checked(object sender, RoutedEventArgs e)
        {
            TxtDescription.Visibility = Visibility.Collapsed;
        }

        private void rdbtnCash_Checked(object sender, RoutedEventArgs e)
        {
            TxtDescription.Visibility = Visibility.Collapsed;
        }

        private async void BtnAddFiles_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".pdf");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.txtAttachedFiles.Text = "Factura: " + file.Name;
            }
            else
            {
                this.txtAttachedFiles.Text = "No hay archivos adjuntos";
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            rdbtnCash.IsChecked = true;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

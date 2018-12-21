

namespace Nexxon.Views.Records
{
    using System.Text;
    using Windows.UI.Xaml.Controls;
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Media.Animation;
    using Nexxon.Models.Security;
    using Nexxon.Models.Records;
    using Nexxon.ViewModels.Security;
    using Nexxon.ViewModels.Records;
    using Windows.UI.Xaml.Navigation;
    using System.Collections.Generic;
    using System.Globalization;

    public sealed partial class AddCase : Page
    {
        private string profile;
        CasesModel casesModel = new CasesModel();

        public AddCase()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AutorizationModel authorizationModel = new AutorizationModel();
            AuthorizationViewModel authorizationViewModel = new AuthorizationViewModel();

            var parameterList = e.Parameter as List<string>;

            profile = parameterList[0];
            casesModel.IdCustomerRecord = Convert.ToInt32(parameterList[1]);

            authorizationModel.UserProfile = this.profile;

            this.DataContext = authorizationModel;
            FormStackPanel.DataContext = casesModel;
            rdbtnJudicial.DataContext = authorizationModel;

            authorizationViewModel.CreateCasePermissions(ref authorizationModel);

            rdbtnNotary.IsChecked = true;
        }

        private void rdbtnNotary_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CasesViewModel casesViewModel = new CasesViewModel();
            string errorMessage = string.Empty;
            
            casesModel.IdServiceArea = 2;

            casesViewModel.LoadServices(ref errorMessage, ref casesModel);

            TxtSuePartyName.Visibility = Visibility.Collapsed;
            TxtSuePartyID.Visibility = Visibility.Collapsed;
            TxtJuzgado.Visibility = Visibility.Collapsed;
            TxtLegalOfficeID.Visibility = Visibility.Collapsed;
        }

        private void rdbtnJudicial_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CasesViewModel casesViewModel = new CasesViewModel();
            string errorMessage = string.Empty;

            casesModel.IdServiceArea = 1;

            casesViewModel.LoadServices(ref errorMessage, ref casesModel);

            TxtSuePartyName.Visibility = Visibility.Visible;
            TxtSuePartyID.Visibility = Visibility.Visible;
            TxtJuzgado.Visibility = Visibility.Visible;
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
            string _errorMessage = "";

            CasesViewModel casesViewModel = new CasesViewModel();

            casesViewModel.LoadCasesStatus(ref _errorMessage, ref casesModel);

            casesModel.CaseStartDate = DateTime.Today;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Content = null;
            this.DataContext = null;
        }

        private async void BtnAddCase_Click(object sender, RoutedEventArgs e)
        {
            string Message = "", caseId = "";

            CasesViewModel casesViewModel = new CasesViewModel();

            casesViewModel.CreateNewCase(ref Message, ref casesModel);

            if (Message != string.Empty)
            {
                var newCaseResultDialog = new NewCaseResultDialog(Message, "");
                await newCaseResultDialog.ShowAsync();
            }
            else
            {
                Message = "El caso se creó de manera exitosa";
                caseId = "Número de caso: " + casesModel.InternalCaseNumber;

                var newRecordResultDialog = new NewRecordResultDialog(Message, caseId);
                await newRecordResultDialog.ShowAsync();

                this.Frame.Content = null;
                this.DataContext = null;
            }
        }

        private void TxtAmount_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key.ToString().Equals("Back"))
            {
                e.Handled = false;
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                if (e.Key.ToString() == string.Format("Number{0}", i))
                {
                    e.Handled = false;
                    return;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                if (e.Key.ToString() == string.Format("NumberPad{0}", i))
                {
                    e.Handled = false;
                    return;
                }
            }
            e.Handled = true;
        }
    }
}

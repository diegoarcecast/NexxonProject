
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
    using Nexxon.ViewModels.Records;
    using Nexxon.Models.Records;

    public sealed partial class RecordsPage : Page
    {
        private string userProfile;
        RecordsModel newRecord = new RecordsModel();
        RecordsModel editRecord = new RecordsModel();
        RecordsModel checkRecord = new RecordsModel();
        AuthenticationModel authenticationModel = new AuthenticationModel();
        AutorizationModel authorizationModel = new AutorizationModel();
        AuthorizationViewModel authorizationViewModel = new AuthorizationViewModel();

        public RecordsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.userProfile = e.Parameter.ToString();
            authorizationModel.UserProfile = this.userProfile;

            this.DataContext = authorizationModel;
            PI_CreateRecords.DataContext = newRecord;
            PI_UpdateRecords.DataContext = editRecord;
            PI_CheckRecords.DataContext = checkRecord;

            authorizationViewModel.RecordsPagePermissions(ref authorizationModel);
        }

        private void BtnCreateCase_Click(object sender, RoutedEventArgs e)
        {
            CheckRecordsFrame.Navigate(typeof(Records.AddCase), userProfile, new DrillInNavigationTransitionInfo());
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
            string Message = string.Empty;
            string recordNumber = string.Empty;

            RecordsViewModel recordsViewModel = new RecordsViewModel();

            recordsViewModel.CreateNewCustomerRecord(ref Message, ref newRecord);

            if (Message == string.Empty)
            {
                Message = "El expediente se ha creado de manera exitosa";
                recordNumber = "Número de expediente: " + newRecord.RecordId;

                var newRecordResultDialog = new NewRecordResultDialog(Message, recordNumber);
                await newRecordResultDialog.ShowAsync();

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
            else
            {
                var newRecordResultDialog = new NewRecordResultDialog(Message, recordNumber);
                await newRecordResultDialog.ShowAsync();
            }
        }

        private void BtnAddRecordCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }

        private async void BtnEditRecord_Click(object sender, RoutedEventArgs e)
        {
            string Message = string.Empty;

            RecordsViewModel recordsViewModel = new RecordsViewModel();

            recordsViewModel.EditCustomerRecord(ref Message, ref editRecord);

            if (Message != string.Empty)
            {
                var newRecordResultDialog = new NewRecordResultDialog(Message, "");
                await newRecordResultDialog.ShowAsync();
            }
            else
            {
                Message = "El expediente se modificó de manera exitosa";

                var newRecordResultDialog = new NewRecordResultDialog(Message, "");
                await newRecordResultDialog.ShowAsync();

                Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
            }
        }

        private void BtnEditRecordCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RdbtnNacional.IsChecked = true;
            editRecord.IsEditRecordBtnEnabled = false;
        }

        private async void ASBAllRecords_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            string Message = string.Empty;

            RecordsViewModel recordsViewModel = new RecordsViewModel();

            recordsViewModel.SearchAllCustomerRecords(ref checkRecord, ref Message);

            if (Message != string.Empty)
            {
                var newRecordResultDialog = new NewRecordResultDialog(Message, "");
                await newRecordResultDialog.ShowAsync();
            }
            else if (checkRecord.RecordsList.Count == 0 || checkRecord.RecordsList is null)
            {
                Message = "No se encontró ningún expediente con el criterio dado";

                var newRecordResultDialog = new NewRecordResultDialog(Message, "");
                await newRecordResultDialog.ShowAsync();
            }
        }

        private void RdbtnNacional_Checked(object sender, RoutedEventArgs e)
        {
            newRecord.CustomerIdType = "Nacional";
        }

        private void RdbtnExtranjero_Checked(object sender, RoutedEventArgs e)
        {
            newRecord.CustomerIdType = "Extranjero";
        }
        
        private async void TxtRecord_EditRecord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Message = string.Empty;

            RecordsViewModel recordsViewModel = new RecordsViewModel();

            recordsViewModel.SearchSpecificCustomerRecords(ref editRecord, ref Message);

            if (Message != string.Empty)
            {
                var newRecordResultDialog = new NewRecordResultDialog(Message, "");
                await newRecordResultDialog.ShowAsync();
            }
            else
            {
                editRecord.IsEditRecordBtnEnabled = true;
            }
        }

        private async void ASBAllRecords_EditRecord_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            string Message = string.Empty;

            RecordsViewModel recordsViewModel = new RecordsViewModel();

            recordsViewModel.SearchAllCustomerRecords(ref editRecord, ref Message);

            if (Message != string.Empty)
            {
                var newRecordResultDialog = new NewRecordResultDialog(Message, "");
                await newRecordResultDialog.ShowAsync();
            }
            else if (editRecord.RecordsList.Count == 0 || editRecord.RecordsList is null)
            {
                Message = "No se encontró ningún expediente con el criterio dado";

                var newRecordResultDialog = new NewRecordResultDialog(Message, "");
                await newRecordResultDialog.ShowAsync();
            }
        }

        private void LV_CheckRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

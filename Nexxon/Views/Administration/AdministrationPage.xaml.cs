using System;
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
using Nexxon.Models.Security;
using Nexxon.ViewModels.Security;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nexxon.Views.Administration
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdministrationPage : Page
    {
        private string userProfile;
        private string userEmail;
        UsersModel usersModel = new UsersModel();
        UsersModel editUser = new UsersModel();
        UsersViewModel usersViewModel = new UsersViewModel();
        AuthenticationModel authenticationModel = new AuthenticationModel();
        AutorizationModel authorizationModel = new AutorizationModel();

        public AdministrationPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AuthorizationViewModel authorizationViewModel = new AuthorizationViewModel();

            List<UsersModel> ProfilesList = new List<UsersModel>();

            string sMsgError = "";

            authorizationModel = (AutorizationModel)e.Parameter;
            userProfile = authorizationModel.UserProfile;
            userEmail = authorizationModel.UserEmail;

            authorizationModel.UserProfile = this.userProfile;

            authorizationViewModel.AdministrationPermissions(ref authorizationModel);

            this.DataContext = authorizationModel;

            usersViewModel.LoadUserRoles(ref sMsgError, ref usersModel);
            usersViewModel.LoadUserRoles(ref sMsgError, ref editUser);

            FormChangePassword.DataContext = authorizationModel;
            FormNewPassword.DataContext = usersModel;
            MainPanelAddUser.DataContext = usersModel;
            FormEditUser.DataContext = editUser;
        }

        private async void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string Message = "";
            usersModel.UserPassword = "";
            usersViewModel.CreateNewUser(ref Message, ref usersModel);

            if (Message == "")
            {
                Message = "El usuario se agregó de manera correcta!";
                var administrationResultDialog = new AdministrationResultDialog(Message, usersModel.UserPassword);
                await administrationResultDialog.ShowAsync();
                Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
            }
            else
            {
                var administrationResultDialog = new AdministrationResultDialog(Message, usersModel.UserPassword);
                await administrationResultDialog.ShowAsync();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }

        private async void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {
            string Message = string.Empty;

            //editUser.UserEmail = authorizationModel.UserEmail;
            usersViewModel.EditUser(ref Message, ref editUser);

            if (Message == "")
            {
                Message = "El usuario se modificó de manera exitosa";
                var administrationResultDialog = new AdministrationResultDialog(Message, "");
                await administrationResultDialog.ShowAsync();
                Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
            }
            else
            {
                var administrationResultDialog = new AdministrationResultDialog(Message, "");
                await administrationResultDialog.ShowAsync();
            }
        }

        private void BtnCancelEdit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }

        private void BtnCancelChangePassword_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string editErrorMessage = "";

            usersModel.UserEmail = authorizationModel.UserEmail;
            usersViewModel.SearchUser(ref usersModel, ref editErrorMessage);

            if (editErrorMessage != string.Empty)
            {
                var administrationResultDialog = new AdministrationResultDialog(editErrorMessage, "");
                await administrationResultDialog.ShowAsync();
            }
            else
            {
                var administrationResultDialog = new AdministrationResultDialog("Usuario encontrado, puede proceder a cambiar la contraseña", "");
                await administrationResultDialog.ShowAsync();
            }
        }

        private async void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            string Message = "";
            if (TxtNewPassword.Password == TxtConfirmNewPassword.Password)
            {
                usersModel.UserEmail = authorizationModel.UserEmail;
                usersViewModel.ChangeUserPassword(ref Message, ref usersModel);

                if (Message == "")
                {
                    Message = "La contraseña se cambio exitosamente";
                    var administrationResultDialog = new AdministrationResultDialog(Message, "");
                    await administrationResultDialog.ShowAsync();
                    Frame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
                }
                else
                {
                    var administrationResultDialog = new AdministrationResultDialog(Message, "");
                    await administrationResultDialog.ShowAsync();
                }
            }
            else
            {
                Message = "Por favor verifiquen que la contraseña y su verificación coincidan";
                var administrationResultDialog = new AdministrationResultDialog(Message, "");
                await administrationResultDialog.ShowAsync();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RdbtnNational.IsChecked = true;
        }

        private void CbxProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            usersModel.UserProfileId = Convert.ToInt32(CbxProfile.SelectedValue);
        }

        private void RdbtnNational_Checked(object sender, RoutedEventArgs e)
        {
            usersModel.UserIdType = RdbtnNational.Content.ToString();
        }

        private void RdbtnInternational_Checked(object sender, RoutedEventArgs e)
        {
            usersModel.UserIdType = RdbtnInternational.Content.ToString();
        }

        private async void BtnSearchEditUser_Click(object sender, RoutedEventArgs e)
        {
            string editErrorMessage = "";

            usersViewModel.SearchUser(ref editUser, ref editErrorMessage);

            if (editErrorMessage != string.Empty)
            {
                var administrationResultDialog = new AdministrationResultDialog(editErrorMessage, "");
                await administrationResultDialog.ShowAsync();
            }
        }
    }
}

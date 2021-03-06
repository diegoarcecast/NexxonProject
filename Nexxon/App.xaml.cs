﻿
namespace Nexxon
{

    using Nexxon.Views;
    using System;
    using Windows.ApplicationModel;
    using Windows.ApplicationModel.Activation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }
        
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (!(Window.Current.Content is Frame rootFrame))
            {
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated){ }
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                    rootFrame.Navigate(typeof(LoginPage), e.Arguments);

                Window.Current.Activate();
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }

        #region Connection String
        private string connectionString =
            "SERVER = localhost; DATABASE = DB_BUFFET_NEXXON; USER ID = sa; PASSWORD = N3xx0n";

        public string ConnectionString { get => connectionString; }
        #endregion

        #region DB Params
        private string _spSearchUser = "spListarUsuario";
        public string SpSearchUser { get => _spSearchUser; }

        private string _tblUsers = "T_USUARIO";
        public string TblUsers { get => _tblUsers; }

        private string _spChangeUserPassword = "spEditarContrasena";
        public string SpChangeUserPassword { get => _spChangeUserPassword; }

        private string _spEditUser = "spEditarUsuario";
        public string SpEditUser { get => _spEditUser; }

        private string _spAuthentication = "spAutenticarUsuario";
        public string SpAuthentication { get => _spAuthentication; }

        private string _tblAuthentication = "T_USUARIO";
        public string TblAuthentication { get => _tblAuthentication; }

        private string _spListProfiles = "spListarPerfil";
        public string SpListProfiles { get => _spListProfiles; }

        private string _tblProfiles = "T_PERFIL";
        public string TblProfiles { get => _tblProfiles; }

        private string _spCreateUser = "spAgregarUsuario";
        public string SpCreateUser { get => _spCreateUser; }

        private string _spCreateCustomerRecord = "spAgregarExpediente";
        public string SpCreateCustomerRecord { get => _spCreateCustomerRecord; }

        private string _spSearchAllRecords = "spListarExpedientesExistentes";
        public string SpSearchAllRecords { get => _spSearchAllRecords; }

        private string _spSearchSpecificRecord = "spListarExpediente";
        public string SpSearchSpecificRecord { get => _spSearchSpecificRecord; }

        private string _tblCustomerRecords = "T_EXPEDIENTE";
        public string TblCustomerRecords { get => _tblCustomerRecords; }

        private string _spEditCustomerRecord = "spEditarExpediente";
        public string SpEditCustomerRecord { get => _spEditCustomerRecord; }

        private string _spListServices = "spListarServicio";
        public string SpListServices { get => _spListServices; }

        private string _tblServices = "T_SERVICIO";
        public string TblServices { get => _tblServices; }

        private string _spAddNewCase = "spAgregarCaso";
        public string SpAddNewCase { get => _spAddNewCase; }

        private string _spListPossibleCaseStatus = "spListarEstadosParaCasos";
        public string SpListPossibleCaseStatus { get => _spListPossibleCaseStatus; }

        private string _tblStatus = "T_ESTADO";
        public string TblStatus { get => _tblStatus; }

        private string _spListCustomerCases = "spListarCasosExistentes";
        public string SpListCustomerCases { get => _spListCustomerCases; }

        private string _spListSpecificCase = "spListarCaso";
        public string SpListSpecificCase { get => _spListSpecificCase; }

        private string _tblCases = "T_CASO";
        public string TblCases { get => _tblCases; }
        #endregion

    }
}

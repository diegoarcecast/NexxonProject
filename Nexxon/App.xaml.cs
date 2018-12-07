
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
            "SERVER = GREIVIN; DATABASE = DB_BUFFET_NEXXON; USER ID = sa; PASSWORD = N3xx0n";

        public string ConnectionString { get => connectionString; set => connectionString = value; }
        #endregion

        #region DB Params
        private string spAuthentication = "spAutenticarUsuario";
        public string SpAuthentication { get => spAuthentication; set => spAuthentication = value; }

        private string tblAuthentication = "T_USUARIO";
        public string TblAuthentication { get => tblAuthentication; set => tblAuthentication = value; }
        #endregion

    }
}

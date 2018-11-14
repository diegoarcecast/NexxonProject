
namespace Nexxon.Views
{

    using Nexxon.Models;
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Vista del menú principal
    /// </summary>
    public sealed partial class RootPage : Page
    {
        public RootPage()
        {
            this.InitializeComponent();
            SideMenuView.ItemsSource = Test;
        }

        public List<RootItems> Test { get; set; } = new List<RootItems>
        {
            new RootItems
            {
                Icon = "\uE13D",
                Name = "Clientes"
            },
            new RootItems
            {
                Icon = "\uE8B7",
                Name = "Expedientes"
            },
            new RootItems
            {
                Icon = "\uE163",
                Name = "Agenda"
            },
            new RootItems
            {
                Icon = "\uE8C7",
                Name = "Pagos"
            },
            new RootItems
            {
                Icon = "\uE136",
                Name = "Perfil"
            },
            new RootItems
            {
                Icon = "\uE8BD",
                Name = "Notificaciones"
            }
        };

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }

        private void SideMenuView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var items = (RootItems)e.ClickedItem;
            switch (items.Name.ToString())
            {
                case "Clientes":
                    ContentFrame.Navigate(typeof(RootClientPage));
                    break;
                case "Expedientes":
                    ContentFrame.Navigate(typeof(RootRecordsPage));
                    break;
                case "Agenda":
                    ContentFrame.Navigate(typeof(Agenda.RootAgendaPage));
                    break;
                case "Pagos":
                    //ContentFrame.Navigate(typeof());
                    break;
                case "Perfil":
                    //ContentFrame.Navigate(typeof());
                    break;
                case "Notificaciones":
                    //ContentFrame.Navigate(typeof());
                    break;
                default:
                    Application.Current.Exit();
                    break;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
            }
        }
    }
}

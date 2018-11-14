
namespace Nexxon.Views
{
    using Nexxon.Models;
    using System.Collections.Generic;
    using Windows.UI.Xaml.Controls;

    public sealed partial class RootClientPage : Page
    {
        public RootClientPage()
        {
            this.InitializeComponent();
            MenuClient.ItemsSource = Test;
        }

        public List<RootClientItems> Test { get; set; } = new List<RootClientItems>
        {
            new RootClientItems
            {
                Name = "Agregar cliente"
            },
            new RootClientItems
            {
                Name = "Buscar cliente"
            }
        };

        private void MenuClient_ItemClick(object sender, ItemClickEventArgs e)
        {
            var items = (RootClientItems)e.ClickedItem;
            switch (items.Name.ToString())
            {
                case "Agregar cliente":
                    ContentFrame.Navigate(typeof(AddClientPage));
                    break;
                case "Buscar cliente":
                    ContentFrame.Navigate(typeof(FindClientPage));
                    break;
            }
        }
    }
}

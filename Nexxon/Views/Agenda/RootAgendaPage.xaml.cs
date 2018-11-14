//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.InteropServices.WindowsRuntime;
//using Windows.Foundation;
//using Windows.Foundation.Collections;
//using Windows.UI.Xaml;
//using Windows.UI.Xaml.Controls;
//using Windows.UI.Xaml.Controls.Primitives;
//using Windows.UI.Xaml.Data;
//using Windows.UI.Xaml.Input;
//using Windows.UI.Xaml.Media;
//using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nexxon.Views.Agenda
{
    using Nexxon.Models;
    using System.Collections.Generic;
    using Windows.UI.Xaml.Controls;

    public sealed partial class RootAgendaPage : Page
    {
        public RootAgendaPage()
        {
            this.InitializeComponent();
            MenuAgenda.ItemsSource = Test;
        }

        public List<RootAgendaItems> Test { get; set; } = new List<RootAgendaItems>
        {
            new RootAgendaItems
            {
                Name = "Ver agenda"
            },
            new RootAgendaItems
            {
                Name = "Crear un evento"
            }
        };

        private void MenuAgenda_ItemClick(object sender, ItemClickEventArgs e)
        {
            var items = (RootAgendaItems)e.ClickedItem;
            switch (items.Name.ToString())
            {
                case "Ver agenda":
                    ContentFrame.Navigate(typeof(DetailsAgendaPage));
                    break;
                case "Crear un evento":
                    ContentFrame.Navigate(typeof(CreateEventAgendaPage));
                    break;
            }
        }
    }
}

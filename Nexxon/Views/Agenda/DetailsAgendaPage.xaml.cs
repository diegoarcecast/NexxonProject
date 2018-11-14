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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nexxon.Views.Agenda
{
    using Nexxon.Models;
    using System.Collections.Generic;
    using Windows.UI.Xaml.Controls;

    public sealed partial class DetailsAgendaPage : Page
    {
        public DetailsAgendaPage()
        {
            this.InitializeComponent();
            EventsList.ItemsSource = Test;
        }

        public List<EventListAgendaItems> Test { get; set; } = new List<EventListAgendaItems>
        {
            new EventListAgendaItems
            {
                Name = "3:00 p.m. - Reunion"
            },
            new EventListAgendaItems
            {
                Name = "4:00 p.m. - Tomar cafe"
            }
        };

        private void EventList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

    }
}

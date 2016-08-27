using GroupeCinema;
using GroupeCinema.API;
using GroupeCinema.Cinema;
using GroupeCinema.Cinema.Entities;
using GroupeCinema.Database;
using GroupeCinema.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfGroupeCinema.Views;
using WpfGroupeCinema.Views.Pages;

namespace WpfGroupeCinema.ViewModel
{
    public class HomeEnterViewModel
    {
        private HomeEnterView homeEnterView;

        public HomeEnterView HomeEnterView
        {
            get { return homeEnterView; }
            set { homeEnterView = value; }
        }

        public HomeEnterViewModel(HomeEnterView homeEnterView)
        {
            this.homeEnterView = homeEnterView;

            this.HomeEnterView.cinemaListUserControl.cinemasListView.SelectionChanged += CinemasListView_SelectionChanged;

            Logs();

            SetupCinemaList();
        }
        private async void SetupCinemaList()
        {
            List<Cinema> results = new List<Cinema>();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Cinema> manager5 = new MySQLManager<Cinema>(DataConnectionResource.LOCALMYQSL);
                results = manager5.Get().Result as List<Cinema>;
                
            });

            //Crud<Cinema> manager5 = new Crud<Cinema>();
            //results = manager5.Get().Result as List<Cinema>;

            if (results != null)
            {
                this.HomeEnterView.cinemaListUserControl.LoadItems(results);
            }

        }

        // Test Notif
        public void Observabler()
        {
            ObservedClass obs = new ObservedClass();
            NotifiedClass n1 = new NotifiedClass();
            NotifiedClass n2 = new NotifiedClass();
        }


        private void CinemasListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((Cinema)e.AddedItems[0] != null)
            {
                Cinema cinema = new Cinema();
                cinema = (Cinema)e.AddedItems[0];
                this.homeEnterView.cinemaUserControl.Cinema = (Cinema)e.AddedItems[0];                
            }
        }
        
        
        private void Logs()
        {
            //Logger logger = new Logger(LogMode.EXTERNAL, AlertMode.MESSAGE_BOX);
            //logger.Log("Bienvenue sur le groupement de cinema");
            /*MessageBoxResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }*/
            //MessageBoxResult result = MessageBox.Show("Bienvenue sur le groupement de cinema", "GroupeCinema");
        }

        
    }
}

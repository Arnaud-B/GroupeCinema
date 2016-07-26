using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfGroupeCinema.ViewModel;
using GroupeCinema.Cinema;
using WpfGroupeCinema.Views.Pages;

namespace WpfGroupeCinema.Views
{
    /// <summary>
    /// Interaction logic for CinemaEnterView.xaml
    /// </summary>
    public partial class CinemaEnterView : Page
    {
        private CinemaEnterViewModel cinemaEnterViewModel;

        public CinemaEnterViewModel CinemaEnterViewModel
        {
            get { return cinemaEnterViewModel; }
            set { cinemaEnterViewModel = value; }
        }

        public CinemaEnterView()
        {
            InitializeComponent();
            this.cinemaEnterViewModel = new CinemaEnterViewModel(this);
        }

        private void BtnNavigate1_Click(object sender, RoutedEventArgs e)
        {
            //this.Content = new RegularClientEnterView();
            this.NavigationService.Navigate(new Page2());
        }
        /*private void BtnNavigate2_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow1 window = new NavigationWindow1();
            window.Show();
            //this.NavigationService.Navigate(new Page2());
        }*/
    }
}

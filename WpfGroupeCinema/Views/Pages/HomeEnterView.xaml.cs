using GroupeCinema.Cinema;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfGroupeCinema.ViewModel;

namespace WpfGroupeCinema.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomeEnterView : Page
    {
        private HomeEnterViewModel homeEnterViewModel;

        public HomeEnterViewModel HomeEnterViewModel
        {
            get
            {
                return homeEnterViewModel;
            }
            set
            {
                homeEnterViewModel = value;
            }
        }
        public HomeEnterView()
        {
            InitializeComponent();
            this.homeEnterViewModel = new HomeEnterViewModel(this);
        }

        private void myBtn_Click(object sender, RoutedEventArgs e)
        {
            
            Cinema cinemaChoose = homeEnterViewModel.HomeEnterView.cinemaUserControl.Cinema;
            if(cinemaChoose != null)
            {
                this.NavigationService.Navigate(new HomeCinemaEnterView(cinemaChoose));
            }
            
        }
    }
}

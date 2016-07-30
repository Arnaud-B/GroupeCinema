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
    /// Interaction logic for DrinkableEnterView.xaml
    /// </summary>
    public partial class DrinkableEnterView : Page
    {
        private DrinkableEnterViewModel drinkableEnterViewModel;
        private Cinema cinema;

        public DrinkableEnterViewModel DrinkableEnterViewModel
        {
            get { return drinkableEnterViewModel; }
            set { drinkableEnterViewModel = value; }
        }

        public DrinkableEnterView()
        {
            InitializeComponent();
            this.drinkableEnterViewModel = new DrinkableEnterViewModel(this);
        }

        public DrinkableEnterView(Cinema cinema)
        {
            InitializeComponent();
            this.drinkableEnterViewModel = new DrinkableEnterViewModel(this);
            this.cinema = cinema;
            DrinkableEnterViewModel.DrinkableEnterView.cinemaUserControl.Cinema = cinema;
        }

        private void BtnNavigate2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomeEnterView());
        }
    }
}

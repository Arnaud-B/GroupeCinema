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
    /// Interaction logic for SelectDrinkableEnterView.xaml
    /// </summary>
    public partial class SelectDrinkableEnterView : Page
    {
        private SelectDrinkableEnterViewModel selectDrinkableEnterViewModel;

        public SelectDrinkableEnterViewModel SelectDrinkableEnterViewModel
        {
            get { return selectDrinkableEnterViewModel; }
            set { selectDrinkableEnterViewModel = value; }
        }

        public SelectDrinkableEnterView()
        {
            InitializeComponent();
            this.selectDrinkableEnterViewModel = new SelectDrinkableEnterViewModel(this);
        }

        public SelectDrinkableEnterView(Cinema cinema, Drinkable drinkable)
        {
            InitializeComponent();
            this.selectDrinkableEnterViewModel = new SelectDrinkableEnterViewModel(this, cinema, drinkable);

            this.selectDrinkableEnterViewModel.SelectDrinkableEnterView.updateDrinkableUserControl.Drinkable = drinkable;
            this.selectDrinkableEnterViewModel.SelectDrinkableEnterView.cinemaUserControl.Cinema = cinema;
            this.selectDrinkableEnterViewModel.SelectDrinkableEnterView.homeUserControl.BtnHome.Click += BtnNavigate_Click;
        }


        private void BtnNavigate_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want go to home ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.NavigationService.Navigate(new HomeEnterView());
            }
        }

        
    }
}

using GroupeCinema.Cinema;
using GroupeCinema.Database;
using GroupeCinema.Enums;
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
    /// Interaction logic for AddMovieEnterView.xaml
    /// </summary>
    public partial class AddMovieEnterView : Page
    {
        private AddMovieEnterViewModel addMovieEnterViewModel;
        private Cinema cinema;

        public AddMovieEnterViewModel AddMovieEnterViewModel
        {
            get { return addMovieEnterViewModel; }
            set { addMovieEnterViewModel = value; }
        }
        public AddMovieEnterView()
        {
            InitializeComponent();
            this.addMovieEnterViewModel = new AddMovieEnterViewModel(this);
        }

        public AddMovieEnterView(Cinema cinema)
        {
            InitializeComponent();
            this.cinema = cinema;
            this.addMovieEnterViewModel = new AddMovieEnterViewModel(this, cinema);
            AddMovieEnterViewModel.AddMovieEnterView.cinemaUserControl.Cinema = cinema;
        }

        private void BtnNavigate2_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want go to home ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.NavigationService.Navigate(new HomeEnterView());
            }
        }
    }
}

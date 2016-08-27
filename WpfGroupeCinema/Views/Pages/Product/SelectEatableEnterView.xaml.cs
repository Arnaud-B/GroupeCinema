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
    /// Interaction logic for SelectEatableEnterView.xaml
    /// </summary>
    public partial class SelectEatableEnterView : Page
    {

        private SelectEatableEnterViewModel selectEatableEnterViewModel;

        public SelectEatableEnterViewModel SelectEatableEnterViewModel
        {
            get { return selectEatableEnterViewModel; }
            set { selectEatableEnterViewModel = value; }
        }

        public SelectEatableEnterView()
        {
            InitializeComponent();
            this.selectEatableEnterViewModel = new SelectEatableEnterViewModel(this);
        }

        public SelectEatableEnterView(Cinema cinema, Eatable eatable)
        {
            InitializeComponent();
            this.selectEatableEnterViewModel = new SelectEatableEnterViewModel(this, cinema, eatable);

            SelectEatableEnterViewModel.SelectEatableEnterView.updateEatableUserControl.Eatable = eatable;
            this.selectEatableEnterViewModel.SelectEatableEnterView.cinemaUserControl.Cinema = cinema;
            this.selectEatableEnterViewModel.SelectEatableEnterView.homeUserControl.BtnHome.Click += BtnNavigate_Click;
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

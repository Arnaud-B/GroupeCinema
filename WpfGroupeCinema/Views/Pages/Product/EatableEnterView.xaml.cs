using GroupeCinema.API;
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
    /// Interaction logic for EatableEnterView.xaml
    /// </summary>
    public partial class EatableEnterView : Page
    {
        private EatableEnterViewModel eatableEnterViewModel;
        private Cinema cinema;

        public EatableEnterViewModel EatableEnterViewModel
        {
            get { return eatableEnterViewModel; }
            set { eatableEnterViewModel = value; }
        }

        public EatableEnterView()
        {
            InitializeComponent();
            this.eatableEnterViewModel = new EatableEnterViewModel(this);
        }

        public EatableEnterView(Cinema cinema)
        {
            InitializeComponent();
            this.eatableEnterViewModel = new EatableEnterViewModel(this, cinema);
            EatableEnterViewModel.EatableEnterView.homeUserControl.BtnHome.Click += BtnNavigate_Click;
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

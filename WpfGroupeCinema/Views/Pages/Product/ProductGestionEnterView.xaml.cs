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
using System.Windows.Shapes;
using WpfGroupeCinema.ViewModel;

namespace WpfGroupeCinema.Views
{
    /// <summary>
    /// Interaction logic for ProcuctGestionEnterView.xaml
    /// </summary>
    public partial class ProductGestionEnterView : Page
    {
        private Cinema cinema;
        private ProductGestionEnterViewModel productGestionEnterViewModel;
        private Eatable eatable;
        private Drinkable drinkable;

        public ProductGestionEnterViewModel ProductGestionEnterViewModel
        {
            get { return productGestionEnterViewModel; }
            set { productGestionEnterViewModel = value; }
        }

        public ProductGestionEnterView()
        {
            InitializeComponent();
            this.productGestionEnterViewModel = new ProductGestionEnterViewModel(this);
        }
        public ProductGestionEnterView(Cinema cinema)
        {
            InitializeComponent();   
            this.cinema = cinema;
            this.productGestionEnterViewModel = new ProductGestionEnterViewModel(this, cinema);


            ProductGestionEnterViewModel.ProductGestionEnterView.eatableListUserControl.eatablesListView.SelectionChanged += EatableListView_Changed;
            ProductGestionEnterViewModel.ProductGestionEnterView.drinkableListUserControl.drinkablesListView.SelectionChanged += DrinkableListView_Changed;

            ProductGestionEnterViewModel.ProductGestionEnterView.chooseProductUserControl.btnChoose.Click += BtnChoose_Click;
            ProductGestionEnterViewModel.ProductGestionEnterView.cinemaUserControl.Cinema = cinema;
            ProductGestionEnterViewModel.ProductGestionEnterView.homeUserControl.BtnHome.Click += BtnNavigate_Click;
        }

        private void EatableListView_Changed(object sender, SelectionChangedEventArgs e)
        {
            if ((Eatable)e.AddedItems[0] != null)
            {
                Eatable eatable = new Eatable();
                eatable = (Eatable)e.AddedItems[0];
                this.eatable = eatable;
            }
        }

        private void DrinkableListView_Changed(object sender, SelectionChangedEventArgs e)
        {
            if ((Drinkable)e.AddedItems[0] != null)
            {
                Drinkable drinkable = new Drinkable();
                drinkable = (Drinkable)e.AddedItems[0];
                this.drinkable = drinkable;
            }
        }

        private void BtnChoose_Click(object sender, RoutedEventArgs e)
        {
            if (this.eatable != null)
            {
                this.NavigationService.Navigate(new SelectEatableEnterView(this.cinema, this.eatable));
            }
            else if (this.drinkable != null)
            {
                this.NavigationService.Navigate(new SelectDrinkableEnterView(this.cinema, this.drinkable));
            }
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

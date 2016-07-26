﻿using GroupeCinema.Cinema;
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
    /// Interaction logic for ProductEnterView.xaml
    /// </summary>
    public partial class ProductEnterView : Page
    {
        private ProductEnterViewModel productEnterViewModel;
        private Cinema cinema;

        public ProductEnterViewModel ProductEnterViewModel
        {
            get { return productEnterViewModel; }
            set { productEnterViewModel = value; }
        }

        public ProductEnterView()
        {
            InitializeComponent();
            this.productEnterViewModel = new ProductEnterViewModel(this);
        }

        public ProductEnterView(Cinema cinema)
        {
            InitializeComponent();
            this.productEnterViewModel = new ProductEnterViewModel(this);
            this.cinema = cinema;
            ProductEnterViewModel.ProductEnterView.cinemaUserControl.Cinema = cinema;
        }


        private void BtnNavigate2_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new Page2());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (this.cinema != null)
            {
                this.NavigationService.Navigate(new AddProductEnterView(this.cinema));
            }
        }
    }
}
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
            this.productGestionEnterViewModel = new ProductGestionEnterViewModel(this,cinema);
            ProductGestionEnterViewModel.ProductGestionEnterView.cinemaUserControl.Cinema = cinema;
        }

        private void BtnNavigate2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomeEnterView());
        }



    }
}
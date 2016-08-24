using GroupeCinema.Cinema;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfGroupeCinema.CinemaListUserControl
{
    /// <summary>
    /// Interaction logic for ProductListUserControl.xaml
    /// </summary>
    public partial class ProductListUserControl : BaseUserControl
    {
        #region Attributes
        private ObservableCollection<Product> products;
        #endregion
        public ListView listView { get; set; }

        public object MyListBoxSelectedValue
        {
            get { return ListBox.SelectedEvent; }
        }

        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set
            {
                this.products = value;
                OnPropertyChanged("Products");
            }
        }
       

        public ProductListUserControl()
        {
            InitializeComponent();
            this.Products = new ObservableCollection<Product>();
            this.productsListView.ItemsSource = this.Products;
            this.listView = this.productsListView;
        }

        public void LoadItems(List<Product> items)
        {
            this.Products.Clear();
            foreach (var item in items)
            {
                Products.Add(item);
            }
        }
    }
}

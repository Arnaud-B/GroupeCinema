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

namespace WpfGroupeCinema.CinemaListUserControl
{
    /// <summary>
    /// Interaction logic for UpdateDrinkableUserControl.xaml
    /// </summary>
    public partial class UpdateDrinkableUserControl : BaseUserControl
    {
   
        private Drinkable drinkable;

        public Drinkable Drinkable
        {
            get
            {
                return drinkable;
            }
            set
            {
                drinkable = value;
                OnPropertyChanged("Drinkable");
            }
        }
        public UpdateDrinkableUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public String Name
        {
            get { return drinkableNameTxtB.Text; }
            set { drinkableNameTxtB.Text = value; }
        }
        public String Price
        {
            get { return drinkablePriceTxtB.Text; }
            set { drinkablePriceTxtB.Text = value; }
        }
        public String Liter
        {
            get { return drinkableLiterTxtB.Text; }
            set { drinkableLiterTxtB.Text = value; }
        }
        public String Number
        {
            get { return drinkableNumberTxtB.Text; }
            set { drinkableNumberTxtB.Text = value; }
        }
    }
}

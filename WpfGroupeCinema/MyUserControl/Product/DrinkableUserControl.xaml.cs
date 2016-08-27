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
using WpfGroupeCinema.CinemaListUserControl;

namespace WpfGroupeCinema.CinemaListUserControl
{
    /// <summary>
    /// Interaction logic for DrinkableUserControl.xaml
    /// </summary>
    public partial class DrinkableUserControl : BaseUserControl
    {
        private Drinkable drinkable;

        public Drinkable Drinkable
        {
            get { return drinkable; }
            set
            {
                drinkable = value;
                OnPropertyChanged("Drinkable");
            }
        }

        public DrinkableUserControl()
        {
            //InitializeComponent();
            this.DataContext = this;
        }
    }
}

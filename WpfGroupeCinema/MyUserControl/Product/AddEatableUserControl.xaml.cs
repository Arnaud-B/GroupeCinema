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
    /// Interaction logic for AddEatableUserControl.xaml
    /// </summary>
    public partial class AddEatableUserControl : BaseUserControl
    {
        private Eatable eatable;

        public Eatable Eatable
        {
            get
            {
                return eatable;
            }
            set
            {
                eatable = value;
                OnPropertyChanged("Eatable");
            }
        }
        public String Name
        {
            get { return eatableNameTxtB.Text; }
            set { eatableNameTxtB.Text = value; }
        }
        public String Price
        {
            get { return eatablePriceTxtB.Text; }
            set { eatablePriceTxtB.Text = value; }
        }
        public String Weight
        {
            get { return eatableWeightTxtB.Text; }
            set { eatableWeightTxtB.Text = value; }
        }
        public String Number
        {
            get { return eatableNumberTxtB.Text; }
            set { eatableNumberTxtB.Text = value; }
        }
        public AddEatableUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}

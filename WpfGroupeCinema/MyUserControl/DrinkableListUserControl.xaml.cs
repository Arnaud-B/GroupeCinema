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
using System.Windows.Shapes;
using WpfGroupeCinema.CinemaListUserControl;

namespace WpfGroupeCinema.MyUserControl
{
    /// <summary>
    /// Interaction logic for DrinkableListUserControl.xaml
    /// </summary>
    public partial class DrinkableListUserControl : BaseUserControl
    {

        private ObservableCollection<Drinkable> drinkables;

        public ObservableCollection<Drinkable> Drinkables
        {
            get { return this.drinkables; }
            set
            {
                this.drinkables = value;
                OnPropertyChanged("Drinkables");
            }
        }

        public DrinkableListUserControl()
        {
            //InitializeComponent();
            this.Drinkables = new ObservableCollection<Drinkable>();
            //this.drinkablesListView.ItemsSource = this.Drinkables;
        }

        public void LoadItems(List<Drinkable> items)
        {
            this.Drinkables.Clear();
            foreach (var item in items)
            {
                Drinkables.Add(item);
            }
        }
    }
}

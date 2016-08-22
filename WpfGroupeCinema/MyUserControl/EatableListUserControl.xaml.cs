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

namespace WpfGroupeCinema.CinemaListUserControl
{
    /// <summary>
    /// Interaction logic for ProductListUserControl.xaml
    /// </summary>
    public partial class EatableListUserControl : BaseUserControl
    {
        private ObservableCollection<Eatable> eatables;

        public ObservableCollection<Eatable> Eatables
        {
            get { return this.eatables; }
            set
            {
                this.eatables = value;
                OnPropertyChanged("Products");
            }
        }

        public EatableListUserControl()
        {
            InitializeComponent();
            this.Eatables = new ObservableCollection<Eatable>();
            this.eatablesListView.ItemsSource = this.Eatables;
        }

        public void LoadItems(List<Eatable> items, Cinema cinema)
        {
            this.Eatables.Clear();
            foreach (var item in items)
            {
              
                if (item.Cinema_id == cinema.Id)
                {
                    Eatables.Add(item);

                }
            }
        }
    }
}

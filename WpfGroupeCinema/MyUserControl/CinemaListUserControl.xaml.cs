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
    /// Interaction logic for CinemaListUserControl.xaml
    /// </summary>
    public partial class CinemaListUserControl : BaseUserControl
    {

        #region Attributes
        private ObservableCollection<Cinema> cinemas;
        #endregion
        public ListView listView { get; set; }

        public object MyListBoxSelectedValue
        {
            get { return ListBox.SelectedEvent; }
        }

        public ObservableCollection<Cinema> Cinemas
        {
            get { return this.cinemas; }
            set
            {
                this.cinemas = value;
                OnPropertyChanged("Cinemas");
            }
        }

        public CinemaListUserControl()
        {
            InitializeComponent();
            this.Cinemas = new ObservableCollection<Cinema>();
            this.cinemasListView.ItemsSource = this.Cinemas;
            this.listView = this.cinemasListView;
        }

        public void LoadItems(List<Cinema> items)
        {
            this.Cinemas.Clear();
            foreach (var item in items)
            {
                Cinemas.Add(item);
            }
        }

        /*private void myBtn2_Click(object sender, RoutedEventArgs e)
        {
            Cinema cineSelected = (Cinema)cinemasListView.SelectedItem;
            Console.WriteLine(cineSelected.Id);
        }*/

    }
}

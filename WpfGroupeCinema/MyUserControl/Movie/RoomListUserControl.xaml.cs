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
    /// Interaction logic for RoomListUserControl.xaml
    /// </summary>
    public partial class RoomListUserControl : BaseUserControl
    {
      
        #region Attributes
        private ObservableCollection<Room> rooms;
        #endregion
        public ListView listView { get; set; }

        public object MyListBoxSelectedValue
        {
            get { return ListBox.SelectedEvent; }
        }

        public ObservableCollection<Room> Rooms
        {
            get { return this.rooms; }
            set
            {
                this.rooms = value;
                OnPropertyChanged("Rooms");
            }
        }

        public RoomListUserControl()
        {
            InitializeComponent();
            this.Rooms = new ObservableCollection<Room>();
            this.roomsListView.ItemsSource = this.Rooms;
            this.listView = this.roomsListView;
        }

        public void LoadItems(List<Room> items)
        {
            this.Rooms.Clear();
            foreach (var item in items)
            {
                Rooms.Add(item);
            }
        }
        public void LoadItems(List<Room> items, Cinema cinema)
        {
            this.Rooms.Clear();
            foreach (var item in items)
            {
                if(item.Cinema_id == cinema.Id)
                {
                    Rooms.Add(item);
                }
            }
        }

    }
}

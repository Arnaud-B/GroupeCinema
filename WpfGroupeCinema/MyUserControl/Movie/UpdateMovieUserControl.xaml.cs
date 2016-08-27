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
    /// Interaction logic for UpdateMovieUserControl.xaml
    /// </summary>
    public partial class UpdateMovieUserControl : BaseUserControl
    {

        private Movie movie;
        private MovieRoom movieRoom;

        public Movie Movie
        {
            get { return movie; }
            set
            {
                movie = value;
            }
        }

        public MovieRoom MovieRoom
        {
            get { return movieRoom; }
            set
            {
                movieRoom = value;
            }
        }

        public String Name
        {
            get { return movieNameTxtB.Text; }
            set { movieNameTxtB.Text = value; }
        }
        public String Author
        {
            get { return movieAuthorTxtB.Text; }
            set { movieAuthorTxtB.Text = value; }
        }
        public String Length
        {
            get { return movieLengthTxtB.Text; }
            set { movieLengthTxtB.Text = value; }
        }
        public String RentTime
        {
            get { return movieRentTimeTxtB.Text; }
            set { movieRentTimeTxtB.Text = value; }
        }

        public UpdateMovieUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}

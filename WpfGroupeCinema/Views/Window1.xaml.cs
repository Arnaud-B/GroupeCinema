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

namespace WpfGroupeCinema.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void BtnNavigate1_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new Page2());
            //this.Content = new RegularClientEnterView();
        }
        private void BtnNavigate2_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow1 window = new NavigationWindow1();
            window.Show();

        }
    }
}

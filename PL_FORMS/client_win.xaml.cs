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

namespace PL_FORMS
{
    /// <summary>
    /// Interaction logic for client_win.xaml
    /// </summary>
    public partial class client_win : Window
    {
        public client_win()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new add_client_win().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new update_client_win().Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new delet_client_w_in().Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new BLFactory.BlFactory().GetBL().createListOfClient();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new show_cli().Show();
        }

    }
}

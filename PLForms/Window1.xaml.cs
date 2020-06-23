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

namespace PLForms
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

        private void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client_register_window crw = new client_register_window();
            add_car ac = new add_car();
            add_fault af = new add_fault();
            switch (MainWindow.a)
            {
                case 0:
                    crw.Show();
                    break;
                case 1:
                    ac.Show();
                    break;
                case 2:
                    af.Show();
                    break;
                default:
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            delete_client dc = new delete_client();
            dc.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow.add_rand();
        }
    }
}

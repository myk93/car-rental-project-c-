using System;
using BL_WcfService;
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
using wcf_UI.ServiceReference1;

namespace wcf_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = new ref_factory.Class1().GetBL() ; 
        public MainWindow()
        {
         
            InitializeComponent();
        }

        private void buut_clie_Click(object sender, RoutedEventArgs e)
        {
            new add_client_win().Show();
        }

        private void buut_car_Click(object sender, RoutedEventArgs e)
        {
            new add_car_win().Show();
        }

        private void buut_rent_Click(object sender, RoutedEventArgs e)
        {
            new add_rent_win().Show();
        }

        private void mida_client_Click(object sender, RoutedEventArgs e)
        {
            new show_cli().Show();
        }

        private void mida_car_Click(object sender, RoutedEventArgs e)
        {
            new show_car().Show();

        }

        private void mida_rent_Click(object sender, RoutedEventArgs e)
        {
            new mida_rent().Show();

        }

        private void del_client_Click(object sender, RoutedEventArgs e)
        {
            new delet_client_w_in().Show();
        }

        private void del_car_Click(object sender, RoutedEventArgs e)
        {
            new delet_car_w_in().Show();
        }

        private void del_rent_Click(object sender, RoutedEventArgs e)
        {
            new dele_rent_win().Show();
        }
    }
}

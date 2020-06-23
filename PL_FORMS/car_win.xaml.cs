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
    /// Interaction logic for car_win.xaml
    /// </summary>
    public partial class car_win : Window
    {
        
        public car_win()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new add_car_win().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new update_car_win().Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new delet_car_w_in().Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new BLFactory.BlFactory().GetBL().createListOfCar();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new show_car().Show();
        }

    }
}

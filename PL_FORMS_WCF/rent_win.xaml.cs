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
    /// Interaction logic for rent_win.xaml
    /// </summary>
    public partial class rent_win : Window
    {
        public rent_win()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new add_rent_win().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new update_rent_win().Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new dele_rent_win().Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new END_rent_win().Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new mida_rent().Show();
        }
    }
}

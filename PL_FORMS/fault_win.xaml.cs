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
    /// Interaction logic for fault_win.xaml
    /// </summary>
    public partial class fault_win : Window
    {
        public fault_win()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new addd_fault_win().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new update_fault_win().Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new dele_fault_win().Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new BLFactory.BlFactory().GetBL().createListOfFault();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new show_fault().Show();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            new conect_fault().Show();
        }
    }
}

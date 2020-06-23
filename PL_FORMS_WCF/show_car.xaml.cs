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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class show_car : Window
    {
        public show_car()
        {
            InitializeComponent();
            dg_r.ItemsSource = new BLFactory.BlFactory().GetBL().return_list(BE.retur.car);
        }

        private void dg_r_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dg_r_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

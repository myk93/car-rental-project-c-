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
    /// Interaction logic for show_fault.xaml
    /// </summary>
    public partial class show_fault : Window
    {
        public show_fault()
        {
            InitializeComponent();
            dg_d.ItemsSource = new BLFactory.BlFactory().GetBL().return_list(BE.retur.fault);
        }
    }
}

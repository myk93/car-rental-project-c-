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

namespace wcf_UI
{
    /// <summary>
    /// Interaction logic for show_cli.xaml
    /// </summary>
    public partial class show_cli : Window
    {
        public show_cli()
        {
            InitializeComponent();
            dg_d.ItemsSource = new ref_factory.Class1().GetBL().return_list(BE.retur.client);
        }
    }
}

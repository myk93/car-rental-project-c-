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
using BL;
using BLFactory;
namespace PLForms
{
    /// <summary>
    /// Interaction logic for delete_client.xaml
    /// </summary>
    public partial class delete_client : Window
    {
        public delete_client()
        {
            InitializeComponent();
            this.Loaded += vt;
        }

        private void vt(object sender, RoutedEventArgs e)
        {
            switch (MainWindow.a)
            {
                case 0:
                    foreach (BE.Client item in new BlFactory().GetBL().return_list(BE.retur.client))
                    {
                        cb_del.Items.Add(item.Id1);
                    }
                    break;
                case 1:
                    foreach (BE.car item in new BlFactory().GetBL().return_list(BE.retur.car))
                    {
                        cb_del.Items.Add(item.car_number);
                    }
                    break;
                case 2:
                    foreach (BE.Fault item in new BlFactory().GetBL().return_list(BE.retur.fault))
                    {
                        cb_del.Items.Add(item.fault_number);
                    }
                    break;
                case 3:
                    foreach (BE.Renting item in new BlFactory().GetBL().return_list(BE.retur.renting))
                    {
                        cb_del.Items.Add(item.running_code);
                    }
                    break;
                default:
                    break;
            }
        }

        private void cb_del_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                    MainWindow.del_number(cb_del.SelectedItem);
        }
    }
}

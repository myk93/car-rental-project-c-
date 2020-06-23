using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
namespace PL_FORMS
{
    /// <summary>
    /// Interaction logic for ma_win.xaml
    /// </summary>
    public partial class ma_win : Window
    {
        IBL bl;
        public ma_win()
        {
            bl = new BLFactory.BlFactory().GetBL();
            InitializeComponent();
            new Thread(() =>
            {
                while (true)
                {
                    foreach (Client item in bl.return_list(retur.client))
                    {
                        try
                        {
                            bl.update_time_adn_distance(item.Id1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                    Thread.Sleep(1000000);
                }

            }).Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new client_win().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new car_win().Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new rent_win().Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new fault_win().Show();
        }
    }
}

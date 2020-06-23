using BL;
using BLFactory;
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
    /// Interaction logic for delet_car_w_in.xaml
    /// </summary>
    public partial class delet_car_w_in : Window
    {
        IBL bl = new BlFactory().GetBL();

        public delet_car_w_in()
        {
            InitializeComponent();
            foreach (BE.car item in bl.return_list(BE.retur.car))
            {
                cb_car.Items.Add(item.car_number);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.del_car((int)cb_car.SelectedItem);
                MessageBox.Show("הרכב נמחק בהצלחה");
                cb_car.Items.Clear();
                foreach (BE.car item in bl.return_list(BE.retur.car))
                {
                    cb_car.Items.Add(item.car_number);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("אתה בטוח שברצונך לבטל", "אזהרה", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}

using BE;
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
    /// Interaction logic for test_date.xaml
    /// </summary>
    public partial class test_date : Window
    {
        IBL bl = new BlFactory().GetBL();
        public test_date()
        {
            InitializeComponent();
            for (int i = 1; i < 13; i++)
                month_test.Items.Add(i);
            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++)
                year_test.Items.Add(i);
            car m = ((IList<car>)(bl.return_list(retur.car))).Where(a => a.car_number == update_car_win.car_number).First();
            month_test.SelectedItem = m.date_of_fix.Value.Month;
            year_test.SelectedItem = m.date_of_fix.Value.Year;

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
              bl.update_car(update_car_win.car_number, update.date_test,new DateTime?( new DateTime((int)year_test.SelectedItem,(int)month_test.SelectedItem,1)));
                MessageBox.Show("הרכב עודכן בהצלחה");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("אתה בטוח שברצונך לבטל", "אזהרה", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}

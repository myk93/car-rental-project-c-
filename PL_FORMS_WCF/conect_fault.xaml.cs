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
    /// Interaction logic for conect_fault.xaml
    /// </summary>
    public partial class conect_fault : Window
    {
        IBL bl = new BlFactory().GetBL();
        int f_number;
        public conect_fault()
        {

            InitializeComponent();
            foreach (BE.car item in bl.return_list(BE.retur.car))
            {
                cb_mr.Items.Add(item.car_number);
            }
            dg_f.ItemsSource = bl.return_list(BE.retur.fault);
        
        }

        public conect_fault(int p)
        {
            InitializeComponent();

           
            dg_f.ItemsSource = bl.return_list(BE.retur.fault);

            cb_mr.Items.Add(p);
            cb_mr.SelectedItem = p;
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
       
            if (MessageBox.Show("אתה בטוח שברצונך לבטל", "אזהרה", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cb_mr.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור מספר רכב", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Date.SelectedDate.HasValue)
            {
                MessageBox.Show("צריך להכניס תאריך תקלה", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (!DateCm.SelectedDate.HasValue)
            {
                MessageBox.Show("צריך להכניס תאריך חזרה מתיקון", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            try
            {
                 bl.add_Car_fault(new BE.Car_Fault((int)cb_mr.SelectedItem, f_number, Date.SelectedDate.Value, DateCm.SelectedDate.Value));
                MessageBox.Show("הקשר נוצר בהצלחה", "הודעה", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new addd_fault_win().Show();
        }

        private void dg_f_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            f_number = ((BE.Fault)dg_f.SelectedItem).fault_number;
        }
    }
}

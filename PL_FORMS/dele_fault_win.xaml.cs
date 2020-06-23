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
    /// Interaction logic for dele_fault_win.xaml
    /// </summary>
    public partial class dele_fault_win : Window
    {
        public dele_fault_win()
        {
            InitializeComponent();
            foreach (Fault item in bl.return_list(retur.fault))
            {
                cb_num.Items.Add(item.fault_number);
            }
        }
        IBL bl = new BlFactory().GetBL();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_num.SelectedIndex==-1)
            {
                MessageBox.Show("צריך לבחור את מה למחוק", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cb_car.SelectedIndex==-1)
            {
                MessageBox.Show("צריך לבחור איזה קשר למחוק", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cb_car.SelectedIndex==0)
            {
                try
                {
                     bl.del_Fault((int)cb_num.SelectedItem);
                    MessageBox.Show("התקלה נמחקה בהצלחה");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"שגיאה",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                return;
            }
            try
            {
                bl.Del_car_fault((int)cb_car.SelectedItem, (int)cb_num.SelectedItem);
                    MessageBox.Show("הקשר נמחק בהצלחה");
                    this.Close();
            }
            catch (Exception ex)
            {
                  MessageBox.Show(ex.Message,"שגיאה",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void cb_num_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_car.Items.Clear();
            cb_car.Items.Add("\n כולל כל הקשריםה כל");
            foreach (Car_Fault item in bl.return_list(retur.car_fault))
            {
                if (item.fault_number==(int)cb_num.SelectedValue)
                {
                    cb_car.Items.Add(item.id);
                }
            }
            if (cb_car.Items.Count==1)
            {
                cb_car.Items.Clear();
                cb_car.Items.Add("אין רכבים מקושרים\n זהימחוק רק את התקלה");
            }
            cb_car.IsEditable = true;
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

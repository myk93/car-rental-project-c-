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
    /// Interaction logic for update_car_win.xaml
    /// </summary>
    public partial class update_car_win : Window
    {
        adrescar ad;
        test_date td;
        static public int car_number;
        bool temp = false;
        IBL bl = new BlFactory().GetBL();

        public update_car_win()
        {
            InitializeComponent();
            foreach (BE.car item in bl.return_list(BE.retur.car))
            {
                cb_car.Items.Add(item.car_number);
            }
            cb_nosa.Items.Add("ק\"מ (מרחק) להוסיף");
            cb_nosa.Items.Add("כתובת הרכב");
            cb_nosa.Items.Add("תקינות הרכב");
            cb_nosa.Items.Add("תאריך הטסט");
            cb_nosa.Items.Add("מושכר");

            cb_trans.Items.Add(true);
            cb_trans.Items.Add(false);
        }

        private void cb_car_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            car_number = (int)cb_car.SelectedItem;
            cb_nosa.IsEnabled = true;
        }

        private void cb_nosa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb_nosa.SelectedIndex)
            {
                case 0://ק\"מ (מרחק) להוסיף
                    tb_trans.Visibility = System.Windows.Visibility.Visible;
                    cb_trans.Visibility = System.Windows.Visibility.Hidden;
                    if (ad != null)
                        ad.Close();
                    if (td != null)
                        td.Close();
                    
                    break;
                case 1://כתובת
                    tb_trans.Visibility = System.Windows.Visibility.Hidden;
                    cb_trans.Visibility = System.Windows.Visibility.Hidden;
                    ad = new adrescar();
                    ad.Show();
                    if (td != null)
                        td.Close();
                    break;
                case 2://תקינות הרכב
                    tb_trans.Visibility = System.Windows.Visibility.Hidden;
                    cb_trans.Visibility = System.Windows.Visibility.Visible;
                    if (ad != null)
                        ad.Close();
                    if (td != null)
                        td.Close();
                    break;
                case 4://מושכר
                    tb_trans.Visibility = System.Windows.Visibility.Hidden;
                    cb_trans.Visibility = System.Windows.Visibility.Visible;
                    if (ad != null)
                        ad.Close();
                    if (td != null)
                        td.Close();
                    break;
                case 3://טסט
                    tb_trans.Visibility = System.Windows.Visibility.Hidden;
                    cb_trans.Visibility = System.Windows.Visibility.Hidden;
                    if (ad != null)
                        ad.Close();
                    td = new test_date();
                    td.Show();
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_nosa.SelectedIndex == 4)
            {
                try
                {
                   bl.update_car(update_car_win.car_number, update.panuy, cb_trans.SelectedItem);
                    MessageBox.Show("הרכב עודכן בהצלחה");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (cb_nosa.SelectedIndex == 2)
            {
                try
                {
                  bl.update_car(update_car_win.car_number, update.takin, cb_trans.SelectedItem);
                    MessageBox.Show("הרכב עודכן בהצלחה");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (cb_nosa.SelectedIndex == 0)
            {
                try
                {
                   bl.update_car(update_car_win.car_number, update.destance, float.Parse(tb_trans.Text));
                    MessageBox.Show("הרכב עודכן בהצלחה");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            this.Close();
        }

        private void tb_trans_TextChanged(object sender, TextChangedEventArgs e)
      {
            foreach (var item in tb_trans.Text)
            {
                int i = 0;
                if ((item > '9' || item < '0'))
                {
                    if (item != '.')
                    {
                        MessageBox.Show("צריך לשלוח רק מספרים", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        tb_trans.Text = tb_trans.Text.Remove(i, 1);
                    }
                }
                i++;
            }
            if (tb_trans.Text.Length > 0 && tb_trans.Text[tb_trans.Text.Length - 1] == '.' && temp)
            {
                MessageBox.Show("מותר רק נקודה עשרונית אחת");
                tb_trans.Text = tb_trans.Text.Remove(tb_trans.Text.Length - 1);
            }
            if (tb_trans.Text.Contains('.'))
            {
                temp = true;
            }   
        }

        
    }
}

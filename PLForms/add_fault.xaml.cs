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

namespace PLForms
{
    /// <summary>
    /// Interaction logic for add_fault.xaml
    /// </summary>
    public partial class add_fault : Window
    {
        List<BE.car> caa;
        public add_fault()
        {
            caa = new List<BE.car>();
            InitializeComponent();
            cb_cars.IsEnabled = false;
            d_end.IsEnabled = false;
            d_start.IsEnabled = false;

            cb_takT.Items.Add(BE.fault_type.betichut);
            cb_takT.Items.Add(BE.fault_type.blamim);
            cb_takT.Items.Add(BE.fault_type.chasmal);
            cb_takT.Items.Add(BE.fault_type.gir);
            cb_takT.Items.Add(BE.fault_type.light);
            cb_takT.Items.Add(BE.fault_type.magavim);
            cb_takT.Items.Add(BE.fault_type.marout);
            cb_takT.Items.Add(BE.fault_type.mazgan);
            cb_takT.Items.Add(BE.fault_type.mnoah);
            cb_takT.Items.Add(BE.fault_type.pancher);
            cb_takT.Items.Add(BE.fault_type.pch);
            cb_takT.Items.Add(BE.fault_type.plastica);
            cb_takT.Items.Add(BE.fault_type.radio);
            cb_takT.Items.Add(BE.fault_type.tipulTen);
            cb_takT.Items.Add(BE.fault_type.tzeva);
            cb_mt.Items.Add(BE.who_fault.blay);
            cb_mt.Items.Add(BE.who_fault.Negligence);
        }


        private void chb_r_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chb_r_Click(object sender, RoutedEventArgs e)
        {
            if (chb_r.IsChecked.Value)
            {
                cb_cars.IsEnabled = true;
                d_end.IsEnabled = true;
                d_start.IsEnabled = true;
                foreach (BE.car item in new BLFactory.BlFactory().GetBL().return_list(BE.retur.car))
                {
                    cb_cars.Items.Add(item.car_number.ToString() + " " + item.car_info.Manufacturer + " " + item.car_info.model);
                    caa.Add(item);
                }
            }
            else
            {
                cb_cars.IsEnabled = false;
                d_end.IsEnabled = false;
                d_start.IsEnabled = false;
                caa.Clear();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_mt.SelectedIndex == -1)
            {
                MessageBox.Show("לא נשלח מי אשם בתקלה");
            }
            else if (cb_takT.SelectedIndex == -1)
            {
                MessageBox.Show("לא נשלח שם התקלה");
            }
            else if (tb_misT.Text==""||tb_misT.Text.Length>7||tb_misT.Text.Length<7)
            {
                MessageBox.Show("לא נשלח מספר התקלה");
            }
            else
            {
                MainWindow.add(new BE.Fault((BE.fault_type)cb_takT.SelectedItem, (BE.who_fault)cb_mt.SelectedItem, int.Parse(tb_misT.Text), (int)cb_takT.SelectedItem, tb_mus.Text));
                if (chb_r.IsEnabled && chb_r.IsChecked.Value)
                {
                    MainWindow.a = 4;
                    MainWindow.add(new BE.Car_Fault(caa[cb_cars.SelectedIndex].car_number, int.Parse(tb_misT.Text), d_start.SelectedDate.Value, d_end.SelectedDate.Value));
                    MainWindow.a = 2;
                }
            }

        }

        private void tb_misT_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_misT.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("צריך לשלוח רק מספרים");
                    tb_misT.Text = tb_misT.Text.Remove(i, 1);
                }
                i++;
            }
            if (tb_misT.Text.Length==7)
            {
                if(new BLFactory.BlFactory().GetBL().is_fault_code_exist(int.Parse(tb_misT.Text)))
                {
                    MessageBox.Show("המספר תקלה הזאת קיימת אנא הכנס מיספר בעל 7 ספרות חדשות", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    tb_misT.Text = tb_misT.Text.Remove(0);

                }
            
            }
            if (tb_misT.Text.Length > 7)
            {
                    MessageBox.Show(" מיספר צריך להיות בעל 7 ספרות", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    tb_misT.Text = tb_misT.Text.Remove(7);
            }
        }

        private void tb_mus_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

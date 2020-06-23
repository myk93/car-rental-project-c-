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
    /// Interaction logic for END_rent_win.xaml
    /// </summary>
    
    public partial class END_rent_win : Window
    {
        IBL bl = new BlFactory().GetBL();
        int total;
        public static BE.car car;
        public static BE.Renting re;
        public END_rent_win()
        {
            InitializeComponent();
            foreach (BE.Renting item in bl.return_list(BE.retur.renting))
                if (!item.ended)
                    combo_rent.Items.Add(item.running_code);
            texst_end_time.Text = DateTime.Now.ToString("dd/MM/yyyy");
            combo_tkinut.Items.Add("תקין");
            combo_tkinut.Items.Add("לא תקין");

        }

        private void combo_rent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (BE.Renting item in bl.return_list(BE.retur.renting))
                if (item.running_code == (long)combo_rent.SelectedValue) 
                {
                    re = new BE.Renting();
                    re = item;
                    text_risuy.Text = item.number_of_rishui.ToString();
                    text_stat_time.Text = item.start_rent.ToString("dd/MM/yyyy");
                    start_KM.Text = item.number_at_start.ToString();
                     foreach (BE.car t in bl.return_list(BE.retur.car))
                         if (t.car_number == item.number_of_rishui)
                         {
                             car = new BE.car();
                             car = t;
                             text_gir.Text = t.car_gear.ToString();
                             text_category.Text = t.rishion.type.ToString();
                             texst_doors.Text = t.number_of_car_doors.ToString();
                             texst_mekomot.Text = t.car_people_able.ToString();
                             break;
                         }
                    break;
                }
                    
            
        }

        private void end_KM_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in end_KM.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("הכנס רק ספרות", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    end_KM.Text = end_KM.Text.Remove(i, 1);
                }

                else
                {
                    total = int.Parse(end_KM.Text) - (int)car.total_distance;
                    neto_dis.Text = total.ToString();
                }
                i++;
                end_KM.Text = end_KM.Text;
            }
        }

        private void combo_tkinut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_tkinut.SelectedIndex ==1)
            {
                new conect_fault(END_rent_win.car.car_number).Show();//פתח חלון 
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (car.total_distance > int.Parse(end_KM.Text) || end_KM.Text.Length ==0)
            {
                MessageBox.Show("הקילו מטר קטן מההתחלה הזנן נכון.", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (combo_tkinut.SelectedIndex ==-1)
            {
                 MessageBox.Show("בחר את מצב חזרת הרכב.", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
            new BLFactory.BlFactory().GetBL().update_rent(re, BE.update.destance, int.Parse(end_KM.Text));
            new BLFactory.BlFactory().GetBL().update_car(car, BE.update.panuy, false);
            new BLFactory.BlFactory().GetBL().update_car(car, BE.update.destance, total);
            float sum = new BLFactory.BlFactory().GetBL().total_price(re.running_code);
            new BLFactory.BlFactory().GetBL().update_rent(re, BE.update.price, sum);
            new BLFactory.BlFactory().GetBL().update_rent(re, BE.update.ended, true);         
            new kabla(re).Show();
         
        }
    }
}

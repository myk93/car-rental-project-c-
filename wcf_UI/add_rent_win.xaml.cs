using BL_WcfService;
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
using ref_factory;
namespace wcf_UI
{
    /// <summary>
    /// Interaction logic for add_rent_win.xaml
    /// </summary>
    public partial class add_rent_win : Window
    {
        IBL bl = new ref_factory.Class1().GetBL();

        public static BE.Drivers dra;
        public static int num_car;
        public static int star_KM;
        public add_rent_win()
        {
            InitializeComponent();
            ////////////gir////////////////////
            gir.Items.Add(BE.gear.yadni);
            gir.Items.Add(BE.gear.automety);
            //////////////////mekomot///////////////////
            mekomot.Items.Add(2);
            mekomot.Items.Add(3);
            mekomot.Items.Add(4);
            mekomot.Items.Add(5);
            mekomot.Items.Add(6);
            /////////////////dopr//////////////
            door.Items.Add(2);
            door.Items.Add(3);
            door.Items.Add(4);
            door.Items.Add(5);
            //////////////categoria////////////////
            for (int i = 0; i <= (int)BE.catagory_of_vehicles.E; i++)
                categorya.Items.Add((BE.catagory_of_vehicles)i);
            /////////////////mspar_nahgim/////////////////////
            mspar_nahgim.Items.Add(1);
            mspar_nahgim.Items.Add(2);
            ///////////////////////////
            date_time.Text = DateTime.Now.ToString("dd/MM/yyyy");
            /////////////////////////


        }

        private void Button_Click(object sender, RoutedEventArgs e)//כפתור ביטול
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//כפתור אישור
        {
            if (tex_num_ren.Text.Count() < 8)
                tex_num_ren.Text = "0";
            if (mspar_nahgim.SelectedIndex == -1)
            {
                MessageBox.Show("בחר כמות נהגים", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (data_car.SelectedIndex == -1)
            {
                MessageBox.Show("בחר מכונית", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (data_clie.SelectedIndex == -1 || data_clie.SelectedIndex >= 2)
            {
                MessageBox.Show("בעייה במספר הנהגים", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!days.SelectedDate.HasValue || days.SelectedDate.Value < DateTime.Now)
            {
                MessageBox.Show("בחר לכמה ימים", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            try
            {
                BE.Client cli = new BE.Client();
                cli = (BE.Client)data_clie.SelectedItem;

                int day = (days.SelectedDate.Value.Year - DateTime.Now.Year) * 365 + (days.SelectedDate.Value.Month - DateTime.Now.Month) * 30 + (days.SelectedDate.Value.Day - DateTime.Now.Day);
                bl.add_rent(new BE.Renting(long.Parse(tex_num_ren.Text), dra, num_car, day, DateTime.Now, days.SelectedDate.Value, false, star_KM, 0, false, 0));

                MessageBox.Show("ההזמנה התבצעה", "ברכות", MessageBoxButton.OK, MessageBoxImage.Information);
                foreach (BE.car item in bl.return_list(BE.retur.car))
                    if (num_car == item.car_number)
                    {
                        bl.update_car(item, BE.update.panuy, false);
                        break;
                    }
                data_clie.SelectedIndex = 0;
                this.Close();
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void tex_num_ren_TextChanged(object sender, TextChangedEventArgs e)//טקסט של מספר ההזמנה 
        {
            int i = 0;
            foreach (var item in tex_num_ren.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("הכנס רק ספרות", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    tex_num_ren.Text = tex_num_ren.Text.Remove(i, 1);
                }
                i++;
                tex_num_ren.Text = tex_num_ren.Text;
            }
        }

        private void sinun_Click(object sender, RoutedEventArgs e)//כפתור הסינון
        {
            if (gir.SelectedIndex == -1)
            {
                MessageBox.Show("מלא את סוג ההילוכים ", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (mekomot.SelectedIndex == -1)
            {
                MessageBox.Show("מלא את מספר המקומות ", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (door.SelectedIndex == -1)
            {
                MessageBox.Show("מלא את מספר הדלתות ", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (categorya.SelectedIndex == -1)
            {
                MessageBox.Show("מלא את קטגוריה ", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                data_clie.ItemsSource = (bl.select_client((BE.catagory_of_vehicles)categorya.SelectedValue));
                data_cli2.ItemsSource = (bl.select_client((BE.catagory_of_vehicles)categorya.SelectedValue));

                int m = (int)(mekomot.SelectedValue);
                int d = (int)(door.SelectedValue);

                data_car.ItemsSource = bl.sinun_car((BE.gear)gir.SelectedValue, (BE.catagory_of_vehicles)categorya.SelectedValue,
                   m, d);
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void data_clie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (mspar_nahgim.SelectedIndex == -1)
            {
                MessageBox.Show("בחר כמה נהגים", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            dra.first_id = ((BE.Client)data_clie.SelectedItem).Id1;
            dra.first_name = "first";
            MessageBox.Show(dra.first_id.ToString(), "נהג ראשון", MessageBoxButton.OK, MessageBoxImage.Information);
            if (mspar_nahgim.SelectedIndex == 1)
            {
                MessageBox.Show("בחר נהג נוסף", "הוספת נהג", MessageBoxButton.OK, MessageBoxImage.Information);
                data_cli2.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                dra.second_id = 0;
                dra.second_name = "";
            }


        }

        private void data_cli2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dra.second_id = ((BE.Client)data_cli2.SelectedItem).Id1;
            dra.second_name = "secend";
            //mspar_nahgim.SelectedValue = "2";
            data_cli2.Visibility = System.Windows.Visibility.Hidden;
            MessageBox.Show(dra.second_id.ToString(), "נהג שני", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void data_car_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void data_car_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            num_car = ((BE.car)data_car.SelectedItem).car_number;
            star_KM = (int)(((BE.car)data_car.SelectedItem).total_distance);
            MessageBox.Show(num_car.ToString(), "מכונית נבחרה", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}

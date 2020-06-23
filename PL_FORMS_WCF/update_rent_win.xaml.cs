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
    /// Interaction logic for update_rent_win.xaml
    /// </summary>
    public partial class update_rent_win : Window
    {
        IBL bl = new BlFactory().GetBL();

        public BE.Renting re;
        public static long num;
        public update_rent_win()
        {
            InitializeComponent();
            matzav.Items.Add("הזמנה פתוחה");
            matzav.Items.Add("הזמנה סגורה");

            nose_end.Items.Add("ביטול/עידכון תקלה");
            nose_end.Items.Add("מרחק");
            nose_end.Items.Add("תשלום");
            nose.Items.Add("מספר ימים");
            nose.Items.Add("להוסיף נהג");
            nose.Items.Add("להוריד נהג");
            takala.Items.Add("תקין");
            takala.Items.Add("לא תקין");
        }

        private void matzav_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nose.Visibility = System.Windows.Visibility.Hidden;
            nose_end.Visibility = System.Windows.Visibility.Hidden;
            switch (matzav.SelectedIndex)
            {

                case 0:
                    foreach (BE.Renting item in bl.return_list(BE.retur.renting))
                    {
                        if (!item.ended)
                            com_rent.Items.Add(item.running_code);

                    }
                    nose.Visibility = System.Windows.Visibility.Visible;
                    break;
                case 1:
                    foreach (BE.Renting item in bl.return_list(BE.retur.renting))
                    {
                        if (item.ended)
                            com_rent.Items.Add(item.running_code);
                    }
                    nose_end.Visibility = System.Windows.Visibility.Visible;

                    break;
                default:
                    break;
            }
        }

        private void nose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                re = new BE.Renting();
                foreach (BE.Renting item in bl.return_list(BE.retur.renting))
                    if (item.running_code == (long)com_rent.SelectedValue)
                        re = item;
                List<BE.Client> cli = new List<BE.Client>();

                switch (nose.SelectedIndex)
                {
                    case 0:
                        num = re.running_code;
                        new update_date_rent().Show();
                        break;
                    case 1:
                        if (re.number_of_pepole == 2)
                        {
                            MessageBox.Show("אין אפשרות להוסיף נהג", "שדה הנהגים מלא", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        foreach (BE.car item in bl.return_list(BE.retur.car))
                            if (item.car_number == re.number_of_rishui)
                            {
                                try
                                {
                                    cli = bl.select_client(item.rishion.type);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                break;
                            }
                        foreach (BE.Client item in cli)
                            if (item.Id1 != re.driver.first_id)
                                driver.Items.Add(item.Id1);
                        osafa.Visibility = System.Windows.Visibility.Visible;
                        driver.Visibility = System.Windows.Visibility.Visible;
                        break;
                    case 2:
                        if (re.number_of_pepole == 1)
                        {
                            MessageBox.Show("אין אפשרות להוריד נהג", "שדה הנהגים ", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        try
                        {
                            bl.update_rent(re, BE.update.morid_n, 0);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        MessageBox.Show("הנהג ירד", "שדה הנהגים ", MessageBoxButton.OK, MessageBoxImage.Error);

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nose_end_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* nose_end.Items.Add("ביטול/עידכון תקלה");
            nose_end.Items.Add("מרחק");
            nose_end.Items.Add("תשלום"); 
           */
            re = new BE.Renting();
            foreach (BE.Renting item in bl.return_list(BE.retur.renting))
                if (item.running_code == (long)com_rent.SelectedValue)
                    re = item;
            List<BE.Client> cli = new List<BE.Client>();

            switch (nose_end.SelectedIndex)
            {
                case 0:
                    takala.Visibility = System.Windows.Visibility.Visible;
                    te_takala.Visibility = System.Windows.Visibility.Visible;

                    break;
                case 1:
                    mer.Visibility = System.Windows.Visibility.Visible;
                    merchak.Visibility = System.Windows.Visibility.Visible;
                  //  OK1.Visibility = System.Windows.Visibility.Visible;
                    break;
                case 2:
                    pri.Visibility = System.Windows.Visibility.Hidden;
                    price.Visibility = System.Windows.Visibility.Hidden;
                    OK.Visibility = System.Windows.Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        private void driver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            { 
           bl.update_rent(re, BE.update.rishion_nahg, (long)driver.SelectedValue);
            MessageBox.Show("הנהג נוסף", "שדה הנהגים מלא", MessageBoxButton.OK, MessageBoxImage.Error);

            osafa.Visibility = System.Windows.Visibility.Hidden;
            driver.Visibility = System.Windows.Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void takala_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            { 
            switch (takala.SelectedIndex)
            {
                case 0:
                   bl.update_rent(re, BE.update.takin, true);
                    foreach (BE.car item in bl.return_list(BE.retur.car))
                        if (item.car_number == re.number_of_rishui)
                        {
                            bl.update_car(item, BE.update.takin, true);
                            break;
                        }
                    takala.Visibility = System.Windows.Visibility.Hidden;
                    te_takala.Visibility = System.Windows.Visibility.Hidden;
                    MessageBox.Show("עוכנה תקלה", "תקלה", MessageBoxButton.OK, MessageBoxImage.Error);

                    break;
                case 1:
                   bl.update_rent(re, BE.update.takin, false);
                    foreach (BE.car item in bl.return_list(BE.retur.car))
                        if (item.car_number == re.number_of_rishui)
                        {
                           bl.update_car(item, BE.update.takin, false);
                            break;
                        }
                    takala.Visibility = System.Windows.Visibility.Hidden;
                    te_takala.Visibility = System.Windows.Visibility.Hidden;
                    MessageBox.Show("עוכנה תקלה", "תקלה", MessageBoxButton.OK, MessageBoxImage.Error);

                    break;
                default:
                    break;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in price.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("הכנס רק ספרות", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    price.Text = price.Text.Remove(i, 1);
                }
                i++;
            }
        }

        private void price_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in price.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("הכנס רק ספרות", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    price.Text = price.Text.Remove(i, 1);
                }
                i++;
            }

        }

        private void OK_Click(object sender, RoutedEventArgs e)//אישור
        {
            try
            {
               bl.update_rent(re, BE.update.price, float.Parse(price.Text));
                MessageBox.Show("מחיר עודכן", "מחיר ", MessageBoxButton.OK, MessageBoxImage.Error);
                pri.Visibility = System.Windows.Visibility.Visible;
                price.Visibility = System.Windows.Visibility.Visible;
                OK.Visibility = System.Windows.Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OK1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float m = float.Parse(merchak.Text);
               bl.update_rent(re, BE.update.destance, m);
                foreach (BE.car item in bl.return_list(BE.retur.car))
                    if (item.car_number == re.number_of_rishui)
                    {
                        bl.update_car(item, BE.update.destance, m);
                        break;
                    }

                MessageBox.Show("מרחק סופי עודכן", "מרחק ", MessageBoxButton.OK, MessageBoxImage.Error);
                mer.Visibility = System.Windows.Visibility.Hidden;
                merchak.Visibility = System.Windows.Visibility.Hidden;
                //OK1.Visibility = System.Windows.Visibility.Hidden;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

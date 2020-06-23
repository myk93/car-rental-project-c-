using System;
using BL_WcfService;
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

namespace wcf_UI
{
    /// <summary>
    /// Interaction logic for add_client_win.xaml
    /// </summary>
    public partial class add_client_win : Window
    {

        IBL bl = new ref_factory.Class1().GetBL();

        public add_client_win()
        {
            InitializeComponent();
            VIP.Items.Add("false");

            VIP.Items.Add("true");
            for (int i = 1; i < 13; i++)
            {
                month_resayon.Items.Add(i);
            }

            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++)
            {
                year_resayon.Items.Add(i);
            }
            for (int i = 1; i < 13; i++)
            {
                month_card.Items.Add(i);
            }
            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++)
            {
                year_card.Items.Add(i);
            }
            for (int i = 0; i < 5; i++)
            {
                category_resayon.Items.Add((BE.catagory_of_vehicles)i);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_id.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("צריך לשלוח רק מספרים");
                    tb_id.Text = tb_id.Text.Remove(i, 1);
                }
                else
                {
                    tb_id1.Text = tb_id.Text;
                }
                i++;
            }

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_city.Text)
            {
                if (!((item <= 'z' && item >= 'A') || (item <= 'ת' && item >= 'א')))
                {
                    MessageBox.Show("צריך להכניס רק אותיות");
                    tb_city.Text = tb_city.Text.Remove(i, 1);
                }
                i++;
            }
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_build.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("צריך לשלוח רק מספרים");
                    tb_build.Text = tb_build.Text.Remove(i, 1);
                }
                i++;
            }
        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            if (tb_cvc.Text.Count() == 4)
            {
                tb_cvc.Text = tb_cvc.Text.Remove(3);
                MessageBox.Show(" המספר צריך להיות בעל 3 ספרות");
            }
            int i = 0;
            foreach (var item in tb_cvc.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("צריך לשלוח רק מספרים");
                    tb_cvc.Text = tb_cvc.Text.Remove(i, 1);
                }
                i++;
            }
        }

        private void category_resayon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            int id1 = 0;
            if (tb_id1.Text != "0")
            {
                if (tb_id.Text.Count() != 9)
                {
                    MessageBox.Show(" המספר צריך להיות בעל 9 ספרות");
                    return;
                }
                id1 = int.Parse(tb_id1.Text);
            }
            if (!date.SelectedDate.HasValue)
            {
                MessageBox.Show("צריך להכניס תאריך לידה");
                return;
            }
            if (year_resayon.SelectedIndex == -1 || month_resayon.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור תאריך לרישיון");
                return;
            }
            if (category_resayon.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור סוג רישיון");
                return;
            }
            if (tb_cardN.Text.Length < 7 || tb_cardN.Text.Length > 16)
            {
                MessageBox.Show("מספר אשראי אינו תקין");
                return;
            }
            if (tb_cvc.Text.Length < 3)
            {
                MessageBox.Show("אינו תקין CVV מספר");
                return;
            }
            if (year_card.SelectedIndex == -1 || month_card.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור תאריך לאשראי");
                return;
            }
            if (tb_city.Text == "" || tb_stre.Text == "" || tb_build.Text == "")
            {
                MessageBox.Show("הכתובת אינה תקינה");
                return;
            }

            BE.addres t;
            t.building = int.Parse(tb_build.Text);
            t.city = tb_city.Text;
            t.street = tb_stre.Text;

            BE.rishion rr;
            rr.catgor = (BE.catagory_of_vehicles)category_resayon.SelectedIndex;
            rr.tokf = new DateTime();
            rr.tokf.AddYears((int)year_resayon.Items[year_resayon.SelectedIndex]);
            rr.tokf.AddMonths((int)month_resayon.Items[month_resayon.SelectedIndex] - 1);
            rr.mispar_rishion = 0;

            BE.CreditCard cc;
            cc.cvc_number = int.Parse(tb_cvc.Text);
            cc.exp_date = new DateTime((int)year_card.SelectionBoxItem, (int)month_card.SelectionBoxItem, 1);
            cc.number_c = tb_cardN.Text;

            bool isv = false;
            if ((string)VIP.SelectedValue == "true")
                isv = true;
            try
            {
                bl.add_client(new BE.Client(t, date.SelectedDate.Value, rr, cc, 0, 0, isv, id1));
                MessageBox.Show("client was added sucsesfuly");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tb_cardN_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_cardN.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("צריך לשלוח רק מספרים");
                    tb_cardN.Text = tb_cardN.Text.Remove(i, 1);
                }
                i++;
            }
        }

     
    }
}

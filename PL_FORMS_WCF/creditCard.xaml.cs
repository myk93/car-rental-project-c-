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
using BLFactory;
using BE;
using BL;

namespace PL_FORMS
{
    /// <summary>
    /// Interaction logic for creditCard.xaml
    /// </summary>
    public partial class creditCard : Window
    {
        IBL bl = new BlFactory().GetBL();

        public creditCard()
        {
            InitializeComponent();
            for (int i = 1; i < 13; i++)
            {
                month_card.Items.Add(i);
            }
            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++)
            {
                year_card.Items.Add(i);
            }
            Client m = ((IList<Client>)(bl.return_list(retur.client))).Where(a => a.Id1 == update_client_win.id).First();
            month_card.SelectedValue = m.Card_dit.exp_date.Month;
            year_card.SelectedValue = m.Card_dit.exp_date.Year;
            tb_cardN.Text = m.Card_dit.number_c;
            tb_cvc.Text = m.Card_dit.cvc_number.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreditCard cc;
            cc.cvc_number = int.Parse(tb_cvc.Text);
            cc.number_c = tb_cardN.Text;
            cc.exp_date = new DateTime((int)year_card.SelectedItem, (int)month_card.SelectedItem, 1);
            try
            {
               bl.update_client(update_client_win.id, update.cradit_card, (object)cc);
                MessageBox.Show("הלקוח עודכן בהצלחה");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("אתה בטוח שברצונך לבטל", "אזהרה", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}

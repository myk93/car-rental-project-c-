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
using BL;
using BE;
using BLFactory;
namespace PLForms
{
    /// <summary>
    /// Interaction logic for client_register_window.xaml
    /// </summary>
    public partial class client_register_window : Window
    {
        
        public client_register_window()
        {
            InitializeComponent();
            for (int i = 1; i < 100; i++)
            {
                me_bo.Items.Add(i);
            }
           
            for (int i = 0; i < 10; i++)
            {
                cb_mt.Items.Add(i);
                cb_vatk.Items.Add(i);
            }
           
           
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            addres ad;
            ad.city = tb_City.Text;
            ad.street = tb_str.Text;
            ad.building =int.Parse(me_bo.Text);
            DateTime dt = d_tlida.SelectedDate.Value;
            rishion ri;
            switch (cobo.Text)
            {
                case "A":
                    ri.catgor = catagory_of_vehicles.A;
                    break;
                case"B":
                    ri.catgor = catagory_of_vehicles.B;
                    break;
                case "C":
                    ri.catgor = catagory_of_vehicles.C;
                    break;
                case "D":
                    ri.catgor = catagory_of_vehicles.D;
                    break;
                case "E":
                     ri.catgor = catagory_of_vehicles.E;
                    break;
                default:
                    ri.catgor = catagory_of_vehicles.B;
                    break;
            }
         //   ri.mispar_rishion = int.Parse(mis_ris.Text);
            ri.mispar_rishion = int.Parse(tb_tz.Text);
            ri.tokf = d_tfuga.SelectedDate.Value;
            CreditCard cc;
            cc.exp_date = d_ashray.SelectedDate.Value;
            cc.cvc_number = int.Parse(tb_cvc.Text);
            cc.number_c = tb_cardn.Text;
            Client cli = new Client(ad, dt, ri, cc, (int)cb_vatk.SelectedItem, (int)(cb_mt.SelectedItem), (isVip.SelectedItem.ToString() == "true".ToString() ? true : false), int.Parse(tb_tz.Text));
            MainWindow.add(cli);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            MessageBox.Show("הלקוח התווסף");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_cvc.Text.Count() == 4)
            { 
               tb_cvc.Text= tb_cvc.Text.Remove(3);
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

        private void cbY_Copy1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mis_ris_TextChanged(object sender, TextChangedEventArgs e)
        {
            //int i=0;
            //foreach (var item in mis_ris.Text)
            //{
            //    if (item>'9'||item<'0')
            //    {
            //        MessageBox.Show("צריך לשלוח רק מספרים");
            //        mis_ris.Text = mis_ris.Text.Remove(i,1);
            //    }
            //    i++;
            //}
            
        }

        private void tb_City_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_City.Text)
            {
                if (!((item <= 'z' && item >= 'A') || (item <= 'ת' && item >= 'א')))
                {
                    MessageBox.Show("mmmm");
                    tb_City.Text = tb_City.Text.Remove(i, 1);
                }
                i++;
            }
        }

        private void tb_str_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_str.Text)
            {
                if (!((item <= 'z' && item >= 'A') || (item <= 'ת' && item >= 'א')))
                {
                    MessageBox.Show("mmmm");
                    tb_str.Text = tb_str.Text.Remove(i, 1);
                }
                i++;
            }
        }

        private void tb_tz_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_tz.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("צריך לשלוח רק מספרים");
                    tb_tz.Text = tb_tz.Text.Remove(i, 1);
                }
                i++;
            }
        }

        private void tb_cardn_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_cardn.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("צריך לשלוח רק מספרים");
                    tb_cardn.Text = tb_cardn.Text.Remove(i, 1);
                }
                i++;
            }
        }
    }
}
/*
            int i=0;
            foreach (var item in mis_ris.Text)
            {
                if (!((item <= 'z' && item >= 'A') || (item <= 'ת' && item >= 'א')))
                {
                    MessageBox.Show("mmmm");
                    mis_ris.Text = mis_ris.Text.Remove(i,1);
                }
                i++;
            }
 */
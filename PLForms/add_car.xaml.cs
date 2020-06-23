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
using BE;
using BL;
using BLFactory;

namespace PLForms
{
    /// <summary>
    /// Interaction logic for add_car.xaml
    /// </summary>
    public partial class add_car : Window
    {
        IBL bl = new BlFactory().GetBL();
        public add_car()
        {
            InitializeComponent();

            for (int i = 800; i < 3000; i++)
            {
                me_bo.Items.Add(i);
            }
            gir.Items.Add("אוטמטי");
            gir.Items.Add("ידני");
            for (int i = 2; i < 8; i++)
            {
                cb_nos.Items.Add(i);
            }
            for (int i = 2; i < 6; i++)
            {
                cb_door.Items.Add(i);
            }
            for (int i = 1; i < 100; i++)
            {
                me_bo_Copy.Items.Add(i);
            }
        }
        bool temp = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            car_type ct;
            ct.Manufacturer = tb_str.Text;
            ct.model = tb_City.Text;
            ct.Engine_capacety = (int)(me_bo.SelectedItem);
            gear g = (gear)gir.SelectedItem;
            addres ad;
            rishion_rachav rr;
            ad.city = tb_City_Copy.Text;
            ad.street = tb_str_Copy.Text;
            ad.building = (int)me_bo_Copy.SelectedItem;
            rr.test = d_rr.SelectedDate.Value;
            switch (cobo.Text)
            {
                case "A":
                    rr.type = catagory_of_vehicles.A;
                    break;
                case "B":
                    rr.type = catagory_of_vehicles.B;
                    break;
                case "C":
                    rr.type = catagory_of_vehicles.C;
                    break;
                case "D":
                    rr.type = catagory_of_vehicles.D;
                    break;
                case "E":
                    rr.type = catagory_of_vehicles.E;
                    break;
                default:
                    rr.type = catagory_of_vehicles.B;
                    break;
            }
          //  new car(ct, g, (int)cb_nos.SelectedItem, (int)cb_door.SelectedItem, ad, rr, int.Parse(kilo.Text), d_ya.SelectedDate.Value);

        }

        private void tb_City_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_City_Copy.Text)
            {
                if (!((item <= 'z' && item >= 'A') || (item <= 'ת' && item >= 'א')))
                {
                    MessageBox.Show("mmmm");
                    tb_City_Copy.Text = tb_City_Copy.Text.Remove(i, 1);
                }
                i++;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_nur.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("צריך לשלוח רק מספרים", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    tb_nur.Text = tb_nur.Text.Remove(i, 1);
                }
                i++;
            }
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

        private void kilo_TextChanged(object sender, TextChangedEventArgs e)
        {

            foreach (var item in kilo.Text)
            {
                int i = 0;
                if ((item > '9' || item < '0'))
                {
                    if (item!='.')
                    {
                        MessageBox.Show("צריך לשלוח רק מספרים", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        kilo.Text = kilo.Text.Remove(i, 1);
                    }
                }
                i++;
            }
            if (kilo.Text.Length > 0 && kilo.Text[kilo.Text.Length - 1] == '.' && temp)
            {
                MessageBox.Show("מותר רק נקודה עשרונית אחת");
                kilo.Text = kilo.Text.Remove(kilo.Text.Length - 1);
            }
            if (kilo.Text.Contains('.'))
            {
                temp = true;
            }   
        }

        private void tb_str_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_str_Copy.Text)
            {
                if (!((item <= 'z' && item >= 'A') || (item <= 'ת' && item >= 'א')))
                {
                    MessageBox.Show("mmmm");
                    tb_str_Copy.Text = tb_str_Copy.Text.Remove(i, 1);
                   
                }
                i++;
            }
        }
    }
}
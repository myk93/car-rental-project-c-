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
    /// Interaction logic for address.xaml
    /// </summary>
    public partial class address : Window
    {
        IBL bl = new BlFactory().GetBL();

        public address()
        {
            InitializeComponent();
            Client m = ((IList<Client>)(new BlFactory().GetBL().return_list(retur.client))).Where(a => a.Id1 == update_client_win.id).First();
            tb_build.Text = m.Address1.building.ToString();
            tb_city.Text = m.Address1.city;
            tb_stre.Text = m.Address1.street;
        }

        private void tb_city_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            addres ad;
            ad.street = tb_stre.Text;
            ad.city = tb_city.Text;
            ad.building = int.Parse(tb_build.Text);
            try
            {
               bl.update_client(update_client_win.id, update.address, ad);
                MessageBox.Show("הלקוח עודכן בהצלחה");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
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

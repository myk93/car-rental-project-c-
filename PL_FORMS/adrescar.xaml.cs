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
    /// Interaction logic for adrescar.xaml
    /// </summary>
    public partial class adrescar : Window
    {
        IBL bl = new BlFactory().GetBL();

        public adrescar()
        {
            InitializeComponent();
            car m = ((IList<car>)(new BlFactory().GetBL().return_list(retur.car))).Where(a => a.car_number == update_car_win.car_number).First();
            tb_build.Text = m.snif_address.building.ToString();
            tb_city.Text = m.snif_address.city;
            tb_stre.Text = m.snif_address.street;
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
                bl.update_car(update_car_win.car_number, update.address, ad);
                MessageBox.Show("הרכב עודכן בהצלחה");
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

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
    /// Interaction logic for driver_lisence.xaml
    /// </summary>
    public partial class driver_lisence : Window
    {
        IBL bl = new BlFactory().GetBL();

        public driver_lisence()
        {
            InitializeComponent();
            for (int i = 1; i < 13; i++)
            {
                month_resayon.Items.Add(i);
            }

            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++)
            {
                year_resayon.Items.Add(i);
            }
            for (int i = 0; i < 5; i++)
            {
                
                category_resayon.Items.Add((catagory_of_vehicles)i);
            }
            Client m = ((IList<Client>)(bl.return_list(retur.client))).Where(a => a.Id1 == update_client_win.id).First();
            month_resayon.SelectedValue = m.rishoi.tokf.Month;
            year_resayon.SelectedValue = m.rishoi.tokf.Year;
            category_resayon.SelectedValue = m.rishoi.catgor;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rishion rr;
            rr.tokf = new DateTime((int)year_resayon.SelectedItem, (int)month_resayon.SelectedValue, 1);
            rr.catgor = (catagory_of_vehicles)category_resayon.SelectedItem;
            rr.mispar_rishion = int.Parse((update_client_win.id).ToString());
            try
            {
                bl.update_client(update_client_win.id, update.rishion_nahg, rr);
                MessageBox.Show("הלקוח עודכן בהצלחה");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButton.OK,MessageBoxImage.Error);
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

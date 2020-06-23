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
    /// Interaction logic for update_date_rent.xaml
    /// </summary>
    public partial class update_date_rent : Window
    {
        BE.Renting ren;
        IBL bl = new BlFactory().GetBL();

        public update_date_rent()
        {
            InitializeComponent();
            //BE.Renting ren = new Renting();
           ren = (((List<Renting>)bl.return_list(retur.renting))
                .Where(a => a.running_code == update_rent_win.num )).First();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!tarich.SelectedDate.HasValue || tarich.SelectedDate.Value < DateTime.Now)
            {
                MessageBox.Show("בחר לכמה ימים", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                bl.update_rent(ren, update.mispar_yamim, tarich.SelectedDate.Value);
                this.Close();
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

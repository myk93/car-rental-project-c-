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

namespace wcf_UI
{
    /// <summary>
    /// Interaction logic for dele_rent_win.xaml
    /// </summary>
    public partial class dele_rent_win : Window
    {
        /// <summary>
        /// Interaction logic for dele_rent_win.xaml
        /// </summary>
        IBL bl = new ref_factory.Class1().GetBL();

        public dele_rent_win()
        {
            InitializeComponent();
            foreach (BE.Renting item in bl.return_list(BE.retur.renting))
                if (item.ended)
                    num_re.Items.Add(item.running_code);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (BE.Renting item in bl.return_list(BE.retur.renting))
                    if (item.running_code == (long)num_re.SelectedValue)
                    {
                        new ref_factory.Class1().GetBL().del_rent(item);
                        break;
                    }
                MessageBox.Show("הההזמנה נמחק בהצלחה");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

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
    /// Interaction logic for delet_client_w_in.xaml
    /// </summary>
    public partial class delet_client_w_in : Window
    {
    
        IBL bl = new ref_factory.Class1().GetBL();

        public delet_client_w_in()
        {

            InitializeComponent();
            foreach (BE.Client item in bl.return_list(BE.retur.client))
            {
                cb_del.Items.Add(item.Id1);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.del_client((long)cb_del.SelectedItem);
                MessageBox.Show("הלקוח נמחק בהצלחה");
                cb_del.Items.Clear();
                foreach (BE.Client item in bl.return_list(BE.retur.client))
                {
                    cb_del.Items.Add(item.Id1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("אתה בטוח שברצונך לבטל", "אזהרה", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

    }
}

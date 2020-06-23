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
    /// Interaction logic for update_client_win.xaml
    /// </summary>
    public partial class update_client_win : Window
    {
        IBL bl = new BlFactory().GetBL();
        public static long id;
        creditCard cc ;
        driver_lisence dl;
        address ad;
        public update_client_win()
        {
            InitializeComponent();
            foreach (BE.Client item in bl.return_list(BE.retur.client))
            {
                cb_id.Items.Add(item.Id1);
            }
            cb_what_to_up.Items.Add("רשיון נהיגה");
            cb_what_to_up.Items.Add("כתובת");
            cb_what_to_up.Items.Add("חבר מועדון");
            cb_what_to_up.Items.Add("כרטיס אשראי");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("אתה בטוח שברצונך לבטל","אזהרה",MessageBoxButton.YesNo,MessageBoxImage.Warning)==MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void cb_what_to_up_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (cb_what_to_up.SelectedIndex)
            {
                case 0://רשיון נהיגה
                    if (cc != null)
                        cc.Close();
                    cb_vip.Visibility = System.Windows.Visibility.Hidden;
                    dl = new driver_lisence();
                    dl.Show();
                    if (ad != null)
                        ad.Close(); 
                    break;
                case 1://כתובת
                    if (cc != null)
                        cc.Close();
                    if (dl != null)
                        dl.Close();
                    cb_vip.Visibility = System.Windows.Visibility.Hidden;
                    ad = new address();
                    ad.Show();
                    break;
                case 2://חבר מועדון
                    if (cc!=null)
                      cc.Close();
                    if (dl != null)
                        dl.Close();
                    if (ad != null)
                        ad.Close();  
                    cb_vip.Visibility = System.Windows.Visibility.Visible;
                    break;
                case 3://כרטיס אשראי
                    cc = new creditCard();
                    if (dl != null)
                        dl.Close();
                    if (ad != null)
                        ad.Close(); 
                    cb_vip.Visibility = System.Windows.Visibility.Hidden;
                    cc.Show();
                    break;
                default:
                    break;
            }
        }

        private void cb_id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update_client_win.id = (long)cb_id.SelectedItem;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cb_what_to_up.SelectedIndex==2)
            {
                try
                {
                  bl.update_client(update_client_win.id, update.vip, (bool)cb_vip.SelectedItem);
                    MessageBox.Show("הלקוח עודכן בהצלחה");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

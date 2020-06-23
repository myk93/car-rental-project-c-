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
    /// Interaction logic for update_fault_win.xaml
    /// </summary>
    public partial class update_fault_win : Window
    {
        public string[] musacim = { "דני אמויאל", "קרסו", "חלקי חילוף", "מוסכי פורד", "דודו גרשון פנצרים", "גולין פנצרים", "פחחות וצבע", "צמפיון מוטורס", "הונדה" };
        IBL bl = new BlFactory().GetBL();

        public static int mis_tak;
        public update_fault_win()
        {

            InitializeComponent();
            cb_ni.Items.Add("מספר ימים לתיקון");
            cb_ni.Items.Add("מוסך");
            cb_ni.Items.Add("גורם התקלה");
            cb_ni.Items.Add("פירוט התקלה");
            cb_ni.Items.Add("מחיר");
            foreach (BE.Fault item in  bl.return_list(BE.retur.fault))
            {
                cb_m.Items.Add(item.fault_number);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_m.SelectedIndex != -1)
            {
                switch (cb_ni.SelectedIndex)
                {
                    case -1:
                        MessageBox.Show("צריך לבחור את מה לעדכן");
                        return;
                    case 0:
                        if (cb_trans.SelectedIndex == -1)
                        {
                            MessageBox.Show("צריך לבחור את מה לעדכן");
                            return;
                        }
                        bl.update_Fault((int)cb_m.SelectedValue, BE.update.mispar_yamim, (int)cb_trans.SelectedValue);
                        MessageBox.Show("העדכון הושלם");
                        break;
                    case 1:
                             if (cb_trans.SelectedIndex == -1)
                        {
                            MessageBox.Show("צריך לבחור את מה לעדכן");
                            return;
                        }
                        bl.update_Fault((int)cb_m.SelectedValue, BE.update.musch, (string)cb_trans.SelectedValue);
                        MessageBox.Show("העדכון הושלם");
                        break;
                    case 2:
                        if (cb_trans.SelectedIndex == -1)
                        {
                            MessageBox.Show("צריך לבחור את מה לעדכן");
                            return;
                        }
                        bl.update_Fault((int)cb_m.SelectedValue, BE.update.gorm_htakla, (BE.who_fault)cb_trans.SelectedValue);
                        MessageBox.Show("העדכון הושלם");
                        break;
                    case 3:
                        if (cb_trans.SelectedIndex == -1)
                        {
                            MessageBox.Show("צריך לבחור את מה לעדכן");
                            return;
                        }
                        bl.update_Fault((int)cb_m.SelectedValue, BE.update.mispar_yamim, (int)cb_trans.SelectedValue);
                        MessageBox.Show("העדכון הושלם");
                        break;
                    case 4:
                             if (cb_trans.SelectedIndex == -1)
                        {
                            MessageBox.Show("צריך לבחור את מה לעדכן");
                            return;
                        }
                        bl.update_Fault((int)cb_m.SelectedValue, BE.update.price, (string)tb_trans.Text);
                        MessageBox.Show("העדכון הושלם");
                        this.Close();
                        break;
                    default:
                        break;
                }
            }
        }

        private void cb_m_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mis_tak = (int)cb_m.SelectedItem;
        }

        private void cb_ni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_trans.Items.Clear();

            switch (cb_ni.SelectedIndex)
            {
                case 0://מספר ימים לתיקון
                    tb_trans.Visibility = System.Windows.Visibility.Hidden;
                    for (int i = 0; i < 30; i++)
                    {
                        cb_trans.Items.Add(i);
                    }
                    cb_trans.Visibility = System.Windows.Visibility.Visible;
                    break;
                case 1://מוסך
                    tb_trans.Visibility = System.Windows.Visibility.Hidden;
                    foreach (var item in musacim)
                    {
                        cb_trans.Items.Add(item);
                    }
                    cb_trans.Visibility = System.Windows.Visibility.Visible;
                    break;
                case 2://גורם התקלה
                    tb_trans.Visibility = System.Windows.Visibility.Hidden;
                    cb_trans.Items.Add(BE.who_fault.blay);
                    cb_trans.Items.Add(BE.who_fault.Negligence);
                    cb_trans.Visibility = System.Windows.Visibility.Visible;
                    break;
                case 3://פירוט התקלה
                    tb_trans.Visibility = System.Windows.Visibility.Hidden;

                    cb_trans.Items.Add(BE.fault_type.betichut);
                    cb_trans.Items.Add(BE.fault_type.blamim);
                    cb_trans.Items.Add(BE.fault_type.chasmal);
                    cb_trans.Items.Add(BE.fault_type.gir);
                    cb_trans.Items.Add(BE.fault_type.light);
                    cb_trans.Items.Add(BE.fault_type.magavim);
                    cb_trans.Items.Add(BE.fault_type.marout);
                    cb_trans.Items.Add(BE.fault_type.mazgan);
                    cb_trans.Items.Add(BE.fault_type.mnoah);
                    cb_trans.Items.Add(BE.fault_type.pancher);
                    cb_trans.Items.Add(BE.fault_type.pch);
                    cb_trans.Items.Add(BE.fault_type.plastica);
                    cb_trans.Items.Add(BE.fault_type.radio);
                    cb_trans.Items.Add(BE.fault_type.tipulTen);
                    cb_trans.Items.Add(BE.fault_type.tzeva);
                    cb_trans.Visibility = System.Windows.Visibility.Visible;
                    break;
                case 4://מחיר
                    tb_trans.Visibility = System.Windows.Visibility.Visible;
                    cb_trans.Visibility = System.Windows.Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        private void tb_trans_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;

            foreach (var item in tb_trans.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("צריך לשלוח רק מספרים");
                    tb_trans.Text = tb_trans.Text.Remove(i, 1);
                }
                i++;
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

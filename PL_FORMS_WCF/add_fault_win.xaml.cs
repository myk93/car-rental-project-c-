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
    /// Interaction logic for addd_fault_win.xaml
    /// </summary>
    public partial class addd_fault_win : Window
    {
        public string[] musacim = { "דני אמויאל", "קרסו", "חלקי חילוף", "מוסכי פורד", "דודו גרשון פנצרים", "גולין פנצרים", "פחחות וצבע", "צמפיון מוטורס", "הונדה" };
        IBL bl = new BlFactory().GetBL();

        public addd_fault_win()
        {
            InitializeComponent();
            foreach (var item in musacim)
            {
                combo_musach.Items.Add(item);
            }
         
            combo_kind_fault.Items.Add(BE.fault_type.betichut);
            combo_kind_fault.Items.Add(BE.fault_type.blamim);
            combo_kind_fault.Items.Add(BE.fault_type.chasmal);
            combo_kind_fault.Items.Add(BE.fault_type.gir);
            combo_kind_fault.Items.Add(BE.fault_type.light);
            combo_kind_fault.Items.Add(BE.fault_type.magavim);
            combo_kind_fault.Items.Add(BE.fault_type.marout);
            combo_kind_fault.Items.Add(BE.fault_type.mazgan);
            combo_kind_fault.Items.Add(BE.fault_type.mnoah);
            combo_kind_fault.Items.Add(BE.fault_type.pancher);
            combo_kind_fault.Items.Add(BE.fault_type.pch);
            combo_kind_fault.Items.Add(BE.fault_type.plastica);
            combo_kind_fault.Items.Add(BE.fault_type.radio);
            combo_kind_fault.Items.Add(BE.fault_type.tipulTen);
            combo_kind_fault.Items.Add(BE.fault_type.tzeva);
            for (int i = 1; i <= 30; i++)
            {
                days_fix.Items.Add(i);
            }

            ///////////////////////////////////
            combo_gorem.Items.Add(BE.who_fault.blay);
            combo_gorem.Items.Add(BE.who_fault.Negligence);
            ///////////////////////////////////
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("אתה בטוח שברצונך לבטל", "אזהרה", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void days_fix_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int mis_tak;
            if (tb_mis_tak.Text != "0")
                if (tb_mis_tak.Text.Length != 7)
                {
                    MessageBox.Show("המספר תקלה אינו תקין");
                    return;
                }
                else
                    mis_tak = int.Parse(tb_mis_tak.Text);
            else
                mis_tak = 0;
            if (combo_kind_fault.SelectedIndex==-1)
            {
                MessageBox.Show("צריך לבחור את סוג התקלה");
                return;
            }
            if (combo_gorem.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור ממה נגרם התקלה");
                return;
            }
            if (combo_musach.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור מוסך");
                return;
            }
            int pri;
            if (KM.Text.Length==0)
		        pri=(int)combo_kind_fault.SelectedItem;
            else
	            pri=int.Parse(KM.Text);
            try
            {
             bl.add_Fault(new Fault((fault_type)combo_kind_fault.SelectedItem, (who_fault)combo_gorem.SelectedItem, mis_tak, pri, (string)combo_musach.SelectedItem));
                MessageBox.Show("הלקוח עודכן בהצלחה");
                this.Close();
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message,"שגיאה",MessageBoxButton.OK,MessageBoxImage.Error) ;
            }    
        }

        private void combo_kind_fault_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void combo_musach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }//
    }
}
